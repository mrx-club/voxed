using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace Core.Services.TextFormatter
{
    public interface ITextFormatterService
    {
        string Format(string content);
        List<string> GetRepliedHash(string content);
    }

    public class TextFormatterService : ITextFormatterService
    {
        private readonly HtmlEncoder encoder;

        public TextFormatterService(HtmlEncoder encoder)
        {
            this.encoder = encoder;
        }

        public string Format(string contenido)
        {
            if (contenido == null)
            {
                return null;
            }

            var tags = new List<string>();

            var x = contenido
                    .Split("\n")
                    .Select(t =>
                    {
                        t = encoder.Encode(t);
                        var esLink = false;
                        var esTag = false;

                        //Links
                        t = Regex.Replace(t, @"&gt;(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b(\S*)", m =>
                        {
                            var link = m.Value.Replace("&gt;", "");
                            esLink = true;

                            //VERSION SEGURA para que solo acceda a link con SSL
                            //link = Regex.Replace(link, @"(http(s)?:\/\/)", "");
                            //return $@"<a href=""//{link}"" target=""_blank"">&gt;{link}</a>";

                            return $@"<a href=""{link}"" target=""_blank"">&gt;{link}</a>";
                        });

                        if (esLink) return t;

                        //if (t.StartsWith("&gt;&gt;"))
                        //{
                        //    var id = t
                        //    //.Replace("&gt;&gt;", "")
                        //    //.Replace("&#xD;", "")
                        //    .Trim();
                        //    return $"<a href=\"#{id}\" data-quote=\"{id}\">&gt;&gt;{id}</a>\n<br>";
                        //}

                        if (t.StartsWith("&gt;&gt;"))
                        {
                            var id = t
                            .Replace("&gt;&gt;", "")
                            .Replace("&#xD;", "")
                            .Trim();
                            return $"<a href=\"#{id}\" data-quote=\"{id}\">&gt;&gt;{id}</a>";
                        }

                        //Respuestas
                        t = Regex.Replace(t, @"&gt;&gt;([A-Z0-9]{7})", m =>
                        {
                            esTag = true;
                            if (tags.Contains(m.Value)) return "";
                            esTag = true;
                            tags.Add(m.Value);
                            var id = m.Groups[1].Value;
                            return $"<a href=\"#{id}\" class=\"restag\" r-id=\" {id}\">&gt;&gt;{id}</a>";
                        });


                        //Texto verde
                        t = Regex.Replace(t.Replace("&#xA;", "\n"), @"&gt;(?!https?).+(?:$|\n)", m =>
                        {
                            if (esLink || esTag) return m.Value;
                            var text = m.Value;
                            return $@"<span class=""greentext"">{text}</span>";
                        });

                        return t;

                    });

            //var ret = string.Join("\n", x);
            var ret = string.Join("<br>\n", x);
            //var ret = string.Join("\r\n", x);
            //var ret = string.Join("<br>", x); // No funciona cuando js intenta crear los tag en los comments
            return ret;

            //VERSION SEGURA PROBARLO A FUTURO
            //var sanitezed = sanitizer.Sanitize(ret);
            //return sanitezed;
        }

        public List<string> GetRepliedHash(string content)
        {
            var list = new List<string>();

            if (string.IsNullOrWhiteSpace(content))
            {
                return list;
            }

            //var hashLength = 7;

            //return Regex.Matches(content, @">>([A-Z0-9]{7})") // {7} is hash lenght
            //    .Select(m => m.Groups[1].Value)
            //    .Distinct()
            //    .ToList();

            var hashes = Regex.Matches(content, @"&gt;&gt;([A-Z0-9]{7})") // {7} is the hash lenght
                .Select(m => m.Groups[1].Value)
                .Distinct()
                .ToList();

            list.AddRange(hashes);

            return list;
        }
        //public class FormateadorService
        //{
        //    private readonly HtmlEncoder encoder;
        //    private readonly static HtmlSanitizer sanitizer =
        //        new HtmlSanitizer("a span".Split(" "),
        //        allowedAttributes: "href target class r-id".Split(" "));
        //    public FormateadorService(HtmlEncoder encoder)
        //    {
        //        this.encoder = encoder;
        //    }

        //    public string Parse(string contenido)
        //    {
        //        var tags = new List<string>();
        //        string ret = string.Join("\n", contenido.Split("\n").Select(t => {
        //            t = encoder.Encode(t);
        //            var esLink = false;
        //            var esTag = false;
        //            //Links
        //            t = Regex.Replace(t, @"&gt;(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b(\S*)", m => {
        //                var link = m.Value.Replace("&gt;", "");
        //                link = Regex.Replace(link, @"(http(s)?:\/\/)", "");
        //                esLink = true;
        //                return $@"<a href=""//{link}"" target=""_blank"">&gt;{link}</a>";
        //            });
        //            if (esLink) return t;
        //            //Respuestas
        //            t = Regex.Replace(t, @"&gt;&gt;([A-Z0-9]{7})", m => {
        //                if (tags.Contains(m.Value)) return "";
        //                esTag = true;
        //                tags.Add(m.Value);
        //                var id = m.Groups[1].Value;
        //                return $"<a href=\"#{id}\" class=\"restag\" r-id=\" {id}\">&gt;&gt;{id}</a>";
        //            });

        //            //Texto verde
        //            t = Regex.Replace(t.Replace("&#xA;", "\n"), @"&gt;(?!https?).+(?:$|\n)", m => {
        //                if (esLink || esTag) return m.Value;
        //                var text = m.Value;
        //                return $@"<span class=""verde"">{text}</span>";
        //            });
        //            return t;
        //        }));
        //        return sanitizer.Sanitize(ret);
        //    }

        //    public string[] GetRepliedHash(string contenido)
        //    {
        //        return Regex.Matches(contenido, @">>([A-Z0-9]{7})")
        //            .Select(m => {
        //                return m.Groups[1].Value;
        //            }).ToArray();
        //    }
    }
}



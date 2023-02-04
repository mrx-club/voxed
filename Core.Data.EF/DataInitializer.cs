using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Data.EF
{
    public class DataInitializer
    {
        private readonly VoxedContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DataInitializer(VoxedContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            await InitializeTables();
            await InitializeCategories();
            await InitializeRoles();
            await InitializeUsers();
        }

        private async Task InitializeTables()
        {
            // Using this method you won't be able to use Migrations
            //await _context.Database.EnsureCreatedAsync();

            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any()) 
                await _context.Database.MigrateAsync();
        }

        private async Task InitializeRoles()
        {
            if (await _roleManager.Roles.AnyAsync()) return;

            var roles = Enum.GetValues(typeof(RoleType)).Cast<RoleType>();

            foreach (var role in roles)
            {
                var newRole = await _roleManager.FindByNameAsync(Enum.GetName(typeof(RoleType), role));
                if (newRole == null)
                {
                    newRole = new Role { Name = Enum.GetName(typeof(RoleType), role) };
                    var result = await _roleManager.CreateAsync(newRole);
                    if (!result.Succeeded)
                    {
                        throw new Exception($"Can't create role {Enum.GetName(typeof(RoleType), role)}: {string.Join(", ", result.Errors.Select(e => $"{e.Code}:{e.Description}"))}");
                    }
                }
            }
        }

        private async Task InitializeUsers()
        {
            if (await _userManager.Users.AnyAsync()) return;            

            var administrator = new User
            {
                UserName = "admin",
                EmailConfirmed = true,
                UserType = UserType.Administrator
            };

            var result = await _userManager.CreateAsync(administrator, "Admin1234");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(administrator, nameof(RoleType.Administrator));
            }
        }

        private async Task InitializeCategories()
        {
            if (await _context.Categories.AnyAsync()) return; // DB has been seeded

            var categories = new Category[]
            {
                new Category{
                    Name = "Anime",
                    ShortName = "anm",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/anm.jpg",
                        ThumbnailUrl = "/img/categories/anm.jpg",
                        Type = MediaType.Image
                    },
                },
                new Category{
                    Name = "Arte",
                    ShortName = "art",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/art.jpg",
                        ThumbnailUrl = "/img/categories/art.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Autos y Motos",
                    ShortName = "aut",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/aut.jpg",
                        ThumbnailUrl = "/img/categories/aut.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Ciencia",
                    ShortName = "cnc",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/cnc.jpg",
                        ThumbnailUrl = "/img/categories/cnc.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Cine",
                    ShortName = "cin",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/cin.jpg",
                        ThumbnailUrl = "/img/categories/cin.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Consejos",
                    ShortName = "con",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/_con.jpg",
                        ThumbnailUrl = "/img/categories/_con.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Deportes",
                    ShortName = "dpt",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/dpt.jpg",
                        ThumbnailUrl = "/img/categories/dpt.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Download",
                    ShortName = "dwl",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/dwl.jpg",
                        ThumbnailUrl = "/img/categories/dwl.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Economia",
                    ShortName = "eco",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/eco.jpg",
                        ThumbnailUrl = "/img/categories/eco.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Gastronomia",
                    ShortName = "gas",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/gas.jpg",
                        ThumbnailUrl = "/img/categories/gas.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "General",
                    ShortName = "off",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/off.jpg",
                        ThumbnailUrl = "/img/categories/off.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Historias",
                    ShortName = "his",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/his.jpg",
                        ThumbnailUrl = "/img/categories/his.jpg",
                        Type = MediaType.Image,
                    }
                },
                new Category{
                    Name = "Humanidad",
                    ShortName = "hum",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/hum.jpg",
                        ThumbnailUrl = "/img/categories/hum.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Humor",
                    ShortName = "hmr",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/hmr.jpg",
                        ThumbnailUrl = "/img/categories/hmr.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Juegos",
                    ShortName = "gmr",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/gmr.jpg",
                        ThumbnailUrl = "/img/categories/gmr.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Literatura",
                    ShortName = "lit",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/lit.jpg",
                        ThumbnailUrl = "/img/categories/lit.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Lugares",
                    ShortName = "lgr",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/lgr.jpg",
                        ThumbnailUrl = "/img/categories/lgr.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Musica",
                    ShortName = "mus",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/mus.jpg",
                        ThumbnailUrl = "/img/categories/mus.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Noticias",
                    ShortName = "not",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/not.jpg",
                        ThumbnailUrl = "/img/categories/not.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Paranormal",
                    ShortName = "par",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/par.jpg",
                        ThumbnailUrl = "/img/categories/par.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Politica",
                    ShortName = "pol",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/pol.jpg",
                        ThumbnailUrl = "/img/categories/pol.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Preguntas",
                    ShortName = "prg",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/prg.jpg",
                        ThumbnailUrl = "/img/categories/prg.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Programacion",
                    ShortName = "pro",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/pro.jpg",
                        ThumbnailUrl = "/img/categories/pro.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Salud",
                    ShortName = "sld",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/sld.jpg",
                        ThumbnailUrl = "/img/categories/sld.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Tecnologia",
                    ShortName = "tec",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/tec.jpg",
                        ThumbnailUrl = "/img/categories/tec.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Videos (webm)",
                    ShortName = "vid",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/vid.jpg",
                        ThumbnailUrl = "/img/categories/vid.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Youtubers",
                    ShortName = "ytb",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/ytb.jpg",
                        ThumbnailUrl = "/img/categories/ytb.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "GTB",
                    ShortName = "gtb",
                    Nsfw = true,
                    Media = new Media {
                        Url = "/img/categories/gtb.jpg",
                        ThumbnailUrl = "/img/categories/gtb.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Porno",
                    ShortName = "xxx",
                    Nsfw = true,
                    Media = new Media {
                        Url = "/img/categories/xxx.jpg",
                        ThumbnailUrl = "/img/categories/xxx.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Random",
                    ShortName = "uff",
                    Nsfw = false,
                    Media = new Media {
                        Url = "/img/categories/uff.jpg",
                        ThumbnailUrl = "/img/categories/uff.jpg",
                        Type = MediaType.Image
                    }
                },
                new Category{
                    Name = "Sexy",
                    ShortName = "hot",
                    Nsfw = true,
                    Media = new Media {
                        Url = "/img/categories/hot.jpg",
                        ThumbnailUrl = "/img/categories/hot.jpg",
                        Type = MediaType.Image
                    }
                },
            };


            await _context.Categories.AddRangeAsync(categories);

            await _context.SaveChangesAsync();
        }
    }
}

using eLibrary.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eLibrary.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                //Provera da postoji Database
                context.Database.EnsureCreated();
                //Adding writers
                if (!context.Writers.Any())
                {
                    context.Writers.AddRange(new List<Writer>()
                    {
                        new Writer()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/Geek_Bar_Tor_authors_event_-_Cixin_Liu_%2818397919319%29.jpg/800px-Geek_Bar_Tor_authors_event_-_Cixin_Liu_%2818397919319%29.jpg",
                            FullName = "Cixin Liu",
                            Bio = "Chinese SciFi writer"
                        },
                        new Writer()
                        {
                            ProfilePictureURL = "https://images.squarespace-cdn.com/content/v1/59b8357cbebafb5c24d3b950/1617232083087-WFR9JXV7ZHMW7Y87ZW4W/00129.png?format=1500w",
                            FullName = "Charles Bukowski",
                            Bio = "American writer"
                        },
                        new Writer()
                        {
                            ProfilePictureURL = "https://guysalvidge.files.wordpress.com/2019/10/sergei-dovlatov-010.jpg",
                            FullName = "Sergey Dovlatov",
                            Bio = "Russian writer"
                        },
                        new Writer()
                        {
                            ProfilePictureURL = "https://gdb.rferl.org/6EB294F5-110C-4E71-BD79-79CE79D24CAB_w1278_s_d2.jpg",
                            FullName = "Fyodor Dostoyevski",
                            Bio = "Russian writer"
                        },
                        new Writer()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/93/J._D._Salinger_%28Catcher_in_the_Rye_portrait%29.jpg/800px-J._D._Salinger_%28Catcher_in_the_Rye_portrait%29.jpg",
                            FullName = "J.D.Selinger",
                            Bio = "American Novel writer"
                        }
                    });
                    context.SaveChanges();
                }
                //Adding books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Title = "Three Body Problem",
                            Description = "Sci Fi book",
                            ImageURL = "https://m.media-amazon.com/images/I/51E28X-SNTL.jpg",
                            Price = 14.50,
                            ReleaseDate = DateTime.Now.AddDays(1),
                            WriterId = 1,
                            BookCategory = BookCategory.scienceFiction
                        },
                        new Book()
                        {
                            Title = "Freny and Zoe",
                            Description = "American Novel",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/7/72/Frannyzoey.jpg",
                            Price = 16.50,
                            ReleaseDate = DateTime.Now.AddDays(3),
                            WriterId = 5,
                            BookCategory = BookCategory.novel
                        },
                        new Book()
                        {
                            Title = "Gambler",
                            Description = "Russian rulet",
                            ImageURL = "https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781625582584/the-gambler-9781625582584_lg.jpg",
                            Price = 14.50,
                            ReleaseDate = DateTime.Now.AddDays(2),
                            WriterId = 4,
                            BookCategory = BookCategory.novel
                        },
                        new Book()
                        {
                            Title = "Dark forest",
                            Description = "Sci Fi book",
                            ImageURL = "https://thebookcoverdesigner.com/wp-content/uploads/2020/11/The-dark-forest.jpg",
                            Price = 18.50,
                            ReleaseDate = DateTime.Now.AddDays(2),
                            WriterId = 1,
                            BookCategory = BookCategory.scienceFiction
                        },
                        new Book()
                        {
                            Title = "Karamazovi brothers",
                            Description = "Russian novel",
                            ImageURL = "https://images-na.ssl-images-amazon.com/images/I/51Bz-aHxQXL._SY344_BO1,204,203,200_.jpg",
                            Price = 14.50,
                            ReleaseDate = DateTime.Now.AddDays(2),
                            WriterId = 4,
                            BookCategory = BookCategory.novel
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

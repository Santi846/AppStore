using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppStore.Models.Domain;

public class LoadDatabase{
    public static async Task InsertData(DatabaseContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager){

        //if there is not data receiben
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole("ADMIN"));
        }

        if (!userManager.Users.Any())
        {
            var user = new ApplicationUser {
                Nombre = "Vaxi Dres",
                Email = "vdres@work.com.uy",
                UserName = "vdres"
            };


            await userManager.CreateAsync(user, "Contrase;a123");
            await userManager.AddToRoleAsync(user, "ADMIN");
        }

        if (!context.Categorias!.Any())
        {
            await context.Categorias!.AddRangeAsync(
                new Categoria {Nombre = "Drama"},
                new Categoria {Nombre = "Comedia"},
                new Categoria {Nombre = "Accion"},
                new Categoria {Nombre = "Terror"},
                new Categoria {Nombre = "Aventura"}
            );

            await context.SaveChangesAsync();
        }

        if (!context.Libros!.Any())
        {
            await context.Libros!.AddRangeAsync( 
                new Libro {
                    Titulo = "Primer libro creado",
                    CreateDate = DateTime.ParseExact("20/06/2024", "dd/MM/yyyy", null),
                    Imagen = "libro1.png",
                    Autor = "Santiago Arocha"
                },

                new Libro {
                    Titulo = "Segundo libro creado",
                    CreateDate = DateTime.ParseExact("20/06/2024", "dd/MM/yyyy", null),
                    Imagen = "libro2.png",
                    Autor = "Santiago Arocha"
                }
            );

            await context.SaveChangesAsync();
        }

        if (!context.LibroCategorias!.Any())
        {
            await context.LibroCategorias!.AddRangeAsync( 
                new LibroCategoria {
                    CategoriaId = 1,
                    LibroId = 1
                },

                new LibroCategoria {
                    CategoriaId = 2,
                    LibroId = 2
                }
            );

            await context.SaveChangesAsync();
        }

        context.SaveChanges();
    }
};
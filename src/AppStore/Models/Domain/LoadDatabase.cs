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
            context.Categorias!.AddRange(
                new Categoria {Nombre = "Drama"},
                new Categoria {Nombre = "Comedia"},
                new Categoria {Nombre = "Accion"},
                new Categoria {Nombre = "Terror"},
                new Categoria {Nombre = "Aventura"}
            );
        }

        if (!context.Libros!.Any())
        {
            context.Libros!.AddRange( 
                new Libro {
                    Titulo = "Primer libro creado",
                    CreateDate = "20/06/2024",
                    Imagen = "libro1.png",
                    Autor = "Santiago Arocha"
                },

                new Libro {
                    Titulo = "Segundo libro creado",
                    CreateDate = "20/06/2024",
                    Imagen = "libro2.png",
                    Autor = "Santiago Arocha"
                }
            );
        }

        if (!context.LibroCategorias!.Any())
        {
            context.LibroCategorias!.AddRange( 
                new LibroCategoria {
                    CategoriaId = 1,
                    LibroId = 1
                },

                new LibroCategoria {
                    CategoriaId = 2,
                    LibroId = 2
                }
            );
        }

        context.SaveChanges();
    }
};
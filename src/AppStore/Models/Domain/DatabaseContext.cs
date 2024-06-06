using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AppStore.Models.Domain;

public class DatabaseContext : IdentityDbContext<ApplicationUser>{

    public DbSet<Categoria>? Categorias {get;set;}

    public DbSet<Libro>? Libros {get;set;}

    public DbSet<LibroCategoria>? LibroCategorias {get;set;}
    
};
// using System.Security.Cryptography.X509Certificates;
// using Microsoft.EntityFrameworkCore.Diagnostics;
// using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.Domain;

    public class Libro
    {
        [Key] //set the Id as Key
        [Required] //set the Id required
        public int Id{get;set;}

        public string? Titulo {get;set;}

        // public string? Descripcion {get;set;}

        public string? CreateDate {get;set;}
        // public System.DateTime CreateDate {get;set;}

        // public Precio? PrecioPromocion {get;set;}

        // Save more than one commentary
        // public ICollection<Comentario>? ComentarioLista {get;set;}

        // public ICollection<LibroAutor>? AutorLink {get;set;}
        public string? Imagen {get;set;}

        [Required] //set the Author required
        public string? Autor {get;set;}

        public virtual ICollection<Categoria>? CategoriaRelationList {get;set;}

        public virtual ICollection<LibroCategoria>? LibroCategoriaRelationList {get;set;}
    }

using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AppStore.Models.Domain;

public class Categoria {

    [Key]
    [Required]
    public int Id { get; set; }

    public String? Nombre { get; set; }

}
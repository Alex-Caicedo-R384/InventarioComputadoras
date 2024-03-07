using System.ComponentModel.DataAnnotations;

namespace InventarioComputadoras.Models
{
    public class Computadora
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Oficina")]
        public string? Oficina { get; set; }

        [Display(Name = "Nombre anterior")]
        public string? NombreAnterior { get; set; }
    
        [Display(Name = "Nombre nuevo")]
        public string? NombreNuevo { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public string? Departamento { get; set; }

        [Display(Name = "Dirección IP")]
        public string? DireccionIp { get; set; }

        public bool SinNombreAnterior { get; set; }
        public bool SinDireccionIP { get; set; }

    }
}

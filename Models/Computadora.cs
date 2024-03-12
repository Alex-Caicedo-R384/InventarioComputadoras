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
    
        [Display(Name = "Nombre Actual")]
        public string? NombreNuevo { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public string? Departamento { get; set; }

        [Display(Name = "Dirección IP")]
        public string? DireccionIp { get; set; }

        [Display(Name = "Licencia Sistema Operativo")]
        public string? LicenciaSO { get; set; }

        [Display(Name = "Sistema Operativo")]
        public string? SistemaOperativo { get; set; }

        [Display(Name = "Licencia de Office")]
        public string? Office { get; set; }

        [Display(Name = "Version de Office")]
        public string? VersionOffice { get; set; }

        [Display(Name = "Licencia de Antivirius")]
        public string? LicenciaAntivirus { get; set; }

        [Display(Name = "Nombre de Antivirius")]
        public string? VersionAntivirus { get; set; }

        [Display(Name = "Fecha de instalación de Office")]
        public DateTime? FechaOffice { get; set; }

        [Display(Name = "Usuario")]
        public string? Usuario { get; set; }

        [Display(Name = "¿Se encuentra en Dominio?")]
        public string? Dominio { get; set; }

        [Display(Name = "Código Constitucional")]
        public string? CodigoConstitucional { get; set; }

        [Display(Name = "Fecha de Adquisición")]
        public DateTime? FechaAdquisicion { get; set; }

        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        public bool SinNombreAnterior { get; set; }
        public bool SinDireccionIP { get; set; }

        public bool SinLicenciaSO { get; set; }
        public bool ConLicenciaSO { get; set; }

        public bool SinLicenciaOffice { get; set; }
        public bool ConLicenciaOffice { get; set; }

        public bool SinAntivirus { get; set; }
        public bool ConAntivirus { get; set; }
    }
}

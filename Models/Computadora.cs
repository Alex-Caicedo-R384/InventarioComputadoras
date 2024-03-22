using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioComputadoras.Models
{
    public class Computadora
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Oficina")]
        public string Oficina { get; set; }

        [Display(Name = "Nombre Anterior")]
        public string? NombreAnterior { get; set; }
    
        [Display(Name = "Nombre Actual")]
        public string? NombreNuevo { get; set; }

        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

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

        [Required]
        [Display(Name = "Código Constitucional")]
        public string? CodigoConstitucional { get; set; }

        [Display(Name = "Fecha de Adquisición")]
        public DateTime? FechaAdquisicion { get; set; }

        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        [Display(Name = "Proveedor")]
        public string? Proveedor { get; set; }

        [Display(Name = "Tipo de Dispositivo")]
        public string? Tipo { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string? Marca { get; set; }

        [Required]
        [Display(Name = "Número de Parte")]
        public string? NParte { get; set; }


        [Display(Name = "Número de Serie")]
        public string? NSerie { get; set; }

        [Required]
        [Display(Name = "MotherBoard")]
        public string? MotherBoard { get; set; }

        [Required]
        [Display(Name = "Procesador")]
        public string? Procesador { get; set; }


        //----------------------------------------------Memoria RAM----------------------------------------------------------------------//
        [Required]
        [Display(Name = "Tipo de Memoria RAM")]
        public string? MemoriaRamTipo { get; set; }

        [Display(Name = "Cantidad de Modulos de Memoria RAM")]
        public string? MemoriaModulos { get; set; }

        [Required]
        [Display(Name = "Capacidad de Memoria RAM")]
        public string? MemoriaRamCapacidad { get; set; }

        [Required]
        [Display(Name = "Marca de Memoria RAM")]
        public string? MemoriaRamMarca { get; set; }

        [Required]
        [Display(Name = "Número de Serie de Memoria RAM")]
        public string? MemoriaRamNumeroSerie { get; set; }

        [Required]
        [Display(Name = "Número de Parte de Memoria RAM")]
        public string? MemoriaRamNumeroParte { get; set; }

        //------------------------------------------------------------------------------------------------------------------------------//
        //----------------------------------------------Almacenamiento-----------------------------------------------------------------//
        [Display(Name = "Tipo de Almacenamiento")]
        public string? AlmacenamientoTipo { get; set; }

        [Required]
        [Display(Name = "Capacidad de Almacenamiento")]
        public string? AlmacenamientoCapacidad { get; set; }

        [Required]
        [Display(Name = "Marca de Almacenamiento")]
        public string? AlmacenamientoMarca { get; set; }

        [Required]
        [Display(Name = "Número de Serie de Almacenamiento  ")]
        public string? AlmacenamientoNumeroSerie { get; set; }

        [Required]
        [Display(Name = "Número de Parte de Almacenamiento")]
        public string? AlmacenamientoNumeroParte { get; set; } 


        public List<Almacenamiento> Almacenamientos { get; set; }

        public Computadora()
        {
            Almacenamientos = new List<Almacenamiento>();
        }
        //------------------------------------------------------------------------------------------------------------------------------//
        public bool SinNombreAnterior { get; set; }
        public bool SinDireccionIP { get; set; }

        public bool SinLicenciaSO { get; set; }
        public bool ConLicenciaSO { get; set; }

        public bool SinLicenciaOffice { get; set; }
        public bool ConLicenciaOffice { get; set; }

        public bool SinAntivirus { get; set; }
        public bool ConAntivirus { get; set; }

    }

    public class Almacenamiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Tipo de Almacenamiento")]
        public string? TipoAlmacenamiento { get; set; }

        [Display(Name = "Capacidad de Almacenamiento")]
        public string? CapacidadAlmacenamiento { get; set; }

        [Display(Name = "Marca de Almacenamiento")]
        public string? MarcaAlmacenamiento { get; set; }

        [Display(Name = "Número de Serie")]
        public string? NumeroSerieAlmacenamiento { get; set; }

        [Display(Name = "Número de Parte")]
        public string? NumeroParteAlmacenamiento { get; set; }

        public int ComputadoraId { get; set; }
        public Computadora? Computadora { get; set; }
    }
}

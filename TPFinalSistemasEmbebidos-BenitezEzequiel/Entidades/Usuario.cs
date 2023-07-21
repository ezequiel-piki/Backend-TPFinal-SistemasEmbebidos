using System.ComponentModel.DataAnnotations;

namespace TPFinalSistemasEmbebidos_BenitezEzequiel.Entidades
{
    public class Usuario
    {
        [Key]
        public  int Identificador { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }
        
        [StringLength(50)]
        public string Apellido { get; set; }

        [EmailAddress]
        public  string Email { get; set; }
        public int Dni { get; set; }

    }
}

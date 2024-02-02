using System.ComponentModel.DataAnnotations;

namespace ClientesMABB.Models
{
    public class Cliente
    {
        //ClienteId, Nombres, Telefono, Celular, Rnc, Email, Direccion
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten letras y espacios.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "El campo Teléfono debe tener el formato XXX-XXX-XXXX.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo Celular es obligatorio.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "El campo Celular debe tener el formato XXX-XXX-XXXX.")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "El campo Rnc es obligatorio.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El campo Rnc debe tener el formato 000000000.")]
        public string? Rnc { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@(outlook\.com|hotmail\.com|gmail\.com|yahoo\.com|yahoo\.es|outlook\.es|hotmail\.es|gmail\.es)$",
            ErrorMessage = "Revise el email ingresado, el formato es ejemplo@dominio.com, dominios aceptados: outlook.com\\es - hotmail.com\\es - gmail.com\\es - yahoo.com\\es")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Dirección no debe de tener más de 200 caracteres.")]
        public string? Direccion { get; set; }
    }
}
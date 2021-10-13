using System.ComponentModel.DataAnnotations;

namespace Entidades.Entidade
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hey..Este campo é obrigatório")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Hey..Este campo é obrigatório")]
        public string sobrenome { get; set; }
        [Required(ErrorMessage = "Hey..Este campo é obrigatório")]
        public string endereço { get; set; }
    }
}
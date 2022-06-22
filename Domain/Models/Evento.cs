using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Evento
    {
        [Key]
        [Required]
        public int IdEvento { get; set; }
        [Required(ErrorMessage = "O campo Local é obrigatorio")]
        public string Local { get; set; }
        [Required(ErrorMessage = "A Data do Evento é obrigatorio")]
        public DateTime DataEvento { get; set; }
        [Required(ErrorMessage = "O Tema do Evento é obrigatorio")]
        public string Tema { get; set; }

        [Range(0,30,ErrorMessage ="O Evento so pode ter ate 30 pessoas")]
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImgURL { get; set; }
        public Situation Situation { get; set; } 
    }
}

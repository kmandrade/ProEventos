using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class EventoDto
    {
        public string Local { get; set; }
        [Required(ErrorMessage = "A Data do Evento é obrigatorio")]
        public DateTime DataEvento { get; set; }
        [Required(ErrorMessage = "O Tema do Evento é obrigatorio")]
        public string Tema { get; set; }

        [Range(0, 30, ErrorMessage = "O Evento so pode ter ate 30 pessoas")]
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImgURL { get; set; }
        
    }
}

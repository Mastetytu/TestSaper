using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaperModel
{
    public class GameInfoResponse
    {
        [Required]
        public Guid GameId { get; set; }

        [Range(0, 29, ErrorMessage = "Колонка проверяемой ячейки должна быть от 0 до 29")]
        public int Col { get; set; }

        [Range(0, 29, ErrorMessage = "Ряд проверяемой ячейки должна быть от 0 до 29")]
        public int Row { get; set; }
        public bool Completed { get; set; }

        public List<List<string>> Field { get; set; }
    }
}

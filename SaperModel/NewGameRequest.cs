using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaperModel
{
    public class NewGameRequest
    {
        [Range(2, 30, ErrorMessage = "Ширина игрового поля должна быть от 2 до 30")]
        public int Width { get; set; }

        [Range(2, 30, ErrorMessage = "Высота игрового поля должна быть от 2 до 30")]
        public int Height { get; set; }

        [Range(0, 899, ErrorMessage = "Количество мин на поле должно быть от 0 до 899")]
        public int MinesCount { get; set; }

        public void Validate()
        {
            if (MinesCount >= Width * Height)
            {
                throw new ValidationException("Значение поля MinesCount не могут быть больше или равно количеству клеток поля");
            }
        }
    }
}

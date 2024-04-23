using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models
{
    //Регион
    public class Region
    {
        public int Id { get; set; } //Идентификатор

        [Required(ErrorMessage = "Введите наименование")]
        public string? Nm { get; set; } //Наименование региона

        [Required(ErrorMessage = "Введите код")]
        [RegularExpression(@"\d{2}", ErrorMessage = "Некорректный код")]
        public string? GIBDD { get; set; } //Код ГИБДД
    }
}

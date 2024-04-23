using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models
{
    //Дом
    public class House
    {
        [Key]
        public int Id { get; set; } //Идентификатор

        [Required(ErrorMessage = "Введите Номер лота")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Некорректный Номер лота")]
        public string? Lot { get; set; } //Номер лота

        [Required(ErrorMessage = "Введите Адрес объекта")]
        public string? Address { get; set; } //Адрес

        public string? Notes { get; set; } //Примечание
        public bool IsExclusive { get; set; } //Эксклюзивный объект
        public bool IsMortagege { get; set; } //Возможна ипотека

        [Required(ErrorMessage = "Введите Жилую площадь")]
        [Range(1, double.MaxValue, ErrorMessage = "Введите корректную Жилую площадь")]
        public double Squeare { get; set; } //Жилая площадь дома

        [Required(ErrorMessage = "Введите Количество комнат")]
        [Range(1, int.MaxValue, ErrorMessage = "Введите корректное Число комнат")]
        public int NumOfRoms { get; set; } //Количество комнат

        [Required(ErrorMessage = "Укажите Цену объекта")]
        [Range(1, double.MaxValue, ErrorMessage = "Введите корректную Цену")]
        public double Price { get; set; } //Цена

        public string? ImageUrl { get; set; } //Фото;

        [Range(1, int.MaxValue, ErrorMessage = "Выберите регион")]
        public int RegionId { get; set; } //Идентификатор региона

        [ForeignKey("RegionId")]
        public Region? Region { get; set; } //Навигационное поле

        public ICollection<Owner> Owners { get; set; } = new List<Owner>();
    }
}

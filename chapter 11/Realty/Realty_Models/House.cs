using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models
{
    //Дом
    public class House
    {
        public int Id { get; set; } //Идентификатор
        public string? Lot { get; set; } //Номер лота
        public string? Address { get; set; } //Адрес
        public string? Notes { get; set; } //Примечание
        public bool IsExclusive { get; set; } //Эксклюзивный объект
        public bool IsMortagege { get; set; } //Возможна ипотека
        public double Squeare { get; set; } //Жилая площадь дома
        public int NumOfRoms { get; set; } //Количество комнат
        public double Price { get; set; } //Цена
        public string? ImageUrl { get; set; } //Фото;
        public int RegionId { get; set; } //Идентификатор региона
    }
}

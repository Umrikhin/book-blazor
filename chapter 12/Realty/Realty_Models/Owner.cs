using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realty_Models
{
    //Владелец
    public class Owner
    {
        public int Id { get; set; } //Идентификатор
        public string? Fio { get; set; } //Ф.И.О. собственника
        public DateTime StartTitul { get; set; } //Дата регистрации
        public string? TypeTitul { get; set; } //Вид собственности
        public string? NumTitul { get; set; } //Номер регистрации права
        public DateTime? EndTitul { get; set; } //Дата прекращения права
        public int HouseId { get; set; } //Идентификатор дома
    }
}

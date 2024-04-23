﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Realty_Models
{
    public class Newbuilding
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование ЖК")]
        public string NameHouse { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Тип дома")]
        public string TypeHouse { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Адрес ЖК")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Год сдачи")]
        public int? YearOfDelivery { get; set; }

        [Required]
        [Display(Name = "Количество квартир")]
        public int? NumOfApart { get; set; }

        [Required]
        [Display(Name = "Этажность")]
        public int? NumOfStoreys { get; set; }

        [Required]
        [Display(Name = "Есть ли парковка")]
        public bool? IsParking { get; set; }
    }
}

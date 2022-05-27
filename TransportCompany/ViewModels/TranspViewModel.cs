using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.ViewModels
{
    public class TranspViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Марка
        /// </summary>
        public string Mark { get; set; }
        /// <summary>
        /// Номер авто
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Грузоподъемность
        /// </summary>
        public float? LoadCapasity { get; set; }

        /// <summary>
        /// Характеристика
        /// </summary>
        public string Characteristics { get; set; }

        /// <summary>
        /// Назначение ТС (ЕСЛИ IsSpecial = false!)
        /// </summary>
        public TransportPurpose TransportPurpose { get; set; }

        /// <summary>
        /// Транспорт является спецтехникой
        /// </summary>
        public bool IsSpecial { get; set; }
        /// <summary>
        /// Назначение спецтехники (ЕСЛИ IsSpecial = true!)
        /// </summary>
        public TransportSpecialPurpose TransportSpecialPurpose { get; set; }

        /// <summary>
        /// Стоимость руб/ч
        /// </summary>
        public decimal Cost { get; set; }


        /// <summary>
        /// Оплата водителю руб/ч
        /// </summary>
        public decimal PayToDriver { get; set; }
    }
}

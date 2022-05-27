using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// БД таблица "Рейс"
    /// </summary>
    public class Reys
    {
        public int Id { get; set; }

        /// <summary>
        /// Удельная стоимость
        /// </summary>
        public decimal UnitCost { get; set; }

        public float CountKilometers { get; set; }
        public float CountHours { get; set; }
        public int CountPoints { get; set; }

        public int GruzId { get; set; }
        public virtual Gruz Gruz { get; set; }

        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}

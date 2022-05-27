using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// БД таблица "расстояние"
    /// </summary>
    public class Route
    {
        public int Id { get; set; }

        /// <summary>
        /// название маршрута
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Расстояние в км.
        /// </summary>
        public float Length { get; set; }
        public float HoursCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// БД таблица "Груз"
    /// </summary>
    public class Gruz
    {
        public int Id { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Объем, м3
        /// </summary>
        public float Size { get; set; }

        public float MinTemp { get; set; }

        public float MaxTemp { get; set; }
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.ViewModels
{
    public class TransitViewModel
    {
        public int GruzId { get; set; }
        public Transp Transp { get; set; }
        public int RouteId { get; set; }
        public int DriverId { get; set; }
        public Contragent Contragent { get; set; }
        public IEnumerable<Contragent> Contragents { get; set; }
        public IEnumerable<Route> Routes { get; set; }
        public IEnumerable<Driver> Drivers { get; set; }
        public Transit Transit { get; set; }

        public bool IsNewContragent { get; set; }
    }
}

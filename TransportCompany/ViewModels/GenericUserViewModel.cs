using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.ViewModels
{
    public class GenericUserViewModel
    {
        public int Id { get; init; }
        public IEnumerable<Models.Transp> Transps { get; init; }
    }
}

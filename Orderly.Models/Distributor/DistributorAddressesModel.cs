using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models.Distributor
{
    public class DistributorAddressesModel
    {
        public bool Group { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<Addresses> Addresses { get; set; }
    }

    public class Addresses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}

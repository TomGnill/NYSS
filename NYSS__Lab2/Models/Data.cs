using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYSS__Lab2.Models
{
    [Serializable]
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string ConfidentialityOffense { get; set; }
        public string ContinuityOffense { get; set; }
        public string AvailabilityOffense { get; set; }
    }
}

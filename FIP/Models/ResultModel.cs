using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIP.Models
{
    public class ResultModel
    {
        public int pkid { get; set; }
        public int count { get; set; }
        public List<Country> country { get; set; } = new();
        public string calculatorMessage { get; set; } = string.Empty;
    }

    public class Country
    {
        public string value { get; set; } = string.Empty;
        public string subValue { get; set; } = string.Empty;
        public string currencyUnit { get; set; } = string.Empty;
    }

}

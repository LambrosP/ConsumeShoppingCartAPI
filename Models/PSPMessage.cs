using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeShoppingCartAPI.Models
{
    public class PSPMessage
    {
        public string command { get; set; }

        public int status { get; set; }

        public string message { get; set; }

        public object data { get; set; }
    }
}

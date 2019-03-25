using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kuzey.UI.Web.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
        public string userName { get; set; }
        public DateTime issued { get; set; }
        public DateTime expires { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshTokenApp.Model
{
    public class RefreshToken
    {
        public Guid Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storyboard.Data.DTOs
{
    public class HttpResponseDTO
    {
        public string statusCode { get; set; }
        public string Message { get; set; }
        public dynamic data { get; set; }
    }
}

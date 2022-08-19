using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementCore.Response
{
    public class SuccessResponse
    {
        public  string ResponseCode { get; set; }
        public  string ResponseMessage { get; set; }
        public  string ResponseToken { get; set; }
        public  object Data { get; set; }
        public int DataCount { get; set; }
    }
}

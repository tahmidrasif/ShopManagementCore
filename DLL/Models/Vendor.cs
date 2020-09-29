using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class Vendor
    {
        public long VendorId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string OfficePhone { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
    }
}

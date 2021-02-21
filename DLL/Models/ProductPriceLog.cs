using System;
using System.Collections.Generic;

namespace DLL.Models
{
    public partial class ProductPriceLog
    {
        public long ProductPriceLogId { get; set; }
        public long? ProductPriceId { get; set; }
        public long? ProductId { get; set; }
        public decimal? UnitPurchasePrice { get; set; }
        public bool? PpvatIncluded { get; set; }
        public decimal? PpvatPercent { get; set; }
        public decimal? Ppvat { get; set; }
        public decimal? PpotherCharge { get; set; }
        public decimal? TotalPurchasePrice { get; set; }
        public decimal? UnitSalesPrice { get; set; }
        public bool? SpvatIncluded { get; set; }
        public decimal? SpvatPercent { get; set; }
        public decimal? Spvat { get; set; }
        public decimal? SpotherCharge { get; set; }
        public decimal? TotalSalesPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }

        public virtual ProductPrice ProductPrice { get; set; }
    }
}

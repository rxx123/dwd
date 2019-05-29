using System;
using System.Collections.Generic;

namespace kcdz.dwd.api.Models
{
    public partial class EquipmentLedger
    {
        public int Id { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceClassify { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string BelongOrgan { get; set; }
        public string BelongStation { get; set; }
        public string CommissioningDate { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceStatus { get; set; }
        public string Remark { get; set; }
        public string ViewPhoto { get; set; }
    }
}

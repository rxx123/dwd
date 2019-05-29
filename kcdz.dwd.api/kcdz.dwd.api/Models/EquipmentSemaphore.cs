using System;
using System.Collections.Generic;

namespace kcdz.dwd.api.Models
{
    public partial class EquipmentSemaphore
    {
        public int Id { get; set; }
        public int? EquipmentLedgerId { get; set; }
        public string DeviceName { get; set; }
        public string BelongStation { get; set; }
        public string LineLimit { get; set; }
        public string AdjacentLimit { get; set; }
        public string LensGroupType { get; set; }
        public string NumberIndicators { get; set; }
        public string InstitutionalType { get; set; }
        public string EquipmentModel { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace kcdz.dwd.api.Models
{
    public partial class EquipmentZone
    {
        public int Id { get; set; }
        public int EquipmentLedgerId { get; set; }
        public string DeviceName { get; set; }
        public string BelongStation { get; set; }
        public string Type { get; set; }
        public string System { get; set; }
        public string Coding { get; set; }
        public string ZoneLength { get; set; }
    }
}

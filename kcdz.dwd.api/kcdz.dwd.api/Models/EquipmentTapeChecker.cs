using System;
using System.Collections.Generic;

namespace kcdz.dwd.api.Models
{
    public partial class EquipmentTapeChecker
    {
        public int Id { get; set; }
        public int EquipmentLedgerId { get; set; }
        public string DeviceName { get; set; }
        public string BelongStation { get; set; }
        public string TapeCheckerType { get; set; }
        public string OnThatTime { get; set; }
        public string Vender { get; set; }
    }
}

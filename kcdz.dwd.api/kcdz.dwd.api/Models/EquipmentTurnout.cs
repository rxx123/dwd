using System;
using System.Collections.Generic;

namespace kcdz.dwd.api.Models
{
    public partial class EquipmentTurnout
    {
        public int Id { get; set; }
        public int EquipmentLedgerId { get; set; }
        public string DeviceName { get; set; }
        public string BelongStation { get; set; }
        public string MainLine { get; set; }
        public string SwitchType { get; set; }
        public string NumberSwitchMachine { get; set; }
        public string GapSupervision { get; set; }
        public string SnowMelting { get; set; }
        public string TapeChecker { get; set; }
        public string SettingType { get; set; }
        public string InterlockType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcdz.dwd.api.Dtos
{
    public class EquipmentLedgerGetDto
    {
        public int per_page { get; set; }
        public int currentPage { get; set; }
        public string station { get; set; }
        public string keywordsDeviceName { get; set; }
        public string keywordsDeviceType { get; set; }
        public string keywordsDeviceClassify { get; set; }
    }
}

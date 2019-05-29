using System;
using System.Collections.Generic;

namespace kcdz.dwd.api.Models
{
    public partial class Drawing
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string DrawingName { get; set; }
        public string DrawingUrl { get; set; }
    }
}

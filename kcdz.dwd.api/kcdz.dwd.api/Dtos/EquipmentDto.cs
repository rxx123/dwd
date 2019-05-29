using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcdz.dwd.api.Dtos
{
    public class EquipmentDto
    {
        //信号机
        public class EquipmentSemaphore
        {
            public int Id { get; set; }
            public int EquipmentLedgerId { get; set; }
            public string DeviceName { get; set; }//名称
            public string BelongStation { get; set; }
            public string LineLimit { get; set; }//本线限界
            public string AdjacentLimit { get; set; }//邻线限界
            public string LensGroupType { get; set; }//透镜组类型（透镜式，LED式）
            public string NumberIndicators { get; set; }//表示器个数
            public string InstitutionalType { get; set; }//机构类型(铝合金、铸铁、复合材料)
            public string EquipmentModel { get; set; }//器材型号
        }
        //道岔
        public class EquipmentTurnout
        {
            public string Name { get; set; }//名称
            public string MainLine { get; set; }//正线道岔（是、否）
            public string SwitchType { get; set; }//道岔类型（包含钢轨类型）（50KG、60KG）(1/12、1/9AT、1/12P60AT)
            public string NumberSwitchMachine { get; set; }//转辙机数量
            public string GapSupervision { get; set; }//缺口监督（有、无）
            public string SnowMelting { get; set; }//融雪装置（有、无）
            public string TapeChecker { get; set; }//密贴检查器
            public string SettingType { get; set; }//安装装置类型
            public string InterlockType { get; set; }//联锁类型(单动、双动、三动)
        }
        //转辙机
        public class EquipmentSwitchMachine
        {
            public string SwitchMachineType { get; set; }//转辙机类型（ZD6D）
            public string OnThatTime { get; set; }//上道时间(2011)
            public string Vender { get; set; }//厂家
            public string WayInstall { get; set; }//安装方式(左、右)
        }
        //密贴检查器
        public class EquipmentTapeChecker
        {
            public string TapeCheckerType { get; set; }//类型
            public string OnThatTime { get; set; }//上道时间
            public string Vender { get; set; }//厂家
        }
        //区段
        public class EquipmentZone
        {
            public string Name { get; set; }//名称
            public string Type { get; set; }//类型(一送一受、一送两受、一送三受)
            public string System { get; set; }//制式(25周相敏、直流、不对称)
            public string Coding { get; set; }//电码化(无电码化、电化ZPW-2000A、电化UM2000)
            public string ZoneLength { get; set; }//区段长度
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcdz.dwd.api.Dtos
{
    public class EquipmentLedgerDto
    {
        public string deviceCode { get; set; }//设备代码
        public string deviceClassify { get; set; }//设备分类
        public string deviceName { get; set; }//设备名称
        public string deviceType { get; set; }//设备型号
        public string belongOrgan { get; set; }//所属机构
        public string belongStation { get; set; }//所属站
        public string commissioningDate { get; set; }//投产日期
        public string manufacturer { get; set; }//生产厂家
        public string deviceStatus { get; set; }//设备状态
        public string remark { get; set; }//备注
        public string viewPhoto{ get; set; }//照片名称
    }
}

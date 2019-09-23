using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAnalyze_E1
{
    class FeiKunData
    {
        public String DtEnd { get; set; }//2018-10-01 00:01:22; 通话结束时间
        public String SType { get; set; }//TELEPHONE;通话类型 TELEPHONE时有Phone Code 可能为“undefined”
        public String Name1 { get; set; }//PHIF_01L; 呼入或者呼出通道名
        public String Role1 { get; set; }//Unknown Role;使用电话的角色？？
        public String Column1 { get; set; }//69229017; 可能是某种角色的Code
        public String Name2 { get; set; }//WP_045;呼入或者呼出通道名
        public String Chnl1{ get; set; }//7003;通道号
        public String PhoneCode1 { get; set; }//7003; 大多为6位，有部分位4位同column2 可能是呼入或者呼出号码
        public String State { get; set; }//4; 4，2两个数字为多，是某种状态？
        public String Chnl2 { get; set; }//0045;通道号
        public String PhoneCode2 { get; set; } //283145;大多为6位，有部分位4位同column2 可能是呼入或者呼出号码
        public String Column3 { get; set; }//0;
        public String DtCoulmn4 { get; set; }//00:00:04;普遍为10s以内 振铃时间？？
        public String DtStart { get; set; }//2018-10-01 00:00:44;通话开始时间
        public String DtHolding { get; set; }//00:00:38;通话时长
        public String Coulmn5 { get; set; }//0;
        public String Coulmn6 { get; set; }//END_BY_INTERNAL_USER;
        public String Coulmn7 { get; set; }//OUTCALL,STANDARD CALL,NOT_CONF,NOT_TRANSFER,NOT_DIVERSION,NOT_CALLFWD;
        public String Coulmn8 { get; set; }//Unknown TrunkGroup;
        public String Coulmn9 { get; set; }//0;
        public String Coulmn10 { get; set; }//0;
        public String Coulmn11 { get; set; }//0;
        public String Coulmn12 { get; set; }//0;

        public Int32 Matching { get; set; }//匹配度
    }
}

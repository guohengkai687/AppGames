using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAnalyze_E1
{
    class OperaFile
    {
        public void Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                AddTelePhoneList(line);
                //Console.WriteLine(line.ToString());
            }
        }
        public List<FeiKunData> Flist = new List<FeiKunData>();
        public int DistanceTime = 5;
        private void AddTelePhoneList(string line)
        {
            if (line.Contains("TELEPHONE"))
            {
                string[] str = line.Split(';');
                FeiKunData feiKun = new FeiKunData();
                feiKun.DtEnd = str[0];
                feiKun.SType = str[1];
                feiKun.Name1 = str[2];
                feiKun.Role1 = str[3];
                feiKun.Column1 = str[4];
                feiKun.Name2 = str[5];
                feiKun.Chnl1 = str[6];
                feiKun.PhoneCode1 = str[7];
                feiKun.State = str[8];
                feiKun.Chnl2 = str[9];
                feiKun.PhoneCode2 = str[10];
                feiKun.Column3 = str[11];
                feiKun.DtCoulmn4 = str[12];
                feiKun.DtStart = str[13];
                feiKun.DtHolding = str[14];
                feiKun.Coulmn5 = str[15];
                feiKun.Coulmn6 = str[16];
                feiKun.Coulmn7 = str[17];
                feiKun.Coulmn8 = str[18];
                feiKun.Coulmn9 = str[19];
                feiKun.Coulmn10 = str[20];
                feiKun.Coulmn11 = str[21];
                feiKun.Coulmn12 = str[22];
                Flist.Add(feiKun);
            }
        }

        private E1Sound GetPhoneCode(List<FeiKunData> feiKuns, E1Sound e1)
        {
            if (feiKuns.Count > 0)
            {
                FeiKunData fei = feiKuns.FirstOrDefault<FeiKunData>();
                e1.PhoneCode1 = fei.PhoneCode1;
                e1.PhoneCode2 = fei.PhoneCode2;

                return e1;
            }
            else
            {
                return null;
            }
        }
        private List<FeiKunData> DataCompareFeiKun(List<FeiKunData> feiKuns, E1Sound e1)
        {
            List<FeiKunData> list = new List<FeiKunData>();
            List<FeiKunData> list1 = new List<FeiKunData>();
            List<FeiKunData> list2 = new List<FeiKunData>();
            //先通过通道号筛选通话记录合集
            foreach (var item in feiKuns)
            {
                if ((item.Chnl1 == e1.Chnl1 && item.Chnl2 == e1.Chnl2) ||
                    (item.Chnl1 == e1.Chnl2 && item.Chnl2 == e1.Chnl1))
                {
                    list.Add(item);
                }
            }
            if (list.Count <= 0)
            {
                return null;
            }
            //再根据通话时长筛选通话记录集合
            foreach (var item1 in list)
            {
                if (DataSpanAnalyze(item1, e1) > 0)
                {
                    list1.Add(item1);
                }
            }
            if (list1.Count <= 0)
            {
                return null;
            }
            //最后根据开始时间结束时间模糊定位通话记录集合
            foreach (var item2 in list1)
            {
                int Das = DataSpanAnalyze(item2, e1);
                TimeSpan stimefeikun = Convert.ToDateTime(item2.DtStart).TimeOfDay;
                TimeSpan stimee1 = Convert.ToDateTime(e1.DateStart).TimeOfDay;
                TimeSpan etimefeikun = Convert.ToDateTime(item2.DtEnd).TimeOfDay;
                TimeSpan etimee1 = Convert.ToDateTime(e1.DateEnd).TimeOfDay;

                switch (Das)
                {
                    case 1: //时长一样
                        if (stimefeikun == stimee1 && etimefeikun == etimee1)
                        {
                            item2.Matching = 100;
                            list2.Add(item2);
                        }
                        else if (stimefeikun < stimee1 && etimefeikun < etimee1 && etimefeikun > stimee1)
                        {
                            list2.Add(item2);
                        }
                        else if (stimefeikun > stimee1 && etimefeikun > etimee1 && stimefeikun < etimee1)
                        {
                            list2.Add(item2);
                        }
                        else
                        {

                        }
                        break;
                    case 2: //FeiKun记录时长 大于 E1记录时长
                        if (stimefeikun < stimee1 && System.Math.Abs(TimeSpan.Compare(etimefeikun, etimee1)) <= DistanceTime)
                        {
                            list2.Add(item2);
                        }
                        else if (System.Math.Abs(TimeSpan.Compare(stimefeikun, stimee1)) <= DistanceTime && etimefeikun > etimee1)
                        {
                            list2.Add(item2);
                        }
                        else if (stimefeikun > stimee1 && etimefeikun < etimee1)
                        {
                            list2.Add(item2);
                        }
                        else
                        {

                        }
                        break;
                    case 3: //FeiKun记录时长 小于 E1记录时长
                        if (stimefeikun < stimee1 && etimefeikun < etimee1 && etimefeikun > stimee1)
                        {
                            list2.Add(item2);
                        }
                        else if (stimefeikun > stimee1 && stimefeikun < etimee1 && etimefeikun > etimee1)
                        {
                            list2.Add(item2);
                        }
                        else if (stimefeikun < stimee1 && etimefeikun > etimee1)
                        {
                            list2.Add(item2);
                        }
                        else
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
            return null;
        }

        private int DataSpanAnalyze(FeiKunData item1, E1Sound e1)
        {
            DateTime dt1 = Convert.ToDateTime(item1.DtHolding);
            DateTime dt2 = Convert.ToDateTime(e1.DateSpan);
            int dt = TimeSpan.Compare(dt1.TimeOfDay, dt2.TimeOfDay);
            if (dt1 == dt2)//两个时间段相等，或者相差小于5s
            {
                return 1;
            }
            else if (dt1 != dt2 && dt > 0 && dt <= DistanceTime)
            {
                return 2; //dt1>dt2
            }
            else if (dt1 != dt2 && dt < 0 && dt >= DistanceTime * -1)
            {
                return 3; //dt1<dt2
            }
            else
            {
                return 0;
            }
        }
    }
}

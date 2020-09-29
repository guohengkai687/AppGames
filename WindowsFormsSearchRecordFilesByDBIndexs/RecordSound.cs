using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsSearchRecordFilesByDBIndexs
{
    public class RecordSound : ICloneable
    {
        private long _pK;
        public long PK
        {
            get { return _pK; }
            set { _pK = value; }
        }
        private int _chnlID;
        public int ChnlID
        {
            get { return _chnlID; }
            set { _chnlID = value; }
        }

        private string _telNum = "";
        public string TelNum
        {
            get { return _telNum; }
            set { _telNum = value; }
        }
        private DateTime _rTime;
        public DateTime RTime
        {
            get { return _rTime; }
            set { _rTime = value; }
        }
        private int _rLen;
        public int RLen
        {
            get { return _rLen; }
            set { _rLen = value; }
        }
        private int _hDNO;
        public int HDNO
        {
            get { return _hDNO; }
            set { _hDNO = value; }
        }
        private int _packRate;
        public int PackRate
        {
            get { return _packRate; }
            set { _packRate = value; }
        }
        private int _ringTimes;
        public int RingTimes
        {
            get { return _ringTimes; }
            set { _ringTimes = value; }
        }
        private string _recNum = "";
        public string RecNum
        {
            get { return _recNum; }
            set { _recNum = value; }
        }
        private int _callType;
        /// <summary>
        /// 0,未知 1呼入,2呼出 3,未接
        /// </summary>
        public int CallType
        {
            get { return _callType; }
            set { _callType = value; }
        }

        private string _remark = "";
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private int _keepFlag;
        public int KeepFlag
        {
            get { return _keepFlag; }
            set { _keepFlag = value; }
        }
        private string _reserve = "";
        public string Reserve
        {
            get { return _reserve; }
            set { _reserve = value; }
        }

        public object Clone()
        {
            RecordSound record = new RecordSound();
            record.ChnlID = this.ChnlID;
            record.CallType = this.CallType;
            record.HDNO = this.HDNO;
            record.KeepFlag = this.KeepFlag;
            record.PackRate = this.PackRate;
            record.PK = this.PK;
            record.RecNum = this.RecNum;
            record.Remark = this.Remark;
            record.RingTimes = this.RingTimes;
            record.RLen = this.RLen;
            record.RTime = this.RTime;
            record.TelNum = this.TelNum;
            //record.TimeZone = this.TimeZone;
            record.Reserve = this.Reserve;
            return record;
        }
    }
}

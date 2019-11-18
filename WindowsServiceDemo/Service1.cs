using System;
using System.ServiceProcess;
using System.Threading;

namespace WindowsServiceDemo
{
    public partial class ServiceTest : ServiceBase
    {
        System.Threading.Timer recordTimer;
        public ServiceTest()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            IntialSaveRecord();

        }

        protected override void OnStop()
        {
            if (recordTimer != null)
            {
                recordTimer.Dispose();
            }

        }
        private void IntialSaveRecord()
        {
            TimerCallback timerCallback = new TimerCallback(CallbackTask);


            AutoResetEvent autoEvent = new AutoResetEvent(false);


            recordTimer = new System.Threading.Timer(timerCallback, autoEvent, 10000, 60000 * 10);
        }


        private void CallbackTask(Object stateInfo)
        {
            FileOperation.SaveRecord(string.Format(@"当前记录时间：{0},状况：程序运行正常！", DateTime.Now));
        }

    }
}

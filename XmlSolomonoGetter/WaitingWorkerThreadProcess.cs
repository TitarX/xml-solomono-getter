using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace XmlSolomonoGetter
{
    class WaitingWorkerThreadProcess
    {
        public delegate void MainFormInvokeDelegate();

        private MainFormInvokeDelegate mainFormInvokeDelegate = null;
        private MainForm mainForm = null;
        private Thread workerThread = null;
        private Thread thisThread = null;

        public WaitingWorkerThreadProcess(MainForm mainForm, Thread workerThread)
        {
            this.mainForm = mainForm;
            this.workerThread = workerThread;

            Thread thisThread = new Thread(this.Run);
            this.thisThread = thisThread;
            thisThread.Start();
        }

        public Thread ThisThread
        {
            get
            {
                return thisThread;
            }
        }

        private void Run()
        {
            if (workerThread.IsAlive)
            {
                workerThread.Join();
            }

            mainFormInvokeDelegate = delegate
            {
                mainForm.ChangeFormComponentsStatusAtStopping();
            };
            mainForm.Invoke(mainFormInvokeDelegate);
        }
    }
}

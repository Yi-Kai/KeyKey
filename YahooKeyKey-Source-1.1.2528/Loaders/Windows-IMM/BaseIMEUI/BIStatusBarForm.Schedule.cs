using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseIMEUI
{
    public partial class BIStatusBarForm
    {
        private int m_idleCount = 0;
        private bool m_usedEmptyWorkingSetCheck = false;
        private bool m_usedRecuceMemoryCheck = false;
        private bool m_firstReduceMemoryCheck = false;

        public void ResetIdleCount()
        {
            this.m_usedEmptyWorkingSetCheck = false;
            this.m_usedRecuceMemoryCheck = false;
            this.m_idleCount = 0;
        }

        private void InstallIdleTimer()
        {
            Timer idleTimer = new Timer();
            idleTimer.Interval = 1000 * 60;
            idleTimer.Tick += new EventHandler(TickIdleTimer);
            idleTimer.Enabled = true;
            idleTimer.Start();
        }

        void TickIdleTimer(object sender, EventArgs e)
        {
            this.m_idleCount++;

            if (m_idleCount > 10)
            {
                if (this.m_usedEmptyWorkingSetCheck)
                    return;
                Win32FunctionHelper.EmptyWorkingSet();
                m_usedEmptyWorkingSetCheck = true;
            }
            if (m_idleCount > 5)
            {
                if (m_usedRecuceMemoryCheck)
                    return;
                Win32FunctionHelper.ReduceMemory();
                m_usedRecuceMemoryCheck = true;
            }
            else if (m_firstReduceMemoryCheck == false)
            {
                Win32FunctionHelper.ReduceMemoryAtFirstTime();
                m_firstReduceMemoryCheck = true;
            }
        }
    }
}

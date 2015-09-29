using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlomalyTimeSeriesDetector.entity
{
    public class NSubsequence
    {
        private int start;
        private int end;

        public NSubsequence()
        {
        }

        public NSubsequence(int start, int end)
        {
            if (start <= end) {
                MessageBox.Show("can't create Subsequence with start-end: " + start + "-" + end);
                return;
            }
            this.start = start;
            this.end = end;
        }

        public int getEnd()
        {
            return end;
        }

        public int getStart()
        {
            return start;
        }

        public void setEnd(int end)
        {
            this.end = end;
        }

        public void setStart(int start)
        {
            this.start = start;
        }

        public int getLength()
        {
            return end - start + 1;
        }
    }
}

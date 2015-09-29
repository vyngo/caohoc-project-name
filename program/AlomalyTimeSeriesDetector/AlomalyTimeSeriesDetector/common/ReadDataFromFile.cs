using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlomalyTimeSeriesDetector.entity;

namespace AlomalyTimeSeriesDetector.common
{
    public class ReadDataFromFile
    {
        private string fileName;
        public ReadDataFromFile(string fileName)
        {
            this.fileName = fileName;
        }
        public NTimeSeries read()
        {
            // TODO code application logic here
            System.IO.StreamReader scanner = null;
            NTimeSeries series = new NTimeSeries();
            try
            {
                // Location of file to read

                scanner = new System.IO.StreamReader(fileName);
                string line = null;
                while ((line = scanner.ReadLine()) != null)
                {
                    series.addData(Double.Parse(line));
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex, ex.StackTrace);
            }
            finally
            {
                if (scanner != null)
                {
                    scanner.Close();
                }
            }
            return series;
        }
    }
}

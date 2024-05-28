using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesForecasting.Model
{
    public class YolcuTahmini
    {
        public float[] TahminiYolcuSayısı { get; set; }
        public float[] TahminiAltSınır { get; set; }
        public float[] TahminiUstSınır { get; set; }
    }
}

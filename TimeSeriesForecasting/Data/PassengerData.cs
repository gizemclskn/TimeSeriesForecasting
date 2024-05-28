using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesForecasting.Data
{
    public class PassengerData
    {
        [LoadColumn(0)]
        public string Month { get; set; }

        [LoadColumn(1)]
        public float Passengers { get; set; }
    }
}

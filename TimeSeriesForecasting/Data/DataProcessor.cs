using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesForecasting.Data
{
    
    using Microsoft.ML;

    public class DataProcessor
    {
        public IDataView LoadData(MLContext context, string dataPath)
        {
            return context.Data.LoadFromTextFile<PassengerData>(dataPath, separatorChar: ',', hasHeader: true);
        }
    }
   
}

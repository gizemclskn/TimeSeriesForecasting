using System;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.TimeSeries;
using TimeSeriesForecasting.Data;
using TimeSeriesForecasting.Model;

class Program
{
    static void Main(string[] args)
    {

        var context = new MLContext();

        var dataPath = "C:\\Study\\example\\TimeSeriesForecasting\\TimeSeriesForecasting\\airline-passengers.csv";

        var dataProcessor = new DataProcessor();
        var data = dataProcessor.LoadData(context, dataPath);

        var splitData = context.Data.TrainTestSplit(data, testFraction: 0.5);

   
        var trainData = splitData.TrainSet;

        var testData = splitData.TestSet;

        var modelTrainer = new ModelTrainer(context, trainData);
        modelTrainer.TrainModel();


        modelTrainer.SaveModel("model.zip");


        var loadedModel = new ModelTrainer(context, null);
        loadedModel.LoadModel("model.zip");

        var forecastingEngine = loadedModel.GetModel().Transform(testData);
        var predictions = context.Data.CreateEnumerable<YolcuTahmini>(forecastingEngine, false);


        var originalData = context.Data.CreateEnumerable<PassengerData>(testData, false);

 
        Console.WriteLine("Gerçek Veri\tTahmin Edilen Veri");
        foreach (var (prediction, original) in predictions.Zip(originalData, (p, o) => (p, o)))
        {
            Console.WriteLine($"{original.Passengers}\t\t{prediction.TahminiYolcuSayısı[0]}");
        }
    }
}

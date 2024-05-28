using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.TimeSeries;
using TimeSeriesForecasting.Data;

public class ModelTrainer
{
    private readonly MLContext _context;
    private readonly IDataView _data;
    private ITransformer _model;

    public ModelTrainer(MLContext context, IDataView data)
    {
        _context = context;
        _data = data;
    }

    public void TrainModel()
    {
        var pipeline = _context.Forecasting.ForecastBySsa(
            outputColumnName: "TahminiYolcuSayısı",
            inputColumnName: nameof(PassengerData.Passengers),
            windowSize: 12,
            seriesLength: 24,
            trainSize: 100, 
            horizon: 45,
            confidenceLevel: 0.95f,
            confidenceLowerBoundColumn: "TahminiAltSınır",
            confidenceUpperBoundColumn: "TahminiUstSınır");

        _model = pipeline.Fit(_data);
    }

    public void SaveModel(string filePath)
    {
        _context.Model.Save(_model, null, filePath);
    }

    public void LoadModel(string filePath)
    {
        _model = _context.Model.Load(filePath, out _);
    }

    public ITransformer GetModel()
    {
        return _model;
    }
}

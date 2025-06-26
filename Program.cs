using Microsoft.ML;
using Microsoft.ML.Data;
using System;

public class ResumeData
{
    [LoadColumn(0)]
    public string CombinedText { get; set; }

    [LoadColumn(1)]
    public float Score { get; set; }
}

public class ResumePrediction
{
    [ColumnName("Score")]
    public float Score { get; set; }
}

class Program
{
    static void Main()
    {
        var context = new MLContext();

        var data = context.Data.LoadFromTextFile<ResumeData>(
            path: "data.csv", separatorChar: ',', hasHeader: true);

        var pipeline = context.Transforms.Text.FeaturizeText("Features", nameof(ResumeData.CombinedText))
            .Append(context.Regression.Trainers.Sdca(labelColumnName: "Score", featureColumnName: "Features"));

        var model = pipeline.Fit(data);

        context.Model.Save(model, data.Schema, "../MLModel/ResumeScorer.mlmodel");
        Console.WriteLine("Model trained and saved as ResumeScorer.mlmodel ✅");
    }
}

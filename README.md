# ResumeModelTrainer

## Overview
This is a simple console application to train an ML.NET regression model that scores resumes based on combined resume and job description text.  
It reads training data from a CSV file and outputs a serialized ML model file (`ResumeScorer.mlmodel`).

---

## Prerequisites

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) installed
- Training data CSV file named `data.csv` placed in the `ResumeModelTrainer` folder

---

## Training Data Format

- The CSV file `data.csv` should have a header row with two columns:
  - `CombinedText` (string): concatenated resume text and job description text
  - `Score` (float): numerical score representing how well the resume fits the job

Example:

```csv
CombinedText,Score
"Experienced C# developer with ML.NET knowledge",0.85
"Junior software engineer familiar with Python",0.4
```

1. Setup & Run

Open a terminal and navigate to the ResumeModelTrainer directory.

2. Restore dependencies:
```
dotnet restore
```
3. Build the project:
```
dotnet build
```
4. Run the trainer:
```
dotnet run
```
The program will read data.csv, train a regression model, and save ResumeScorer.mlmodel to the ../MLModel/ directory relative to ResumeModelTrainer.
Output

ResumeScorer.mlmodel file in the ResumeScreenerApp/MLModel/ directory (or wherever specified in the code).
Notes

Make sure the data.csv file contains quality training data for better model accuracy.
Update or retrain the model as needed when new data becomes available.

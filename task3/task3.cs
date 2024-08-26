using System;
using System.Collections;
using System.Text.Json;

if (args.Length != 3)
{
    Console.WriteLine("Invalid arguments");
    return;
}

string testsPath = args[0];
string valuesPath = args[1];
string reportPath = args[2];

TestsRoot testsRoot;
TestsResult testsResult;

using (StreamReader reader = new StreamReader(testsPath))
{
    string jsonText = reader.ReadToEnd();
    testsRoot = JsonSerializer.Deserialize<TestsRoot>(jsonText);
}

using (StreamReader reader = new StreamReader(valuesPath))
{
    string jsonText = reader.ReadToEnd();
    testsResult = JsonSerializer.Deserialize<TestsResult>(jsonText);
}

foreach (var item in testsRoot.tests)
{
    FillValues(item);
}

void FillValues(Test test)
{
    foreach (var item in testsResult.values)
    {
        if (item.id == test.id)
        {
            test.value = item.value;
        }
    }

    if (test.values != null)
    {
        foreach (var item in test.values)
        {
            FillValues(item);
        }
    }
}

string json = JsonSerializer.Serialize(testsRoot);

using (StreamWriter writer = new StreamWriter(reportPath))
{
    writer.WriteLine(json);
}

// Deserialize tests.json
public class TestsRoot
{
    public List<Test> tests { get; set; }
}

public class Test
{
    public int id { get; set; }
    public string title { get; set; }
    public string value { get; set; }
    public List<Test> values { get; set; }
}

// Deserialize values.json
public class TestsResult
{
    public List<Value> values { get; set; }
}

public class Value
{
    public int id { get; set; }
    public string value { get; set; }
}
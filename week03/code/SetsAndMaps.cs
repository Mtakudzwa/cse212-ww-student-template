using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            seen.Add(word);
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3].Trim(); // Get 4th column

            if (!degrees.ContainsKey(degree))
                degrees[degree] = 0;

            degrees[degree]++;
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string Normalize(string word) =>
            new string(word.ToLower().Where(char.IsLetterOrDigit).OrderBy(c => c).ToArray());

        return Normalize(word1) == Normalize(word2);
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag}")
            .ToArray();

        return summaries;
    }
}

public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public FeatureProperties Properties { get; set; }
}

public class FeatureProperties
{
    public string Place { get; set; }
    public double Mag { get; set; }
}

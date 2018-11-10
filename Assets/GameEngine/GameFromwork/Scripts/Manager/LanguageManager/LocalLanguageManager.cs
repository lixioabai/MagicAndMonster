using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalLanguageManager {

    private static LocalLanguageManager _instance;

    public static LocalLanguageManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LocalLanguageManager();
            }
            return _instance;
        }
    }

    private const string Chinese= "LocalLanguage/Chinese";
    private const string English = "LocalLanguage/English";

    public const string Language = English;

    private Dictionary<string, string> Dict;

    public LocalLanguageManager()
    {
        Dict = new Dictionary<string, string>();

       TextAsset ta=Resources.Load<TextAsset>(Language);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line) == false)
            {
                string[] keyvalues = line.Split('=');
                Dict.Add(keyvalues[0], keyvalues[1]);
            }
        }
    }

    public void Init()
    {
        // do nothing
    }

    public string GetValue(string key)
    {
        string value;
        Dict.TryGetValue(key, out value);
        return value;
            
    }
}

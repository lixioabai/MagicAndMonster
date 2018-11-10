using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class CSV
{
    static CSV csv;
    public static CSV GetInstance()
    {
        if(csv==null)
        {
            csv = new CSV();
        }
        return csv;
    }
    public List<string> m_ArrayData = new List<string>();
    private CSV()
    {
        m_ArrayData = new List<string>();
    }
    public void loadFile(string path, string fileName)
    {
        m_ArrayData.Clear();
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "//" + fileName);
        }
        catch
        {
            Debug.Log("file don't finded!");
        }
        string line;
        while((line=sr.ReadLine())!=null)
        {
            m_ArrayData.Add(line);
        }
        sr.Close();
        sr.Dispose();
    }
}

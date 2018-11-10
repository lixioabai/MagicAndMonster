using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class AudioWindowEditor : EditorWindow {

    [MenuItem("Manager/AduioManager")]
    static void CreatWindwo()
    {
        Rect rect = new Rect(400,400,300,300);
        // AudioWindowEditor window = EditorWindow.GetWindowWithRect(typeof(AudioWindowEditor), rect) as AudioWindowEditor;
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("音效管理") ;
        window.Show();
    }

    void Awake()
    {
        LoadAudioList();
    }



    private string audioName;
    private string audioPath= "Audio/";
    private AudioClip audioClip;
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();
    void OnGUI()
    {

        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名称");
        GUILayout.Label("音效路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();
        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);

            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);
            if (GUILayout.Button("删除"))
            {
                audioDict.Remove(key);
                SaveAudioList();
                return;
            }
            GUILayout.EndHorizontal();
        }
        EditorGUILayout.Space();
        audioName = EditorGUILayout.TextField("音效名字", audioName);
        EditorGUILayout.Space();
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);
     
        if (GUILayout.Button("添加音效"))
        {
          object o=  Resources.Load(audioPath);
            if (null == o)
            {
                Debug.LogWarning("音效不存在于：" + audioPath + "添加失败");
                audioPath = "";
            }
            else
            {
                if (audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("名称已存在，请修改");
                }
                else
                {
                    audioDict.Add(audioName, audioPath);
                    SaveAudioList();
                }
               
            }
        }

      
    }

   

    private void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            sb.Append(key+","+value+"\n");
          
        }

       
        File.WriteAllText(AudioManager.AudioTextPath, sb.ToString());
      
    }

    private void LoadAudioList()
    {
        audioDict = new Dictionary<string, string>();
        if (File.Exists(AudioManager.AudioTextPath) == false)
        {
            Debug.Log("wenjia");
            return;
        }
        string[] lines = File.ReadAllLines(AudioManager.AudioTextPath);
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyvalue = line.Split(',');
            audioDict.Add(keyvalue[0], keyvalue[1]);
        }
    }

    void OnInspectorUpdate()
    {
        Awake();
    }
	
}

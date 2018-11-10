using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// 用来显示API 参数及用法的窗口
/// </summary>
public class APIArgsShowWindows : EditorWindow {

    public static APIArgsShowWindows _instance;

    private static string Tittle = "概述";
    private static string Intruduce = "介绍";
    private static string Use = "使用方法";

    Vector2 _scrollPos;
    public static void ShowAPIWindwos(string tittle,string intruduce,string use)
    {
        _instance = EditorWindow.GetWindow<APIArgsShowWindows>();
        _instance.titleContent = new GUIContent("Args API");

        Tittle = tittle;
        Intruduce = intruduce;
        Use = use;
    }

    void OnGUI()
    { 

       if(GUILayout.Button("关闭",EasyMVC_API.SetGUIStyle(Color.black,GUI.skin.button)))
        {
            Close();
        }

       _scrollPos = GUILayout.BeginScrollView(_scrollPos);
       GUILayout.BeginVertical("Box");
       GUILayout.Label("概述",EasyMVC_API.SetGUIStyle(Color.green,GUI.skin.label));
       GUILayout.Label(Tittle, EasyMVC_API.SetGUIStyle(Color.white, GUI.skin.label));

       GUILayout.Space(20);

       GUILayout.Label("介绍", EasyMVC_API.SetGUIStyle(Color.green, GUI.skin.label));
       GUILayout.Label(Intruduce, EasyMVC_API.SetGUIStyle(Color.white, GUI.skin.label));

       GUILayout.Space(30);

       GUILayout.Label("使用方法", EasyMVC_API.SetGUIStyle(Color.green, GUI.skin.label));
       GUILayout.Label(Use, EasyMVC_API.SetGUIStyle(Color.white, GUI.skin.label));

       GUILayout.EndVertical();
       GUILayout.EndScrollView();
    }
}

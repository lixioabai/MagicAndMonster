using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// API 总界面
/// </summary>
public class APIWindwos : EditorWindow
{
    public enum ScriptsType
    { 
        None,
        PanelMgr,
        PanelBase,
        Other
    }


    
    public static APIWindwos _instance;

    private ScriptsType scriptsType = ScriptsType.None;

    public static void ShowAPIWindwos()
    {
        _instance = EditorWindow.GetWindow<APIWindwos>();
        _instance.titleContent = new GUIContent("EasyMVC API");
    }



    /// <summary>
    /// 绘制界面
    /// </summary>
    void OnGUI()
    {

        scriptsType = (ScriptsType)EditorGUILayout.EnumPopup("类别", scriptsType);

        if (scriptsType == ScriptsType.None)
        {
            GUILayout.BeginVertical("Box");

            

            GUILayout.EndVertical();
        }

        if (scriptsType == ScriptsType.PanelBase)
        {
            GUILayout.BeginVertical("Box");

            if (GUILayout.Button("PanelBase"))
            {
                PanelBaseWindows.ShowAPIWindwos();
            }

            GUILayout.EndVertical();
        }
        if (scriptsType == ScriptsType.PanelMgr)
        {
            GUILayout.BeginVertical("Box");

            GUILayout.Button("PanelBase");

            GUILayout.EndVertical();
        }

        if (scriptsType == ScriptsType.Other)
        {
            GUILayout.BeginVertical("Box");

            GUILayout.Button("PanelBase");

            GUILayout.EndVertical();
        }

        
        
         
     
    }


}

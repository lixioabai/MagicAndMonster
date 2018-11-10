using UnityEngine;
using System.Collections;
using UnityEditor;

public class EasyMVC_API : EditorWindow 
{
    [MenuItem("MVCTools/API")]
    public static void OpenAPIWindows()
    {
        bool result = EditorUtility.DisplayDialog("API通知", "是否查阅API接口", "Open", "Cancel");
        if (result)
        {
            APIWindwos.ShowAPIWindwos();
        }
    }


       /// <summary>
    ///  设置GUI样式
   /// </summary>
   /// <param name="color">颜色</param>
   /// <param name="Type">组件类型（button lab   --->GUI.skin.button）</param>
   /// <param name="Bold">是否加粗</param>
   /// <returns>样式</returns>
   public static  GUIStyle SetGUIStyle(Color color, GUIStyle Type, bool Bold = false)
    {

        GUIStyle guiStyle = new GUIStyle(Type);
        guiStyle.alignment = TextAnchor.LowerCenter;
        if (Bold)
        {
            guiStyle.fontStyle = FontStyle.Bold;
        }
        guiStyle.fontSize = 18;
        guiStyle.normal.textColor = color;
        return guiStyle;
    }

}



using UnityEngine;
using System.Collections;
using UnityEditor;

public class PoorManagerEditor : EditorWindow {

    [MenuItem("Manager/Creat GameObjectPoorConfig")]
    static void CreateGameObjectPoorList()
    {
		GameObjectManagerList poorList = ScriptableObject.CreateInstance<GameObjectManagerList>();
        string path =PoorManager.PoorConfigPath;
        AssetDatabase.CreateAsset(poorList,path);
        AssetDatabase.SaveAssets();
    }
}

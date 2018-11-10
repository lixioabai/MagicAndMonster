using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoorManager  {

    private static PoorManager _instance;

    public static PoorManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PoorManager();
            }
            return _instance;
        }
    }

    private static string poorConfigPathPrefix = "Assets/GameEngine/Resources/";
    private const string poorConfigtPathMiddle = "gameObjectPoor";
    private const string poorConfigPathPosfix = ".asset";

    public static string PoorConfigPath
    {
        get
        {
            return poorConfigPathPrefix + poorConfigtPathMiddle + poorConfigPathPosfix;
        }
    }

    private Dictionary<string, GameObjectManager> poorDict;

    private PoorManager()
    {
        GameObjectManagerList mangaerList = Resources.Load<GameObjectManagerList>(poorConfigtPathMiddle);

        poorDict = new Dictionary<string, GameObjectManager>();

        foreach (GameObjectManager poor in mangaerList.pooList)
        {
            poorDict.Add(poor.name, poor);
        }
    }

    public void Init()
    {
        // do nothing
    }


    public GameObject GetIns(string poorName)
    {
        GameObjectManager poor;
        if (poorDict.TryGetValue(poorName, out poor))
        {
            return poor.GetInst();
        }
        Debug.LogWarning("Poor:"+poorName+" is not exits!!!" );
        return null;
    }
   
}

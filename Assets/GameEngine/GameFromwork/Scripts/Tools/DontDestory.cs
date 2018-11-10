using UnityEngine;
using System.Collections;

public class DontDestory : MonoBehaviour {

    public static DontDestory Instance;

    public bool DontDestoryOnLoad = true;
	void Start () 
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
        if (DontDestoryOnLoad)
        {
            GameObject.DontDestroyOnLoad(this);
        }


	}
	
	 
}

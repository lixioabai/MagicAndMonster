using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoorManager.Instance.GetIns("bullet");
        }
        if (Input.GetMouseButtonDown(1))
        {
            PoorManager.Instance.GetIns("music");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.LoadLevel("PoorManagerTest2");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Application.LoadLevel("PoorManagerTest");
        }

    }

    
}

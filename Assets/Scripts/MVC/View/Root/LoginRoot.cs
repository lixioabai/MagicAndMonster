using UnityEngine;
using EasyMVC;

public class LoginRoot : MonoBehaviour {

	
	void Start ()
    {
        PanelMgr.instance.OpenPanel<LoginPanel>("","");
	}
	
	
}

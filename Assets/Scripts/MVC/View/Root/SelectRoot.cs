using UnityEngine;
using EasyMVC;

public class SelectRoot : MonoBehaviour {

	
	void Start ()
    {
        PanelMgr.instance.OpenPanel<SelectPlayerPanel>("","");
	}

}

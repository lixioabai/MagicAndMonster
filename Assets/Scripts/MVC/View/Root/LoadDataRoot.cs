using UnityEngine;
using System.Collections;

public class LoadDataRoot : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        EasyMVC.PanelMgr.instance.OpenPanel<LoadDataPanel>("","");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class DeactiveTime : MonoBehaviour {

    public float times=3;
	void OnEnable () {
        Invoke("Deactive", times);

	}
	
	void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}

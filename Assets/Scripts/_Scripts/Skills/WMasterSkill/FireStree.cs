using UnityEngine;
using System.Collections;

public class FireStree : MonoBehaviour {
    public GameObject fire;
    float alltouch;
    float times;
	void Start () {
        alltouch = 4.1f;
        times = 0f;
	}
	void Update () {
        times -= Time.deltaTime;
        alltouch -= Time.deltaTime;
        if (alltouch >= 0)
        {
            if (times <= 0)
            {
                Instantiate(fire, this.transform.position, this.transform.rotation);
                times = 0.1f;
            }
        }
	}
}

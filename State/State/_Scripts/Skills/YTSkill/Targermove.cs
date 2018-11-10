using UnityEngine;
using System.Collections;

public class Targermove : MonoBehaviour {
    public GameObject T;
	void Start () {
        T = GameObject.FindGameObjectWithTag("Player").transform.FindChild("Dummy04").FindChild("Box001").gameObject;
	}
	void Update () {
        this.transform.position = new Vector3(T.transform.position.x, T.transform.position.y - 1f, T.transform.position.z);
	}
}

using UnityEngine;
using System.Collections;

public class SuiJiGoblin : MonoBehaviour {
    public GameObject Goblin_;
    float X_;
    float Z_;
    float times=10f;
	void Start () {
	
	}
	void Update () {
        times -= Time.deltaTime;
        if(times<=0)
        {
            X_ =this.transform.position.x+Random.Range(-10,10);
            Z_ =this.transform.position.z+Random.Range(-10,10);
            Instantiate(Goblin_,new Vector3(X_,this.transform.position.y,Z_),this.transform.rotation);
            times = 5f;
        }
	}
}

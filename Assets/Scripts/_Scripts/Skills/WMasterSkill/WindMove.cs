using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindMove : MonoBehaviour {
    HashSet<GameObject> enemys = new HashSet<GameObject>();
    float jishi = 1f;
    bool move = true;
	void Start () {
	
	}
	void Update () {
        jishi -= Time.deltaTime;
        if(jishi<=0)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            foreach(GameObject o in enemys)
            {
                o.transform.parent = null;
            }
            Destroy(this.gameObject);
        }
        if (jishi <= 0.3f&&move)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            this.transform.position = Vector3.Lerp(this.transform.position, this.transform.parent.transform.FindChild("feng").transform.position, 3.5f * Time.deltaTime);
        }
	}
    void OnTriggerStay(Collider other)
    {
        if(other.tag=="enemy")
        {
            other.transform.parent = this.transform;
            enemys.Add(other.gameObject);
        }
        if(other.tag=="Obstacles")
        {
            move = false;
            this.transform.parent.transform.FindChild("feng").transform.position = this.transform.position;
        }
    }
}

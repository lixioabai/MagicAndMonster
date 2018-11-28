using UnityEngine;
using System.Collections;

public class TestPool : MonoBehaviour {

    public GameObject prefab;
    public GameObject cube;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
           
                ObjectPoor.Instance().Create(prefab,transform.position,Quaternion.identity);
            
            
        }
        if (Input.GetKeyDown(KeyCode.K))
        {


            ObjectPoor.Instance().Create(cube, transform.position, Quaternion.identity);


        }
    }
}

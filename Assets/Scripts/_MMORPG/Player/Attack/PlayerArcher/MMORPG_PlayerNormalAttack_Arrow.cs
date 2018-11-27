using UnityEngine;
using System.Collections;

/// <summary>
/// 弓箭
/// </summary>
public class MMORPG_PlayerNormalAttack_Arrow : MonoBehaviour {

    public Vector3 direction;
    public GameObject target;


    void Start ()
    {
       
	}


	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.transform.position, 0.1f);
        }
      
	}
}

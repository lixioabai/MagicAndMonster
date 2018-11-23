using UnityEngine;
using System.Collections;

/// <summary>
/// 弓箭
/// </summary>
public class MMORPG_PlayerNormalAttack_Arrow : MonoBehaviour {

    public Vector3 direction;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
       transform.localPosition = Vector3.MoveTowards(transform.localPosition, direction, 0.1f);
	}
}

using UnityEngine;
using System.Collections;

public class TestInputs : MonoBehaviour {

	
	void Start () {
	
	}
	
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MessageDispatcher.Instance.DispatchMessage(0, transform,transform, (int)MessagesType.Player_SkillQ, EntityManager.Instance.GetEntityFromTransform(transform), 1f);
        }

	}
}

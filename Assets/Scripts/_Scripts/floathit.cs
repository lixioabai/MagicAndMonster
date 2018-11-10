using UnityEngine;
using System.Collections;

public class floathit : MonoBehaviour {
    public float times=10f;
    bool canhit;
    int i=0;
	void Start () {
        canhit = true;
	}
	void Update () {
        times -= Time.deltaTime;
        if(!canhit)
        {
            times = 6f;
            canhit = true;
        }
	}
    void OnTriggerStay(Collider other)
    {
        if (times <= 0&&canhit)
        {
            if (other.tag == "Player")
            {
                if (i % 2 == 0)
                {
                    MessageDispatcher.Instance.DispatchMessage(0, this.transform, other.transform, (int)MessagesType.Msg_BeingUpFukongBig, EntityManager.Instance.GetEntityFromTransform(this.transform), 10f, Buff.Burnt);
                    i++;
                }
                else
                {
                    MessageDispatcher.Instance.DispatchMessage(0, this.transform, other.transform, (int)MessagesType.Msg_BeingUpFukongSmall, EntityManager.Instance.GetEntityFromTransform(this.transform), 10f, Buff.Burnt);
                    i++;
                }
                    canhit = false;
            }
        }
    }
}

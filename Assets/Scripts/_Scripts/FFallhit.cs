using UnityEngine;
using System.Collections;

public class FFallhit : MonoBehaviour {
    public float times = 10f;
    bool canhit;
    void Start()
    {
        canhit = true;
    }
    void Update()
    {
        times -= Time.deltaTime;
        if (!canhit)
        {
            times = Random.Range(2,6);
            canhit = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (times <= 0 && canhit)
        {
            if (other.tag == "Player")
            {
                MessageDispatcher.Instance.DispatchMessage(0, this.transform, other.transform, (int)MessagesType.Msg_BeingUpForced_Fall, EntityManager.Instance.GetEntityFromTransform(this.transform), 10f);
                canhit = false;
            }
        }
    }
}

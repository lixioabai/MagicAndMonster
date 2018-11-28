using UnityEngine;
using System.Collections;

public class DelayDeletePoorObject : MonoBehaviour {

    public float DestoryTime = 3f;

	void Update ()
    {
        DestoryTime -= Time.deltaTime;
        if (DestoryTime <= 0)
        {
            ObjectPoor.Instance().Delete(transform.gameObject, Vector3.zero, Quaternion.identity);
            DestoryTime = 3f;
        }

    }
}

using UnityEngine;
using System.Collections;
public class toujicamera : MonoBehaviour {
	public bool istouji=false;
    public float times;
	GameObject cameraweizhi;
    GameObject Playerweizhi;
    Vector3 point;
    bool record = true;
	void Start () {
	}
	void Update () {
        foreach (Transform c in this.transform.parent.GetComponentsInChildren<Transform>())
		{
			if(c.tag=="cameraweizhi")
			{
                cameraweizhi = c.gameObject;
			}
            if(c.tag=="zhujueweizhi")
            {
                Playerweizhi = c.gameObject;
            }
		}
        if(istouji)
        {
            Camera.main.transform.LookAt(Playerweizhi.transform.position);
            if(record)
            {
                StartCoroutine("f1");
                this.transform.parent.GetComponent<CameraMovement>().enabled = false;
                record = false;
            }
            
        }
        else
        {
            record = true;
            StopCoroutine("f1");
            iTween.Pause();
            this.transform.parent.GetComponent<CameraMovement>().enabled = true;
        }
	}
    IEnumerator f1()
    {
        yield return new WaitForSeconds(0.1f);
        iTween.MoveTo(transform.gameObject, iTween.Hash("position", cameraweizhi.transform.position, "time", 1f, "easeType", iTween.EaseType.easeInBack, "looptype", iTween.LoopType.none, "delay", 0f));
        //iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
        yield return new WaitForSeconds(times);
        istouji = false;
        //iTween.MoveTo(transform.gameObject, iTween.Hash("position", point, "time", 1f, "easeType", iTween.EaseType.easeInBack, "looptype", iTween.LoopType.none, "delay", 0f));
    }
}

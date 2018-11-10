using UnityEngine;
using System.Collections;

public class shuzhishengcheng : MonoBehaviour {
	public GameObject uilabel;
	public Vector3 derenweizhi;
	public float shanghai;
	public Color color=Color.red;
	GameObject mylabel;
	public bool ispiao=false;
	void Start () {
	}
		void OnGUI() {
		if(ispiao)
		{
			mylabel=(GameObject)Instantiate(uilabel,transform.position,transform.rotation);
			mylabel.transform.parent=GameObject.FindGameObjectWithTag("UI").transform;
			mylabel.GetComponent<piaoshuzhi>().direnweizhi=new Vector3(derenweizhi.x,derenweizhi.y+1.2f,derenweizhi.z);
			mylabel.GetComponent<piaoshuzhi>().shanghai=shanghai;
			mylabel.GetComponent<piaoshuzhi>().shanghaishuxing=color;
			ispiao=false;
		}
	}
}

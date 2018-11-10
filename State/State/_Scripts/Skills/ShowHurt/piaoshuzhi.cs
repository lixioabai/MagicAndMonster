using UnityEngine;
using System.Collections;

public class piaoshuzhi : MonoBehaviour {
	UILabel mylabel;
	public float shanghai=-1;
	public Color shanghaishuxing;
	public Vector3 direnweizhi;
	float times=1f;
	float distance;
	float scaneValue;
	public Camera c;
	void Start () {
		c=GameObject.FindGameObjectWithTag("uicamera").GetComponent<Camera>();
		mylabel=this.GetComponent<UILabel>();
		distance = Vector3.Distance(direnweizhi,Camera.main.transform.position);
		mylabel.color=shanghaishuxing;
	}
	Vector3 ChangePos(Vector3 point)
	{
		Vector3 point1=Camera.main.WorldToScreenPoint(point);
		Vector3 point2=c.ScreenToWorldPoint(point1);
		point2.z=0;
		return point2;
	}
	void OnGUI () {
		direnweizhi=new Vector3(direnweizhi.x,direnweizhi.y+Time.deltaTime*2f,direnweizhi.z);
		mylabel.color=new Color(mylabel.color.r,mylabel.color.g,mylabel.color.b,mylabel.color.a-Time.deltaTime);
		times-=Time.deltaTime;
		mylabel.text=""+(int)shanghai;
		if(times<=0)
		{
			Destroy(this.gameObject);
		}
		scaneValue = distance/Vector3.Distance(direnweizhi, Camera.main.transform.position);
		mylabel.transform.localScale = Vector3.one * scaneValue;
		mylabel.transform.position = ChangePos(direnweizhi);

	}
}

using UnityEngine;
using System.Collections;

public class piaoshuzhi : MonoBehaviour {

	public float shanghai=-1;
	public Color shanghaishuxing;
	public Vector3 direnweizhi;
	float times=1f;
	float distance;
	float scaneValue;
	public Camera c;
	void Start () {
		c=GameObject.FindGameObjectWithTag("uicamera").GetComponent<Camera>();

		distance = Vector3.Distance(direnweizhi,Camera.main.transform.position);
	
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
		
		times-=Time.deltaTime;
	
		if(times<=0)
		{
			Destroy(this.gameObject);
		}
		scaneValue = distance/Vector3.Distance(direnweizhi, Camera.main.transform.position);
		

	}
}

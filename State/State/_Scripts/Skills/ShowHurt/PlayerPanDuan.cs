using UnityEngine;
using System.Collections;

public class PlayerPanDuan : MonoBehaviour {
	GameObject player;
	public MonoBehaviour donghua;
	public string dongzuo="daiji";
	public TextAsset W_knight_Skill;
	SkillInfo skinfo;

	void Start () {
		player=GameObject.FindGameObjectWithTag("Player");
		skinfo=this.GetComponent<SkillInfo>();
	}


	void Update () {
        if (player.name == "Knight_W")
		{
            //GameObject.FindGameObjectWithTag("Player").GetComponent<nvqishidonghua>().dongzuo=dongzuo;
		}
		if(player.name=="nvfashi")
		{
		}
		if(player.name=="nandashi")
		{
		}
	}
}

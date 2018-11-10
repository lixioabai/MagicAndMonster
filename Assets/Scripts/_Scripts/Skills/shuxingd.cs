using UnityEngine;
using System.Collections;

public class shuxingd : MonoBehaviour {
	shuxing Info;
	void Start () { 
	}
	void Update () {
	}
	public void ShangHaiJiSuan(shuxing enemyshuxing,SkillProperty name,float addState,float keeptime)
	{
		StartCoroutine(State(enemyshuxing,name,addState,keeptime));
	}
	IEnumerator State(shuxing enemyshuxing,SkillProperty name,float addState,float keeptime)
	{
		switch(name)
		{
		case SkillProperty.Attack:
			if(keeptime<=0)
			{
				enemyshuxing.Attack1+=addState;
			}
			else
			{
				enemyshuxing.Attack1+=addState;
				yield return new WaitForSeconds(keeptime);
				enemyshuxing.Attack1-=addState;
			}
			break;
		case SkillProperty.DEF:
			if(keeptime<=0)
			{
				enemyshuxing.DEF1+=addState;
			}
			else
			{
				enemyshuxing.DEF1+=addState;
				yield return new WaitForSeconds(keeptime);
				enemyshuxing.DEF1-=addState;
			}
			break;
		case SkillProperty.Field:
			if(keeptime<=0)
			{
				enemyshuxing.Field1+=addState;
			}
			else
			{
				enemyshuxing.Field1+=addState;
				yield return new WaitForSeconds(keeptime);
				enemyshuxing.Field1-=addState;
			}
			break;
		case SkillProperty.HP:
			if(keeptime<=0)
			{
				enemyshuxing.HP1+=addState;
			}
			else
			{
				enemyshuxing.HP1+=addState;
				yield return new WaitForSeconds(keeptime);
				enemyshuxing.HP1-=addState;
			}
			break;
		case SkillProperty.HPre:
			if(keeptime<=0)
			{
				enemyshuxing.HPre1+=addState;
			}
			else
			{
				enemyshuxing.HPre1+=addState;
				yield return new WaitForSeconds(keeptime);
				enemyshuxing.HPre1-=addState;
			}
			break;
		case SkillProperty.MoveSpeed:
			if(keeptime<=0)
			{
				enemyshuxing.MoveSpeed1+=addState;
			}
			else
			{
				enemyshuxing.MoveSpeed1+=addState;
				yield return new WaitForSeconds(keeptime);
				enemyshuxing.MoveSpeed1-=addState;
			}
			break;
		}
	}
}

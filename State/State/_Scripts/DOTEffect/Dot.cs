using UnityEngine;
using System.Collections;

public enum DOTProperty
{
	MoveSpeed,
	Attack,
	DEF,
	HP
}

public enum Buff
{
	Null,
	Drug,
	Frostbite,
	Burnt,
	Shield,
    SuperArmor
}

public class Dot  {
    public int ID;                          //buffID
	public Buff dot;						//buff类
	public string name;						//buff名
	public float keeptime;					//持续时间
	public float xgz;						//效果值
    public SkillProperty applyProperty;		//buff影响的属性（DEF等）
}

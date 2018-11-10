using UnityEngine;
using System.Collections;

public enum SkillProperty				//技能影响的属性
{
	MoveSpeed,
	DEF,
	Attack,
	Field,
	HP,
	HPre
}

public class Skills  {
	public int ID;						//技能id
    public string iconname;         //图片名
	public string Key;					//技能按键
	public string name;					//技能名
	public float Times;					//冷却
    public float hitnum;                //伤害值
	public Buff buff;					//技能效果（中毒等）
    public SkillProperty applyProperty;	//技能影响的属性（HP等）
    public int fly;                     //击飞高度
    public int weight;					//权重
    public string playername;   //角色名
}

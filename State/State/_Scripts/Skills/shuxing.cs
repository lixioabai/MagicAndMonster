using UnityEngine;
using System.Collections;

public class shuxing : MonoBehaviour {
	void Start () {}
	void Update () {
	}

	private float HP=620f;              //生命
	private float MAXHP=320f;           //最大生命
	private float MP=100f;              //蓝
	private float MAXMP=100f;           //最大蓝值
	private float EXP=0;                //经验
	private float MAXEXP=100f;          //最大经验
	private float Attack=50f;           //攻击力
	private float MAttack=0;            //法术强度
	private float MoveSpeed=1f;         //移动速度
	private float DEF=18f;              //物理防御
	private float RES=30f;              //魔法抗性
	private int LEVEL=1;                //等级
	private float Crit=0;               //暴击概率
	private float MAXCrit=100f;         //最大暴击概率
	private float SBlood=0;             //吸血
	private float MAXSBlood=200f;       //最大吸血值
	private float HPre=5f;              //生命回复（每5秒）
	private float MPre=5f;              //魔法回复（每5秒）
	private float Field=30f;            //视野范围
	private float Money=350f;           //金钱

	public float HP1
	{
		get { return HP; }
		set { HP = value; }
	}
	public float MAXHP1
	{
		get { return MAXHP; }
		set { MAXHP = value; }
	}
	public float MP1
	{
		get { return MP; }
		set { MP = value; }
	}
	public float MAXMP1
	{
		get { return MAXMP; }
		set { MAXMP = value; }
	}
	public float EXP1
	{
		get { return EXP; }
		set { EXP = value; }
	}
	public float MAXEXP1
	{
		get { return MAXEXP; }
		set { MAXEXP = value; }
	}
	public float Attack1
	{
		get { return Attack; }
		set { Attack = value; }
	}
	public float MAttack1
	{
		get { return MAttack; }
		set { MAttack = value; }
	}
	public float MoveSpeed1
	{
		get { return MoveSpeed; }
		set { MoveSpeed = value; }
	}
	public float DEF1
	{
		get { return DEF; }
		set { DEF = value; }
	}
	public float RES1
	{
		get { return RES; }
		set { RES = value; }
	}
	public int LEVEL1
	{
		get { return LEVEL; }
		set { LEVEL = value; }
	}
	public float Crit1
	{
		get { return Crit; }
		set { Crit = value; }
	}
	public float MAXCrit1
	{
		get { return MAXCrit; }
		set { MAXCrit = value; }
	}
	public float SBlood1
	{
		get { return SBlood; }
		set { SBlood = value; }
	}
	public float MAXSBlood1
	{
		get { return MAXSBlood; }
		set { MAXSBlood = value; }
	}
	public float HPre1
	{
		get { return HPre; }
		set { HPre = value; }
	}
	public float MPre1
	{
		get { return MPre; }
		set { MPre = value; }
	}
	public float Field1
	{
		get { return Field; }
		set { Field = value; }
	}
	public float Money1
	{
		get { return Money; }
		set { Money = value; }
	}
}



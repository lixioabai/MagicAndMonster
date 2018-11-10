using UnityEngine;
using System.Collections;

public class DotEffect : MonoBehaviour {

	private shuxingd att;
	private shuxing sx;

	public Buff dote;

    private float Btimes = 0;                   //烧伤持续时间
    private float Dtimes = 0;                   //中毒持续时间
    private float Ftimes = 0;                   //冻伤持续时间
    private float Stimes = 0;                   //护盾持续时间

    private float Btimes1 = 0;                  //烧伤掉血效果触发时间
    private float Dtimes1 = 0;                  //中毒掉血效果出发时间

	void Start () {
		dote=Buff.Null;
		sx=this.GetComponent<shuxing>();
		att=GameObject.FindGameObjectWithTag("Player").GetComponent<shuxingd>();
	}

	void Update () {
		Btimes-=Time.deltaTime;
		Dtimes-=Time.deltaTime;

        if (dote == Buff.Null)
        {
            user(dote);
        }
        else if (dote == Buff.Burnt && Btimes <= 0)
        {
            user(dote);
        }
        else if (dote == Buff.Drug && Dtimes <= 0)
        {
            user(dote);
        }
        else if (dote == Buff.Frostbite && Ftimes <= 0)
        {
            user(dote);
        }
        else if (dote == Buff.Shield && Stimes <= 0)
        {
            user(dote);
        }

        if (Btimes > 0)
        {
            Btimes1 -= Time.deltaTime;
            if (Btimes1 <= 0)
            {
                att.ShangHaiJiSuan(sx,DOTInfo._dotinstance.GetSkillInfoByld(Buff.Burnt).applyProperty,DOTInfo._dotinstance.GetSkillInfoByld(Buff.Burnt).xgz,0);
                Btimes1 = 1f;
            }
        }
        if (Dtimes1 > 0)
        {
            att.ShangHaiJiSuan(sx, DOTInfo._dotinstance.GetSkillInfoByld(Buff.Drug).applyProperty, DOTInfo._dotinstance.GetSkillInfoByld(Buff.Drug).xgz, 0);
        }

	}
	private void user(Buff idd)
	{
		Dot dot1 = null;
		dot1 = DOTInfo._dotinstance.GetSkillInfoByld(idd);
		Dotinfos(dot1);
	}
	private void Dotinfos(Dot dot)
	{
		switch(dot.dot)
		{
		case Buff.Drug:att.ShangHaiJiSuan(sx,dot.applyProperty,dot.xgz,dot.keeptime);
			Dtimes=dot.keeptime;
			break;
		case Buff.Frostbite:att.ShangHaiJiSuan(sx,dot.applyProperty,dot.xgz,dot.keeptime);
			Ftimes=dot.keeptime;
			break;
		case Buff.Burnt:att.ShangHaiJiSuan(sx,dot.applyProperty,dot.xgz,dot.keeptime);
            Btimes = dot.keeptime;
			break;
		case Buff.Shield:att.ShangHaiJiSuan(sx,dot.applyProperty,dot.xgz,dot.keeptime);
			Stimes=dot.keeptime;
			break;
		case Buff.Null:
			break;
		}
	}
}
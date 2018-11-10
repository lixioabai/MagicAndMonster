using UnityEngine;
using System.Collections;
/// <summary>
/// 技能父类
/// </summary>
[System.Serializable]
public class Skill
{

    public string skill_Name;//技能名称
    public MovieTexture skill_Demo;
    public int skill_ID;//技能ID
    public int preSkill_ID;//前置技能ID
    public string skill_Desc;//技能说明
    public Texture2D skill_Icon;//技能图标
    public int skill_level;//当前技能等级
    public int Max_level;//最大技能等级
    public float CoolDown;//技能CD
    public float CurCD;//当前技能CD
    public float PubCD;//公共技能CD
    public float CurPubCD;//当前公共CD
    public int releaseWay;//1为主动技能，0为被动技能，-1为增益技能

    //构造函数
    public Skill(string name, int id, int preid, string desc, int level, int max, float CD, float PCD, int releaseway)
    {
        skill_Name = name;
        skill_Demo = Resources.Load<MovieTexture>("Skill Demo/" + skill_ID.ToString());
        skill_ID = id;
        preSkill_ID = preid;
        skill_Desc = desc;
        skill_Icon = Resources.Load<Texture2D>("Skill Icon/" + skill_ID.ToString());
        skill_level = level;
        Max_level = max;
        CoolDown = CD;
        CurCD = 0;
        PubCD = PCD;
        CurPubCD = 0;
        releaseWay = releaseway;
    }

    //空构造函数
    public Skill()
    {
        skill_ID = -1;
    }

    //深拷贝函数
    public Skill Clone()
    {
        return this.MemberwiseClone() as Skill;
    }

    //施放技能
    public void Puting()
    {
        Debug.Log("施放技能：" + skill_Name);
    }
}

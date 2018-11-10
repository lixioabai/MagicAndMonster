using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 技能数据
/// </summary>
public class SkillDatebase : MonoBehaviour
{

    public List<Skill> skills = new List<Skill>();

    void Start()
    {
        skills.Add(new Skill("冰冻监狱", 0, -1, "形成一个冰冻监狱", 0, 10, 4f, 1f, 1));
        skills.Add(new Skill("冰刃", 1, 6, "发出一个冰刃匕首", 0, 10, 5f, 1f, 1));
        skills.Add(new Skill("冰霜尖刺", 2, 3, "突然出现冰刺", 0, 10, 3f, 1f, 1));
        skills.Add(new Skill("冰息术", 3, 5, "使敌人无法呼吸", 0, 10, 10f, 1f, 1));
        skills.Add(new Skill("冲刺攻击", 4, 1, "移动位移攻击", 0, 10, 10f, 1f, 1));
        skills.Add(new Skill("电网", 5, 0, "电形成的网", 0, 10, 10f, 1f, -1));
        skills.Add(new Skill("法术奥义", 6, 4, "增加人物法术攻击", 0, 10, 0f, 1f, 0));
    }
}

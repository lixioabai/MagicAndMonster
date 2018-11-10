using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 技能框
/// </summary>

public class Skill_UI : MonoBehaviour
{
    public GameObject skillName;//技能名字
    public GameObject movieTexture;//技能动画
    public GameObject skilldescinfo;//技能描述

    public List<Skill> skill = new List<Skill>();//技能链表
    private SkillDatebase datebase;//技能数据库
    public GameObject skillWin;//技能框界面
    public GameObject Tooltip;//技能介绍框
    public bool draggingSkill;//技能是否正被拖拽
    public Skill dragedSkill;//被拖拽的技能
    private bool Show_Skill = false;//是否显示技能框
    public GameObject Temp;//拖拽临时图标

    void Start()
    {
        //初始化技能数据
        datebase = GameObject.Find("Skill_Datebase").GetComponent<SkillDatebase>();
        //初始化技能框界面
        initSkill_UI();

    }

    void Update()
    {
        //是否显示技能框
        if (Input.GetKeyDown(KeyCode.K))
        {
            Show();
        }

        //如果技能正被拖拽
        if (draggingSkill)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //清空技能拖拽
                Clear_Draged();
            }
            Temp.transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
            Temp.GetComponent<UITexture>().mainTexture = dragedSkill.skill_Icon;
        }

        //技能冷却
        skillCD();

        //技能公共冷却
        skillPubCD();
    }

    //技能冷却
    void skillCD()
    {
        for (int i = 0; i < skill.Count; i++)
        {
            if (skill[i].CurCD != 0)
            {
                skill[i].CurCD -= Time.deltaTime;
                if (skill[i].CurCD <= 0)
                {
                    skill[i].CurCD = 0;
                }
            }
        }
    }

    //公共技能冷却
    void skillPubCD()
    {
        for (int i = 0; i < skill.Count; i++)
        {
            if (skill[i].CurPubCD != 0)
            {
                skill[i].CurPubCD -= Time.deltaTime;
                if (skill[i].CurPubCD <= 0)
                {
                    skill[i].CurPubCD = 0;
                }
            }
        }
    }

    //显示技能界面
    public void Show()
    {
        Show_Skill = !Show_Skill;
        if (!Show_Skill)
            Singleton.inventory.showTooltip = false;
        //还原窗口位置
        if (Show_Skill)
        {
            transform.FindChild("Win").position = transform.position;
        }
        skillWin.SetActive(Show_Skill);
        //置顶窗口
        Singleton.UI.UI_Top(skillWin.transform.parent);

    }

    //初始化技能框界面
    void initSkill_UI()
    {
        for (int i = 0; i < datebase.skills.Count; i++)
        {
            //数据添加到skill列表中
            skill.Add(datebase.skills[i]);
            //从资源中载入skill预设体
            GameObject Skill = (GameObject)Instantiate(Resources.Load("skill"));
            //初始化技能格id
            Skill.GetComponent<SkillCell>().skillID = skill[i].skill_ID;
            //添加位置
            Skill.transform.parent = GameObject.Find("skill_UI/Win/ScrollView/UIGrid").transform;
            //本地比例
            Skill.transform.localScale = new Vector3(1, 1, 1);
        }
        //格子内位置重新排列
        GetComponentInChildren<UIGrid>().repositionNow = true;
        GetComponentInChildren<UIScrollView>().Press(true);
        skillWin.SetActive(false);
        draggingSkill = false;

    }

    //清空技能拖拽
    public void Clear_Draged()
    {
        dragedSkill = new Skill();
        draggingSkill = false;
        Temp.GetComponent<UITexture>().mainTexture = null;
    }

    //技能升级
    public void SkillUP(int id)
    {
        if (skill[id].skill_level < skill[id].Max_level)
            skill[id].skill_level++;
    }

    //技能降级
    public void SkillDown(int id)
    {
        if (skill[id].skill_level > 0)
        {
            skill[id].skill_level--;
        }
    }

    //使用技能
    public void UseSkill(ref Skill S)
    {
        if (S.CurCD == 0 && S.CurPubCD == 0)
        {
            //施放技能
            S.Puting();
            //设置冷却时间
            S.CurCD = S.CoolDown;
        }
    }

    public void UsePubSkill(ref Skill S)
    {
        if (S.CurPubCD == 0/* && S.CurCD == 0*/)
        {
            S.CurPubCD = S.PubCD;
        }
    }

    //寻找技能框是否有该id的技能,若有则返回技能框ID号,否则返回-1
    public int GetSkillID(int id)
    {
        for (int i = 0; i < skill.Count; i++)
        {
            if (skill[i].skill_ID == id)
            {
                return i;
            }
        }
        return -1;
    }

    //显示技能介绍
    public void Show_Tooltip(int id)
    {
        //判断是否是被动技能
        if (skill[id].CoolDown == 0)
        {
            Tooltip.GetComponentInChildren<UILabel>().text =
                "[FF0000]名称 :[-] [99ff00][被动][-]" + skill[id].skill_Name + "\n\n" +
                "[FF0000]说明 :[-] " + skill[id].skill_Desc + "\n\n" +
                "[FF0000]下一级技能说明 :[-] " + skill[id].skill_Desc + "\n\n" +
                "[FF0000]技能等级 :[-] " + skill[id].skill_level;
            Tooltip.GetComponentInChildren<UILabel>().SetDimensions(164, 28);
        }
        else
        {
            Tooltip.GetComponentInChildren<UILabel>().text =
                "[FF0000]名称 :[-] " + skill[id].skill_Name + "\n\n" +
                "[FF0000]说明 :[-] " + skill[id].skill_Desc + "\n\n" +
                "[FF0000]下一级技能说明 :[-] " + skill[id].skill_Desc + "\n\n" +
                "[FF0000]技能等级 :[-] " + skill[id].skill_level;
            Tooltip.GetComponentInChildren<UILabel>().SetDimensions(164, 28);
        }

    }

    //交换技能
    public void ChangeSkill(ref Skill skill1, ref Skill skill2)
    {
        Skill skill = new Skill();
        skill = skill1;
        skill1 = skill2;
        skill2 = skill;
    }

    //技能描述信息
    public void GetSkillDescInfo(int id)
    {

        skillName.GetComponent<UILabel>().text =
            "[E4C543FF] [-]" + Singleton.skillUI.skill[id].skill_Name;

        movieTexture.GetComponent<UITexture>().mainTexture = Singleton.skillUI.skill[id].skill_Demo;

        int preskillID = Singleton.skillUI.skill[id].preSkill_ID;

        if (Singleton.skillUI.skill[id].releaseWay == 1)
        {
            if (Singleton.skillUI.skill[id].preSkill_ID < 0)
            {
                skilldescinfo.GetComponent<UILabel>().text =
                    "学习等级：" + "[48F15FFF] [-]" + Singleton.skillUI.skill[id].skill_level + "\n\n" +
                    "前置技能：无" + "\n\n" +
                    "释放方式：" + "[48F15FFF] 主动 [-]" + "\n\n" +
                    "冷却时间：" + Singleton.skillUI.skill[id].CoolDown + "\n\n" +
                    "技能效果：" + Singleton.skillUI.skill[id].skill_Desc + "\n\n" +
                    "下一级技能效果：" + Singleton.skillUI.skill[id].skill_Desc;
            }
            else
            {
                skilldescinfo.GetComponent<UILabel>().text =
                    "学习等级：" + "[48F15FFF] [-]" + Singleton.skillUI.skill[id].skill_level + "\n\n" +
                    "前置技能：" + Singleton.skillUI.skill[preskillID].skill_Name + "\n\n" +
                    "释放方式：" + "[48F15FFF] 主动 [-]" + "\n\n" +
                    "冷却时间：" + Singleton.skillUI.skill[id].CoolDown + "\n\n" +
                    "技能效果：" + Singleton.skillUI.skill[id].skill_Desc + "\n\n" +
                    "下一级技能效果：" + Singleton.skillUI.skill[id].skill_Desc;
            }

        }
        else if (Singleton.skillUI.skill[id].releaseWay == 0)
        {
            if (Singleton.skillUI.skill[id].preSkill_ID < 0)
            {
                skilldescinfo.GetComponent<UILabel>().text =
                    "学习等级：" + "[48F15FFF] [-]" + Singleton.skillUI.skill[id].skill_level + "\n\n" +
                    "前置技能：无" + "\n\n" +
                    "释放方式：" + "[48F15FFF] 被动 [-]" + "\n\n" +
                    "技能效果：" + Singleton.skillUI.skill[id].skill_Desc + "\n\n" +
                    "下一级技能效果：" + Singleton.skillUI.skill[id].skill_Desc;
            }
            else
            {
                skilldescinfo.GetComponent<UILabel>().text =
                    "学习等级：" + "[48F15FFF] [-]" + Singleton.skillUI.skill[id].skill_level + "\n\n" +
                    "前置技能：" + Singleton.skillUI.skill[preskillID].skill_Name + "\n\n" +
                    "释放方式：" + "[48F15FFF] 被动 [-]" + "\n\n" +
                    "技能效果：" + Singleton.skillUI.skill[id].skill_Desc + "\n\n" +
                    "下一级技能效果：" + Singleton.skillUI.skill[id].skill_Desc;
            }
        }
        else if (Singleton.skillUI.skill[id].releaseWay == -1)
        {
            if (Singleton.skillUI.skill[id].preSkill_ID < 0)
            {
                skilldescinfo.GetComponent<UILabel>().text =
                    "学习等级：" + "[48F15FFF] [-]" + Singleton.skillUI.skill[id].skill_level + "\n\n" +
                    "前置技能：无" + "\n\n" +
                    "释放方式：" + "[48F15FFF] 增益 [-]" + "\n\n" +
                    "冷却时间：" + Singleton.skillUI.skill[id].CoolDown + "\n\n" +
                    "技能效果：" + Singleton.skillUI.skill[id].skill_Desc + "\n\n" +
                    "下一级技能效果：" + Singleton.skillUI.skill[id].skill_Desc;
            }
            else
            {
                skilldescinfo.GetComponent<UILabel>().text =
                    "学习等级：" + "[48F15FFF] [-]" + Singleton.skillUI.skill[id].skill_level + "\n\n" +
                    "前置技能：" + Singleton.skillUI.skill[preskillID].skill_Name + "\n\n" +
                    "释放方式：" + "[48F15FFF] 增益 [-]" + "\n\n" +
                    "冷却时间：" + Singleton.skillUI.skill[id].CoolDown + "\n\n" +
                    "技能效果：" + Singleton.skillUI.skill[id].skill_Desc + "\n\n" +
                    "下一级技能效果：" + Singleton.skillUI.skill[id].skill_Desc;
            }
        }

    }

    //保存技能数据
    public void OnAppClick()
    {
        for (int i = 0; i < skill.Count; i++)
        {
            //保存技能等级
            PlayerPrefs.SetInt("Skill Level" + i, skill[i].skill_level);
        }
    }

    //加载技能数据
    public void OnInitClick()
    {
        for (int i = 0; i < skill.Count; i++)
        {
            //加载技能等级
            skill[i].skill_level = PlayerPrefs.GetInt("Skill Level" + i);
        }
    }

}

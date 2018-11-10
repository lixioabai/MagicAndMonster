using UnityEngine;
using System.Collections;
/// <summary>
/// 技能槽
/// </summary>
public class SkillCell : MonoBehaviour
{

    public GameObject Icon;//技能图标
    public GameObject Level;//技能等级
    public GameObject Name;//技能名称
    public GameObject skillLV;//等级显示
    public int skillID;//技能槽ID号

    void Update()
    {
        //显示数据
        Icon.GetComponent<UITexture>().mainTexture = Singleton.skillUI.skill[skillID].skill_Icon;
        Level.GetComponent<UILabel>().text = "LV" + Singleton.skillUI.skill[skillID].skill_level.ToString();
        Name.GetComponent<UILabel>().text = Singleton.skillUI.skill[skillID].skill_Name;
        if (skillID == 0)
        {
            skillLV.GetComponent<UILabel>().text = "LV1";
        }
        else
        {
            skillLV.GetComponent<UILabel>().text = "LV" + (skillID * 10).ToString();
        }
    }

    void OnPress()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //不在拖拽状态中
            if (!Singleton.inventory.draggingItem && !Singleton.key.draggingKey)
            {
                //判断该图标是否是被动技能
                if (Singleton.skillUI.skill[skillID].CoolDown > 0)
                {
                    Singleton.skillUI.draggingSkill = true;
                    Singleton.skillUI.dragedSkill = Singleton.skillUI.skill[skillID];
                }
            }

            //得到技能信息
            Singleton.skillUI.GetSkillDescInfo(skillID);
        }
//         if (Input.GetMouseButtonDown(1))
//         {
//             //得到技能信息
//             Singleton.skillUI.GetSkillDescInfo(skillID);
//         }

    }

    //鼠标经过技能框
    void OnHover(bool isOver)
    {
        if (isOver)
        {
            Singleton.skillUI.Show_Tooltip(skillID);
            Singleton.inventory.showTooltip = true;
        }
        else
        {
            Singleton.inventory.showTooltip = false;
        }
    }

}

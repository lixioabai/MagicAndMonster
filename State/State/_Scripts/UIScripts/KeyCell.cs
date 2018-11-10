using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 快捷按钮
/// </summary>
public class KeyCell : MonoBehaviour
{

    public GameObject Icon;//快捷键图标
    public GameObject CoolDown;//冷却时间
    public GameObject count;//物品数量
    public item keyItem;//快捷物品
    public Skill keySkill;//快捷技能
    public int KeyItemID;//快捷键物品背包的ID号

    void Start()
    {
        KeyItemID = -1;
    }

    void Update()
    {
        //显示
        Show_Date();

        //快捷键操作
        UseKey();

        //快捷键冷却图标
        Icon_CoolDown();
    }

    //快捷键冷却图标
    void Icon_CoolDown()
    {
        if (keySkill.skill_ID != -1)
        {
            if (keySkill.CurCD != 0/* && keySkill.CurPubCD != 0*/)
            {
                //图标冷却显示
                Icon.GetComponentInChildren<UISprite>().fillAmount = keySkill.CurCD / keySkill.CoolDown;

                if (keySkill.CoolDown > 10)
                {
                    if (keySkill.CoolDown * (keySkill.CurCD / keySkill.CoolDown) < 10)
                    {
                        CoolDown.GetComponentInChildren<UILabel>().text = (keySkill.CoolDown * (keySkill.CurCD / keySkill.CoolDown)).ToString("#0.0");
                    }
                    else
                    {
                        CoolDown.GetComponentInChildren<UILabel>().text = (keySkill.CoolDown * (keySkill.CurCD / keySkill.CoolDown)).ToString("#0");
                    }
                }
                else
                {
                    CoolDown.GetComponentInChildren<UILabel>().text = (keySkill.CoolDown * (keySkill.CurCD / keySkill.CoolDown)).ToString("#0.0");
                }
            }
            else if (keySkill.PubCD != 0/* && keySkill.CurCD == 0*/)
            {
                //公共技能冷却显示
                Icon.GetComponentInChildren<UISprite>().fillAmount = keySkill.CurPubCD / keySkill.PubCD;
            }
            else
            {
                Icon.GetComponentInChildren<UISprite>().fillAmount = 0;
            }

        }
        else
        {
            //清除图标冷却
            Icon.GetComponentInChildren<UISprite>().fillAmount = 0;
        }

    }

    //判断是否按下快捷键
    void UseKey()
    {
        if (Input.GetKeyDown(name.ToLower()))
        {
            if (keyItem.itemID != -1)
            {
                Singleton.inventory.UseItem(KeyItemID);
            }
            else if (keySkill.skill_ID != -1)
            {
                Singleton.skillUI.UseSkill(ref keySkill);
            }
        }
        //公共冷却时间
        else if ((Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.F4)
             || Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.F6) || Input.GetKeyDown(KeyCode.F7) || Input.GetKeyDown(KeyCode.F8)
             || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.V)
             || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Alpha1)
             || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5)
             || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha9)))
        {
            Singleton.skillUI.UsePubSkill(ref keySkill);

            //GameObject[] key = GameObject.FindGameObjectsWithTag("Key");
            //foreach (GameObject key1 in key)
            //{
            //    if (key1.GetComponent<KeyCell>().keySkill.skill_ID != -1)
            //    {
            //        print("0000000");
            //    }
            //    else
            //    {
            //        //Singleton.skillUI.UsePubSkill(ref keySkill);
            //    }
            //}
        }

    }

    //显示图标及数量
    void Show_Date()
    {
        if (keyItem.itemIcon != null)
        {
            //显示快捷物品图标
            Icon.GetComponent<UITexture>().mainTexture = keyItem.itemIcon;
        }
        else if (keySkill.skill_Icon != null)
        {
            //显示快捷技能图标
            Icon.GetComponent<UITexture>().mainTexture = keySkill.skill_Icon;
        }
        else
        {
            Icon.GetComponent<UITexture>().mainTexture = null;
        }

        if (keyItem.itemNum != 0)
        {
            //显示物品数量
            count.GetComponent<UILabel>().text = keyItem.itemNum.ToString();
        }
        else
        {
            count.GetComponent<UILabel>().text = null;
            CoolDown.GetComponent<UILabel>().text = null;
        }
    }

    //鼠标事件
    void OnPress()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (keyItem.itemID != -1)
            {
                Singleton.inventory.UseItem(KeyItemID);
            }
            else if (keySkill.skill_ID != -1)
            {
                Singleton.skillUI.UseSkill(ref keySkill);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            //物品正在拖拽时
            if (Singleton.inventory.draggingItem)
            {
                //拖拽物必须为消耗品才可以设置快捷键
                if (Singleton.inventory.dragedItem.itemType == item.ItemType.Potion)
                {
                    //清除该物品之前的快捷键
                    Singleton.key.Clear_ItemKey(Singleton.inventory.dragedItem);
                    keyItem = Singleton.inventory.dragedItem;
                    KeyItemID = Singleton.inventory.dragedID;
                    Singleton.inventory.BackItem();

                    //清空快捷技能
                    keySkill = new Skill();
                }
            }

            //如果拖拽图标是技能
            else if (Singleton.skillUI.draggingSkill)
            {
                //交换技能
                Singleton.skillUI.ChangeSkill(ref keySkill, ref Singleton.skillUI.dragedSkill);
                //清空该技能之前的快捷键
                //Singleton.key.Clear_SkillKey(Singleton.skillUI.dragedSkill);

                //keySkill = Singleton.skillUI.dragedSkill;

                ////清空技能拖拽
                //Singleton.skillUI.Clear_Draged();

                //清空快捷物品
                KeyItemID = -1;
                keyItem = new item();

            }
            //如果拖拽的是快捷键
            else if (Singleton.key.draggingKey)
            {
                keyItem = Singleton.inventory.dragedItem;
                KeyItemID = Singleton.inventory.dragedID;
                //清空拖拽
                Singleton.inventory.Clear_dragedItem();

                keySkill = new Skill();

            }
            else
            {
                if (keyItem.itemID != -1)
                {
                    //设置拖拽物
                    Singleton.inventory.dragedItem = keyItem;
                    Singleton.inventory.dragedID = KeyItemID;
                    KeyItemID = -1;
                    keyItem = new item();
                    //快捷键被拖拽
                    Singleton.key.draggingKey = true;
                }
                else if (keySkill.skill_ID != -1)
                {
                    Singleton.skillUI.dragedSkill = keySkill;
                    Singleton.skillUI.draggingSkill = true;
                    keySkill = new Skill();
                }
            }
        }
    }

    //鼠标放上去提示信息
    void OnHover(bool isOver)
    {
        if (isOver && (keyItem.itemID != -1 || keySkill.skill_ID != -1))
        {
            if (keyItem.itemID != -1)
            {
                Singleton.inventory.Show_Tooltip(Singleton.inventory.inventory[keyItem.itemID]);
            }
            else if (keySkill.skill_ID != -1)
            {
                Singleton.skillUI.Show_Tooltip(keySkill.skill_ID);
            }
            Singleton.inventory.showTooltip = true;
        }
        else
        {
            Singleton.inventory.showTooltip = false;
        }
    }

}

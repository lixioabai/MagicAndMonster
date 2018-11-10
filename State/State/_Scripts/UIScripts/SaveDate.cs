using UnityEngine;
using System.Collections;
/// <summary>
/// 数据存储
/// </summary>
public class SaveDate : MonoBehaviour
{

    void OnGUI()
    {
        //if(GUI.Button(new Rect(40,150,100,40),"Save"))
        //    Save();
        //if(GUI.Button(new Rect(40,200,100,40),"Load"))
        //    Load();
        //    

        //if (GUI.Button(new Rect(1050, 520, 120, 40), "技能K,背包I" + "\n" + "装备E,任务T")){}

    }
    //保存数据
    void Save()
    {
        Singleton.inventory.SaveInventory();
        Singleton.equip.SaveEquipment();
        Singleton.key.SaveKey();
        Singleton.skillUI.OnAppClick();
        Singleton.money.SaveMoney();
    }
    //加载数据
    void Load()
    {
        //清空拖拽物
        Singleton.inventory.Clear_dragedItem();

        Singleton.inventory.LoadInventory();
        Singleton.equip.LoadEquipment();
        Singleton.key.LoadKey();
        Singleton.skillUI.OnInitClick();
        Singleton.money.LoadMoney();
    }
}

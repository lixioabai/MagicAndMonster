using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 装备栏管理
/// </summary>
public class Equip_Manager : MonoBehaviour
{

    public GameObject EquipUI;//装备栏UI
    public GameObject Temp;//被拖拽的临时UI
    private bool showEquipment = false;//是否显示装备栏
    public List<item> Equip = new List<item>();//定义装备栏线性表
    public bool is_draged;

    void Start()
    {
        is_draged = false;
        //初始化
        initEuip();
    }

    void Update()
    {
        //是否按下装备按钮
        if (Input.GetKeyDown(KeyCode.E))
        {
            Show();
        }
    }

    //显示装备栏
    public void Show()
    {
        showEquipment = !showEquipment;
        if (!showEquipment)
            Singleton.inventory.showTooltip = false;
        //还原窗口位置
        if (showEquipment)
        {
            EquipUI.transform.FindChild("Win").position = EquipUI.transform.position;
        }

        EquipUI.SetActive(showEquipment);
        //置顶窗口
        Singleton.UI.UI_Top(EquipUI.transform);
    }

    //初始化装备栏
    void initEuip()
    {
        for (int i = 0; i < 13; i++)
        {
            Equip.Add(new item());
        }
        EquipUI.SetActive(showEquipment);
    }

    //保存装备栏
    public void SaveEquipment()
    {
        for (int i = 0; i < Equip.Count; i++)
        {
            PlayerPrefs.SetInt("Equip" + i, Equip[i].itemID);
        }
    }

    //加载装备栏
    public void LoadEquipment()
    {
        for (int i = 0; i < Equip.Count; i++)
        {
            Equip[i] = PlayerPrefs.GetInt("Equip" + i, -1) >= 0 ? Singleton.inventory.datebase.items[PlayerPrefs.GetInt("Equip" + i)] : new item();
        }
    }

    //返回装备按钮ID号
    public int GetEquipID(string name)
    {
        int n = 0;
        switch (name)
        {
            case "MainHandWeapon":
                n = 0;
                break;
            case "OffHandWeapon":
                n = 1;
                break;
            case "Casque":
                n = 2;
                break;
            case "Clothing":
                n = 3;
                break;
            case "Wrister":
                n = 4;
                break;
            case "Necklace":
                n = 5;
                break;
            case "Ring":
                n = 6;
                break;
            case "Erring":
                n = 7;
                break;
            case "Shoes":
                n = 8;
                break;
            case "Trousers":
                n = 9;
                break;

            default:
                n = -1;
                break;
        }
        return n;
    }

}

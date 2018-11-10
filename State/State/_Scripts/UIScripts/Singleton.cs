using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{

    public static Inventory_Manager inventory;//背包
    public static Equip_Manager equip;//装备栏
    public static Key key;//快捷键
    public static Skill_UI skillUI;//技能框
    public static Task_UI taskUI;//任务框
    public static Money money;//金钱
    public static UI_Manager UI;//UI管理
    public static KeyControl keyControl;
    //public static MiniMap nimimMap;//小地图
    //public static BossBlood bossBlood;//Boss血条
    //public static TeamMates teamMates;//队友


    void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory_Manager>();
        equip = GameObject.Find("Equipment").GetComponent<Equip_Manager>();
        key = GameObject.Find("short cut/Key").GetComponent<Key>();
        skillUI = GameObject.Find("skill_UI").GetComponent<Skill_UI>();
        taskUI = GameObject.Find("task_UI").GetComponent<Task_UI>();
        money = GameObject.Find("inventory/Win/money").GetComponent<Money>();
        UI = GameObject.Find("UI Root").GetComponent<UI_Manager>();
        keyControl = GameObject.Find("short cut").GetComponent<KeyControl>();
        //nimimMap = GameObject.Find("MiniMap").GetComponent<MiniMap>();
        //bossBlood = GameObject.Find("BossBlood").GetComponent<BossBlood>();
        //teamMates = GameObject.Find("TeamMates").GetComponent<TeamMates>();
    }

}

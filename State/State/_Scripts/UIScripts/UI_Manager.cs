using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_Manager : MonoBehaviour
{
    private Transform equipment;//装备框
    private Transform inventory;//背包框
    private Transform short_cut;//快捷键框
    private Transform skill;//技能框
    private Transform task;//任务框
    private Transform temp;//拖拽图标
    private Transform tooltip;//信息框
    private List<Transform> UI = new List<Transform>();

    private bool menu = false;

    void Start()
    {
        equipment = transform.FindChild("equipment");
        inventory = transform.FindChild("inventory");
        task = transform.FindChild("task_UI");
        skill = transform.FindChild("skill_UI");
        short_cut = transform.FindChild("short cut");
        temp = transform.FindChild("Temp");
        tooltip = transform.FindChild("Tooltip");

        //初始化UI位置
        UI.Add(equipment);
        UI.Add(inventory);
        UI.Add(skill);
        UI.Add(task);

        //初始化UI顺序及UI事件
        for (int i = 0; i < UI.Count; i++)
        {
            SetDepth(UI[i], i + 1);
            UI_Event(UI[i]);
        }

        Singleton.taskUI.taskWin.SetActive(false);

        //Screen.lockCursor = true;
    }

    ////鼠标双击
    //void OnGUI()
    //{
    //    Event mouse = Event.current;
    //    if (mouse.isMouse && mouse.type == EventType.MouseDown && mouse.clickCount == 2)
    //    {
    //        print("Double Click!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    //    }
    //}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("UI_Manager:按键Escape");

            //if (!Singleton.inventory.showTooltip)
            //{
            //    Singleton.skillUI.skillWin.SetActive(false);
            //    Singleton.taskUI.taskWin.SetActive(false);
            //    Singleton.inventory.InventoryUI.SetActive(false);
            //}
            //OnOffMenu();
        }
    }

    //鼠标光标锁定。这里只是写着玩玩
    void OnOffMenu()
    {
        if (!menu && Time.timeScale != 0.0f)
        {
            menu = true;
            Time.timeScale = 0.0f;
            Screen.lockCursor = false;
        }
        else if (menu)
        {
            menu = false;
            Time.timeScale = 1.0f;
            Screen.lockCursor = true;
        }

    }

    //设置UI顺序
    void UIOrder()
    {
        for (int i = 0; i < UI.Count; i++)
        {
            SetDepth(UI[i], i);
        }
    }

    //UI单击事件
    void UI_Click(GameObject ui, bool isPress)
    {
        if (Input.GetMouseButtonDown(0))
        {
            UI_Top(ui.transform.parent.parent);
        }
    }

    //UI置顶
    public void UI_Top(Transform ui)
    {
        for (int i = 0; i < UI.Count; i++)
        {
            if (UI[i] == ui)
            {
                UI.Add(UI[i]);
                UI.RemoveAt(i);
                UIOrder();
                break;
            }
        }

    }
    //UI事件
    void UI_Event(Transform ui)
    {
        GameObject BG = GameObject.Find(ui.name + "/Win/BG");
        UIEventListener.Get(BG).onPress = UI_Click;
    }

    //设置UI深度
    void SetDepth(Transform ui, int depth)
    {
        if (ui.name == "skill_UI" || ui.name == "task_UI" || ui.name == "inventory")
        {
            ui.Find("Win/ScrollView").GetComponent<UIPanel>().depth = depth;
        }
        
        ui.Find("Win").GetComponent<UIPanel>().depth = depth;
    }

    //获取UI深度
    int GetDepth(Transform ui)
    {
        return ui.GetComponentInChildren<UIPanel>().depth;
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 任务框
/// </summary>

public class Task_UI : MonoBehaviour
{
    public GameObject taskname;//任务名
    public GameObject taskdesc;//任务描述

    public List<Task> task = new List<Task>();//任务链表
    private TaskDatebase datebase;//任务数据
    public GameObject taskWin;//任务界面
    public GameObject ToopTip;//任务介绍框
    private bool Show_Task = false;//是否显示任务框

    void Start()
    {
        //初始化任务数据
        datebase = GameObject.Find("Task_Datebase").GetComponent<TaskDatebase>();
        //初始化任务框界面
        initTask_UI();
    }

    void Update()
    {
        //显示任务界面快捷键
        if (Input.GetKeyDown(KeyCode.T))
        {
            Show();
        }
    }

    //显示任务界面
    public void Show()
    {
        Show_Task = !Show_Task;
        if (!Show_Task)
            Singleton.inventory.showTooltip = false;
        //还原窗口位置
        if (Show_Task)
        {
            transform.FindChild("Win").position = transform.position;
        }
        taskWin.SetActive(Show_Task);
        //置顶窗口
        Singleton.UI.UI_Top(taskWin.transform.parent);
    }

    //初始化
    void initTask_UI()
    {
        for (int i = 0; i < datebase.tasks.Count; i++)
        {
            task.Add(datebase.tasks[i]);//从任务数据中添加任务
            GameObject Task = (GameObject)Instantiate(Resources.Load("task"));//加载任务的预设
            Task.GetComponent<TaskCell>().taskID = i;//设置任务的id
            Task.transform.parent = GameObject.Find("task_UI/Win/ScrollView/UIGrid").transform;//任务添加到的位置
            Task.transform.localScale = new Vector3(1, 1, 1);
        }

        GetComponentInChildren<UIGrid>().repositionNow = true;
        GetComponentInChildren<UIScrollView>().Press(true);
        //taskWin.SetActive(false);
    }

    //显示任务介绍
    public void Show_Tooptip(int id)
    {
        //ToopTip.GetComponentInChildren<UILabel>().text = "[FF0000]名称 :[-]" + task[id].task_Name + "\n\n" + "[FF0000]描述 : [-]" + task[id].task_Des;
        if (task[id].task_Type == 0)
        {
            ToopTip.GetComponentInChildren<UILabel>().text = "[FF0000]名称 :[-] [99ff00][主线][-]" + task[id].task_Name + "\n\n" + "[FF0000]描述 : [-]" + task[id].task_Des;
        }
        else
        {
            ToopTip.GetComponentInChildren<UILabel>().text = "[FF0000]名称 :[-] [99ff00][支线][-]" + task[id].task_Name + "\n\n" + "[FF0000]描述 : [-]" + task[id].task_Des;
        }
    }

    //得到描述信息
    public void GetTaskInfoDesc(int id)
    {
        taskname.GetComponent<UILabel>().text = Singleton.taskUI.task[id].task_Name;
        taskdesc.GetComponent<UILabel>().text = Singleton.taskUI.task[id].task_Des;
    }

    //放弃任务
    public void OnGiveUpTaskBtnClick()
    {
        Debug.Log("放弃任务！");
    }

    //接受任务
    public void AcceptTask(int id)
    {
        Debug.Log("接受任务！");
    }
    //显示任务奖励
    public void Show_Reward()
    {
        Debug.Log("奖励");
    }

    //保存任务
    public void SaveTask()
    {
        for (int i = 0; i < task.Count; i++ )
        {
            PlayerPrefs.SetInt("Task" + i, task[i].task_ID);
        }
    }

    //加载任务
    public void LoadTask()
    {
        for (int i = 0; i < task.Count; i++ )
        {
            task[i] = PlayerPrefs.GetInt("Task" + i, -1) >= 0 ? Singleton.taskUI.datebase.tasks[PlayerPrefs.GetInt("Task") + i] : new Task();
        }
    }

}

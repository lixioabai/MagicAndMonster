using UnityEngine;
using System.Collections;

/// <summary>
/// 任务
/// </summary>

public class TaskCell : MonoBehaviour
{
    public GameObject backGroundOne;//主线任务背景图
    public GameObject backGroundTwo;//支线任务背景图
    public GameObject task;//任务
    public UIGrid grid;

    public GameObject type;//类型（主线、支线任务）
    public GameObject name;//任务名
    public int taskID;

    void Start()
    {
        grid = GameObject.Find("UIGrid").GetComponent<UIGrid>();
    }

    void Update()
    {
        //初始化
        initTaskCell();
    }

    //初始化
    void initTaskCell()
    {
        //判断主线支线任务，如果是主线任务显示主线背景图，如果是支线任务显示支线背景图
        if (Singleton.taskUI.task[taskID].task_Type == 0)
        {
            backGroundOne.gameObject.SetActive(true);
            backGroundTwo.gameObject.SetActive(false);
            //得到任务的名字和主线（支线）
            type.GetComponent<UILabel>().text = "主线";
            name.GetComponent<UILabel>().text = Singleton.taskUI.task[taskID].task_Name;
        }
        else if (Singleton.taskUI.task[taskID].task_Type == 1)
        {
            backGroundOne.gameObject.SetActive(false);
            backGroundTwo.gameObject.SetActive(true);

            //得到任务的名字和主线（支线）
            type.GetComponent<UILabel>().text = "支线";
            name.GetComponent<UILabel>().text = Singleton.taskUI.task[taskID].task_Name;
        }

    }

    void OnPress()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("-------------------------------------------------");
        //}
    }

    void OnHover(bool isOver)
    {
        if (isOver)
        {
            Singleton.taskUI.Show_Tooptip(taskID);
            Singleton.inventory.showTooltip = true;
        }
        else
        {
            Singleton.inventory.showTooltip = false;
        }
    }

    //得到任务信息
    public void GetTaskInformation()
    {
        Singleton.taskUI.GetTaskInfoDesc(taskID);
        Singleton.taskUI.AcceptTask(taskID);
        Singleton.taskUI.Show_Reward();
        if (Singleton.taskUI.task[taskID].task_Type == 1)
        {
            //删除任务
            //Destroy(task);
            //隐藏任务
            task.gameObject.SetActive(false);
            //重新排列
            grid.repositionNow = true;
        }
    }

}

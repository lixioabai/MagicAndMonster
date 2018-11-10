using UnityEngine;
using System.Collections;

/// <summary>
/// 任务父类
/// </summary>

[System.Serializable]
public class Task
{
    public string task_Name;//任务名称
    public int task_ID;//任务ID
    public string task_Des;//任务描述
    public int task_Type;//主线、支线

    //构造函数
    public Task(string name, int id, string des, int type)
    {
        task_Name = name;
        task_ID = id;
        task_Des = des;
        task_Type = type;
    }

    //空构造函数
    public Task()
    {
        task_ID = -1;
    }

    //深拷贝构造函数
    public Task Clone()
    {
        return this.MemberwiseClone() as Task;
    }

    public void Putting()
    {
        Debug.Log("任务：" + task_Name);
    }

}

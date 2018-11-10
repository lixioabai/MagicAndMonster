using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 任务数据
/// </summary>

public class TaskDatebase : MonoBehaviour
{

    public List<Task> tasks = new List<Task>();

    void Start()
    {
        tasks.Add(new Task("任务0", 0, "这是主线任务描述00000000000000000000000000000000", 0));
        tasks.Add(new Task("任务1", 1, "这是主线任务描述1111111111111111111", 0));
        tasks.Add(new Task("任务2", 2, "这是支线任务描述111111111111111111111111111111111111", 1));
        tasks.Add(new Task("任务3", 3, "这是支线任务描述2222222222222222", 1));
        tasks.Add(new Task("任务4", 4, "这是支线任务描述3333333333333333333333", 1));
        tasks.Add(new Task("任务5", 5, "这是支线任务描述44444444444444", 1));
        tasks.Add(new Task("任务6", 6, "这是支线任务描述5555555555555555555555555555555555555555555555555555", 1));
        tasks.Add(new Task("任务7", 7, "然而没什么用描述222222222222222222222222222", 0));
        tasks.Add(new Task("任务8", 8, "这是支线任务描述66666666666666666666", 1));
        tasks.Add(new Task("任务9", 9, "这是支线任务描述7", 1));
        tasks.Add(new Task("任务10", 10, "这是支线任务描述88888888888888888888888888888888888888888888888", 1));
        tasks.Add(new Task("任务11", 11, "这是支线任务描述999999999999999999999999999999", 1));
        tasks.Add(new Task("任务12", 12, "这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述这是支线任务描述10", 1));
    }

}

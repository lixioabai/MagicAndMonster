using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        // 游戏的每一帧都会执行一次延迟消息队列检测
        // 该类需要挂在某个物体上，最好是摄像机
        MessageDispatcher.Instance.DispatchDelayedMessage();
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 所有游戏对象的基类
/// </summary>
public class BaseGameEntity : MonoBehaviour
{
    // 用Transfrom充当标识符
    private Transform _myTransform;
    private static List<Transform> myTransList = new List<Transform>();
    public Transform myTransform { get { return _myTransform; } }

    protected void setTransform(Transform val)
    {
        if (myTransList.Contains(val))
        {
            Debug.LogError("Already contains transform: " + val);
            return;
        }

        myTransList.Add(val);
        _myTransform = val;
    }

    public virtual bool HandleMessage(Telegram telegram)
    {
        return false;
    }
}

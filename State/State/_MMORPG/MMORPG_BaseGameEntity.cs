using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 所有游戏对象的基类
/// </summary>
public class MMORPG_BaseGameEntity : MonoBehaviour {

    /// <summary>
    /// 游戏对象的唯一标识
    /// </summary>
    private Transform m_Transform;
    private static List<Transform> m_GameEntity_TransformList = new List<Transform>();
    public Transform M_Transform { get { return m_Transform; } }

    protected void SetTransform(Transform val)
    {
        if (m_GameEntity_TransformList.Contains(val))
        {
            Debug.LogError("there is already contains transfrom :"+val);
            return;
        }
        m_GameEntity_TransformList.Add(val);
        m_Transform = val;
    }

    public virtual bool HandleMessage(Telegram telegram)
    {
        return false;
    }
}

using UnityEngine;
using System.Collections;


/// <summary>
/// 减益Buff基类
/// </summary>
public class MMORPG_BaseDeBuff : MonoBehaviour {

    /// <summary>
    /// BUFF归属
    /// </summary>
    protected MMORPG_BaseObject m_Owner;

    /// <summary>
    /// Buff 持续时间
    /// </summary>
    public float m_Time;


    /// <summary>
    /// Buff类型
    /// </summary>
    protected EnumDefine.DeBuffType m_DebuffType;

    /// <summary>
    /// buff减益数值
    /// </summary>
    protected float m_Value;

    /// <summary>
    /// 获得buff类型
    /// </summary>
    /// <returns></returns>
    public EnumDefine.DeBuffType GetDeBuffType()
    {
        return m_DebuffType;

    }

    /// <summary>
    /// 获得增益数值
    /// </summary>
    /// <returns></returns>
    public float GetValue()
    {
        return m_Value;
    }

    /// <summary>
    /// 获得本类实例
    /// </summary>
    /// <returns></returns>
    public static MMORPG_BaseDeBuff GetInstance(EnumDefine.DeBuffType type)
    {
        switch (type)
        {
            case EnumDefine.DeBuffType.Ice:
                return new MMORPG_DeBuff_Ice();
            case EnumDefine.DeBuffType.Fire:
                return new MMORPG_DeBuff_Fire();
            case EnumDefine.DeBuffType.Poison:
                return new MMORPG_DeBuff_Poison();
            case EnumDefine.DeBuffType.Light:
                return new MMORPG_DeBuff_Light();
            case EnumDefine.DeBuffType.Dark:
                return new MMORPG_DeBuff_Dark();
            default:
                return new MMORPG_BaseDeBuff();
        }

    }

    /// <summary>
    /// 初始化debuff
    /// </summary>
    /// <param name="type"></param>
    /// <param name="time"></param>
    /// <param name="owner"></param>
    /// <param name="value"></param>
    public virtual void OnInit(EnumDefine.DeBuffType type, float time, MMORPG_BaseObject owner, float value)
    {
        this.m_DebuffType = type;
        this.m_Time = time;
        this.m_Owner = owner;
        this.m_Value = value;
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnDestory()
    {

    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// Buff基类
/// </summary>
public class MMORPG_BaseBuff
{
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
    protected EnumDefine.BuffType m_buffType;

    /// <summary>
    /// buff增益数值
    /// </summary>
    protected float m_Value;

    /// <summary>
    /// 获得buff类型
    /// </summary>
    /// <returns></returns>
    public EnumDefine.BuffType GetBuffType()
    {
        return m_buffType;

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
    public static MMORPG_BaseBuff GetInstance(EnumDefine.BuffType type)
    {
        switch (type)
        {
            case EnumDefine.BuffType.Ice:
                return new MMORPG_Buff_Ice();
            case EnumDefine.BuffType.Fire:
                return new MMORPG_Buff_Fire();
            case EnumDefine.BuffType.Poison:
                return new MMORPG_Buff_Poison();
            case EnumDefine.BuffType.Light:
                return new MMORPG_Buff_Light();
            case EnumDefine.BuffType.Dark:
                return new MMORPG_Buff_Dark();
            default:
                return new MMORPG_BaseBuff();
        }
        
    }

    /// <summary>
    /// 初始化buff
    /// </summary>
    /// <param name="type"></param>
    /// <param name="time"></param>
    /// <param name="owner"></param>
    /// <param name="value"></param>
    public virtual void OnInit(EnumDefine.BuffType type, float time, MMORPG_BaseObject owner, float value)
    {
        this.m_buffType = type;
        this.m_Time = time;
        this.m_Owner = owner;
        this.m_Value = value;
    }

    public virtual  void OnUpdate()
    {
       
    }

    public virtual void OnDestory()
    {
       
    }


}

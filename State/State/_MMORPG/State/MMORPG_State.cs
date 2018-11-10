using UnityEngine;
using System.Collections;

/// <summary>
/// 状态机基类，所有状态均继承自该状态机，每个不同的状态只允许有一个实例
/// </summary>
public class MMORPG_State<entityType> 
{
    public entityType Target;

    /// <summary>
    /// 进入状态
    /// </summary>
    /// <param name="entity"></param>
    public virtual void Enter(entityType entity) { }

    /// <summary>
    /// 执行状态
    /// </summary>
    /// <param name="entity"></param>
    public virtual void Execute(entityType entity) { }

    /// <summary>
    /// 结束状态
    /// </summary>
    /// <param name="entity"></param>
    public virtual void Exit(entityType entity) { }

    /// <summary>
    /// 接收到消息执行的动作
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="telegram"></param>
    /// <returns></returns>
    public virtual bool OnMessage(entityType entity, Telegram telegram)
    {
        return false;
    }
}

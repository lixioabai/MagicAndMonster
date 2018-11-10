using UnityEngine;
using System.Collections;

/// <summary>
/// 所有状态都继承自该类，且每个不同的状态都只能有一个实例
/// </summary>
public class State<entityType>
{
    public entityType Target;

    /// <summary>
    /// 进入该状态之后执行的动作
    /// </summary>
    /// <param name="entity">该状态作用的实体</param>
    public virtual void Enter(entityType entity)
    {

    }

    /// <summary>
    /// 在该状态当中时一直执行的动作
    /// </summary>
    /// <param name="entity">该状态作用的实体</param>
    /// 
    public virtual void Execute(entityType entity)
    {

    }

    /// <summary>
    /// 退出该状态时执行的动作
    /// </summary>
    /// <param name="entity">该状态作用的实体</param>
    public virtual void Exit(entityType entity)
    {

    }

    /// <summary>
    /// 接受到消息之后执行的动作
    /// </summary>
    /// <param name="entity">作用的实体</param>
    /// <param name="telegram">传递的消息</param>
    public virtual bool OnMessage(entityType entity, Telegram telegram)
    {
        return false;
    }
}

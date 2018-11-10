using UnityEngine;
using System.Collections;

/// <summary>
/// 管理游戏实体的状态切换和行为
/// </summary>
public class StateMachine<entityType>
{
    // 指向该状态机目前所指向的实例
    private entityType mpOwner;

    // 实例现在所处的状态
    private State<entityType> mpCurrentState;
    // 记录实例的上一个状态
    private State<entityType> mpPreviousState;
    // 每次FSM被更新时调用该状态逻辑
    private State<entityType> mpGlobalState;

    public StateMachine(entityType owner)
    {
        mpOwner = owner;
        mpCurrentState = null;
        mpPreviousState = null;
        mpGlobalState = null;
    }

    public void GlobalStateEnter()
    {
        mpGlobalState.Enter(mpOwner);
    }

    /// <summary>
    /// 为某个实体设置全局状态
    /// </summary>
    /// <param name="globalState">实例化之后的某个状态</param>
    public void SetGlobalState(State<entityType> globalState)
    {
        mpGlobalState = globalState;
        mpGlobalState.Target = mpOwner;
        mpGlobalState.Enter(mpOwner);
    }

    /// <summary>
    /// 为某个实体设置目前的状态
    /// </summary>
    /// <param name="currentState">实例化之后的某个状态</param>
    public void SetCurrentState(State<entityType> currentState)
    {
        mpCurrentState = currentState;
        mpCurrentState.Target = mpOwner;
        mpCurrentState.Enter(mpOwner);
    }

    // 每一帧都需要调用该函数来实现当前状态中的行为
    public void FSMUpdate()
    {
        // 如果存在全局状态，则需要调用它的Execute方法
        if (mpGlobalState != null)
            mpGlobalState.Execute(mpOwner);
        if (mpCurrentState != null)
            mpCurrentState.Execute(mpOwner);
    }

    /// <summary>
    /// 改变某个实体的状态
    /// </summary>
    /// <param name="pNewState">新的状态</param>
    public void ChangeState(State<entityType> pNewState)
    {
        if (pNewState == null)
        {
            Debug.LogError("该状态不存在");
        }
        mpCurrentState.Exit(mpOwner);
        // 保留前一个状态的记录
        mpPreviousState = mpCurrentState;

        mpCurrentState = pNewState;
        mpCurrentState.Target = mpOwner;
        mpCurrentState.Enter(mpOwner);
    }

    /// <summary>
    /// 使当前实体返回上一个状态
    /// </summary>
    public void RevertToPreviousState()
    {
        ChangeState(mpPreviousState);
    }

    // 指向目前的状态
    public State<entityType> CurrentState { get { return mpCurrentState; } }

    // 指向全局状态
    public State<entityType> GlobalState { get { return mpGlobalState; } }

    // 指向前一个状态
    public State<entityType> PrevioudState { get { return mpPreviousState; } }

    /// <summary>
    /// 发送一个消息
    /// </summary>
    /// <returns>消息是否传送成功</returns>
    public bool HandleMessage(Telegram msg)
    {
        //Debug.Log("HandleMessage");

        if (mpCurrentState != null && mpCurrentState.OnMessage(mpOwner, msg))
        {
            //Debug.Log("Curr Not null");
            return true;
        }

        if (mpGlobalState != null && mpGlobalState.OnMessage(mpOwner, msg))
        {
            //Debug.Log("Glo Not null");
            return true;
        }

        //Debug.Log("null");
        return false;
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 管理游戏实体的状态切换和行为
/// </summary>
public class MMORPG_StateMachine<entityType> 
{
    /// <summary>
    /// 指向该状态目前所有的实例
    /// </summary>
    private entityType m_Owner;

    /// <summary>
    /// 当前所处的状态
    /// </summary>
    private State<entityType> m_CurrentState;

    /// <summary>
    /// 上一个状态
    /// </summary>
    private State<entityType> m_PreviousState;

    /// <summary>
    /// 每次FSM更新时调用该状态并执行逻辑
    /// </summary>
    private State<entityType> m_GlobalState;

    /// <summary>
    /// 初始化状态机
    /// </summary>
    /// <param name="owner"></param>
    public MMORPG_StateMachine(entityType owner)
    {
        m_Owner = owner;
        m_CurrentState = null;
        m_PreviousState = null;
        m_GlobalState = null;
    }

    public void GlobalStateEnter()
    {
        m_GlobalState.Enter(m_Owner);
    }

    /// <summary>
    /// 为某个实体设置全局状态
    /// </summary>
    /// <param name="globalState"></param>
    public void SetGloablState(State<entityType> globalState)
    {
        m_GlobalState = globalState;
        m_GlobalState.Target = m_Owner;
        m_GlobalState.Enter(m_Owner);
    }

    /// <summary>
    /// 设置当前状态
    /// </summary>
    public void SetCurrentState(State<entityType> currentState)
    {
        m_CurrentState = currentState;
        m_CurrentState.Target = m_Owner;
        m_CurrentState.Enter(m_Owner);
    }

    /// <summary>
    /// 每一帧都要调用来实现状态中的行为
    /// </summary>
    public void FSMUpdate()
    {
        //如果存在全局状态则需要调用它的执行方法
        if (m_GlobalState != null)
        {
            m_GlobalState.Execute(m_Owner);
        }

        if (m_CurrentState != null)
        {
            m_CurrentState.Execute(m_Owner);
        }
    }


    /// <summary>
    ///改变状态 
    /// </summary>
    public void ChangeState(State<entityType> newState)
    {
        if (newState == null)
        {
            Debug.LogError("不存在该状态");
        }
        m_CurrentState.Exit(m_Owner);

        //更新执行当前的状态覆盖上一个状态
        m_PreviousState = m_CurrentState;

        m_CurrentState = newState;
        m_CurrentState.Target = m_Owner;
        m_CurrentState.Enter(m_Owner);
    }

    /// <summary>
    /// 使当前实例返回上一个状态
    /// </summary>
    public void RevertToPreviousState()
    {
        ChangeState(m_PreviousState);
    }


    public State<entityType> CurrentState { get { return m_CurrentState; } }

    public State<entityType> GlobalState { get { return m_GlobalState; } }

    public State<entityType> PreviousState { get { return m_PreviousState; } }

    public bool HandleMessage(Telegram telegram)
    {
        if (m_CurrentState != null && m_CurrentState.OnMessage(m_Owner, telegram))
        {
            return true;
        }
        if (m_GlobalState != null && m_GlobalState.OnMessage(m_Owner, telegram))
        {
            return true;
        }
        return false;
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MMORPG_BaseObject_Player : MMORPG_BaseObject
{
    public enum PlayerType
    {
        None,
        /// <summary>
        /// 战士
        /// </summary>
        Sword,
        /// <summary>
        /// 法师
        /// </summary>
        Magic,
        /// <summary>
        /// 刺客
        /// </summary>
        Assassin,
        /// <summary>
        /// 弓箭手
        /// </summary>
        Archer
    }



    /// <summary>
    /// 状态机
    /// </summary>
    private StateMachine<MMORPG_BaseObject_Player> myStateMachine;

    /// <summary>
    /// 是否正在使用虚拟摇杆
    /// </summary>
    public bool isET;

    /// <summary>
    /// 自动打怪
    /// </summary>
    public bool isAutoAttack;

    public PlayerType playerType;



    public override void Start()
    {
        base.Start();
        myStateMachine = new StateMachine<MMORPG_BaseObject_Player>(this);
        myStateMachine.SetCurrentState(MMORPG_BaseObject_Player_State_Idle.Instance);
        myStateMachine.SetGlobalState(MMORPG_BaseObject_Player_State_Global.Instance);

    }

    public override void Update()
    {
        base.Update();
        myStateMachine.FSMUpdate();//状态机更新
    }

    public StateMachine<MMORPG_BaseObject_Player> GetFSM()
    {
        return myStateMachine;
    }


    public override bool HandleMessage(Telegram telegram)
    {
        return myStateMachine.HandleMessage(telegram);
    }






    #region 战斗


    #endregion

}

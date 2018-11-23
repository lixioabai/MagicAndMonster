using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_AI_State_Idle : State<MMORPG_BaseObject_AI>
{

    private static MMORPG_BaseObject_AI_State_Idle instance;
    public static MMORPG_BaseObject_AI_State_Idle Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_AI_State_Idle();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_AI entity)
    {
       

    }
    public override void Execute(MMORPG_BaseObject_AI entity)
    {
        if (entity.FightObject == null)
        {
            if (entity.m_enemys.Count <= 0)
            {
                entity.RefreshEnemyList();
                entity.GetMinDistancePlayer();
            }
            else
            {
                entity.GetMinDistancePlayer();
            }
        }
       

        //在待机中判断是否要追击
        if (entity.CheckChaseDistance())
        {
            //转向敌人
            entity.TurnTo(entity.FightObject);
            //进入追逐状态
            entity.AI_GetFSM().SetCurrentState(MMORPG_BaseObject_AI_State_Chase.Instance);
        }
        entity.AnimationStateChange(MMORPG_AnimationStateInfo.Idle,true);
    }
    public override void Exit(MMORPG_BaseObject_AI entity)
    {

    }
    public override bool OnMessage(MMORPG_BaseObject_AI entity, Telegram telegram)
    {
        if (!entity.IsDie)
        {
           
        }
        return false;
    }
}

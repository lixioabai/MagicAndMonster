using UnityEngine;
using System.Collections;

/// <summary>
/// AI追逐状态
/// </summary>
public class MMORPG_BaseObject_AI_State_Chase : State<MMORPG_BaseObject_AI>
{ 

    private static MMORPG_BaseObject_AI_State_Chase instance;
    public static MMORPG_BaseObject_AI_State_Chase Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_AI_State_Chase();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_AI entity)
    {

        //朝敌人方向移动
        //追逐敌人
        entity.AnimationStateChange(MMORPG_AnimationStateInfo.Run, true);
        entity.myCapCollider.SimpleMove(entity.GetMinDistancePlayer().transform.position * entity.MoveSpeed);

    }
    public override void Execute(MMORPG_BaseObject_AI entity)
    {
        if (entity.FightObject == null)
        {
            entity.FightObject = entity.GetMinDistancePlayer();
        }

        Debug.Log("追逐");


        if (entity.CheckBakcDistance())
        {
            entity.AnimationStateChange(MMORPG_AnimationStateInfo.Run, true);
            entity.AI_GetFSM().ChangeState(MMORPG_BaseObject_AI_State_BackBirth.Instance);
        }
        else
        {

            //在追击中判断是否满足攻击
            if (entity.CheckAttackDistance())
            {
                entity.AI_GetFSM().ChangeState(MMORPG_BaseObject_AI_State_Attack.Instance);
            }
            else
            {

                if (entity.CheckChaseDistance())
                {
                    //继续追击
                    //朝敌人方向移动
                    //追逐敌人
                    entity.TurnTo(entity.FightObject);
                    entity.AnimationStateChange(MMORPG_AnimationStateInfo.Run, true);
                    entity.myCapCollider.SimpleMove((entity.FightObject.transform.position - entity.transform.position)*entity.MoveSpeed);
                }
                else
                {
                    entity.AI_GetFSM().ChangeState(MMORPG_BaseObject_AI_State_Idle.Instance);
                }
            }
        }

    }
    public override void Exit(MMORPG_BaseObject_AI entity)
    {
        Debug.Log("退出状态");
    }
    public override bool OnMessage(MMORPG_BaseObject_AI entity, Telegram telegram)
    {
        if (!entity.IsDie)
        {

        }
        return false;
    }
}

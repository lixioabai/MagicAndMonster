using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_AI_State_Attack : State<MMORPG_BaseObject_AI>
{ 

    private static MMORPG_BaseObject_AI_State_Attack instance;
    public static MMORPG_BaseObject_AI_State_Attack Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_AI_State_Attack();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_AI entity)
    {

        entity.attackTime = 0;
        entity.AnimationStateChange(MMORPG_AnimationStateInfo.Attack, true);
    }

    public override void Execute(MMORPG_BaseObject_AI entity)
    {

      
            //攻击中判断追击 //如果攻击时玩家移动则攻击完毕再判断追击
            if (!entity.CheckAttackDistance())
            {
                if (entity.AllowAttack()&&!entity.myAnimation.IsPlaying(MMORPG_AnimationStateInfo.Attack))
                {
                    entity.AI_GetFSM().SetCurrentState(MMORPG_BaseObject_AI_State_Chase.Instance);
                }
            }
            else
            {
                if (!entity.AllowAttack())
                {
                    entity.AnimationStateChange(MMORPG_AnimationStateInfo.Idle, true);
                }
                else
                {
                    entity.TurnTo(entity.FightObject);
                    entity.AnimationStateChange(MMORPG_AnimationStateInfo.Attack, true);
                    if (entity.AnimationIsPlayingOver(MMORPG_AnimationStateInfo.Attack))
                    {
                        entity.attackTime = 2;
                    }
                }

            }
        
       
        //entity.AI_GetFSM().SetCurrentState(MMORPG_BaseObject_AI_State_Idle.Instance);


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

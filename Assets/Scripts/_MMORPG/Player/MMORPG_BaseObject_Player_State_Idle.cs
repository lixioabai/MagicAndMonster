using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_Player_State_Idle : State<MMORPG_BaseObject_Player>
{

    private static MMORPG_BaseObject_Player_State_Idle instance;
    public static MMORPG_BaseObject_Player_State_Idle Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_Player_State_Idle();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_Player entity)
    {

       
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || entity.isET)
            {

                entity.GetFSM().SetCurrentState(MMORPG_BaseObject_Player_State_Move.Instance);
            }
            else
            {
                if (entity.isFightState)
                {
                    entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackIdle, true);
                }
                else
                {
                entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.NormalIdle, true);
                 }
               
            }

        #region 休闲和战斗状态
        if (entity.isFightState)
        {
            entity.ExitFightTime -= Time.deltaTime;
            if (entity.ExitFightTime <= 0)
            {
                entity.isFightState = false;
                entity.ExitFightTime = MMORPG_GlobalParmater.TIME_EXIST_FIGHT;
            }
        }

        #endregion




    }
    public override void Execute(MMORPG_BaseObject_Player entity)
    {
      
          


        #region 自动打怪
        //自动打怪
        if (entity.isAutoAttack)
        {

            entity.GetMinDistancePlayer();
            float distance = Vector3.Distance(entity.transform.position, entity.FightObject.transform.position);
            if (distance < entity.chaseDistance)
            {
                if (entity.CheckAttackDistance())
                {
                    entity.GetFSM().SetCurrentState(MMORPG_BaseObject_Player_State_Attack.Instance);
                }
                else
                {

                    entity.TurnTo(entity.FightObject);
                    entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackRun, true);
                    entity.myCapCollider.SimpleMove((entity.FightObject.transform.position - entity.transform.position));
                }
            }
            else
            {
                if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || entity.isET)
                {

                    entity.GetFSM().SetCurrentState(MMORPG_BaseObject_Player_State_Move.Instance);
                }
                else
                {
                    if (entity.isFightState)
                    {
                        entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackIdle, true);
                    }
                    else
                    {
                        entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.NormalIdle, true);
                    }
                }
            }

        }
        #endregion
        else
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || entity.isET)
            {

                entity.GetFSM().SetCurrentState(MMORPG_BaseObject_Player_State_Move.Instance);
            }
            else
            {
                if (entity.isFightState)
                {
                    entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackIdle, true);
                }
                else
                {
                    entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.NormalIdle, true);
                }
            }
        }


    }
    public override void Exit(MMORPG_BaseObject_Player entity)
    {

    }
    public override bool OnMessage(MMORPG_BaseObject_Player entity, Telegram telegram)
    {
        if (!entity.IsDie)
        {
           
        }
        return false;
    }
}

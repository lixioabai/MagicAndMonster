using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_Player_State_Move : State<MMORPG_BaseObject_Player>
{ 

    private static MMORPG_BaseObject_Player_State_Move instance;
    public static MMORPG_BaseObject_Player_State_Move Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_Player_State_Move();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_Player entity)
    {

        if (entity.isFightState)
        {
            entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackRun, true);
        }
        else
        {
            entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.NormalRun, true);
        }
        
    }
    public override void Execute(MMORPG_BaseObject_Player entity)
    {

        if (entity.AnimationIsPlayingOver())
        {
            entity.GetFSM().SetCurrentState(MMORPG_BaseObject_Player_State_Idle.Instance);
           // Debug.Log("去执行待机");
        }
       
    }
    public override void Exit(MMORPG_BaseObject_Player entity)
    {
       // Debug.Log("退出状态");
    }
    public override bool OnMessage(MMORPG_BaseObject_Player entity, Telegram telegram)
    {
        if (!entity.IsDie)
        {

        }
        return false;
    }
}

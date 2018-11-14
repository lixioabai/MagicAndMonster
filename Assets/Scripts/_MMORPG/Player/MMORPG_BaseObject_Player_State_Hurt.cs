using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_Player_State_Hurt : State<MMORPG_BaseObject_Player>
{

    private static MMORPG_BaseObject_Player_State_Hurt instance;
    public static MMORPG_BaseObject_Player_State_Hurt Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_Player_State_Hurt();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_Player entity)
    {
        Debug.Log("被攻击收到消息");
        entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.HurtFloat, true);
       
    }
    public override void Execute(MMORPG_BaseObject_Player entity)
    {

        if (entity.AnimationIsPlayingOver())
        {
            entity.GetFSM().SetCurrentState(MMORPG_BaseObject_Player_State_Idle.Instance);
        }
        Debug.Log("受伤状态");
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

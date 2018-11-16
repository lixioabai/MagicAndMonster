using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_AI_State_Hurt : State<MMORPG_BaseObject_AI>
{
    private float WaitTime = 2f;
    private static MMORPG_BaseObject_AI_State_Hurt instance;
    public static MMORPG_BaseObject_AI_State_Hurt Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_AI_State_Hurt();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_AI entity)
    {
        WaitTime = 1;
        entity.AnimationStateChange(MMORPG_AnimationStateInfo_AI.Hurt, true);
        Debug.Log("<Color=green>进入受伤状态</Color>");
    }
    public override void Execute(MMORPG_BaseObject_AI entity)
    {

        WaitTime -= Time.deltaTime;
        if (WaitTime <= 0)
        {
            //if (entity.AnimationIsPlayingOver())
            {
                entity.AI_GetFSM().SetCurrentState(MMORPG_BaseObject_AI_State_Idle.Instance);
            }
            WaitTime = 2;
        }
       

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

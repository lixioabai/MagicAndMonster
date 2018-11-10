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
                entity.AnimationStateChange(MMORPG_AnimationStateInfo.Idle, true);
            }
      
       
       
    }
    public override void Execute(MMORPG_BaseObject_Player entity)
    {
      
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || entity.isET)
            {

                entity.GetFSM().SetCurrentState(MMORPG_BaseObject_Player_State_Move.Instance);
            }
            else
            {
                entity.AnimationStateChange(MMORPG_AnimationStateInfo.Idle, true);
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

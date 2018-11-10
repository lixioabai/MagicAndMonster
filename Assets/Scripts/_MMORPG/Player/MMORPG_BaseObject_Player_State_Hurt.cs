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

    }
    public override void Execute(MMORPG_BaseObject_Player entity)
    {
        //if (hp <= 0)
        //{
        //    entity.GetFSM().ChangeState(Enemy_Type_One_DieState.Instance);
        //}
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

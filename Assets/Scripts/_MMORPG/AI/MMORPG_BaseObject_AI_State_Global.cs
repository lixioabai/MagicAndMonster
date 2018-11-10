using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_AI_State_Global : State<MMORPG_BaseObject_AI> {

    private static MMORPG_BaseObject_AI_State_Global instance;
    public static MMORPG_BaseObject_AI_State_Global Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_AI_State_Global();
            }
            return instance;
        }
    }


    public override void Enter(MMORPG_BaseObject_AI entity)
    {

    }
    public override void Execute(MMORPG_BaseObject_AI entity)
    {
        //if (hp <= 0)
        //{
        //    entity.GetFSM().ChangeState(Enemy_Type_One_DieState.Instance);
        //}
    }
    public override void Exit(MMORPG_BaseObject_AI entity)
    {

    }
    public override bool OnMessage(MMORPG_BaseObject_AI entity, Telegram telegram)
    {
        Debug.Log("GetMessage");

       
        
        return false;
    }
}

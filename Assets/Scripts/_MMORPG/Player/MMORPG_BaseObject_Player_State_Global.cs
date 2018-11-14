using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_Player_State_Global : State<MMORPG_BaseObject_Player> {

    private static MMORPG_BaseObject_Player_State_Global instance;
    public static MMORPG_BaseObject_Player_State_Global Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_Player_State_Global();
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

        if (Input.GetKeyDown(KeyCode.H))
        {
            entity.GetFSM().ChangeState(MMORPG_BaseObject_Player_State_Hurt.Instance);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (entity.GetFSM().CurrentState == MMORPG_BaseObject_Player_State_Attack.Instance)
                return;
            entity.GetFSM().ChangeState(MMORPG_BaseObject_Player_State_Attack.Instance);
        }
    }
    public override void Exit(MMORPG_BaseObject_Player entity)
    {

    }
    public override bool OnMessage(MMORPG_BaseObject_Player entity, Telegram telegram)
    {
        Debug.Log("GetMessage");
        if (telegram.Msg == (int)EnumDefine.MessageType.Hurt)
        {
            entity.GetFSM().ChangeState(MMORPG_BaseObject_Player_State_Hurt.Instance);
            return true;
        }
        if (telegram.Msg == (int)EnumDefine.MessageType.HurtBack)
        {
            entity.GetFSM().ChangeState(MMORPG_BaseObject_Player_State_Hurt.Instance);
            return true;
        }
        if (telegram.Msg == (int)EnumDefine.MessageType.HurtFloat)
        {
            entity.GetFSM().ChangeState(MMORPG_BaseObject_Player_State_Hurt.Instance);
            return true;
        }


        return false;
    }
}

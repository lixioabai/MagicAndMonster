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

    #region Buff 判断
            if (telegram.bufftype != EnumDefine.BuffType.None)
            {
                entity.AddBuff(telegram.bufftype, telegram.bufftime, telegram.buffvalue);
            }
            if (telegram.debufftype != EnumDefine.DeBuffType.None)
            {
                entity.AddDeBuff(telegram.debufftype, telegram.bufftime, telegram.buffvalue);
            }
    #endregion

       
        if (telegram.Msg == (int)EnumDefine.MessageType.Hurt)
        {
            //掉血
            entity.AI_GetFSM().ChangeState(MMORPG_BaseObject_AI_State_Hurt.Instance);
            return true;
        }

        if (telegram.Msg == (int)EnumDefine.MessageType.NormalHurt)
        {
           //掉血
            return true;
        }

      

        return false;
    }
}

using UnityEngine;
using System.Collections;

public class Player_GlobalState : State<Player> 
{
    private static Player_GlobalState instance;
    public static Player_GlobalState Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new Player_GlobalState();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {

    }
    public override void Execute(Player entity)
    {

    }
    public override void Exit(Player entity)
    {

    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        
        if (entity.mymotor.IsTouchingGround)
        {
            if (entity.isPasive)
            {
                if (telegram.Msg == (int)MessagesType.player_MinisterFlash)
                {
                    entity.GetFSM().ChangeState(Player_StateMinisterFlash.Instance);
                    return true;
                }
                if (telegram.Msg == (int)MessagesType.player_WTeanaFlash)
                {
                    entity.GetFSM().ChangeState(Player_StateTeanaFlash.Instance);
                    return true;
                }
            }
            else
            {
                if (entity.isskilling == false)
                {
                    if (telegram.Msg == (int)MessagesType.Player_SkillQ)
                    {
                        
                        entity.GetFSM().ChangeState(Player_StateSkillQ.Instance);
                        return true;
                    }
                    if (telegram.Msg == (int)MessagesType.Player_SkillF)
                    {
                        entity.GetFSM().ChangeState(Player_StateSkillF.Instance);
                        return true;
                    }
                    if (telegram.Msg == (int)MessagesType.Player_SkillM)
                    {
                        entity.GetFSM().ChangeState(Player_StateSkillM.Instance);
                        return true;
                    }
                    if (telegram.Msg == (int)MessagesType.Player_SkillR)
                    {
                        entity.GetFSM().ChangeState(Player_StateSkillR.Instance);
                        return true;
                    }
                    if (telegram.Msg == (int)MessagesType.Player_SkillS)
                    {
                        entity.GetFSM().ChangeState(Player_StateSkillS.Instance);
                        return true;
                    }
                    if (telegram.Msg == (int)MessagesType.player_WEtherFlash)
                    {
                        entity.GetFSM().ChangeState(Player_StateWEtherFlash.Instance);
                        return true;
                    }
                    if (telegram.Msg == (int)MessagesType.Player_Flash)
                    {
                        entity.GetFSM().ChangeState(Player_StateFlash.Instance);
                        return true;
                    }
                    if (telegram.Msg == (int)MessagesType.player_MasterFlash)
                    {
                        entity.GetFSM().ChangeState(Player_StateMasterFlash.Instance);
                        return true;
                    }
                }
            }
        }
        if (telegram.Msg == (int)MessagesType.Msg_BeingHurt)
        {
            if (!entity.SuperArmor)
            {
                entity.GetFSM().ChangeState(Player_StateHurt.Instance);
            }
            return true;
        }
        if (telegram.Msg == (int)MessagesType.Msg_BeingUpFukongBig)
        {
            entity.flyhigh = 25f;
            if (!entity.SuperArmor)
            {
                entity.GetFSM().ChangeState(Player_StateFloating.Instance);
            }
            return true;
        }
        if (telegram.Msg == (int)MessagesType.Msg_BeingUpFukongSmall)
        {
            entity.flyhigh = 18f;
            if (!entity.SuperArmor)
            {
                entity.GetFSM().ChangeState(Player_StateFloating.Instance);
            }
            return true;
        }
        if (telegram.Msg == (int)MessagesType.Msg_BeingUpForced_Fall)
        {
            if (!entity.SuperArmor)
            {
                entity.GetFSM().ChangeState(Player_StateForce_Fall.Instance);
            }
            return true;
        }
        return false;
    }
    public void NewBuff(Buff buff, Player e)
    {
        GameObject Effect;
        switch(buff)
        {
            case Buff.SuperArmor:
                try
                {
                    e.transform.FindChild("SuperArmor").GetComponent<EveryBuff>().Bufftimes = BuffInfo._Buffinstance.GetBuffInfoByld(BuffInfo._Buffinstance.GetBuffInfo("SuperArmor")).keeptime;
                }
                catch
                {
                    Effect = (GameObject)Object.Instantiate(Buff_Effect.Buff_SuperArmor, e.player.transform.position, e.player.transform.rotation);
                    Effect.name = "SuperArmor";
                    Effect.transform.parent = e.transform;
                }
                break;
            case Buff.Null:
                break;
        }
    }
}
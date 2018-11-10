using UnityEngine;
using System.Collections;
public class Goblin_GlobalState : State<Goblin>
{
    private static Goblin_GlobalState instance;
    public static Goblin_GlobalState Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new Goblin_GlobalState();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {

    }
    public override void Execute(Goblin entity)
    {
        if (!entity.stateInfo.IsName("Die") && entity.motor.IsTouchingGround && entity.stateInfo.normalizedTime >= 0.8f && entity.GetComponent<CapsuleCollider>().enabled==true)
        {
            if (entity.Property.HP1 <= 0)
            {
                entity.motor.RemoveForce();
                entity.GetFSM().ChangeState(Goblin_StateDie.Instance);
            }
        }
    }
    public override void Exit(Goblin entity)
    {

    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        if (!entity.IsDie)
        {
            if (!entity.IsFrozen)
            {
                if (telegram.Msg == (int)MessagesType.Msg_BeingHurt)
                {
                    entity.ShowHurt.Show = true;
                    entity.ShowHurt.hurtnum = telegram.hurt;
                    entity.Property.HP1 -= telegram.hurt;
                    entity.GetFSM().ChangeState(Goblin_StateHurt.Instance);
                    return true;
                }
                if (telegram.Msg == (int)MessagesType.Msg_BeingUpFukongBig)
                {
                    entity.ShowHurt.Show = true;
                    entity.ShowHurt.hurtnum = telegram.hurt;
                    entity.Property.HP1 -= telegram.hurt;
                    entity.flyhigh = 25f;
                    entity.GetFSM().ChangeState(Goblin_StateFloating.Instance);
                    return true;
                }
                if (telegram.Msg == (int)MessagesType.Msg_BeingUpFukongSmall)
                {
                    entity.ShowHurt.Show = true;
                    entity.ShowHurt.hurtnum = telegram.hurt;
                    entity.Property.HP1 -= telegram.hurt;
                    entity.flyhigh = 18f;
                    entity.GetFSM().ChangeState(Goblin_StateFloating.Instance);
                    return true;
                }
                if (telegram.Msg == (int)MessagesType.Msg_BeingUpForced_Fall)
                {
                    entity.ShowHurt.Show = true;
                    entity.ShowHurt.hurtnum = telegram.hurt;
                    entity.Property.HP1 -= telegram.hurt;
                    entity.GetFSM().ChangeState(Goblin_StateForced_Fall.Instance);
                    return true;
                }
                if (telegram.Msg == (int)MessagesType.Msg_BeingHitDown)
                {
                    entity.ShowHurt.Show = true;
                    entity.ShowHurt.hurtnum = telegram.hurt;
                    entity.Property.HP1 -= telegram.hurt;
                    entity.GetFSM().ChangeState(Goblin_StateHitDown_Fall.Instance);
                    return true;
                }
                if (telegram.Msg == (int)MessagesType.Msg_BeingForzen)
                {
                    entity.ShowHurt.Show = true;
                    entity.ShowHurt.hurtnum = telegram.hurt;
                    entity.Property.HP1 -= telegram.hurt;
                    entity.GetFSM().ChangeState(Goblin_StateFrozen.Instance);
                    return true;
                }
            }
        }
        return false;
    }
}






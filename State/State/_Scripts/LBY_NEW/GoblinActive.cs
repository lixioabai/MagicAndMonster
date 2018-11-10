using UnityEngine;
using System.Collections;

public class Goblin_StateIdle : State<Goblin>
{
    public static string animatorStateName = "movement";
    private static Goblin_StateIdle instance;
    public static Goblin_StateIdle Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateIdle();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
    }
    public override void Execute(Goblin entity)
    {

    }
    public override void Exit(Goblin entity)
    {

    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateStandUp : State<Goblin>
{
    public static string animatorStateName = "StandUp";
    private static Goblin_StateStandUp instance;
    public static Goblin_StateStandUp Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateStandUp();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
    }
    public override void Execute(Goblin entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Goblin_StateIdle.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateIdle.Instance);
            }
            if (entity.stateInfo.IsName(Goblin_StateStandUp.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateStandUp.Instance);
            }
        }
    }
    public override void Exit(Goblin entity)
    {
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}
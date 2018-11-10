using UnityEngine;
using System.Collections;

public class BuffState : State<Buff>
{
    private static BuffState instance;
    public static BuffState Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new BuffState();
            }
            return instance;
        }
    }
    public override void Enter(Buff entity)
    {

    }
    public override void Execute(Buff entity)
    {

    }
    public override void Exit(Buff entity)
    {

    }
    public override bool OnMessage(Buff entity, Telegram telegram)
    {
        return false;
    }
}

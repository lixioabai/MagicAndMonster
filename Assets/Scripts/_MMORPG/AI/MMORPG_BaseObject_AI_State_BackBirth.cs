using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_AI_State_BackBirth : State<MMORPG_BaseObject_AI>
{

    private static MMORPG_BaseObject_AI_State_BackBirth instance;
    public static MMORPG_BaseObject_AI_State_BackBirth Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_AI_State_BackBirth();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_AI entity)
    {
       

    }
    public override void Execute(MMORPG_BaseObject_AI entity)
    {
        float distance = Vector3.Distance(entity.transform.position, entity.birthPos);
        if (distance <= 1f)
        {
            entity.AI_GetFSM().ChangeState(MMORPG_BaseObject_AI_State_Idle.Instance);
            entity.isBakcToBirth = false;
        }
        else
        {
            entity.TurnTo(entity.birthPos);
            entity.AnimationStateChange(MMORPG_AnimationStateInfo.Run, true);
            entity.myCapCollider.SimpleMove((entity.birthPos - entity.transform.position) * entity.MoveSpeed);
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

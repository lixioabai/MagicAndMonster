using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_Player_State_Attack : State<MMORPG_BaseObject_Player>
{
    private int AttackIndex = 0;
    private static MMORPG_BaseObject_Player_State_Attack instance;
    public static MMORPG_BaseObject_Player_State_Attack Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_Player_State_Attack();
            }
            return instance;
        }
    }

    public override void Enter(MMORPG_BaseObject_Player entity)
    {
        
        AttackIndex++;
        Debug.Log("攻击顺序： "+ AttackIndex);
        switch (AttackIndex)
        {
            case 1:
                entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackOne, true); //单体

                entity.GetMinDistancePlayer();
                



                break;
            case 2:
                entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackTwo, true); //单体
                break;
            case 3:
                entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackThree, true); //AOE
                break;
            case 4:
                entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackFour, true); //AOE
                AttackIndex = 0;
                break;
            default:
                break;
        }

    }
    public override void Execute(MMORPG_BaseObject_Player entity)
    {
      
        if (entity.AnimationIsPlayingOver())
        {
            entity.GetFSM().SetCurrentState(MMORPG_BaseObject_Player_State_Idle.Instance);
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

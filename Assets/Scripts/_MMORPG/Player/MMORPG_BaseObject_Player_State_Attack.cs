using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
                AttackOne(entity);
                break;
            case 2:
                entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackTwo, true); //单体
                AttackOne(entity);
                break;
            case 3:
                entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackThree, true); //AOE
                AttackOne(entity);
                break;
            case 4:
                entity.AnimationStateChange(MMORPG_AnimationStateInfo_Player.AttackFour, true); //AOE
                AttackOne(entity);
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


    #region 将攻击单独独立出来
    //如果攻击目标为空 则遍历敌人集合 找到最近的敌人
    //如果最近的敌人超出攻击范围，则朝最近的敌人方向移动
    //在攻击范围内。攻击



    /// <summary>
    /// 攻击1判定
    /// </summary>
    private void AttackOne(MMORPG_BaseObject_Player entity)
    {
        //获取攻击目标
 
        //根据各个英雄攻击距离和攻击方式不同需要分为近战和远战

       
        entity.GetMinDistancePlayer();

        if (entity.FightObject == null)
            return;

        float distance = Vector3.Distance(entity.transform.position, entity.FightObject.transform.position);
        if (distance > entity.attackDistance)
        {
            return;
        }


           entity.transform.LookAt(entity.FightObject.transform.position);
            if (entity.myAnimation["AttackOne"].length > 0.5f)
            {
                //近战攻击
                MessageDispatcher.Instance.DispatchMessage(0, entity.transform, entity.FightObject.transform, (int)EnumDefine.MessageType.Hurt, EntityManager.Instance.GetEntityFromTransform(entity.transform), 10f, Buff.Burnt);
                Debug.Log("<Color=red>攻击消息发送</Color>");
               
                //远战攻击
                //实例化 弓箭、魔法球
                GameObject Arrow = Resources.Load<GameObject>("Arrow");
                GameObject.Instantiate(Arrow, entity.transform.position, Quaternion.identity);
                Arrow.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().direction = entity.FightObject.transform.position;
                    //近战攻击
                    MessageDispatcher.Instance.DispatchMessage(0, entity.transform, entity.FightObject.transform, (int)EnumDefine.MessageType.Hurt, EntityManager.Instance.GetEntityFromTransform(entity.transform), 10f, Buff.Burnt);
                    Debug.Log("<Color=red>远程攻击</Color>");
                
            }
           

        
    }

    /// <summary>
    /// 攻击2判定
    /// </summary>
    private void AttackTwo(MMORPG_BaseObject_Player entity)
    {
        List<GameObject> AttackList= entity.GetAoeAttackEnemy();

        if (entity.myAnimation["AttackOne"].length > 0.5f)
        {
            for (int i = 0; i < AttackList.Count; i++)
            {
                //近战攻击
                MessageDispatcher.Instance.DispatchMessage(0, entity.transform, entity.FightObject.transform, (int)EnumDefine.MessageType.Hurt, EntityManager.Instance.GetEntityFromTransform(entity.transform), 10f, Buff.Burnt);
                Debug.Log("<Color=red>攻击消息发送</Color>");


                //远战攻击
                //实例化 弓箭、魔法球
                GameObject Arrow = Resources.Load<GameObject>("Arrow");
                GameObject.Instantiate(Arrow, entity.transform.position, Quaternion.identity);
                Arrow.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().direction = entity.FightObject.transform.position;
                //近战攻击
                MessageDispatcher.Instance.DispatchMessage(0, entity.transform, entity.FightObject.transform, (int)EnumDefine.MessageType.Hurt, EntityManager.Instance.GetEntityFromTransform(entity.transform), 10f, Buff.Burnt);
                Debug.Log("<Color=red>远程攻击</Color>");

            }
           

          

        }

    }
    #endregion


}

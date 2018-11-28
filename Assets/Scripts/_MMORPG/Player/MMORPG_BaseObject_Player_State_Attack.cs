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
                AttackTwo(entity);
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

            switch (entity.playerType)
            {
                case MMORPG_BaseObject_Player.PlayerType.None:
                    break;
                case MMORPG_BaseObject_Player.PlayerType.Sword:
                    //近战攻击
                    //实例化特效
                    GameObject Effect = Resources.Load<GameObject>("Effect/Sword/Boy_Attack_01");
                   // GameObject effect = GameObject.Instantiate(Effect, entity.attackPos.position,entity.transform.rotation) as GameObject;
                    ObjectPoor.Instance().Create(Effect, entity.attackPos.position, Quaternion.identity);

                    Debug.Log("生成特校");
                    break;
                case MMORPG_BaseObject_Player.PlayerType.Magic:
                    //远战攻击
                    //实例化 弓箭、魔法球
                    GameObject Magic = Resources.Load<GameObject>("Arrow");
                    GameObject magic = GameObject.Instantiate(Magic, entity.transform.position, Quaternion.identity) as GameObject;
                    magic.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target = entity.FightObject;
                    break;
                case MMORPG_BaseObject_Player.PlayerType.Assassin:
                    //近战攻击
                    //实例化特效
                    break;
                case MMORPG_BaseObject_Player.PlayerType.Archer:
                    //远战攻击
                    //实例化 弓箭、魔法球
                    GameObject Arrow = Resources.Load<GameObject>("Arrow");
                    GameObject arrow = GameObject.Instantiate(Arrow, entity.transform.position, Quaternion.identity) as GameObject;
                    arrow.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target = entity.FightObject;
                    break;
                default:
                    break;
            }

               
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

        if (entity.myAnimation["AttackTwo"].length > 0.5f)
        {
            for (int i = 0; i < AttackList.Count; i++)
            {
                switch (entity.playerType)
                {
                    case MMORPG_BaseObject_Player.PlayerType.None:
                        break;
                    case MMORPG_BaseObject_Player.PlayerType.Sword:
                        //近战攻击
                        //实例化特效
                        GameObject Effect = Resources.Load<GameObject>("Effect/Sword/Boy_Attack_02");
                        // GameObject effect = GameObject.Instantiate(Effect, entity.attackPos.position,entity.transform.rotation) as GameObject;
                        ObjectPoor.Instance().Create(Effect, entity.attackPos.position, Quaternion.identity);
                        Debug.Log("生成特校");
                        break;
                    case MMORPG_BaseObject_Player.PlayerType.Magic:
                        //远战攻击
                        //实例化 弓箭、魔法球
                        GameObject Magic = Resources.Load<GameObject>("Arrow");
                        GameObject magic = GameObject.Instantiate(Magic, entity.transform.position, Quaternion.identity) as GameObject;
                        magic.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target = entity.FightObject;
                        break;
                    case MMORPG_BaseObject_Player.PlayerType.Assassin:
                        //近战攻击
                        //实例化特效
                        break;
                    case MMORPG_BaseObject_Player.PlayerType.Archer:
                        //远战攻击
                        //实例化 弓箭、魔法球
                        GameObject Arrow = Resources.Load<GameObject>("Arrow");
                        GameObject arrow = GameObject.Instantiate(Arrow, entity.transform.position, Quaternion.identity) as GameObject;
                        arrow.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target = entity.FightObject;
                        break;
                    default:
                        break;
                }


                MessageDispatcher.Instance.DispatchMessage(0, entity.transform, AttackList[i].transform, (int)EnumDefine.MessageType.Hurt, EntityManager.Instance.GetEntityFromTransform(entity.transform), 10f, Buff.Burnt);
                Debug.Log("<Color=red>远程攻击</Color>");

            }
           

          

        }

    }
    #endregion


}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AIType
{
    /// <summary>
    /// 队友
    /// </summary>
    Friend,
    /// <summary>
    /// 敌人
    /// </summary>
    Enemy,

    /// <summary>
    /// 中立
    /// </summary>
    Middle,
}

public class MMORPG_BaseObject_AI : MMORPG_BaseObject
{
    /// <summary>
    /// AI类型
    /// </summary>
    public AIType aIType;

    private StateMachine<MMORPG_BaseObject_AI> m_ai_stateMachine;

    /// <summary>
    /// 攻击间隔
    /// </summary>
    public float attackTime;

    /// <summary>
    /// 返回出生点  无敌免疫等
    /// </summary>
    public bool isBakcToBirth;
   

    public override void Start()
    {
        

        aIType = AIType.Enemy;
        attackTime = 0.5f;
        isBakcToBirth = false;


        setTransform(transform);
        RefreshEnemyList();
        m_ai_stateMachine = new StateMachine<MMORPG_BaseObject_AI>(this);
        m_ai_stateMachine.SetCurrentState(MMORPG_BaseObject_AI_State_Idle.Instance);
        m_ai_stateMachine.SetGlobalState(MMORPG_BaseObject_AI_State_Global.Instance);
        EntityManager.Instance.RegisterEntity(this);
        birthPos = transform.position;
    }

   public override void Update()
    {
        UpdateBuffs();   //增益Buff更新
        UpdateDeBuffs(); //减益Buff更新

        m_ai_stateMachine.FSMUpdate();//状态机更新



    }

    /// <summary>
    /// 状态机
    /// </summary>
    /// <returns></returns>
    public StateMachine<MMORPG_BaseObject_AI> AI_GetFSM()
    {
        return m_ai_stateMachine;
    }


    #region 战斗

    /// <summary>
    /// 检查追击距离
    /// </summary>
    public bool CheckChaseDistance()
    {
        if (FightObject == null)
        {
            Debug.Log("没有目标");
            return false;
        }
        else
        {
            float distance = Vector3.Distance(transform.position, FightObject.transform.position);
            if (distance < chaseDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 检查返回距离
    /// </summary>
    public bool CheckBakcDistance()
    { 
            float distance = Vector3.Distance(transform.position, birthPos);
            if (distance > backDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
    }

    /// <summary>
    /// 允许攻击
    /// </summary>
    /// <returns></returns>
    public bool AllowAttack()
    {
        attackTime -= Time.deltaTime;
        if (attackTime <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    #endregion

    public override bool HandleMessage(Telegram telegram)
    {
        return m_ai_stateMachine.HandleMessage(telegram);
    }

   
}

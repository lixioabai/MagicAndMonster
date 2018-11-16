using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MMORPG_BaseObject_Player : MMORPG_BaseObject
{
    /// <summary>
    /// 状态机
    /// </summary>
    private StateMachine<MMORPG_BaseObject_Player> myStateMachine;

    /// <summary>
    /// 是否正在使用虚拟摇杆
    /// </summary>
    public bool isET;

    /// <summary>
    /// 自动打怪
    /// </summary>
    public bool isAutoAttack;

    public override void Start()
    {
        base.Start();
        myStateMachine = new StateMachine<MMORPG_BaseObject_Player>(this);
        myStateMachine.SetCurrentState(MMORPG_BaseObject_Player_State_Idle.Instance);
        myStateMachine.SetGlobalState(MMORPG_BaseObject_Player_State_Global.Instance);

    }

    public override void Update()
    {
        base.Update();
        myStateMachine.FSMUpdate();//状态机更新
    }

    public StateMachine<MMORPG_BaseObject_Player> GetFSM()
    {
        return myStateMachine;
    }


    public override bool HandleMessage(Telegram telegram)
    {
        return myStateMachine.HandleMessage(telegram);
    }






    #region 战斗

    /// <summary>
    /// 得到离自己最近的敌人  单体伤害攻击（只打最近的敌人）
    /// </summary>
    /// <returns></returns>
    public void GetMinDistancePlayer()
    {
        RefreshEnemyList();
        GameObject attactObj = null;
        float MinDistance = Mathf.Infinity;
        for (int i = 0; i < m_enemys.Count; i++)
        {
            float currentDistance = Vector3.Distance(m_enemys[i].transform.position, transform.position);
            if (currentDistance < MinDistance)
            {
                MinDistance = currentDistance;
                attactObj = m_enemys[i];

            }
        }
            FightObject = attactObj;
    }

   
    

    /// <summary>
    /// 检查单体攻击距离
    /// </summary>
    public bool CheckAttackDistance()
    {
        GetMinDistancePlayer();
        if (FightObject == null)
        {
            Debug.Log("没有目标");
            return false;
        }
        else
        {
            float distance = Vector3.Distance(transform.position, FightObject.transform.position);
            if (distance < attackDistance)
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
    /// 刷新敌人集合
    /// </summary>
    public override void RefreshEnemyList()
    {
        base.RefreshEnemyList();
        GameObject[] arr = null;
        arr = GameObject.FindGameObjectsWithTag("Enemy");
        m_enemys.Clear();
        m_enemys = new List<GameObject>(arr);
    }


    /// <summary>
    /// 刷新在攻击范围内离敌人集合
    /// </summary>
    public List<GameObject> GetAoeAttackEnemy()
    {
        base.RefreshEnemyList();
        GameObject[] arr = null;
        arr = GameObject.FindGameObjectsWithTag("Enemy");
        m_enemys.Clear();

        for (int i = 0; i < arr.Length; i++)
        {
            if (Vector3.Distance(arr[i].transform.position, transform.position) <= attackDistance)
            {
                if (!m_enemys.Contains(arr[i]))
                {
                    m_enemys.Add(arr[i]);
                }
              
            }
        }
        return m_enemys;
    }



    



    #endregion

}

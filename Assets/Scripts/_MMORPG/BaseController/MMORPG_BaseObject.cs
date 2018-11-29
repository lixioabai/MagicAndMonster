using UnityEngine;
using System.Collections;
using System.Collections.Generic;







[RequireComponent( typeof(CharacterController))]
public class MMORPG_BaseObject : BaseGameEntity
{

    #region 公共属性参数等

    /// <summary>
    /// 旋转速度
    /// </summary>
    private float m_RotateSpeed=10;


    /// <summary>
    /// 增益Buff集合
    /// </summary>
    protected List<MMORPG_BaseBuff> m_buffs = new List<MMORPG_BaseBuff>();

    /// <summary>
    /// Buff减益集合
    /// </summary>
    protected List<MMORPG_BaseDeBuff> m_debuffs = new List<MMORPG_BaseDeBuff>();

   

    /// <summary>
    /// 敌人集合
    /// </summary>
    public List<GameObject> m_enemys = new List<GameObject>();



    /// <summary>
    /// 是否死亡
    /// </summary>
    public bool IsDie;


    /// <summary>
    /// 控制器
    /// </summary>
    public CharacterController myCapCollider;

    public Animator myAnimator;

    /// <summary>
    /// 动画器
    /// </summary>
    public Animation myAnimation;

    /// <summary>
    /// 动画状态
    /// </summary>
    public AnimatorStateInfo stateInfo;

    public bool AnimatorChanged = false;

    /// <summary>
    /// 战斗状态
    /// </summary>
    public bool isFightState = false;

    public float ExitFightTime = 20;


    //---------------------------------------------------------------
    //攻击
    /// <summary>
    /// 攻击距离
    /// </summary>
    public float attackDistance=2;

    /// <summary>
    /// 追击距离
    /// </summary>
    public float chaseDistance=10;

    /// <summary>
    /// 返回距离
    /// </summary>
    public float backDistance=20;

    /// <summary>
    /// 是否跟随玩家
    /// </summary>
    public bool FollowPlayer = false;

    /// <summary>
    /// 干架目标
    /// </summary>
    public GameObject FightObject;

    /// <summary>
    /// 移动速度
    /// </summary>
    public float MoveSpeed=10;

    /// <summary>
    /// 出生点
    /// </summary>
    public Vector3 birthPos;

    /// <summary>
    /// 攻击特效位置
    /// </summary>
    public Transform attackPos;

    #endregion


    void Awake()
    {
        IsDie = false;
        myAnimator = GetComponent<Animator>();
        myAnimation = GetComponent<Animation>();
        myCapCollider = GetComponent<CharacterController>();
        attackPos = transform.FindChild("AttackPos").GetComponent<Transform>();
    }
    public virtual void Start()
    {
        setTransform(transform);
        EntityManager.Instance.RegisterEntity(this);
    }
   public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("测试增加一个buff");
            AddDeBuff(EnumDefine.DeBuffType.Fire,10,10);
        }

        UpdateBuffs();   //增益Buff更新
        UpdateDeBuffs(); //减益Buff更新

    }
    

    #region 动画-------------------------------------------------------------------------

    public void AnimatorStateChange(string animatorCondition, bool value)
    {
        myAnimator.SetBool(animatorCondition, value);
    }
    public void AnimatorStateChange(string animatorCondition, int value)
    {
        myAnimator.SetInteger(animatorCondition, value);
    }
    public void AnimatorStateChange(string animatorCondition, float value)
    {
        myAnimator.SetFloat(animatorCondition, value);
    }
    public bool AnimatorStateGetBool(string animatorCondition)
    {
        bool f = myAnimator.GetBool(animatorCondition);
        return f;
    }

 
    public void AnimationStateChange(string animationClipName)
    {
        myAnimation.Play(animationClipName);
    }

    public void AnimationStateChange(string animationClipName,bool CrossFade)
    {
        if (myAnimation.IsPlaying(animationClipName))
        {
            return;
        }
        else
        {
            if (CrossFade)
            {
                myAnimation.CrossFade(animationClipName);
            }
            else
            {
                myAnimation.Play(animationClipName);
            }
            
        }
           
    }

    /// <summary>
    /// 判断动画是否播放完毕
    /// </summary>
    /// <param name="animationClipName"></param>
    /// <returns></returns>
    public bool AnimationIsPlayingOver(string animationClipName)
    {
        if (myAnimation[animationClipName].normalizedTime >= 0.8f)
        {
            return true;
        }
        return false;
    }

    public bool AnimationIsPlayingOver()
    {

        try
        {
            if (myAnimation[GetAnimationPlayingName()].normalizedTime >=1f)
            {
                return true;
            }
        }
        catch
        {
            return true;
        }
        return false;
    }


    public string GetAnimationPlayingName()
    {
        foreach (AnimationState a in myAnimation)
        {
            if (myAnimation.IsPlaying(a.name))
            {
                return a.name;
            }
        }
        return "";
    }
    #endregion


    #region buff-----------------------------------------------------------------

    /// <summary>
    /// 增加buff
    /// </summary>
    /// <param name="type"></param>
    /// <param name="time"></param>
    /// <param name="value"></param>
    protected void AddBuff(EnumDefine.BuffType type, float time, float value)
    {
        MMORPG_BaseBuff buff = m_buffs.Find(x => x.GetBuffType() == type);
        if (buff != null)
        {
            buff.OnInit(type, time, this, value);
        }
        else
        {
            
            MMORPG_BaseBuff instance = MMORPG_BaseBuff.GetInstance(type);
            instance.OnInit(type,time,this,value);
            this.m_buffs.Add(instance);
        }
    }

    /// <summary>
    /// 更新增益buff
    /// </summary>
    protected void UpdateBuffs()
    {
        for (int i = 0; i < m_buffs.Count; i++)
        {
            m_buffs[i].OnUpdate();
        }

        for (int j = m_buffs.Count-1; j >=0; j--)
        {
            MMORPG_BaseBuff buff = this.m_buffs[j];
            buff.m_Time -= Time.deltaTime;
            if (m_buffs[j].m_Time <= 0)
            {
                m_buffs[j].OnDestory();
                m_buffs.RemoveAt(j);
            }
        }

    }

    /// <summary>
    /// 增加减益Buff
    /// </summary>
    /// <param name="type"></param>
    /// <param name="time"></param>
    /// <param name="value"></param>
    protected void AddDeBuff(EnumDefine.DeBuffType type,float time,float value)
    {
        MMORPG_BaseDeBuff debuff = m_debuffs.Find(x => x.GetDeBuffType() == type);
        if (debuff != null)
        {
            debuff.OnInit(type, time, this, value);
        }
        else
        {

            MMORPG_BaseDeBuff instance = MMORPG_BaseDeBuff.GetInstance(type);
            instance.OnInit(type, time, this, value);
            this.m_debuffs.Add(instance);
        }
    }

    /// <summary>
    /// 更新减益buff
    /// </summary>
    protected void UpdateDeBuffs()
    {
        for (int i = 0; i < m_debuffs.Count; i++)
        {
            m_debuffs[i].OnUpdate();
        }

        for (int j = m_debuffs.Count - 1; j >= 0; j--)
        {
            MMORPG_BaseDeBuff debuff = this.m_debuffs[j];
            debuff.m_Time -= Time.deltaTime;
            if (m_debuffs[j].m_Time <= 0)
            {
                m_debuffs[j].OnDestory();
                m_debuffs.RemoveAt(j);
            }
        }

    }


    #endregion


    #region 战斗


    /// <summary>
    /// 得到离自己最近的敌人  单体伤害攻击（只打最近的敌人）
    /// </summary>
    /// <returns></returns>
    public void GetMinDistancePlayer()
    {
        FightObject = null;
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
            FightObject = attactObj;
            Debug.Log("获取最近的目标");
        }
 

    }






    /// <summary>
    /// 检查单体攻击距离
    /// </summary>
    public bool CheckAttackDistance()
    {
       // GetMinDistancePlayer();
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
    public  void RefreshEnemyList()
    {
        
        GameObject[] arr = null;
        arr = GameObject.FindGameObjectsWithTag(GetEnemyTag());
        m_enemys.Clear();
        m_enemys = new List<GameObject>(arr);
    }


    /// <summary>
    /// 刷新在攻击范围内离敌人集合
    /// </summary>
    public List<GameObject> GetAoeAttackEnemy()
    {
        
        GameObject[] arr = null;
        arr = GameObject.FindGameObjectsWithTag(GetEnemyTag());
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

    #region 通用扩展类

    /// <summary>
    /// 转向目标
    /// </summary>
    public void TurnTo(GameObject target)
    {
        if (target == null) return;
        Debug.DrawLine(target.transform.position, this.transform.position, Color.yellow);

        //lock at target Player
             transform.rotation = Quaternion.Slerp(
             myTransform.rotation,
             Quaternion.LookRotation(target.transform.position - transform.position),
             m_RotateSpeed * Time.deltaTime
        );

    }
    /// <summary>
    /// 转向目标点
    /// </summary>
    /// <param name="pos"></param>
    public void TurnTo(Vector3 pos)
    {
        Debug.DrawLine(pos, this.transform.position, Color.yellow);

        //lock at target Player
        transform.rotation = Quaternion.Slerp(
        myTransform.rotation,
        Quaternion.LookRotation(pos - transform.position),
        m_RotateSpeed * Time.deltaTime
     );

    }

    public string GetEnemyTag()
    {
        if (transform.tag == "Player")
        {
            return "Enemy";
        }
        else
        {
            return "Player";
        }
    }

    #endregion

}

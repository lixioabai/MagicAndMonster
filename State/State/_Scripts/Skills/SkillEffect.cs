/*********************************************************************************
 * FileName:    // SkillEffect
 * Description: //用于实现技能打击效果以及配合状态机进行技能数据传输。
 *              该脚本挂在特效上，特效需要有Rigidbody和Collider组件。
 *              之后在Inspector界面中调节参数实现打击效果，参数详细定义见下。
 * Date:        //2016/4/5
 * Update:        //2016/4/7
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine;
using System.Collections;
using UnityEditor;

public enum Specialeffect       //受击效果枚举
{
    Null,
    BigWind
}

public class SkillEffect : MonoBehaviour
{
    [SerializeField]
    public Specialeffect SpecialEffect;         //是否有特殊的受击效果

    [SerializeField]
    public bool IsArow;                 //是否为飞行技能特效

    [SerializeField]
    public float Arowtimes;             //飞行特效时长（最远距离）

    [SerializeField]
    public bool ArowBoom;               //飞行至最后会爆掉

    [SerializeField]
    public float FlySpeed;                 //是否为飞行速度

    [SerializeField]
    public bool IsRotate;                    //是否出现弧度

    [SerializeField]
    public bool HitOnlyOne;             //是否只打击单个目标

    [SerializeField]
    public GameObject Boom;             //爆点特效

    [SerializeField]
    public float UseCollider;           //计时结束后启用碰撞器

    [SerializeField]
    public bool ChildOf;                //是否将打到的怪物变为子物体一起移动

    [SerializeField]
    public GameObject Targer;           //吸引目标

    [SerializeField]
    public float CharmSpeed;            //吸引速率

    [SerializeField]
    public bool IsLook;                 //被击目标是否看向角色

    [SerializeField]
    public bool BeingInvincible;        //被击目标是否会处于无敌状态

    [Serializable]
    public class SkillHit
    {
        public float Times;             //消息发送时间
        public MessagesType Message;    //发送的消息
        public ForceEffect ForceE;      //该段伤害所造成的力
        public bool IsDestroy;          //打击完成后是否删除该特效
        public bool CloseCollider;      //打击完成后停止使用碰撞器
        public bool Charm;              //是否向目标点移动
        public bool UseReturn;          //当技能未命中时，返回Idle状态

        public SkillHit()
        {

        }

        public SkillHit(float times, MessagesType message, ForceEffect forcee, bool isdestroy, bool closecollider, bool charm, bool usereturn)
        {
            Times = times;
            Message = message;
            ForceE = forcee;
            IsDestroy = isdestroy;
            CloseCollider = closecollider;
            Charm = charm;
            UseReturn = usereturn;
        }
    }

    [Serializable]
    public class ForceEffect
    {
        public string ForceName;            //力的名字
        public Vector3 Direction;           //力的方向
        public float EffectTimes;           //力的作用时间

        public ForceEffect()
        {

        }

        public ForceEffect(string forcename, Vector3 direction, float effecttimes)
        {
            ForceName = forcename;
            Direction = direction;
            EffectTimes = effecttimes;
        }
    }

    [SerializeField]
    SkillHit[] skill =
        new SkillHit[1]{
            new SkillHit(0.2f,MessagesType.Msg_BeingHurt,new ForceEffect(
                "",
                new Vector3(0,0,0),
                0.1f
                ),false,false,false,false),
        };

    [HideInInspector]
    public HashSet<GameObject> enemys = new HashSet<GameObject>();         //受击敌人集合

    [HideInInspector]
    int Camb;                   //计数

    [HideInInspector]
    float times;                //计时

    [HideInInspector]
    Skills Skillinfo=new Skills();      //技能信息

    [HideInInspector]
    shuxing PlayerProperty;

    void Awake()
    {
        PlayerProperty=GameObject.FindGameObjectWithTag("Player").GetComponent<shuxing>();
        Camb = 0;
        times = skill[Camb].Times;
        //初始化数据
    }

    void Start()
    {
        try
        {
            Skillinfo = SkillInfo._Skillinstance.GetSkillInfoByld(int.Parse(this.tag));
        }
        catch
        {
            Skillinfo = null;
        }
    }

    void Update()
    {
        if (Camb > 0 && skill[Camb - 1].CloseCollider)
        {
        }
        else
        {
            UseCollider -= Time.deltaTime;
            if (UseCollider <= 0)
            {
                ChangerCollider(true);
            }
        }

        //正常受击效果
        if (SpecialEffect == Specialeffect.Null)
        {
            if (IsArow)
            {
                Arowtimes -= Time.deltaTime;
                transform.Translate(0, 0, FlySpeed * Time.deltaTime);
                if (IsRotate)
                {
                    transform.Rotate(Vector3.right * 40f * Time.deltaTime);
                }

                if (Arowtimes <= 0)
                {
                    if (Boom != null && ArowBoom)
                    {
                        Instantiate(Boom, this.transform.position, this.transform.rotation);
                    }
                    Destroy(this.gameObject);
                }
            }


            if (Camb < skill.Length)
            {
                times -= Time.deltaTime;
                if (times <= 0)
                {
                    if (Camb == skill.Length - 1 && BeingInvincible)
                    {
                        NoInvincible(enemys);
                    }
                    HitEffect(skill[Camb], enemys);
                    if (Camb < skill.Length - 1)
                    {
                        Camb++;
                        times = skill[Camb].Times;
                    }
                    else
                    {
                        times = 99999999f;
                    }
                }
            }
        }
        //特殊效果台风
        else if(SpecialEffect==Specialeffect.BigWind)
        {
            BigWindEffect();
        }
    }

    void LateUpdate()
    {
        if (Camb < skill.Length)
        {
            foreach (GameObject o in enemys)
            {
                if (o != null)
                {
                    if (skill[Camb].Charm)          //将敌人向Targer移动
                    {
                        o.transform.position = Vector3.Lerp(o.transform.position, Targer.transform.position, CharmSpeed);
                    }

                    if (Camb == skill.Length - 1 && ChildOf && o.transform.parent == this.transform)   //将子物体的怪物释放
                    {

                        o.transform.parent = null;
                    }
                }
            }
        }
    }

    void BigWindEffect()
    {
        times -= Time.deltaTime;
        foreach (GameObject o in enemys)
        {
            if (Camb == skill.Length - 1 && times >99f)
            {

            }
            else
            {
                o.transform.LookAt(new Vector3(this.transform.position.x, o.transform.position.y, this.transform.position.z));
                o.transform.RotateAround(this.transform.position, Vector3.down, 500 * Time.deltaTime);
                o.GetComponent<RPGMotor>().AddForce("Fukong", new Vector3(0, 13f, 0), Vector3.zero, 0.1f);
            }
            if (times <= 0)
            {
                if (Skillinfo == null)
                {
                    MessageDispatcher.Instance.DispatchMessage(0, this.transform, o.transform, (int)skill[Camb].Message, EntityManager.Instance.GetEntityFromTransform(this.transform), PlayerProperty.Attack1, Buff.Null);
                }
                else
                {
                    MessageDispatcher.Instance.DispatchMessage(0, this.transform, o.transform, (int)skill[Camb].Message, EntityManager.Instance.GetEntityFromTransform(this.transform), Skillinfo.hitnum, Skillinfo.buff);
                }
            }
        }
        if (times <= 0)
        {
            if (Camb < skill.Length - 1)
            {
                Camb++;
                times = skill[Camb].Times;
            }
            else
            {
                times = 99999999f;
            }
        }
    }       //女法师台风特殊效果

    void NoInvincible(HashSet<GameObject> allenemy)         //将设置为无敌的敌人恢复
    {
        foreach (GameObject o in allenemy)
        {
            o.GetComponent<RPGMotor>().enabled = true;
            o.GetComponent<CapsuleCollider>().enabled = true;
        }
    }

    public void HitEffect(SkillHit skills, HashSet<GameObject> Gameobjects)   //打击效果实现
    {
        if (skills.UseReturn && enemys.Count == 0)      //做投技时用于返回到初始状态
        {
            MessageDispatcher.Instance.DispatchMessage(0, this.transform, GameObject.FindGameObjectWithTag("Player").transform, (int)MessagesType.Player_Idle, EntityManager.Instance.GetEntityFromTransform(this.transform), 1f, Buff.Null);
            ChangerCollider(false);
            Destroy(this.gameObject, 0.2f);
        }
        foreach (GameObject o in enemys)
        {
            if (o != null)
            {
                if (Boom != null)       //若Boom不为空，生成特效
                {
                    Instantiate(Boom, new Vector3(o.transform.position.x, o.transform.position.y + 1f, o.transform.position.z), o.transform.rotation);
                }
                if (Skillinfo == null)
                {
                    MessageDispatcher.Instance.DispatchMessage(0, this.transform, o.transform, (int)skills.Message, EntityManager.Instance.GetEntityFromTransform(this.transform), PlayerProperty.Attack1, Buff.Null);
                }
                else
                {
                    MessageDispatcher.Instance.DispatchMessage(0, this.transform, o.transform, (int)skills.Message, EntityManager.Instance.GetEntityFromTransform(this.transform), Skillinfo.hitnum, Skillinfo.buff);
                }
                //传递消息，造成打击效果
                Vector3 dir = GameObject.FindGameObjectWithTag("player").transform.TransformPoint(skills.ForceE.Direction);
                dir = o.transform.InverseTransformPoint(dir);
                o.GetComponent<RPGMotor>().AddForce(skills.ForceE.ForceName, dir, Vector3.zero, skills.ForceE.EffectTimes);
                //对目标添加力的作用
                if (skills.IsDestroy)           //打击完成后删除该特效
                {
                    Destroy(this.gameObject);
                }
                if (skills.CloseCollider)       //打击完成后停用该碰撞体
                {
                    ChangerCollider(false);
                }
                //if (ChildOf)                    //被击的敌人成为子物体
                //{
                //    o.transform.parent = this.transform;
                //}
            }
        }
    }

    public void ChangerCollider(bool change)            //启用或停用碰撞盒
    {
        try
        {
            this.GetComponent<BoxCollider>().enabled = change;
        }
        catch
        {
            try
            {
                this.GetComponent<CapsuleCollider>().enabled = change;
            }
            catch
            {
                try
                {
                    this.GetComponent<SphereCollider>().enabled = change;
                }
                catch
                {
                    this.GetComponent<MeshCollider>().enabled = change;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)          //添加受击敌人到集合中
    {
        if (other.tag == "Terrain" || other.tag == "Obstacles")
        {
            if (IsArow)
            {
                if (Boom != null && ArowBoom)
                {
                    Instantiate(Boom, this.transform.position, other.transform.rotation);
                }
                Destroy(this.gameObject);
            }
        }
        if (other.tag == "enemy")
        {
            if (IsArow)
            {
                if (Boom != null)
                {
                    Instantiate(Boom, new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), other.transform.rotation);
                }
                    if (Skillinfo == null)
                    {
                        MessageDispatcher.Instance.DispatchMessage(0, this.transform, other.transform, (int)skill.First<SkillHit>().Message, EntityManager.Instance.GetEntityFromTransform(this.transform), PlayerProperty.Attack1, Buff.Null);
                    }
                    else
                    {
                        MessageDispatcher.Instance.DispatchMessage(0, this.transform, other.transform, (int)skill.First<SkillHit>().Message, EntityManager.Instance.GetEntityFromTransform(this.transform), Skillinfo.hitnum, Skillinfo.buff);
                    }
                Destroy(this.gameObject);
            }
            else
            {
                if (HitOnlyOne && enemys.Count > 0)
                {
                }
                else
                {
                    if (ChildOf)                    //被击的敌人成为子物体
                    {
                        other.transform.parent = this.transform;
                    }
                    enemys.Add(other.gameObject);
                    if (IsLook)
                    {
                        other.transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, other.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z));
                    }
                    if (HitOnlyOne)
                    {
                        ChangerCollider(false);
                    }
                    if (BeingInvincible)
                    {
                        other.GetComponent<RPGMotor>().enabled = false;
                        other.GetComponent<CapsuleCollider>().enabled = false;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (enemys != null)
        {
            foreach (GameObject o in enemys)
            {
                if (other.gameObject == o)
                {
                    other.transform.parent = null;
                    enemys.Remove(o);
                    break;
                }
            }
        }
    }       //将子物体的敌人离开时释放
}







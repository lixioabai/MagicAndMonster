using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Player : BaseGameEntity 
{
    public HashSet<GameObject> enemys=new HashSet<GameObject>();

    public bool SuperArmor=false;

    public shuxing Property;
    public bool canatt;
    public float flyhigh;
    CapsuleCollider myCapCollider;
    public int attnum;
    public float times;
    public bool isskilling=false;
    public bool isPasive = false;
    public GameObject player;
    public toujicamera touji;
    StateMachine<Player> myStateMachine;
    public RPGMotor mymotor;
    Transform cameraTransform;
    public Animator myAnimator;
    public AnimatorStateInfo stateInfo;
    public bool AnimatorChanged=false;
    public float FlashCD = 2f;

    void Awake()
    {
        Property=this.GetComponent<shuxing>();
        attnum = 0;

        touji = Camera.main.GetComponent<toujicamera>();
        player=this.transform.parent.gameObject;
        mymotor=this.transform.parent.GetComponent<RPGMotor>();
        myAnimator=GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        myCapCollider = GetComponent<CapsuleCollider>();
    }
	void Start () {
        canatt = true;
        setTransform(transform);
        myStateMachine = new StateMachine<Player>(this);
        myStateMachine.SetCurrentState(Player_StateMove.Instance);
        myStateMachine.SetGlobalState(Player_GlobalState.Instance);
        EntityManager.Instance.RegisterEntity(this);
	}
	void Update () {
        if (AnimatorStateGetBool(PlayerAnimatorCondition.Isup))
        {
            myCapCollider.direction=1;
            myCapCollider.center= new Vector3(0, 0.7f, 0);
        }
        else
        {
            myCapCollider.direction = 2;
            myCapCollider.center = new Vector3(0, 0, 0);
        }

        FlashCD -= Time.deltaTime;
        stateInfo = myAnimator.GetCurrentAnimatorStateInfo(0);
        myStateMachine.FSMUpdate();
        if(mymotor.IsTouchingGround)
        {
            mymotor.gravityEnabled = false;
            myAnimator.SetBool("isair",false);
            canatt = true;
        }
        else
        {
            mymotor.gravityEnabled = true;
            myAnimator.SetBool("isair",true);
            canatt = false;
        }
	}
    public StateMachine<Player> GetFSM()
    {
        return myStateMachine;
    }
    public void AnimatorStateChange(string animatorCondition,bool value)
    {
        myAnimator.SetBool(animatorCondition, value);
    }
    public void AnimatorStateChange(string animatorCondition,int value)
    {
        myAnimator.SetInteger(animatorCondition,value);
    }
    public void AnimatorStateChange(string animatorCondition,float value)
    {
        myAnimator.SetFloat(animatorCondition,value);
    }
    public override bool HandleMessage(Telegram telegram)
    {
        return myStateMachine.HandleMessage(telegram);
    }
    public bool AnimatorStateGetBool(string animatorCondition)
    {
        bool f = myAnimator.GetBool(animatorCondition);
        return f;
    }
    public void EnemyParent(HashSet<GameObject> es)
    {
        foreach (GameObject o in es)
        {
            if (o != null)
            {
                o.transform.parent = null;
            }
        }
        es.Clear();
    }
}

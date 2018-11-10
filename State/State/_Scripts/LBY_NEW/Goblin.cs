using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Goblin : BaseGameEntity
{
    public DisplayerHurt ShowHurt;


    public bool IsDie;
    public shuxing Property;
    public  float flyhigh = 0;                              //浮空值
    public float times;
    public bool IsFrozen = false;
    StateMachine<Goblin> myStateMachine;
    Transform cameraTramsform;

    CapsuleCollider myCapCollider;

    public RPGMotor motor;
    public Animator myAnimator;
    public AnimatorStateInfo stateInfo;
    public bool AnimatorChanged = false;
    public float FlashCD = 5f;
    void Awake()
    {
        ShowHurt=this.GetComponent<DisplayerHurt>();
        IsDie = false;
        Property=this.GetComponent<shuxing>();
        motor=GetComponent<RPGMotor>();
        myAnimator=GetComponent<Animator>();
        cameraTramsform = Camera.main.transform;
        myCapCollider=GetComponent<CapsuleCollider>();
    }
    void Start()
    {
        setTransform(transform);
        myStateMachine = new StateMachine<Goblin>(this);
        myStateMachine.SetCurrentState(Goblin_StateIdle.Instance);
        myStateMachine.SetGlobalState(Goblin_GlobalState.Instance);
        EntityManager.Instance.RegisterEntity(this);
    }
    void Update()
    {
        if (AnimatorStateGetBool(GBAnimatorCondition.Isup))
        {
            myCapCollider.direction=1;
            myCapCollider.center= new Vector3(0, 0.7f, 0);
        }
        else
        {
            myCapCollider.direction = 2;
            myCapCollider.center =new Vector3(0,0,0);
        }
        FlashCD -= Time.deltaTime;
        stateInfo = myAnimator.GetCurrentAnimatorStateInfo(0);
        myStateMachine.FSMUpdate();
    }
    public StateMachine<Goblin>GetFSM()
    {
        return myStateMachine;
    }
    public void AnimatorStateChange(string animatorCondition,bool value)
    {
        myAnimator.SetBool(animatorCondition,value);
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
    public override bool HandleMessage(Telegram telegram)
    {
        return myStateMachine.HandleMessage(telegram);
    }
}

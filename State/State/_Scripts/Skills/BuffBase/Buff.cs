using UnityEngine;
using System.Collections;

public class BuffBase : BaseGameEntity
{
    public bool IsSuperArmor;
    private shuxing Info;
    StateMachine<BuffBase> buffStateMachine;
    void Awake()
    {
        Info=this.GetComponent<shuxing>();
    }
    void Start ()
    {
        buffStateMachine = new StateMachine<BuffBase>(this);
    }
    void Update ()
    {

    }
    public StateMachine<BuffBase> GetFSM()
    {
        return buffStateMachine;
    }
}

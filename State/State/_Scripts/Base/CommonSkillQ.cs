using UnityEngine;
using System.Collections;
using Colorful;

public class WKnightSkillQ:State<Player>
{
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static WKnightSkillQ instance;
    public static WKnightSkillQ Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new WKnightSkillQ();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false ;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling,5f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Knight_W_Effect.Knight_WQ, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
        entity.mymotor.AddForce("KnightSkillQ", new Vector3(0, 0, 7f), Vector3.zero, 1.6f);
    }
    public override void Execute(Player entity)
    {;
        if(entity.stateInfo.IsName(WKnightSkillQ.animatorStateName))
        {
            if(entity.stateInfo.normalizedTime>=0.8f)
            {
                entity.isskilling = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WKnightSkillQ.animatorStateName))
            {
                entity.GetFSM().ChangeState(WKnightSkillQ.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        if (entity.transform.parent.GetComponentInChildren<SkillEffect>().enemys.Count > 0)
        {
            entity.EnemyParent(entity.transform.parent.GetComponentInChildren<SkillEffect>().enemys);
        }
        entity.mymotor.RemoveForce("KnightSkillQ");
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        Object.Destroy(Effect);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WMasterSkillQ : State<Player>
{
    private GameObject Effect;
    bool attonce;
    //private CharacterController player;
    //private Vector3 moveDirection=Vector3.zero;
    public static string animatorStateName = "skills";
    private static WMasterSkillQ instance;
    public static WMasterSkillQ Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WMasterSkillQ();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        attonce = true;
        entity.isskilling = true;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled = false;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 5f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        //Effect = (GameObject)Object.Instantiate(Master_W_Effect.Master_WQ, entity.player.transform.position, entity.player.transform.rotation);
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WMasterSkillQ.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.3f&&attonce)
            {
                Effect = (GameObject)Object.Instantiate(Master_W_Effect.Master_WQ, entity.player.transform.position, entity.player.transform.rotation);
                attonce = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.8f)
            {
                entity.isskilling = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WMasterSkillQ.animatorStateName))
            {
                entity.GetFSM().ChangeState(WMasterSkillQ.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class MMinisterSkillQ : State<Player>
{
    private GameObject Effect;
    float times = 1.8f;
    bool attonce;
    //private CharacterController player;
    //private Vector3 moveDirection=Vector3.zero;
    public static string animatorStateName = "skills";
    private static MMinisterSkillQ instance;
    public static MMinisterSkillQ Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMinisterSkillQ();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        times = 1.8f;
        attonce = true;
        entity.isskilling = true;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled = false;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 5f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_MQ, entity.player.transform.position, entity.player.transform.rotation);
    }
    public override void Execute(Player entity)
    {
        times -= Time.deltaTime;
        if (entity.stateInfo.IsName(WMasterSkillQ.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.3f && attonce)
            {
                attonce = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.8f)
            {
                entity.isskilling = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(MMinisterSkillQ.animatorStateName))
            {
                entity.GetFSM().ChangeState(MMinisterSkillQ.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
        if(times>=0)
        {
            Object.Destroy(Effect);
        }
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WEtherSkillQ : State<Player>
{
    private GameObject Effect;
    float times;
    public static string animatorStateName = "skills";
    private static WEtherSkillQ instance;
    public static WEtherSkillQ Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WEtherSkillQ();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        times = 0.7f;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 5f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_MQ, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
        entity.mymotor.AddForce("WEtherSkillQ", new Vector3(0, 0, 8f), Vector3.zero, 0.9f);
    }
    public override void Execute(Player entity)
    {
        times -= Time.deltaTime;
        if (entity.stateInfo.IsName(WEtherSkillQ.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.8f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.5f)
            {
                entity.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WEtherSkillQ.animatorStateName))
            {
                entity.GetFSM().ChangeState(WEtherSkillQ.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isskilling = false;
        if(times<=0)
        {
            Effect.transform.parent = null;
        }
        else
        {
            entity.mymotor.RemoveForce("WEtherSkillQ");
            Object.Destroy(Effect);
        }
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.GetComponent<CapsuleCollider>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WTeanaSkillQ : State<Player>
{
    private GameObject Effect;
    float times;
    public static string animatorStateName = "skills";
    private static WTeanaSkillQ instance;
    public static WTeanaSkillQ Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WTeanaSkillQ();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        times = 1.5f;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 5f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WQ, entity.player.transform.position, entity.player.transform.rotation);
    }
    public override void Execute(Player entity)
    {
        times -= Time.deltaTime;
        if (entity.stateInfo.IsName(WTeanaSkillQ.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.8f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.5f)
            {
                entity.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WTeanaSkillQ.animatorStateName))
            {
                entity.GetFSM().ChangeState(WTeanaSkillQ.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isskilling = false;
        if (times > 0)
        {
            Object.Destroy(Effect);
        }
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.GetComponent<CapsuleCollider>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}
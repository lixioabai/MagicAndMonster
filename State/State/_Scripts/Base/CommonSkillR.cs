using UnityEngine;
using System.Collections;

public class WKnightSkillR : State<Player>
{
    private GameObject Effect;
    private float times;
    //private CharacterController player;
    public static string animatorStateName = "skills";
    private static WKnightSkillR instance;
    public static WKnightSkillR Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WKnightSkillR();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        times = 1.6f;
        entity.isskilling = true;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled = false;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 3f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Knight_W_Effect.Knight_WR, entity.player.transform.position, entity.player.transform.rotation);
    }
    public override void Execute(Player entity)
    {
        times -= Time.deltaTime;
        if (entity.stateInfo.IsName(WKnightSkillR.animatorStateName))
        {
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
            if (entity.stateInfo.IsName(WKnightSkillR.animatorStateName))
            {
                entity.GetFSM().ChangeState(WKnightSkillR.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        if(times>=0)
        {
            Object.Destroy(Effect);
        }
        else
        {
            Object.Destroy(Effect,1.3f);
        }
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        //player.GetComponent<PlayerMovement>().enabled = true;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WMastertSkillR : State<Player>
{
    private GameObject Effect;
    //private CharacterController player;
    public static string animatorStateName = "skills";
    private static WMastertSkillR instance;
    float times;
    public static WMastertSkillR Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WMastertSkillR();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        times = 0.7f;
        entity.isskilling = true;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled = false;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 3f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Master_W_Effect.Master_WR, entity.player.transform.position, entity.player.transform.rotation);
        Object.Destroy(Effect, 3.5f);
    }
    public override void Execute(Player entity)
    {
        times -= Time.deltaTime;
        if(times<=0)
        {
            entity.GetComponent<CapsuleCollider>().enabled = false;
        }
        if (entity.stateInfo.IsName(WMastertSkillR.animatorStateName))
        {
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
            if (entity.stateInfo.IsName(WMastertSkillR.animatorStateName))
            {
                entity.GetFSM().ChangeState(WMastertSkillR.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = true;
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        //player.GetComponent<PlayerMovement>().enabled = true;
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

public class MMinisterSkillR : State<Player>
{
    private GameObject Effect;
    //private CharacterController player;
    public static string animatorStateName = "skills";
    private static MMinisterSkillR instance;
    public static MMinisterSkillR Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMinisterSkillR();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.isskilling = true;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled = false;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 3f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_MR, entity.player.transform.position, entity.player.transform.rotation);
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WMastertSkillR.animatorStateName))
        {
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
            if (entity.stateInfo.IsName(MMinisterSkillR.animatorStateName))
            {
                entity.GetFSM().ChangeState(MMinisterSkillR.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = true;
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        //player.GetComponent<PlayerMovement>().enabled = true;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WEtherSkillR : State<Player>
{
    private GameObject Effect;
    public static string animatorStateName = "skills";
    bool canmove;
    private static WEtherSkillR instance;
    public static WEtherSkillR Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WEtherSkillR();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        canmove = true;
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 3f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_MR, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        entity.mymotor.Yaw(Input.GetAxisRaw("Mouse X") * Time.smoothDeltaTime * 40f);
        if (entity.stateInfo.IsName(WEtherSkillR.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.8f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.1f&&canmove)
            {
                entity.mymotor.AddForce("WEtherSkillR", new Vector3(0, 0, 10f), Vector3.zero, 2.2f);
                canmove = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WEtherSkillR.animatorStateName))
            {
                entity.GetFSM().ChangeState(WEtherSkillR.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = true;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WTeanaSkillR : State<Player>
{
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static WTeanaSkillR instance;
    public static WTeanaSkillR Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WTeanaSkillR();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 3f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WR, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WTeanaSkillR.animatorStateName))
        {
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
            if (entity.stateInfo.IsName(WTeanaSkillR.animatorStateName))
            {
                entity.GetFSM().ChangeState(WTeanaSkillR.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = true;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}
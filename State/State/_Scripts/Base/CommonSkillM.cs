using UnityEngine;
using System.Collections;

public class WKnightSkillM : State<Player>
{
    private Vector3 v1;
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static WKnightSkillM instance;
    public static WKnightSkillM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WKnightSkillM();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isskilling = true;
        v1 = new Vector3(entity.player.transform.position.x, entity.player.transform.position.y + 1f, entity.player.transform.position.z);
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 4f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName,-1,0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        entity.player.GetComponent<RPGInput>().enabled = false;
        Effect = (GameObject)Object.Instantiate(Knight_W_Effect.Knight_WMouse1, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WKnightSkillQ.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.79f && entity.stateInfo.normalizedTime <= 0.80f)
            {
                Object.Instantiate(Knight_W_Effect.Knight_WBoomArrow, v1, Camera.main.transform.rotation);
            }
            if (entity.stateInfo.normalizedTime >= 0.85f)
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
            if (entity.stateInfo.IsName(WKnightSkillM.animatorStateName))
            {
                entity.GetFSM().ChangeState(WKnightSkillM.Instance);
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
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        Object.Destroy(Effect);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WMasterSkillM : State<Player>
{
    private Vector3 v1;
    private bool canmove;
    private GameObject Effect;
    float times;
    public static string animatorStateName = "skills";
    private static WMasterSkillM instance;
    public static WMasterSkillM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WMasterSkillM();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        times = 0.4f;
        canmove = true;
        entity.isskilling = true;
        v1 = new Vector3(entity.player.transform.position.x, entity.player.transform.position.y + 1f, entity.player.transform.position.z);
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 4f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Master_W_Effect.Master_WMouse1, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
        entity.player.GetComponent<RPGInput>().enabled = false;
    }
    public override void Execute(Player entity)
    {
        times -= Time.deltaTime;
        if (entity.stateInfo.IsName(WMasterSkillM.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.3f &&canmove)
            {
                entity.mymotor.AddForce("MasterSkillF", new Vector3(0, 0, -20f), Vector3.zero, 0.8f);
                canmove = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.85f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.4f)
            {
                Effect.transform.parent = null;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WMasterSkillM.animatorStateName))
            {
                entity.GetFSM().ChangeState(WMasterSkillM.Instance);
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
        entity.mymotor.RemoveForce("MasterSkillF");
        entity.isskilling = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class MMinisterSkillM : State<Player>
{
    private Vector3 v1;
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static MMinisterSkillM instance;
    public static MMinisterSkillM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMinisterSkillM();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isskilling = true;
        v1 = new Vector3(entity.player.transform.position.x, entity.player.transform.position.y + 1f, entity.player.transform.position.z);
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 4f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_MM, entity.player.transform.position, entity.player.transform.rotation);
        entity.player.GetComponent<RPGInput>().enabled = false;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WMasterSkillM.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.85f)
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
            if (entity.stateInfo.IsName(MMinisterSkillM.animatorStateName))
            {
                entity.GetFSM().ChangeState(MMinisterSkillM.Instance);
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
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WEtherSkillM : State<Player>
{
    private Vector3 v1;
    private GameObject Effect;
    bool canmove;
    public static string animatorStateName = "skills";
    private static WEtherSkillM instance;
    public static WEtherSkillM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WEtherSkillM();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        canmove = true;
        entity.GetComponent<CapsuleCollider>().enabled = false;
        
        entity.isskilling = true;
        v1 = new Vector3(entity.player.transform.position.x, entity.player.transform.position.y + 1f, entity.player.transform.position.z);
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 4f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_MM, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
        entity.player.GetComponent<RPGInput>().enabled = false;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WEtherSkillM.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.85f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.2f && canmove)
            {
                entity.mymotor.AddForce("WEtherSkillM", new Vector3(0, 0, 20f), Vector3.zero, 1f);
                entity.mymotor.AddForce("WEtherSkillM_1", new Vector3(0, 25f, 0), Vector3.zero, 0.6f);
                canmove = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WEtherSkillM.animatorStateName))
            {
                entity.GetFSM().ChangeState(WEtherSkillM.Instance);
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
        Effect.transform.parent = null;
        entity.isskilling = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WTeanaSkillM : State<Player>
{
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static WTeanaSkillM instance;
    public static WTeanaSkillM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WTeanaSkillM();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = false;

        entity.isskilling = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 4f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WM, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
        entity.player.GetComponent<RPGInput>().enabled = false;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WTeanaSkillM.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.85f)
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
            if (entity.stateInfo.IsName(WTeanaSkillM.animatorStateName))
            {
                entity.GetFSM().ChangeState(WTeanaSkillM.Instance);
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
        Effect.transform.parent = null;
        entity.isskilling = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}
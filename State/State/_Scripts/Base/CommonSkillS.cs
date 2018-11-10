using UnityEngine;
using System.Collections;

public class WKnightSkillS : State<Player>
{
    private GameObject Effect;
    //private CharacterController player;
    private Vector3 moveDirection = Vector3.zero;
    public static string animatorStateName = "skills";
    private static WKnightSkillS instance;
    public static WKnightSkillS Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WKnightSkillS();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isskilling = true;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled=false;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 2f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Knight_W_Effect.Knight_WSpace, entity.player.transform.position, entity.player.transform.rotation);
        Object.Destroy(Effect,3f);
        entity.mymotor.AddForce("KnightSkillS", new Vector3(0, 5f, -30f), Vector3.zero, 0.7f);
    }
    public override void Execute(Player entity)
    {
        moveDirection.y -= 60f * Time.deltaTime;
        moveDirection.z = -7f;
        if (entity.stateInfo.IsName(animatorStateName))
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
            if (entity.stateInfo.IsName(WKnightSkillS.animatorStateName))
            {
                entity.GetFSM().ChangeState(WKnightSkillS.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.mymotor.RemoveForce("KnightSkillS");
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WMasterSkillS : State<Player>
{
    private GameObject Effect;
    //private CharacterController player;
    private Vector3 moveDirection = Vector3.zero;
    public static string animatorStateName = "skills";
    private static WMasterSkillS instance;
    public static WMasterSkillS Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WMasterSkillS();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled=false;
        entity.mymotor.MovementSpeed = 12f;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 2f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Master_W_Effect.Master_WE, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        entity.mymotor.MovementInput.z += 1f;
        entity.mymotor.Yaw(Input.GetAxisRaw("Mouse X") * Time.smoothDeltaTime * 40f);
        moveDirection.y -= 60f * Time.deltaTime;
        moveDirection.z = -7f;
        if (entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.8f)
            {
                entity.mymotor.MovementSpeed = 4f;
                entity.isskilling = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WMasterSkillS.animatorStateName))
            {
                entity.GetFSM().ChangeState(WMasterSkillS.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.mymotor.MovementSpeed = 4f;
        entity.isskilling = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
        Object.Destroy(Effect);
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class MMinisterSkillS : State<Player>
{
    private GameObject Effect;
    //private CharacterController player;
    public static string animatorStateName = "skills";
    private static MMinisterSkillS instance;
    public static MMinisterSkillS Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMinisterSkillS();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled=false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 2f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_ME, entity.player.transform.position, entity.player.transform.rotation);
        //Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(animatorStateName))
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
            if (entity.stateInfo.IsName(MMinisterSkillS.animatorStateName))
            {
                entity.GetFSM().ChangeState(MMinisterSkillS.Instance);
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

public class WEtherSkillS : State<Player>
{
    private GameObject Effect;
    bool canmove;
    public static string animatorStateName = "skills";
    private static WEtherSkillS instance;
    public static WEtherSkillS Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WEtherSkillS();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        canmove = true;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.GetComponent<CapsuleCollider>().enabled = false;
        //player = GameObject.FindGameObjectWithTag(Global.Player).GetComponent<CharacterController>();
        //player.GetComponent<PlayerMovement>().enabled=false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 2f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_ME, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.8f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.1f&&canmove)
            {
                entity.mymotor.AddForce("WEtherSkillS", new Vector3(0, 0, 20f), Vector3.zero, 0.8f);
                canmove = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WEtherSkillS.animatorStateName))
            {
                entity.GetFSM().ChangeState(WEtherSkillS.Instance);
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
        entity.GetComponent<CapsuleCollider>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WTeanaSkillS : State<Player>
{
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static WTeanaSkillS instance;
    public static WTeanaSkillS Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WTeanaSkillS();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 2f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WE, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(animatorStateName))
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
            if (entity.stateInfo.IsName(WTeanaSkillS.animatorStateName))
            {
                entity.GetFSM().ChangeState(WTeanaSkillS.Instance);
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
        entity.GetComponent<CapsuleCollider>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}



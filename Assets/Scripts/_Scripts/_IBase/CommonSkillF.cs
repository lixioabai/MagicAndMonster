using UnityEngine;
using System.Collections;

public class WKnightSkillF : State<Player>
{
    bool cantiao = true;
    private GameObject Effect;
    //private CharacterController player;
    public static string animatorStateName = "skills";
    private static WKnightSkillF instance;
    private Vector3 moveDirection = Vector3.zero;
    public static WKnightSkillF Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WKnightSkillF();
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
        entity.touji.istouji= true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 6f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Knight_W_Effect.Knight_WF, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        moveDirection.y -= 60f * Time.deltaTime;
        moveDirection.z = -1f;
        if (entity.stateInfo.IsName(WKnightSkillF.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.7f&&cantiao)
            {
                entity.mymotor.AddForce("KnightSkillF", new Vector3(0, 0, -5f), Vector3.zero, 0.5f);
                cantiao = false;
                //player.Move(player.transform.TransformDirection(moveDirection) * Time.deltaTime * 1f);
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
                entity.isskilling = false;
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WKnightSkillF.animatorStateName))
            {
                entity.GetFSM().ChangeState(WKnightSkillF.Instance);
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
        entity.touji.istouji = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        //player.GetComponent<PlayerMovement>().enabled = true;
        entity.player.GetComponent<RPGInput>().enabled = true;
        Effect.GetComponent<BoxCollider>().enabled = false;
        Object.Destroy(Effect, 0.5f);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
        cantiao = true;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        
        if (telegram.Msg == (int)MessagesType.Player_Idle)
        {
            //Object.Destroy(Effect);
            //entity.GetFSM().ChangeState(Player_StateMove.Instance);
            entity.myAnimator.Play(Player_StateMove.animatorStateName);
            //entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
            //entity.AnimatorChanged = false;
            return true;
        }
        return false;
    }
}

public class WMasterSkillF : State<Player>
{
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static WMasterSkillF instance;
    private Vector3 moveDirection = Vector3.zero;
    public static WMasterSkillF Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WMasterSkillF();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 6f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Master_W_Effect.Master_WF, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WMasterSkillF.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.9f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.2f)
            {
                entity.touji.istouji = true;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WMasterSkillF.animatorStateName))
            {
                entity.GetFSM().ChangeState(WMasterSkillF.Instance);
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
        entity.touji.istouji = false;
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        Object.Destroy(Effect);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {

        if (telegram.Msg == (int)MessagesType.Player_Idle)
        {
            entity.myAnimator.Play(Player_StateMove.animatorStateName);
            return true;
        }
        return false;
    }
}

public class MMinisterSkillF : State<Player>
{
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static MMinisterSkillF instance;
    private Vector3 moveDirection = Vector3.zero;
    public static MMinisterSkillF Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMinisterSkillF();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 6f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_MF, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(MMinisterSkillF.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.9f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.15f)
            {
                entity.touji.istouji = true;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(MMinisterSkillF.animatorStateName))
            {
                entity.GetFSM().ChangeState(MMinisterSkillF.Instance);
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
        entity.touji.istouji = false;
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        Object.Destroy(Effect);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {

        if (telegram.Msg == (int)MessagesType.Player_Idle)
        {
            entity.myAnimator.Play(Player_StateMove.animatorStateName);
            return true;
        }
        return false;
    }
}

public class WEtherSkillF : State<Player>
{
    private GameObject Effect;
    bool canmove1;
    bool canmove2;
    public static string animatorStateName = "skills";
    private static WEtherSkillF instance;
    private Vector3 moveDirection = Vector3.zero;
    public static WEtherSkillF Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WEtherSkillF();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        canmove1 = true;
        canmove2 = true;
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 6f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_MF, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WEtherSkillF.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.9f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.5f&&canmove1)
            {
                entity.mymotor.AddForce("WEtherSkillF2", new Vector3(0, 0, 15f), Vector3.zero, 0.8f);
                entity.mymotor.AddForce("WEtherSkillF3", new Vector3(0, 30f, 0), Vector3.zero, 0.4f);
                canmove1 = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.3f && canmove2)
            {
                entity.mymotor.AddForce("WEtherSkillF1", new Vector3(0, 0, 5f), Vector3.zero, 0.3f);
                canmove2 = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.15f)
            {
                entity.touji.istouji = true;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WEtherSkillF.animatorStateName))
            {
                entity.GetFSM().ChangeState(WEtherSkillF.Instance);
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
        entity.touji.istouji = false;
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        Object.Destroy(Effect);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {

        if (telegram.Msg == (int)MessagesType.Player_Idle)
        {
            entity.myAnimator.Play(Player_StateMove.animatorStateName);
            return true;
        }
        return false;
    }
}

public class WTeanaSkillF : State<Player>
{
    private GameObject Effect;
    public static string animatorStateName = "skills";
    private static WTeanaSkillF instance;
    private Vector3 moveDirection = Vector3.zero;
    public static WTeanaSkillF Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WTeanaSkillF();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 6f);
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, true);
        }
        Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WF, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(WTeanaSkillF.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.9f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.15f)
            {
                entity.touji.istouji = true;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(WTeanaSkillF.animatorStateName))
            {
                entity.GetFSM().ChangeState(WTeanaSkillF.Instance);
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
        entity.touji.istouji = false;
        entity.isskilling = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        Object.Destroy(Effect);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsSkill, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {

        if (telegram.Msg == (int)MessagesType.Player_Idle)
        {
            entity.myAnimator.Play(Player_StateMove.animatorStateName);
            return true;
        }
        return false;
    }
}


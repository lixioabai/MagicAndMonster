using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_StateMove : State<Player>
{
    public static string animatorStateName = "movement";
    bool att;
    private static Player_StateMove instance;
    public static Player_StateMove Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateMove();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.attnum = 0;
        att = true;
        //entity.AnimatorStateChange(PlayerAnimatorCondition.IsMove, true);
    }
    public override void Execute(Player entity)
    {
        entity.AnimatorStateChange(PlayerAnimatorCondition.FwordAndBack, Input.GetAxis("Vertical"));
        entity.AnimatorStateChange(PlayerAnimatorCondition.LeftAndRight, Input.GetAxis("Horizontal"));
        if (Input.GetMouseButton(0)&&entity.canatt&&att&&!entity.isskilling)
        {
            entity.GetFSM().ChangeState(Player_StateAtt.Instance);
            att = false;
        }
        //else if (((Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)) || (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))) && entity.FlashCD <= 0)
        ////else if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    entity.GetFSM().ChangeState(Player_StateFlash.Instance);
        //    entity.FlashCD = 2f;
        //}
    }
    public override void Exit(Player entity)
    {
        entity.AnimatorStateChange(PlayerAnimatorCondition.FwordAndBack, 0f);
        entity.AnimatorStateChange(PlayerAnimatorCondition.LeftAndRight,0f);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsMove, false);
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}
public class Player_StateFlash:State<Player>
{
    public static string animatorStateName = "Flash";
    private float shanh = 0f;
    private float shans = 0f;
    private float gravit = 60.0f;
    private float y = 0;
    private static Player_StateFlash instance;
    public static Player_StateFlash Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateFlash();
            }
            return instance;
        }
    }

    public override void Enter(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false ;
        entity.AnimatorStateChange(PlayerAnimatorCondition.FwordAndBack, 0f);
        entity.AnimatorStateChange(PlayerAnimatorCondition.LeftAndRight, 0f);
        y -= gravit * Time.deltaTime;
        entity.myAnimator.Play(animatorStateName, -1, 0);
        if (Input.GetAxis("Horizontal") > 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.FlashF, 2.0f);
            shanh = 30f;
            shans = 0f;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.FlashF, 1.0f);
            shanh = -30f;
            shans = 0f;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.FlashF, 0.0f);
            shanh = 0f;
            shans = 30f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.FlashF, 3.0f);
            shanh = 0f;
            shans = -30f;
        }
        entity.mymotor.AddForce("Flash", new Vector3(shanh, 0, shans), Vector3.zero, 0.5f);
    }

    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >=0.8f)
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
            if (entity.stateInfo.IsName(Player_StateFlash.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateFlash.Instance);
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
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsFlash, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
        //Input.ResetInputAxes();
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateMasterFlash : State<Player>
{
    public static string animatorStateName = "Flash";
    private float shanh = 0f;
    private float shans = 0f;
    private float gravit = 60.0f;
    private float y = 0;
    bool isenable = true;
    private GameObject Effect;
    SkinnedMeshRenderer[] playermesh;
    private static Player_StateMasterFlash instance;
    public static Player_StateMasterFlash Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateMasterFlash();
            }
            return instance;
        }
    }

    public override void Enter(Player entity)
    {
        entity.GetComponent<CapsuleCollider>().enabled = false;
        isenable = true;
        playermesh=entity.player.transform.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < playermesh.Length;i++ )
        {
            playermesh[i].enabled = false;
        }
            Effect = (GameObject)Object.Instantiate(Master_W_Effect.Master_Flash, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.FwordAndBack, 0f);
        entity.AnimatorStateChange(PlayerAnimatorCondition.LeftAndRight, 0f);
        y -= gravit * Time.deltaTime;
        entity.myAnimator.Play(animatorStateName, -1, 0);
        if (Input.GetAxis("Horizontal") > 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.FlashF, 2.0f);
            shanh = 60f;
            shans = 0f;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.FlashF, 1.0f);
            shanh = -60f;
            shans = 0f;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.FlashF, 0.0f);
            shanh = 0f;
            shans = 60f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.FlashF, 3.0f);
            shanh = 0f;
            shans = -60f;
        }
        entity.mymotor.AddForce("Flash", new Vector3(shanh, 0, shans), Vector3.zero, 0.3f);
    }

    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.8f)
            {
                entity.isskilling = false;
            }
            if (entity.stateInfo.normalizedTime >= 0.5f && isenable)
            {
                for (int i = 0; i < playermesh.Length; i++)
                {
                    playermesh[i].enabled = true;
                }
                isenable = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(Player_StateMasterFlash.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMasterFlash.Instance);
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
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsFlash, false);
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
        Object.Destroy(Effect,0.1f);
        //Input.ResetInputAxes();
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateMinisterFlash:State<Player>
{
    public static string animatorStateName = "skills";
    GameObject Effect;
    private static Player_StateMinisterFlash instance;
    public static Player_StateMinisterFlash Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateMinisterFlash();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, true);
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 1f);
        entity.myAnimator.Play(animatorStateName, -1, 0);
        //entity.mymotor.AddForce("MinisterSkillF", new Vector3(0, 0, -16f), Vector3.zero, 0.7f);
        Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_MFlash, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(Player_StateMinisterFlash.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMinisterFlash.Instance);
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
        entity.GetComponent<CapsuleCollider>().enabled = true;
        Object.Destroy(Effect);
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateWEtherFlash : State<Player>
{
    public static string animatorStateName = "skills";
    GameObject Effect;
    private static Player_StateWEtherFlash instance;
    public static Player_StateWEtherFlash Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateWEtherFlash();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, true);
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 1f);
        entity.myAnimator.Play(animatorStateName, -1, 0);
        Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_MShift, entity.player.transform.position, entity.player.transform.rotation);
    }
    public override void Execute(Player entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(Player_StateWEtherFlash.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateWEtherFlash.Instance);
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
        entity.GetComponent<CapsuleCollider>().enabled = true;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateTeanaFlash : State<Player>
{
    public static string animatorStateName = "skills";
    GameObject Effect;
    private static Player_StateTeanaFlash instance;
    public static Player_StateTeanaFlash Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateTeanaFlash();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, true);
        entity.isskilling = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 1f);
        entity.myAnimator.Play(animatorStateName, -1, 0);
        Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WShift, entity.player.transform.position, entity.player.transform.rotation);
        Effect.transform.parent = entity.player.transform;
    }
    public override void Execute(Player entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
            if (entity.stateInfo.IsName(Player_StateTeanaFlash.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateTeanaFlash.Instance);
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
        entity.GetComponent<CapsuleCollider>().enabled = true;
        Object.Destroy(Effect);
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

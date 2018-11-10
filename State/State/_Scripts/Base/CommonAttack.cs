using UnityEngine;
using System.Collections;

public class WKnightAttack : State<Player> 
{
    Vector3 v1;
    bool att = true;
    public static string animatorStateName = "attack";
    private static WKnightAttack instance;
    private GameObject effect;
    private bool canatt;
    public static WKnightAttack Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new WKnightAttack();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.mymotor.IsAtt = true;
        entity.isskilling = true;
        canatt = true;
        //entity.myAnimator.CrossFade("attack", 0.2f);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, true);
        v1 = GameObject.FindGameObjectWithTag(Global.Player).transform.position;
        effect=(GameObject)Object.Instantiate(Knight_W_Effect.Knight_WMouse0, v1, GameObject.FindGameObjectWithTag(Global.Player).transform.rotation);
        effect.transform.parent = GameObject.FindGameObjectWithTag(Global.Player).transform;
        Object.Destroy(effect, 1f);
        //Object.Instantiate(Knight_W_Effect.Knight_WArrow, new Vector3(v1.x, v1.y + 1.3f, v1.z), Camera.main.transform.rotation);
    }
    public override void Execute(Player entity)
    {
        entity.AnimatorStateChange(PlayerAnimatorCondition.FwordAndBack, Input.GetAxis("Vertical"));
        entity.AnimatorStateChange(PlayerAnimatorCondition.LeftAndRight, Input.GetAxis("Horizontal"));
        if (entity.stateInfo.IsName(WKnightAttack.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.6f&&att)
            {
                v1 = GameObject.FindGameObjectWithTag(Global.Player).transform.position;
                Object.Instantiate(Knight_W_Effect.Knight_WArrow, entity.player.transform.FindChild("beijiweizhi").transform.position, Camera.main.transform.rotation);
                att = false;
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
            if (entity.stateInfo.IsName(WKnightAttack.animatorStateName))
            {
                entity.GetFSM().ChangeState(WKnightAttack.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.mymotor.IsAtt = false;
        att = true;
        //v1 = GameObject.FindGameObjectWithTag(Global.Player).transform.position;
        //Object.Instantiate(Knight_W_Effect.Knight_WArrow, new Vector3(v1.x, v1.y + 1.3f, v1.z), Camera.main.transform.rotation);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WMasterAttack : State<Player>
{
    Vector3 v1;
    bool att = true;
    public static string animatorStateName = "attack";
    private static WMasterAttack instance;
    private GameObject effect;
    private bool canatt;
    public static WMasterAttack Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WMasterAttack();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.mymotor.IsAtt = true;
        entity.isskilling = true;
        canatt = true;
        //entity.myAnimator.CrossFade("attack", 0.2f);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, true);
        v1 = GameObject.FindGameObjectWithTag(Global.Player).transform.position;
        //effect = (GameObject)Object.Instantiate(Master_W_Effect.Master_WMouse0_1, v1, GameObject.FindGameObjectWithTag(Global.Player).transform.rotation);
        //effect.transform.parent = GameObject.FindGameObjectWithTag(Global.Player).transform;
        //Object.Destroy(effect, 1f);
        //Object.Instantiate(Knight_W_Effect.Knight_WArrow, new Vector3(v1.x, v1.y + 1.3f, v1.z), Camera.main.transform.rotation);
    }
    public override void Execute(Player entity)
    {
        entity.AnimatorStateChange(PlayerAnimatorCondition.FwordAndBack, Input.GetAxis("Vertical"));
        entity.AnimatorStateChange(PlayerAnimatorCondition.LeftAndRight, Input.GetAxis("Horizontal"));
        if (entity.stateInfo.IsName(WKnightAttack.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.6f && att)
            {
                v1 = GameObject.FindGameObjectWithTag(Global.Player).transform.position;
                Object.Instantiate(Master_W_Effect.Master_WMouse0, entity.player.transform.FindChild("beijiweizhi").transform.position, entity.player.transform.rotation);
                att = false;
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
            if (entity.stateInfo.IsName(WMasterAttack.animatorStateName))
            {
                entity.GetFSM().ChangeState(WMasterAttack.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.mymotor.IsAtt = false;
        att = true;
        //v1 = GameObject.FindGameObjectWithTag(Global.Player).transform.position;
        //Object.Instantiate(Knight_W_Effect.Knight_WArrow, new Vector3(v1.x, v1.y + 1.3f, v1.z), Camera.main.transform.rotation);
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class MMinisterAttack:State<Player>
{
    public static string animatorStateName = "attack";
    bool lianji;
    bool canattmove;
    GameObject Effect;
    private static MMinisterAttack instance;
    public static MMinisterAttack Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMinisterAttack();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.mymotor.IsAtt = true;
        canattmove = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        lianji = false;
        entity.isskilling = true;
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, true);
        }
        if(entity.attnum==0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 0f);
            Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_Matt01, entity.player.transform.position, entity.player.transform.rotation);
        }
        else if (entity.attnum == 1)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 1f);
            Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_Matt02, entity.player.transform.position, entity.player.transform.rotation);
        }
        else if (entity.attnum == 2)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 2f);
            Effect = (GameObject)Object.Instantiate(Minister_M_Effect.Minister_Matt03, entity.player.transform.position, entity.player.transform.rotation);
        }
        Effect.transform.parent = entity.player.transform;
        entity.attnum += 1;
    }
    public override void Execute(Player entity)
    {
        if (canattmove)
        {
            if (entity.attnum == 1)
            {
                if (entity.stateInfo.normalizedTime >= 0.3f)
                {
                    entity.mymotor.AddForce("Att01move", new Vector3(0, 0, 5f), Vector3.zero, 0.2f);
                    canattmove = false;
                }
            }
            else if (entity.attnum == 2)
            {
                if (entity.stateInfo.normalizedTime >= 0.2f)
                {
                    entity.mymotor.AddForce("Att02move", new Vector3(0, 0, 5f), Vector3.zero, 0.2f);
                    canattmove = false;
                }
            }
            else if (entity.attnum == 3)
            {
                if (entity.stateInfo.normalizedTime >= 0.5f)
                {
                    entity.mymotor.AddForce("Att02move", new Vector3(0, 0, 3f), Vector3.zero, 0.5f);
                    canattmove = false;
                }
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            lianji = true;
        }
        if (entity.stateInfo.IsName(MMinisterAttack.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.9f && lianji)
            {
                entity.GetFSM().ChangeState(MMinisterAttack.Instance);
                lianji = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                if (Input.GetMouseButton(0))
                {
                    entity.GetFSM().ChangeState(MMinisterAttack.Instance);
                }
                else
                {
                    entity.GetFSM().ChangeState(Player_StateMove.Instance);
                }
            }
            if (entity.stateInfo.IsName(MMinisterAttack.animatorStateName))
            {
                entity.GetFSM().ChangeState(MMinisterAttack.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.mymotor.IsAtt = false;
        entity.isskilling = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, false);
        entity.AnimatorChanged = false;
        //if(entity.attnum==1&&entity.attnum==2)
        //{
            Object.Destroy(Effect);
        //}
        if(entity.attnum>=3)
        {
            entity.attnum = 0;
        }
        Object.Destroy(Effect,1f);
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WEtherAttack : State<Player>
{
    public static string animatorStateName = "attack";
    bool lianji;
    bool canattmove;
    GameObject Effect;
    private static WEtherAttack instance;
    public static WEtherAttack Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WEtherAttack();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.mymotor.IsAtt = true;
        canattmove = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        lianji = false;
        entity.isskilling = true;
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, true);
        }
        if (entity.attnum == 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 0f);
            Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_Matt01, entity.player.transform.position, entity.player.transform.rotation);
        }
        else if (entity.attnum == 1)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 1f);
            Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_Matt02, entity.player.transform.position, entity.player.transform.rotation);
        }
        else if (entity.attnum == 2)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 2f);
            Effect = (GameObject)Object.Instantiate(Ether_M_Effect.Ether_Matt03, entity.player.transform.position, entity.player.transform.rotation);
        }
        Effect.transform.parent = entity.player.transform;
        entity.attnum += 1;
    }
    public override void Execute(Player entity)
    {
        if (canattmove)
        {
            if (entity.attnum == 1)
            {
                if (entity.stateInfo.normalizedTime >= 0.3f)
                {
                    entity.mymotor.AddForce("Att01move", new Vector3(0, 0, 5f), Vector3.zero, 0.4f);
                    canattmove = false;
                }
            }
            else if (entity.attnum == 2)
            {
                if (entity.stateInfo.normalizedTime >= 0.2f)
                {
                    entity.mymotor.AddForce("Att02move", new Vector3(0, 0, 8f), Vector3.zero, 0.4f);
                    canattmove = false;
                }
            }
            else if (entity.attnum == 3)
            {
                if (entity.stateInfo.normalizedTime >= 0f)
                {
                    entity.mymotor.AddForce("Att03move", new Vector3(0, 0, 10f), Vector3.zero, 0.5f);
                    entity.mymotor.AddForce("Att03_1move", new Vector3(0, 20f, 0), Vector3.zero, 0.5f);
                    canattmove = false;
                }
            }
        }
        
        if (entity.stateInfo.IsName(WEtherAttack.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.5f)
            {
                if (Input.GetMouseButton(0))
                {
                    lianji = true;
                }
            }
            if (entity.stateInfo.normalizedTime >= 0.9f && lianji)
            {
                entity.GetFSM().ChangeState(WEtherAttack.Instance);
                lianji = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                if (Input.GetMouseButton(0))
                {
                    entity.GetFSM().ChangeState(WEtherAttack.Instance);
                }
                else
                {
                    entity.GetFSM().ChangeState(Player_StateMove.Instance);
                }
            }
            if (entity.stateInfo.IsName(WEtherAttack.animatorStateName))
            {
                entity.GetFSM().ChangeState(WEtherAttack.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.mymotor.IsAtt = false;
        entity.isskilling = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, false);
        entity.AnimatorChanged = false;
        //if(entity.attnum==1&&entity.attnum==2)
        //{
        //}
        if (entity.attnum >= 3)
        {
            entity.attnum = 0;
        }
        Object.Destroy(Effect, 2f);
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class WTeanaAttack : State<Player>
{
    public static string animatorStateName = "attack";
    bool lianji;
    bool canattmove;
    GameObject Effect;
    private static WTeanaAttack instance;
    public static WTeanaAttack Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WTeanaAttack();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.mymotor.IsAtt = true;
        canattmove = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        lianji = false;
        entity.isskilling = true;
        if (entity.stateInfo.IsName(animatorStateName))
        {
            entity.myAnimator.Play(animatorStateName, -1, 0);
        }
        else
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, true);
        }
        if (entity.attnum == 0)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 0f);
            Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WAtt_1, entity.player.transform.position, entity.player.transform.rotation);
        }
        else if (entity.attnum == 1)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 1f);
            Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WAtt_2, entity.player.transform.position, entity.player.transform.rotation);
        }
        else if (entity.attnum == 2)
        {
            entity.AnimatorStateChange(PlayerAnimatorCondition.Skilling, 2f);
            Effect = (GameObject)Object.Instantiate(Teana_W_Effect.Teana_WAtt_3, entity.player.transform.position, entity.player.transform.rotation);
        }
        Effect.transform.parent = entity.player.transform;
        entity.attnum += 1;
    }
    public override void Execute(Player entity)
    {
        if (canattmove)
        {
            if (entity.attnum == 1)
            {
                if (entity.stateInfo.normalizedTime >= 0.1f)
                {
                    entity.mymotor.AddForce("Att01move", new Vector3(0, 0, 5f), Vector3.zero, 0.2f);
                    canattmove = false;
                }
            }
            else if (entity.attnum == 2)
            {
                if (entity.stateInfo.normalizedTime >= 0f)
                {
                    entity.mymotor.AddForce("Att02move", new Vector3(0, 0, 8f), Vector3.zero, 0.5f);
                    canattmove = false;
                }
            }
            else if (entity.attnum == 3)
            {
                if (entity.stateInfo.normalizedTime >= 0f)
                {
                    entity.mymotor.AddForce("Att03move", new Vector3(0, 0, 10f), Vector3.zero, 0.3f);
                    //entity.mymotor.AddForce("Att03_1move", new Vector3(0, 20f, 0), Vector3.zero, 0.5f);
                    canattmove = false;
                }
            }
        }

        if (entity.stateInfo.IsName(WTeanaAttack.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.5f)
            {
                if (Input.GetMouseButton(0))
                {
                    lianji = true;
                }
            }
            if (entity.stateInfo.normalizedTime >= 0.9f && lianji)
            {
                entity.GetFSM().ChangeState(WTeanaAttack.Instance);
                lianji = false;
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                if (Input.GetMouseButton(0))
                {
                    entity.GetFSM().ChangeState(WTeanaAttack.Instance);
                }
                else
                {
                    entity.GetFSM().ChangeState(Player_StateMove.Instance);
                }
            }
            if (entity.stateInfo.IsName(WTeanaAttack.animatorStateName))
            {
                entity.GetFSM().ChangeState(WTeanaAttack.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.mymotor.IsAtt = false;
        entity.isskilling = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorStateChange(PlayerAnimatorCondition.IsAttack, false);
        entity.AnimatorChanged = false;
        //if(entity.attnum==1&&entity.attnum==2)
        //{
        //}
        if (entity.attnum >= 3)
        {
            entity.attnum = 0;
        }
        Object.Destroy(Effect, 2f);
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}
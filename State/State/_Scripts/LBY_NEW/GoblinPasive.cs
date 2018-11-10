using UnityEngine;
using System.Collections;

public class Goblin_StateHurt:State<Goblin>             //普通受击
{
    private static Goblin_StateHurt instance;
    public static Goblin_StateHurt Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new Goblin_StateHurt();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        if (entity.AnimatorStateGetBool(GBAnimatorCondition.Isup))                             //判断当前处于站立还是躺下
        {
            entity.GetFSM().ChangeState(Goblin_StateHurt_Up.Instance);
        }
        else
        {
            entity.GetFSM().ChangeState(Goblin_StateHurt_Down.Instance);
        }
    }
    public override void Execute(Goblin entity)
    {
    }
    public override void Exit(Goblin entity)
    {
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateHurt_Up : State<Goblin>             //站立时普通受击
{
    public static string animatorStateName = "atthurt";
    private static Goblin_StateHurt_Up instance;
    public static Goblin_StateHurt_Up Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateHurt_Up();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        entity.myAnimator.Play(animatorStateName, -1, 0);
    }
    public override void Execute(Goblin entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Goblin_StateIdle.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateIdle.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Goblin entity)
    {
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateHurt_Down : State<Goblin>             //躺下时普通受击
{
    public static string animatorStateName = "fallhurt";
    private static Goblin_StateHurt_Down instance;
    public static Goblin_StateHurt_Down Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateHurt_Down();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
        entity.myAnimator.Play(animatorStateName, -1, 0);
    }
    public override void Execute(Goblin entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Goblin_StateFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateFall.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Goblin entity)
    {
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateFloating:State<Goblin>     //浮空
{
    public static string animatorStateName = "fukong";
    private static Goblin_StateFloating instance;
    public static Goblin_StateFloating Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateFloating();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, true);
        entity.myAnimator.Play(animatorStateName, -1, 0);
        entity.motor.AddForce("FuKong", new Vector3(0, entity.flyhigh, 0), Vector3.zero, 0.8f);
    }
    public override void Execute(Goblin entity)
    {
        if (entity.stateInfo.IsName(Goblin_StateFloating.animatorStateName))
        {
            if (entity.motor.IsTouchingGround)
            {
                entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Goblin_StateFallDown.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateFallDown.Instance);
            }
            if (entity.stateInfo.IsName(Goblin_StateFloating.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateFloating.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Goblin entity)
    {
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateFallDown : State<Goblin>     //摔下
{
    public static string animatorStateName = "shuaixia";
    private static Goblin_StateFallDown instance;
    public static Goblin_StateFallDown Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateFallDown();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
    }
    public override void Execute(Goblin entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Goblin_StateFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateFall.Instance);
            }
            if (entity.stateInfo.IsName(Goblin_StateFallDown.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateFallDown.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Goblin entity)
    {
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateFall : State<Goblin>     //躺下状态
{
    public static string animatorStateName = "Fall";
    private static Goblin_StateFall instance;
    public static Goblin_StateFall Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateFall();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        entity.times = 2f;
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
    }
    public override void Execute(Goblin entity)
    {
        entity.times -= Time.deltaTime;
        if (entity.times <= 0)
        {
            entity.AnimatorStateChange(GBAnimatorCondition.Isup, true);
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Goblin_StateStandUp.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateStandUp.Instance);
            }
            if (entity.stateInfo.IsName(Goblin_StateFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateFall.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Goblin entity)
    {
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateForced_Fall : State<Goblin>             //强制倒地
{
    private static Goblin_StateForced_Fall instance;
    public static Goblin_StateForced_Fall Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateForced_Fall();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        if (entity.AnimatorStateGetBool(GBAnimatorCondition.Isup))                             //判断当前处于站立还是躺下
        {
            entity.GetFSM().ChangeState(Goblin_StateForcedFall.Instance);
        }
        else
        {
            entity.GetFSM().ChangeState(Goblin_StateHurt_Down.Instance);
        }
    }
    public override void Execute(Goblin entity)
    {
    }
    public override void Exit(Goblin entity)
    {
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateForcedFall : State<Goblin>             //站立时强制倒地
{
    public static string animatorStateName = "Forced_Fall";
    private static Goblin_StateForcedFall instance;
    public static Goblin_StateForcedFall Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateForcedFall();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
        entity.myAnimator.Play(animatorStateName, -1, 0);
    }
    public override void Execute(Goblin entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Goblin_StateFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateFall.Instance);
            }
            if (entity.stateInfo.IsName(Goblin_StateForcedFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateForcedFall.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Goblin entity)
    {
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateHitDown_Fall : State<Goblin>             //击飞倒地
{
    public static string animatorStateName = "hitdown";
    private static Goblin_StateHitDown_Fall instance;
    public static Goblin_StateHitDown_Fall Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateHitDown_Fall();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
        entity.myAnimator.Play(animatorStateName, -1, 0);
    }
    public override void Execute(Goblin entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Goblin_StateFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateFall.Instance);
            }
            if (entity.stateInfo.IsName(Goblin_StateHitDown_Fall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Goblin_StateHitDown_Fall.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Goblin entity)
    {
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}

public class Goblin_StateFrozen : State<Goblin>             //结冰
{
    public static string animatorStateName = "frozen";
    private static Goblin_StateFrozen instance;
    public static Goblin_StateFrozen Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateFrozen();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        entity.AnimatorStateChange("idle", false);
        entity.IsFrozen = true;
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, true);
        entity.myAnimator.Play(animatorStateName, -1, 0);
    }
    public override void Execute(Goblin entity)
    {
    }
    public override void Exit(Goblin entity)
    {
        entity.IsFrozen = false;
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        if (telegram.Msg == (int)MessagesType.Msg_BeingIdle)
        {
            entity.AnimatorStateChange("idle", true);
            entity.GetFSM().ChangeState(Goblin_StateIdle.Instance);
            return true;
        }
        if (telegram.Msg == (int)MessagesType.Msg_BeingUpFukongBig)
        {
            entity.flyhigh = 25f;
            entity.GetFSM().ChangeState(Goblin_StateFloating.Instance);
            return true;
        }
        if (telegram.Msg == (int)MessagesType.Msg_BeingHurt)
        {
            entity.GetFSM().ChangeState(Goblin_StateHurt.Instance);
            return true;
        }
        return false;
    }
}

public class Goblin_StateDie:State<Goblin>
{
    public static string animatorStateName = "Die";
    private static Goblin_StateDie instance;
    public static Goblin_StateDie Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Goblin_StateDie();
            }
            return instance;
        }
    }
    public override void Enter(Goblin entity)
    {
        entity.motor.RemoveForce();
        entity.GetComponent<CapsuleCollider>().enabled = false;
        entity.IsDie = true;
        entity.myAnimator.Play(animatorStateName, -1, 0);
    }
    public override void Execute(Goblin entity)
    {
        if (entity.stateInfo.IsName(Goblin_StateDie.animatorStateName))
        {
            if (entity.stateInfo.normalizedTime >= 0.9f)
            {
                Object.Destroy(entity.gameObject);
            }
        }
    }
    public override void Exit(Goblin entity)
    {
        
    }
    public override bool OnMessage(Goblin entity, Telegram telegram)
    {
        return false;
    }
}
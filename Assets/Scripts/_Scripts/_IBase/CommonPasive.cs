using UnityEngine;
using System.Collections;

public class Player_StateHurt : State<Player>   //受击
{
    private static Player_StateHurt instance;
    public static Player_StateHurt Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateHurt();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        if (entity.AnimatorStateGetBool(GBAnimatorCondition.Isup))                             //判断当前处于站立还是躺下
        {
            entity.GetFSM().ChangeState(Player_StateHurt_Up.Instance);
        }
        else
        {
            entity.GetFSM().ChangeState(Player_StateHurt_Down.Instance);
        }
    }
    public override void Execute(Player entity)
    {
        
    }
    public override void Exit(Player entity)
    {
        
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateHurt_Up:State<Player>  //站立下受击
{
    public static string animatorStateName = "HeavyHit";
    private static Player_StateHurt_Up instance;
    public static Player_StateHurt_Up Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateHurt_Up();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isPasive = true;
        entity.myAnimator.Play(animatorStateName, -1, 0);
        entity.transform.parent.GetComponent<RPGInput>().enabled=false;
    }
    public override void Execute(Player entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isPasive = false;
        entity.AnimatorChanged = false;
        entity.transform.parent.GetComponent<RPGInput>().enabled = true;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}   

public class Player_StateHurt_Down : State<Player>   //倒地下受击/倒地下强制倒地
{
    public static string animatorStateName = "fallhurt";
    private static Player_StateHurt_Down instance;
    public static Player_StateHurt_Down Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateHurt_Down();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isPasive = true;
        entity.myAnimator.Play(animatorStateName, -1, 0);
        entity.transform.parent.GetComponent<RPGInput>().enabled = false;
    }
    public override void Execute(Player entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateFall.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isPasive = false;
        entity.AnimatorChanged = false;
        entity.transform.parent.GetComponent<RPGInput>().enabled = true;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateFall:State<Player>     //倒地
{
    public static string animatorStateName = "Fall";
    private static Player_StateFall instance;
    public static Player_StateFall Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateFall();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isPasive = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.times = 1f;
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
    }
    public override void Execute(Player entity)
    {
        entity.times -= Time.deltaTime;
        if (entity.times <= 0)
        {
            entity.AnimatorStateChange(GBAnimatorCondition.Isup, true);
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateStandUp.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateStandUp.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isPasive = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}                  

public class Player_StateStandUp : State<Player>    //站起
{
    public static string animatorStateName = "StandUp";
    private static Player_StateStandUp instance;
    public static Player_StateStandUp Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateStandUp();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.isPasive = true;
        entity.myAnimator.Play(animatorStateName, -1, 0);
        entity.transform.parent.GetComponent<RPGInput>().enabled = false;
    }
    public override void Execute(Player entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateMove.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateMove.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.isPasive = false;
        entity.AnimatorChanged = false;
        entity.transform.parent.GetComponent<RPGInput>().enabled = true;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateFloating : State<Player>   //浮空
{
    public static string animatorStateName = "fukong";
    private static Player_StateFloating instance;
    public static Player_StateFloating Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateFloating();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isPasive = true;
        entity.transform.parent.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, true);
        entity.myAnimator.Play(animatorStateName, -1, 0);
        entity.mymotor.RemoveForce("Jump");
        entity.mymotor.RemoveForce("JumpMomentum");
        entity.mymotor.AddForce("FuKong", new Vector3(0, entity.flyhigh, 0), Vector3.zero, 0.8f);
    }
    public override void Execute(Player entity)
    {
        if (entity.stateInfo.IsName(Goblin_StateFloating.animatorStateName))
        {
            if (entity.mymotor.IsTouchingGround)
            {
                entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
            }
        }
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_stateFallDown.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_stateFallDown.Instance);
            }
            if (entity.stateInfo.IsName(Player_StateFloating.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateFloating.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isPasive = false;
        entity.transform.parent.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_stateFallDown:State<Player>     //摔下倒地
{
    public static string animatorStateName = "shuaixia";
    private static Player_stateFallDown instance;
    public static Player_stateFallDown Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_stateFallDown();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isPasive = true;
        entity.transform.parent.GetComponent<RPGInput>().enabled = false;
    }
    public override void Execute(Player entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateFall.Instance);
            }
            if (entity.stateInfo.IsName(Player_stateFallDown.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_stateFallDown.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isPasive = false;
        entity.transform.parent.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateForce_Fall:State<Player>   //强制倒地
{
    private static Player_StateForce_Fall instance;
    public static Player_StateForce_Fall Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new Player_StateForce_Fall();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        if (entity.AnimatorStateGetBool(GBAnimatorCondition.Isup))                             //判断当前处于站立还是躺下
        {
            entity.GetFSM().ChangeState(Player_StateForceFall.Instance);
        }
        else
        {
            entity.GetFSM().ChangeState(Player_StateHurt_Down.Instance);
        }
    }
    public override void Execute(Player entity)
    {
        
    }
    public override void Exit(Player entity)
    {
        
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}

public class Player_StateForceFall:State<Player>    //站立下强制倒地
{
    public static string animatorStateName = "Force_fall";
    private static Player_StateForceFall instance;
    public static Player_StateForceFall Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateForceFall();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        entity.isPasive = true;
        entity.player.GetComponent<RPGInput>().enabled = false;
        entity.AnimatorStateChange(GBAnimatorCondition.Isup, false);
        entity.myAnimator.Play(animatorStateName, -1, 0);
    }
    public override void Execute(Player entity)
    {
        if (entity.AnimatorChanged && !entity.stateInfo.IsName(animatorStateName))
        {
            if (entity.stateInfo.IsName(Player_StateFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateFall.Instance);
            }
            if (entity.stateInfo.IsName(Player_StateForceFall.animatorStateName))
            {
                entity.GetFSM().ChangeState(Player_StateForceFall.Instance);
            }
        }
        if (!entity.AnimatorChanged && entity.stateInfo.IsName(animatorStateName))
        {
            entity.AnimatorChanged = true;
        }
    }
    public override void Exit(Player entity)
    {
        entity.isPasive = false;
        entity.player.GetComponent<RPGInput>().enabled = true;
        entity.AnimatorChanged = false;
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}
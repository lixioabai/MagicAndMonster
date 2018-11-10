using UnityEngine;
using System.Collections;

public class Player_StateAtt : State<Player>
{
    private GameObject player = GameObject.FindGameObjectWithTag(Global.Player);
    public static string animatorStateName = "attack";
    private static Player_StateAtt instance;
    public static Player_StateAtt Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new Player_StateAtt();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        if(player.name=="Knight_W")
        {
            entity.GetFSM().ChangeState(WKnightAttack.Instance);
        }
        else if (player.name == "Master_W")
        {
            entity.GetFSM().ChangeState(WMasterAttack.Instance);
        }
        else if(player.name=="Minister_M")
        {
            entity.GetFSM().ChangeState(MMinisterAttack.Instance);
        }
        else if (player.name == "Ether_W")
        {
            entity.GetFSM().ChangeState(WEtherAttack.Instance);
        }
        else if (player.name == "Teana_W")
        {
            entity.GetFSM().ChangeState(WTeanaAttack.Instance);
        }
    }
    public override void Execute(Player entity)
    {
        
    }
    public override bool OnMessage(Player entity, Telegram telegram)
    {
        return false;
    }
}
public class Player_StateSkillQ : State<Player>
{
    private GameObject player = GameObject.FindGameObjectWithTag(Global.Player);
    public static string animatorStateName = "skills";
    private static Player_StateSkillQ instance;
    public static Player_StateSkillQ Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateSkillQ();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        if (player.name == "Knight_W")
        {
            entity.GetFSM().ChangeState(WKnightSkillQ.Instance);
        }
        else if (player.name == "Master_W")
        {
            entity.GetFSM().ChangeState(WMasterSkillQ.Instance);
        }
        else if (player.name == "Minister_M")
        {
            entity.GetFSM().ChangeState(MMinisterSkillQ.Instance);
        }
        else if (player.name == "Ether_W")
        {
            entity.GetFSM().ChangeState(WEtherSkillQ.Instance);
        }
        else if (player.name == "Teana_W")
        {
            entity.GetFSM().ChangeState(WTeanaSkillQ.Instance);
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
public class Player_StateSkillF : State<Player>
{
    private GameObject player = GameObject.FindGameObjectWithTag(Global.Player);
    public static string animatorStateName = "skills";
    private static Player_StateSkillF instance;
    public static Player_StateSkillF Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateSkillF();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        if (player.name == "Knight_W")
        {
            entity.GetFSM().ChangeState(WKnightSkillF.Instance);
        }
        else if (player.name == "Master_W")
        {
            entity.GetFSM().ChangeState(WMasterSkillF.Instance);
        }
        else if (player.name == "Minister_M")
        {
            entity.GetFSM().ChangeState(MMinisterSkillF.Instance);
        }
        else if (player.name == "Ether_W")
        {
            entity.GetFSM().ChangeState(WEtherSkillF.Instance);
        }
        else if (player.name == "Teana_W")
        {
            entity.GetFSM().ChangeState(WTeanaSkillF.Instance);
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
public class Player_StateSkillR : State<Player>
{
    private GameObject player = GameObject.FindGameObjectWithTag(Global.Player);
    public static string animatorStateName = "skills";
    private static Player_StateSkillR instance;
    public static Player_StateSkillR Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateSkillR();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        if (player.name == "Knight_W")
        {
            entity.GetFSM().ChangeState(WKnightSkillR.Instance);
        }
        else if (player.name == "Master_W")
        {
            entity.GetFSM().ChangeState(WMastertSkillR.Instance);
        }
        else if (player.name == "Minister_M")
        {
            entity.GetFSM().ChangeState(MMinisterSkillR.Instance);
        }
        else if (player.name == "Ether_W")
        {
            entity.GetFSM().ChangeState(WEtherSkillR.Instance);
        }
        else if (player.name == "Teana_W")
        {
            entity.GetFSM().ChangeState(WTeanaSkillR.Instance);
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
public class Player_StateSkillS : State<Player>
{
    private GameObject player = GameObject.FindGameObjectWithTag(Global.Player);
    public static string animatorStateName = "skills";
    private static Player_StateSkillS instance;
    public static Player_StateSkillS Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateSkillS();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        if (player.name == "Knight_W")
        {
            entity.GetFSM().ChangeState(WKnightSkillS.Instance);
        }
        else if (player.name == "Master_W")
        {
            entity.GetFSM().ChangeState(WMasterSkillS.Instance);
        }
        else if (player.name == "Minister_M")
        {
            entity.GetFSM().ChangeState(MMinisterSkillS.Instance);
        }
        else if (player.name == "Ether_W")
        {
            entity.GetFSM().ChangeState(WEtherSkillS.Instance);
        }
        else if (player.name == "Teana_W")
        {
            entity.GetFSM().ChangeState(WTeanaSkillS.Instance);
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
public class Player_StateSkillM : State<Player>
{
    private GameObject player = GameObject.FindGameObjectWithTag(Global.Player);
    public static string animatorStateName = "skills";
    private static Player_StateSkillM instance;
    public static Player_StateSkillM Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player_StateSkillM();
            }
            return instance;
        }
    }
    public override void Enter(Player entity)
    {
        if (player.name == "Knight_W")
        {
            entity.GetFSM().ChangeState(WKnightSkillM.Instance);
        }
        else if (player.name == "Master_W")
        {
            entity.GetFSM().ChangeState(WMasterSkillM.Instance);
        }
        else if (player.name == "Minister_M")
        {
            entity.GetFSM().ChangeState(MMinisterSkillM.Instance);
        }
        else if (player.name == "Ether_W")
        {
            entity.GetFSM().ChangeState(WEtherSkillM.Instance);
        }
        else if (player.name == "Teana_W")
        {
            entity.GetFSM().ChangeState(WTeanaSkillM.Instance);
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
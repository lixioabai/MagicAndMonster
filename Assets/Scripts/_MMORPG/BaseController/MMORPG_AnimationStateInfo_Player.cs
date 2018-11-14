using UnityEngine;
using System.Collections;

public class MMORPG_AnimationStateInfo_Player
{
#region Normal  
    public static string NormalIdle= "NormalIdle";
    public static string NormalRun = "NormalRun";
    public static string NormalWalk = "NormalWalk";
    #endregion


    #region Attack  
    public static string AttackIdle = "AttackIdle";
    public static string AttackWalk = "AttackWalk";
    public static string AttackRun = "AttackRun";

    public static string AttackOne = "AttackOne";
    public static string AttackTwo = "AttackTwo";
    public static string AttackThree = "AttackThree";
    public static string AttackFour = "AttackFour";

    public static string Rush = "Rush";
    public static string HeroWin = "HeroWin";
    #endregion

    #region Hurt  
    public static string Hurt = "Hurt";
    public static string HurtBack = "HurtBack";
    public static string HurtFloat = "HurtFloat";
    #endregion

    #region Skill  
    public static string SkillOne = "SkillOne";
    public static string SkillTwo = "SkillTwo";
    public static string SkillThree = "SkillThree";
    #endregion

    #region Death  
    public static string Death = "Death";
    public static string DeathWake = "DeathWake";
    #endregion
}

using UnityEngine;
using System.Collections;

public class GBAnimatorState
{
	public static string LightHitted = "LightHitted";
    public static string AirHit = "AirHit";
	public static string Throwed = "Throwed";
   



    //所有动画
    public static string Walk = "Walk";
    public static string Idle = "Idle";
    public static string Attack = "attack";
    public static string StandUp = "StandUp";
    public static string Fall = "Fall";
    public static string Die = "Die";  
    //混合树
    public static string hurt_up = "hurt_up";   //浮空受伤害
    public static string hurt_down = "hurt_down"; //倒地受伤害
    public static string movement = "movement"; //移动与攻击混合树
    
    
    

}

public class GBAnimatorCondition
{
	public static string HittedPower = "HittedPower";
	public static string Throwed = "Throwed";
    public static string Hurting = "hurting"; 
    public static string Isup = "isup";
    public static string Issatndup = "issatndup";
    public static string Moving = "moving";
    public static string Isatt = "isatt";
   
}


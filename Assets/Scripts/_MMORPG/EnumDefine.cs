using UnityEngine;
using System.Collections;

public class EnumDefine
{
    public enum PlayerType
    {   
        None,
        Sword,
        Archer,
        Magic
    }

    public enum BuffType
    {
        None,
        Ice,    //冰属性攻击
        Fire,   //火属性攻击
        Poison, //毒属性攻击
        Light,  //光属性攻击
        Dark,   //暗属性攻击
    }

    public enum DeBuffType
    {
        None,
        Ice,    //冰属性防御
        Fire,   //火属性防御
        Poison, //毒属性防御
        Light,  //光属性防御
        Dark,   //暗属性防御
    }

    
    public enum State
    {
        Vertigo, //眩晕
        Flown,   //击飞
        Silent,  //沉默
        Death,   //死亡
    }



    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        NormalHurt,//普通受伤，掉血 不播放受伤动画
        Hurt,     //受伤 
        HurtBack, //击退
        HurtFloat,//击飞

    }
}

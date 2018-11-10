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
        Ice,    //冰属性攻击
        Fire,   //火属性攻击
        Poison, //毒属性攻击
        Light,  //光属性攻击
        Dark,   //暗属性攻击
    }

    public enum DeBuffType
    {
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
}

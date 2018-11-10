using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class AllEffects : MonoBehaviour
{
    public GameObject[] Effects;
    void Awake()
    {
        //Buff特效
        Buff_Effect.Buff_SuperArmor=Effects[44];
        //女骑士特效
        Knight_W_Effect.Knight_WMouse0 = Effects[0];
        Knight_W_Effect.Knight_WQ = Effects[1];
        Knight_W_Effect.Knight_WR = Effects[2];
        Knight_W_Effect.Knight_WF = Effects[3];
        Knight_W_Effect.Knight_WSpace = Effects[4];
        Knight_W_Effect.Knight_WMouse1 = Effects[5];
        Knight_W_Effect.Knight_WFlash = Effects[6];
        Knight_W_Effect.Knight_WArrow = Effects[7];
        Knight_W_Effect.Knight_WBoomArrow = Effects[8];
        //女法师特效
        Master_W_Effect.Master_WMouse0=Effects[9];
        Master_W_Effect.Master_WMouse0_1 = Effects[10];
        Master_W_Effect.Master_WR = Effects[11];
        Master_W_Effect.Master_WQ = Effects[12];
        Master_W_Effect.Master_WMouse1 = Effects[13];
        Master_W_Effect.Master_WE = Effects[14];
        Master_W_Effect.Master_WF = Effects[15];
        Master_W_Effect.Master_Flash = Effects[16];
        //男牧师特效
        Minister_M_Effect.Minister_Matt01 = Effects[17];
        Minister_M_Effect.Minister_Matt02 = Effects[18];
        Minister_M_Effect.Minister_Matt03 = Effects[19];
        Minister_M_Effect.Minister_MQ = Effects[20];
        Minister_M_Effect.Minister_MR = Effects[21];
        Minister_M_Effect.Minister_MM = Effects[22];
        Minister_M_Effect.Minister_MF = Effects[23];
        Minister_M_Effect.Minister_ME = Effects[24];
        Minister_M_Effect.Minister_MFlash = Effects[25];
        //女以太特效
        Ether_M_Effect.Ether_MR = Effects[26];
        Ether_M_Effect.Ether_MQ = Effects[27];
        Ether_M_Effect.Ether_ME = Effects[28];
        Ether_M_Effect.Ether_Matt01 = Effects[29];
        Ether_M_Effect.Ether_Matt02 = Effects[30];
        Ether_M_Effect.Ether_Matt03 = Effects[31];
        Ether_M_Effect.Ether_MF = Effects[32];
        Ether_M_Effect.Ether_MShift = Effects[33];
        Ether_M_Effect.Ether_MM = Effects[34];
        //女天籁特效
        Teana_W_Effect.Teana_WQ=Effects[35];
        Teana_W_Effect.Teana_WM = Effects[36];
        Teana_W_Effect.Teana_WR=Effects[37];
        Teana_W_Effect.Teana_WE = Effects[38];
        Teana_W_Effect.Teana_WShift = Effects[39];
        Teana_W_Effect.Teana_WF = Effects[40];
        Teana_W_Effect.Teana_WAtt_1 = Effects[41];
        Teana_W_Effect.Teana_WAtt_2 = Effects[42];
        Teana_W_Effect.Teana_WAtt_3=Effects[43];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.1f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
}
    public class Knight_W_Effect
    {
        public static GameObject Knight_WMouse0;
        public static GameObject Knight_WQ;
        public static GameObject Knight_WR;
        public static GameObject Knight_WF;
        public static GameObject Knight_WSpace;
        public static GameObject Knight_WMouse1;
        public static GameObject Knight_WFlash;
        public static GameObject Knight_WArrow;
        public static GameObject Knight_WBoomArrow;
    }

public class Master_W_Effect
{
    public static GameObject Master_WMouse0;
    public static GameObject Master_WMouse0_1;
    public static GameObject Master_WR;
    public static GameObject Master_WQ;
    public static GameObject Master_WMouse1;
    public static GameObject Master_WE;
    public static GameObject Master_WF;
    public static GameObject Master_Flash;
}
public class Minister_M_Effect
{
    public static GameObject Minister_Matt01;
    public static GameObject Minister_Matt02;
    public static GameObject Minister_Matt03;
    public static GameObject Minister_MQ;
    public static GameObject Minister_MR;
    public static GameObject Minister_MM;
    public static GameObject Minister_MF;
    public static GameObject Minister_ME;
    public static GameObject Minister_MFlash;
}

public class Ether_M_Effect
{
    public static GameObject Ether_MR;
    public static GameObject Ether_MQ;
    public static GameObject Ether_ME;
    public static GameObject Ether_Matt01;
    public static GameObject Ether_Matt02;
    public static GameObject Ether_Matt03;
    public static GameObject Ether_MF;
    public static GameObject Ether_MShift;
    public static GameObject Ether_MM;
}

public class Teana_W_Effect
{
    public static GameObject Teana_WQ;
    public static GameObject Teana_WM;
    public static GameObject Teana_WR;
    public static GameObject Teana_WE;
    public static GameObject Teana_WShift;
    public static GameObject Teana_WF;
    public static GameObject Teana_WAtt_1;
    public static GameObject Teana_WAtt_2;
    public static GameObject Teana_WAtt_3;
}

public class Buff_Effect
{
    public static GameObject Buff_SuperArmor;
}
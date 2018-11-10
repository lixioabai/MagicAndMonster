using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_Player_State_Die : State<MMORPG_BaseObject_Player>
{

    private static MMORPG_BaseObject_Player_State_Die instance;
    public static MMORPG_BaseObject_Player_State_Die Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_Player_State_Die();
            }
            return instance;
        }
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 玩家数据保存
/// </summary>
public class PlayerSaveModel : MonoBehaviour
{

    //存档1
    public static string PlayerOneName=  "PlayerOneName";
    public static string PlayerOneModel= "PlayerOneModel";
    public static string PlayerOneLevel= "PlayerOneLevel";

    /// <summary>
    /// 加载存档
    /// </summary>
    public static void LoadPlayerOneData()
    {
        PlayerOneName = PlayerPrefs.GetString("PlayerOneName");
        PlayerOneModel = PlayerPrefs.GetString("PlayerOneModel");
    }

    /// <summary>
    /// 更新存档
    /// </summary>
    public static void UpdatePlayerOneData()
    {
        PlayerPrefs.SetString(PlayerOneName, "PlayerOneName");
        PlayerPrefs.SetString(PlayerOneModel, "PlayerOneModel");
    }



    //存档2
    public static string PlayerTwoName;
    public static string PlayerTwoModel;
    public static string PlayerTwoLevel;

    //存档3
    public static string PlayerThreeName;
    public static string PlayerThreeModel;
    public static string PlayerThreeLevel;

    

    

}

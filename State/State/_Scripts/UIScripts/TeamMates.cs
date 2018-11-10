using UnityEngine;
using System.Collections;

/// <summary>
/// 队友
/// </summary>

public class TeamMates : MonoBehaviour
{
    private Transform favicon;
    private Transform blood;
    private Transform magic;
    private Transform friendPro;
    private Transform bloodProgressBar;
    private Transform magicProgressBar;

    void Start()
    {
        favicon = transform.FindChild("Win/FriendInfo/Favicon");
        blood = transform.FindChild("Win/FriendInfo/Blood/Label");
        magic = transform.FindChild("Win/FriendInfo/Magic/Label");
        friendPro = transform.FindChild("Win/FriendInfo/FriendPro/Label");
        bloodProgressBar = transform.FindChild("Win/FriendInfo/Blood");
        magicProgressBar = transform.FindChild("Win/FriendInfo/Magic");
    }

    void Update()
    {
        GetFriendInformation();
    }

    public void GetFriendInformation()
    {
        //TODO:以后要改成动态得到血量蓝量...的信息值。
        //favicon.GetComponent<UITexture>().mainTexture = null;
        blood.GetComponent<UILabel>().text = "1000" + "/" + "1000";
        magic.GetComponent<UILabel>().text = "1000" + "/" + "1000";
        bloodProgressBar.GetComponent<UIProgressBar>().value = 1000f / 1000f;
        magicProgressBar.GetComponent<UIProgressBar>().value = 1000f / 1000f;
        friendPro.GetComponent<UILabel>().text = "Lv." + "100" + " 队友的名字一";
    }

}

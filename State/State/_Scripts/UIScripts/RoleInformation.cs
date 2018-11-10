using UnityEngine;
using System.Collections;

public class RoleInformation : MonoBehaviour
{
    private Transform blood;//血量
    private Transform magic;//魔法量
    private Transform fatigue;//疲劳值
    private Transform favicon;//头像
    private Transform rolePro;//人物属性（等级、名字）
    private Transform bloodProgressBar;//血量条
    private Transform magicProgressBar;//蓝量条
    private Transform fatigueProgressBar;//疲劳值条

    void Start()
    {
        blood = transform.FindChild("Blood/Label");
        magic = transform.FindChild("Magic/Label");
        fatigue = transform.FindChild("Fatigue/Label");
        favicon = transform.FindChild("Favicon");
        rolePro = transform.FindChild("RolePro/Label");
        bloodProgressBar = transform.FindChild("Blood");
        magicProgressBar = transform.FindChild("Magic");
        fatigueProgressBar = transform.FindChild("Fatigue");
    }

    void Update()
    {
        GetRoleInformation();
    }

    //角色信息值
    public void GetRoleInformation()
    {
        //TODO:动态得到数值
        blood.GetComponent<UILabel>().text = "1000/1000";
        magic.GetComponent<UILabel>().text = "1000/1000";
        fatigue.GetComponent<UILabel>().text = "1000/1000";

        bloodProgressBar.GetComponent<UIProgressBar>().value = 1000f / 1000f;
        magicProgressBar.GetComponent<UIProgressBar>().value = 1000f / 1000f;
        fatigueProgressBar.GetComponent<UIProgressBar>().value = 1000f / 1000f;

        //favicon.GetComponent<UITexture>().mainTexture = null/*Resources.Load<UITexture>("Images/role builder-7")*/;
        rolePro.GetComponent<UILabel>().text = "Lv." + "100 " + "玩家的名字一";
    }

}

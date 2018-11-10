using UnityEngine;
using System.Collections;

public class CombatKeyCell : MonoBehaviour
{
    public GameObject icon;//技能图标
    public GameObject key;//技能快捷键
    public GameObject coolDown;//技能冷却时间
    public UITexture iconifo;

    public KeyCode keyCode;//按键
    public KeyCode keyCode2;
    private bool isColding = false;//是否冷却中

    public float curCD;//当前CD
    public float CD;//技能CD
    public float pubCurCD;
    public float pubCD;
    Skills skillinfo=new Skills();

    private GameObject player;
    private string iconname;
    void Start()
    {
        //初始化
        player = GameObject.FindGameObjectWithTag("Player");
        icon.GetComponentInChildren<UISprite>().fillAmount = 0;
        iconname = icon.GetComponent<UITexture>().mainTexture.name;
        curCD = 0;
        coolDown.GetComponent<UILabel>().text = "";
    }

    void Update()
    {
        //使用技能
        UseKey();
        //PubKeyCD();
    }
    void UseKey()
    {
        //当快捷键按下，且技能没有在冷却中
        if ((Input.GetKeyDown(keyCode) || Input.GetKeyDown(keyCode2)) && !isColding && !player.GetComponent<Player>().isskilling && player.GetComponent<Player>().mymotor.IsTouchingGround)
        {
            skillinfo = SkillInfo._Skillinstance.GetSkillInfoByld(SkillInfo._Skillinstance.GetSkillInfo(icon.GetComponent<UITexture>()));
            if (icon.GetComponent<UITexture>().mainTexture.name == "shift" && (player.name == "Minister_M" || player.name == "Teana_W"))
            {
                if(player.GetComponent<Player>().isPasive)
                {
                    try
                    {
                        CD = skillinfo.Times;
                    }
                    catch
                    {
                        Debug.LogError("Can't Finded!");
                    }
                    Skilling(iconname);
                    icon.GetComponentInChildren<UISprite>().fillAmount = 1;
                    isColding = true;
                    coolDown.GetComponent<UILabel>().text = "";
                    curCD = CD;
                }
            }
            else
            {
                if (player.GetComponent<Player>().isPasive == false)
                {
                    try
                    {
                        CD = skillinfo.Times;
                    }
                    catch
                    {
                        Debug.LogError("Can't Finded!");
                    }
                    Skilling(iconname);
                    icon.GetComponentInChildren<UISprite>().fillAmount = 1;
                    isColding = true;
                    coolDown.GetComponent<UILabel>().text = "";
                    curCD = CD;
                }
            }
        }
        if (isColding)
        {
            icon.GetComponentInChildren<UISprite>().fillAmount -= (1f / CD) * Time.deltaTime;
            curCD -= Time.deltaTime;
            //时间显示
            if (curCD >= 10.0f)
            {
                coolDown.GetComponent<UILabel>().text = curCD.ToString("#0");
            }
            if (curCD < 10.0f)
            {
                coolDown.GetComponent<UILabel>().text = curCD.ToString("#0.0");
            }
            if (icon.GetComponentInChildren<UISprite>().fillAmount == 0.0f)
            {
                isColding = false;
                icon.GetComponentInChildren<UISprite>().fillAmount = 0.0f;
                curCD = CD;
            }
            if (coolDown.GetComponent<UILabel>().text == "0.0" || icon.GetComponentInChildren<UISprite>().fillAmount == 0)
            {
                coolDown.GetComponent<UILabel>().text = "";
            }
        }
    }

    void PubKeyCD()
    {
        if (Input.GetKeyDown(keyCode))
        {
            icon.GetComponentInChildren<UISprite>().fillAmount = 1;
            isColding = true;
            coolDown.GetComponent<UILabel>().text = "";
            pubCurCD = pubCD;
        }
        if (isColding)
        {
            if (icon.GetComponentInChildren<UISprite>().fillAmount == 0.0f)
            {
                isColding = false;
                icon.GetComponentInChildren<UISprite>().fillAmount = 0.0f;
                pubCurCD = pubCD;
            }
            if (coolDown.GetComponent<UILabel>().text == "0.0" || icon.GetComponentInChildren<UISprite>().fillAmount == 0)
            {
                coolDown.GetComponent<UILabel>().text = "";
            }
        }

    }

    void Skilling(string iconname)
    {
        switch(iconname)
        {
                
            case "Wknight_Q":
                MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.Player_SkillQ, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                break;
            case "Wknight_M":
                MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.Player_SkillM, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                break;
            case "Wknight_R":
                MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.Player_SkillR, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                break;
            case "Wknight_E":
                MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.Player_SkillS, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                break;
            case "Wknight_F":
                MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.Player_SkillF, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                break;
            case "shift":
                if (player.name == "Master_W")
                {
                    MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.player_MasterFlash, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                }
                else if (player.name == "Minister_M")
                {
                    MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.player_MinisterFlash, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                }
                else if (player.name == "Teana_W")
                {
                    MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.player_WTeanaFlash, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                }
                else if (player.name == "Ether_W")
                {
                    MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.player_WEtherFlash, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.SuperArmor);
                }
                else
                {
                    MessageDispatcher.Instance.DispatchMessage(0, transform, player.transform, (int)MessagesType.Player_Flash, EntityManager.Instance.GetEntityFromTransform(player.transform), 1f, Buff.Null);
                }
                break;
        }
    }
}

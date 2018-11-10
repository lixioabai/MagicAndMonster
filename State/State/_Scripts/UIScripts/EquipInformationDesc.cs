using UnityEngine;
using System.Collections;

/// <summary>
/// 人物属性值
/// </summary>

public class EquipInformationDesc : MonoBehaviour
{

    //一般信息
    private Transform HPValue;//HP
    private Transform MPValue;//MP
    private Transform powerValue;//力量
    private Transform physicalstrengthValue;//体力
    private Transform intelligenceValue;//智力
    private Transform spiritValue;//精神
    private Transform physicalattackValue;//物理攻击
    private Transform magicattackValue;//魔法攻击
    private Transform fatalblowValue;//致命一击
    private Transform physicaltoughnessValue;//物理防御力
    private Transform magicdefenseValue;//魔法防御力
    private Transform MPrepliyValue;//MP回复量

    //详细信息 
    private Transform hardstraightValue;//硬直
    private Transform dizzyValue;//眩晕
    private Transform hardstraightresistanceValue;//硬直抵抗
    private Transform dizzyresistanceValue;//眩晕抵抗
    private Transform waterattackValue;//水攻击
    private Transform fireattackValue;//火攻击
    private Transform iceattackValue;//冰攻击
    private Transform lightattackValue;//光攻击
    private Transform darkattackValue;//暗攻击

    void Start()
    {
        HPValue = transform.FindChild("generalinformationdesc/HPValue");
        MPValue = transform.FindChild("generalinformationdesc/MPValue");
        powerValue = transform.FindChild("generalinformationdesc/powerValue");
        physicalstrengthValue = transform.FindChild("generalinformationdesc/physicalstrengthValue");
        intelligenceValue = transform.FindChild("generalinformationdesc/intelligenceValue");
        spiritValue = transform.FindChild("generalinformationdesc/spiritValue");
        physicalattackValue = transform.FindChild("generalinformationdesc/physicalattackValue");
        magicattackValue = transform.FindChild("generalinformationdesc/magicattackValue");
        fatalblowValue = transform.FindChild("generalinformationdesc/fatalblowValue");
        physicaltoughnessValue = transform.FindChild("generalinformationdesc/physicaltoughnessValue");
        magicdefenseValue = transform.FindChild("generalinformationdesc/magicdefenseValue");
        MPrepliyValue = transform.FindChild("generalinformationdesc/MPrepliyValue");

        hardstraightValue = transform.FindChild("detailedinformationdesc/hardstraightValue");
        dizzyValue = transform.FindChild("detailedinformationdesc/dizzyValue");
        hardstraightresistanceValue = transform.FindChild("detailedinformationdesc/hardstraightresistanceValue");
        dizzyresistanceValue = transform.FindChild("detailedinformationdesc/dizzyresistanceValue");
        waterattackValue = transform.FindChild("detailedinformationdesc/waterattackValue");
        fireattackValue = transform.FindChild("detailedinformationdesc/fireattackValue");
        iceattackValue = transform.FindChild("detailedinformationdesc/iceattackValue");
        lightattackValue = transform.FindChild("detailedinformationdesc/lightattackValue");
        darkattackValue = transform.FindChild("detailedinformationdesc/darkattackValue");

    }

    void Update()
    {
        GetEquipInformationDesc();
    }

    //人物属性值
    public void GetEquipInformationDesc()
    {
        //TODO:以后后面的值要得到
        //一般信息
        HPValue.GetComponent<UILabel>().text = "1000/5000";
        MPValue.GetComponent<UILabel>().text = "1000/5000";
        powerValue.GetComponent<UILabel>().text = "9999";
        physicalstrengthValue.GetComponent<UILabel>().text = "9999";
        intelligenceValue.GetComponent<UILabel>().text = "9999";
        spiritValue.GetComponent<UILabel>().text = "9999";

        physicalattackValue.GetComponent<UILabel>().text = "9999";
        magicattackValue.GetComponent<UILabel>().text = "9999";
        fatalblowValue.GetComponent<UILabel>().text = "9999";
        physicaltoughnessValue.GetComponent<UILabel>().text = "9999";
        magicdefenseValue.GetComponent<UILabel>().text = "9999";
        MPrepliyValue.GetComponent<UILabel>().text = "9999";

        //详细信息
        hardstraightValue.GetComponent<UILabel>().text = "9999";
        dizzyValue.GetComponent<UILabel>().text = "9999";
        hardstraightresistanceValue.GetComponent<UILabel>().text = "9999";
        dizzyresistanceValue.GetComponent<UILabel>().text = "9999";

        waterattackValue.GetComponent<UILabel>().text = "9999";
        fireattackValue.GetComponent<UILabel>().text = "9999";
        iceattackValue.GetComponent<UILabel>().text = "9999";
        lightattackValue.GetComponent<UILabel>().text = "9999";
        darkattackValue.GetComponent<UILabel>().text = "9999";
    }

}

using UnityEngine;
using System.Collections;

public class EquipmentControl : MonoBehaviour
{

    private Transform inforPopupList;
    private Transform generalinformationdesc;//一般信息
    private Transform detailedinformationdesc;//详细信息

    void Start()
    {
        inforPopupList = transform.FindChild("Win/informationdescpopuplist/Label");
        generalinformationdesc = transform.FindChild("Win/informationdesc/generalinformationdesc");
        detailedinformationdesc = transform.FindChild("Win/informationdesc/detailedinformationdesc");

        OnGeneralInformationDescClick();
    }

    void Update()
    {
        if (inforPopupList.GetComponent<UILabel>().text == "一般信息")
        {
            OnGeneralInformationDescClick();
        }
        else if (inforPopupList.GetComponent<UILabel>().text == "详细信息")
        {
            OnDetailedInformationDescClick();
        }
    }

    //一般信息显示
    public void OnGeneralInformationDescClick()
    {
        generalinformationdesc.gameObject.SetActive(true);
        detailedinformationdesc.gameObject.SetActive(false);
    }

    //详细信息显示
    public void OnDetailedInformationDescClick()
    {
        generalinformationdesc.gameObject.SetActive(false);
        detailedinformationdesc.gameObject.SetActive(true);
    }

    //选择装备1
    public void OnChooseEquipOneClick()
    {
        //TODO:
        //Singleton.inventory.SaveInventory();
        Debug.Log("装备一---------");
    }

    //选择装备2
    public void OnChooseEquipTwoClick()
    {
        Debug.Log("装备二---------");
    }

    //选择装备3
    public void OnChooseEquipThreeClick()
    {
        Debug.Log("装备三---------");
    }

    //选择装备4
    public void OnChooseEquipFourClick()
    {
        Debug.Log("装备四---------");
    }
}

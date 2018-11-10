using UnityEngine;
using System.Collections;

public class KeyControl : MonoBehaviour
{
    #region GameObject
    public GameObject Tooltip;
    public GameObject bag;
    public GameObject equip;
    public GameObject skill;
    public GameObject task;
    public GameObject system;

    private Transform pagOne;
    //private Transform pagOnebtn;
    private Transform pagTwo;
    //private Transform pagTwobtn;
    public GameObject keyZ;
    public GameObject key_Z;
    public GameObject keyX;
    public GameObject key_X;
    public GameObject keyC;
    public GameObject key_C;
    public GameObject keyV;
    public GameObject key_V;
    public GameObject keyB;
    public GameObject key_B;
    public GameObject keyN;
    public GameObject key_N;
    public GameObject keyM;
    public GameObject key_M;
    public GameObject keyF4;
    public GameObject key_F4;
    public GameObject keyF5;
    public GameObject key_F5;
    public GameObject keyF6;
    public GameObject key_F6;
    public GameObject keyF7;
    public GameObject key_F7;
    public GameObject keyF8;
    public GameObject key_F8;
    #endregion

    void Start()
    {
        #region SetActive
        pagOne = transform.FindChild("SkillPag/pagone");
        pagTwo = transform.FindChild("SkillPag/pagtwo");
        pagOne.gameObject.SetActive(true);
        pagTwo.gameObject.SetActive(false);
        keyZ.gameObject.SetActive(true);
        keyX.gameObject.SetActive(true);
        keyC.gameObject.SetActive(true);
        keyV.gameObject.SetActive(true);
        keyB.gameObject.SetActive(true);
        keyN.gameObject.SetActive(true);
        keyM.gameObject.SetActive(true);
        keyF4.gameObject.SetActive(true);
        keyF5.gameObject.SetActive(true);
        keyF6.gameObject.SetActive(true);
        keyF7.gameObject.SetActive(true);
        keyF8.gameObject.SetActive(true);

        key_Z.gameObject.SetActive(false);
        key_X.gameObject.SetActive(false);
        key_C.gameObject.SetActive(false);
        key_V.gameObject.SetActive(false);
        key_B.gameObject.SetActive(false);
        key_N.gameObject.SetActive(false);
        key_M.gameObject.SetActive(false);
        key_F4.gameObject.SetActive(false);
        key_F5.gameObject.SetActive(false);
        key_F6.gameObject.SetActive(false);
        key_F7.gameObject.SetActive(false);
        key_F8.gameObject.SetActive(false);
        #endregion

    }

    void Update()
    {

    }

    //翻下一页
    public void OnPagDownClick()
    {
        #region PagDown
        pagOne.gameObject.SetActive(false);
        pagTwo.gameObject.SetActive(true);

        keyZ.gameObject.SetActive(false);
        keyX.gameObject.SetActive(false);
        keyC.gameObject.SetActive(false);
        keyV.gameObject.SetActive(false);
        keyB.gameObject.SetActive(false);
        keyN.gameObject.SetActive(false);
        keyM.gameObject.SetActive(false);
        keyF4.gameObject.SetActive(false);
        keyF5.gameObject.SetActive(false);
        keyF6.gameObject.SetActive(false);
        keyF7.gameObject.SetActive(false);
        keyF8.gameObject.SetActive(false);

        key_Z.gameObject.SetActive(true);
        key_X.gameObject.SetActive(true);
        key_C.gameObject.SetActive(true);
        key_V.gameObject.SetActive(true);
        key_B.gameObject.SetActive(true);
        key_N.gameObject.SetActive(true);
        key_M.gameObject.SetActive(true);
        key_F4.gameObject.SetActive(true);
        key_F5.gameObject.SetActive(true);
        key_F6.gameObject.SetActive(true);
        key_F7.gameObject.SetActive(true);
        key_F8.gameObject.SetActive(true);
        #endregion

    }

    //翻上一页
    public void OnPagUpClick()
    {
        #region PagUp
        pagOne.gameObject.SetActive(true);
        pagTwo.gameObject.SetActive(false);

        keyZ.gameObject.SetActive(true);
        keyX.gameObject.SetActive(true);
        keyC.gameObject.SetActive(true);
        keyV.gameObject.SetActive(true);
        keyB.gameObject.SetActive(true);
        keyN.gameObject.SetActive(true);
        keyM.gameObject.SetActive(true);
        keyF4.gameObject.SetActive(true);
        keyF5.gameObject.SetActive(true);
        keyF6.gameObject.SetActive(true);
        keyF7.gameObject.SetActive(true);
        keyF8.gameObject.SetActive(true);

        key_Z.gameObject.SetActive(false);
        key_X.gameObject.SetActive(false);
        key_C.gameObject.SetActive(false);
        key_V.gameObject.SetActive(false);
        key_B.gameObject.SetActive(false);
        key_N.gameObject.SetActive(false);
        key_M.gameObject.SetActive(false);
        key_F4.gameObject.SetActive(false);
        key_F5.gameObject.SetActive(false);
        key_F6.gameObject.SetActive(false);
        key_F7.gameObject.SetActive(false);
        key_F8.gameObject.SetActive(false);
        #endregion

    }

    public void Show_Tooltip(GameObject go)
    {
        Tooltip.GetComponentInChildren<UILabel>().SetDimensions(60, 16);//这样虽然可以设置Tooltip的长度，但是会影响到其他的Tooltip的宽度，需要在其他用到Tooltip的地方修改下SetDimentsions

        if (go == bag)
        {
            Tooltip.GetComponentInChildren<UILabel>().text = "背包 (B)";
        } 
        else if (go == equip)
        {
            Tooltip.GetComponentInChildren<UILabel>().text = "装备 (E)";
        }
        else if (go == task)
        {
            Tooltip.GetComponentInChildren<UILabel>().text = "任务 (T)";
        }
        else if (go == skill)
        {
            Tooltip.GetComponentInChildren<UILabel>().text = "技能 (K)";
        }
        else if (go == system)
        {
            Tooltip.GetComponentInChildren<UILabel>().text = "设置 (Y)";
        }
    }

}

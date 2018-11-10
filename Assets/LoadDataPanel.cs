//脚本为模板自动生成。 生成时间为：10/26/2018 5:06:14 PM



using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using EasyMVC;



public class LoadDataPanel : PanelBase
{
    public bool CreateOne = false;
    public bool CreateTwo = false;
    public bool CreateThree = false;

    public override void Init(params object[] args) {
   base.Init(args);layer = PanelLayer.Panel;
   skinPath ="LoadDataPanel";} 
   public override void OnShowing()
    {
   base.OnShowing();
   Transform skinTrans = skin.transform;
    RigistButtonEvent("DataPosOneBtn",OnDataPosOneBtnClick);

    RigistButtonEvent("DataPosTwoBtn",OnDataPosTwoBtnClick);

    RigistButtonEvent("DataPosThreeBtn",OnDataPosThreeBtnClick);

    RigistButtonEvent("BackBtn",OnBackBtnClick);

        if (string.IsNullOrEmpty(PlayerSaveModel.PlayerOneName))
        {
            CreateOne = true;
        }
        if (string.IsNullOrEmpty(PlayerSaveModel.PlayerTwoName))
        {
            CreateTwo = true;

        }
        if (string.IsNullOrEmpty(PlayerSaveModel.PlayerThreeName))
        {
            CreateThree = true;
        }
    }
   public void  OnDataPosOneBtnClick()
    {
        if (CreateOne)
        {
            //点击直接进入创建玩家界面
            AppConfig.LoadScene("SelectPlayerScene");
        }
        else
        {
            LoadModel();
            LoadNameAndLevel();
        }
    }

   public void  OnDataPosTwoBtnClick()
    {
        if (CreateTwo)
        {
            //点击直接进入创建玩家界面
            AppConfig.LoadScene("SelectPlayerScene");
        }
    }

   public void  OnDataPosThreeBtnClick()
    {
        if (CreateThree)
        {
            //点击直接进入创建玩家界面
            AppConfig.LoadScene("SelectPlayerScene");
        }
    }

   public void  OnBackBtnClick()
   {
        AppConfig.LoadScene("LoginScene");
   }


    /// <summary>
    /// 加载模型
    /// </summary>
    void LoadModel()
    {

    }

    /// <summary>
    /// 加载等级
    /// </summary>
    void LoadNameAndLevel()
    {

    }

    /// <summary>
    /// 加载网格及其他
    /// </summary>
    void LoadEquipMesh()
    {

    }

    /// <summary>
    /// 加载特效
    /// </summary>
    void ShowEffect()
    {

    }

}
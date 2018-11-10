//脚本为模板自动生成。 生成时间为：10/23/2018 3:37:22 PM



using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using EasyMVC;



public class LoginPanel : PanelBase {
  public override void Init(params object[] args) {
   base.Init(args);layer = PanelLayer.Panel;
   skinPath ="LoginPanel";} 
   public override void OnShowing() {
   base.OnShowing();
   Transform skinTrans = skin.transform;
    RigistButtonEvent("NewGameBtn",OnNewGameBtnClick);

    RigistButtonEvent("ContinueGameBtn",OnContinueGameBtnClick);

    RigistButtonEvent("SetBtn",OnSetBtnClick);

    RigistButtonEvent("QuitBtn",OnQuitBtnClick);

  }
   public void  OnNewGameBtnClick()
    {
        //初始化数据
        AppConfig.LoadScene("SelectPlayerScene");
    }

   public void  OnContinueGameBtnClick()
    {
        //读取数据
    }

   public void  OnSetBtnClick()
    {

    }

   public void  OnQuitBtnClick()
    {
        Application.Quit();
    }

}
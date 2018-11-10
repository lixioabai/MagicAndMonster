//脚本为模板自动生成。 生成时间为：10/23/2018 5:36:37 PM



using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using EasyMVC;



public class SelectPlayerPanel : PanelBase {


     public Text DesLab;
     public InputField NameInput;

    public SelectPlayerFBX Sword;
    public SelectPlayerFBX Archer;
    public SelectPlayerFBX Magic;


    public override void Init(params object[] args)
    {
   base.Init(args);layer = PanelLayer.Panel;
   skinPath ="SelectPlayerPanel";

        Sword = GameObject.Find("SwordObj").GetComponent<SelectPlayerFBX>();
        Archer = GameObject.Find("ArcherObj").GetComponent<SelectPlayerFBX>();
        Magic = GameObject.Find("MagicObj").GetComponent<SelectPlayerFBX>();

    } 
   public override void OnShowing()
    {

   base.OnShowing();
   Transform skinTrans = skin.transform;
    DesLab=GetScripts<Text>("DesLab");

    NameInput = GetScripts<InputField>("NameInput");

    RigistButtonEvent("SwordBtn",OnSwordBtnClick);

    RigistButtonEvent("ArcherBtn",OnArcherBtnClick);

    RigistButtonEvent("MagicBtn",OnMagicBtnClick);

    RigistButtonEvent("MakeSureBtn",OnMakeSureBtnClick);

    RigistButtonEvent("BackBtn",OnBackBtnClick);

    DesLab.text = "等待选择一个英雄";

    }
   public void  OnSwordBtnClick()
    {
        DesLab.text = "战士。近战爆发。上手难度 口";
        Sword.isShow = true;
        if (Archer.isShow)
        {
            Archer.isShow = false;
        }
        if (Magic.isShow)
        {
            Magic.isShow = false;
        }
    }

   public void  OnArcherBtnClick()
    {
        DesLab.text = "弓箭手。远战消耗。上手难度 口口口";
        Archer.isShow = true;
        if (Sword.isShow)
        {
            Sword.isShow = false;
        }
        if (Magic.isShow)
        {
            Magic.isShow = false;
        }
    }

   public void  OnMagicBtnClick()
    {
        DesLab.text = "法师。远战爆发。上手难度 口口口口";
        Magic.isShow = true;
        if (Sword.isShow)
        {
            Sword.isShow = false;
        }
        if (Archer.isShow)
        {
            Archer.isShow = false;
        }
    }


   public void  OnMakeSureBtnClick()
   {
        AppConfig.LoadScene("MainCity");
    }


   public void  OnBackBtnClick()
    {
        AppConfig.LoadScene("LoginScene");
    }

}
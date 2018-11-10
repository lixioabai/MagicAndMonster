using UnityEngine;
using System.Collections;

/// <summary>
/// 加载玩家数据时相机控制
/// </summary>
public class LoadPlayerCameraControl : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void LoadDateOne()
    {
        Anim.Play("DataOne");
    }

    public void LoadDataTwo()
    {
        Anim.Play("DataTwo");
    }

    public void LoadDataThree()
    {
        Anim.Play("DataThree");
    }
   
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 小地图
/// </summary>

public class MiniMap : MonoBehaviour
{
//     private Transform zoomin;
//     private Transform zoomout;
    public Camera miniMapCamera;

    void Start()
    {
        miniMapCamera.fieldOfView = 65f;
    }

    // 放大
    public void ZoomInClick()
    {
        if (miniMapCamera.fieldOfView >= 35f)
        {
            miniMapCamera.fieldOfView = miniMapCamera.fieldOfView - 10f;
        }
    }

    // 缩小
    public void ZoomOutClick()
    {
        if (miniMapCamera.fieldOfView <= 95)
        {
            miniMapCamera.fieldOfView = miniMapCamera.fieldOfView + 10f;
        }
    }

}

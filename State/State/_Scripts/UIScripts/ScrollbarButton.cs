using UnityEngine;
using System.Collections;

/// <summary>
/// 滚动条的上下键控制滚动条移动
/// </summary>

public class ScrollbarButton : MonoBehaviour
{

    //public float value;
    //public float barSize;

    //void Awake()
    //{
    //    value = gameObject.GetComponent<UIScrollBar>().value;
    //    barSize = gameObject.GetComponent<UIScrollBar>().barSize;
    //}

    // 滚动条向上
    public void OnUpClick()
    {
        gameObject.GetComponent<UIScrollBar>().value = gameObject.GetComponent<UIScrollBar>().value -
            (gameObject.GetComponent<UIScrollBar>().barSize / (1.0f - gameObject.GetComponent<UIScrollBar>().barSize));
    }

    // 滚动条向下
    public void OnDownClick()
    {
        gameObject.GetComponent<UIScrollBar>().value = gameObject.GetComponent<UIScrollBar>().value +
            (gameObject.GetComponent<UIScrollBar>().barSize / (1.0f - gameObject.GetComponent<UIScrollBar>().barSize));
    }

}

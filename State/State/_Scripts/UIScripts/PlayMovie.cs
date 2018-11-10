using UnityEngine;
using System.Collections;

/// <summary>
/// 播放技能演示
/// </summary>

public class PlayMovie : MonoBehaviour
{

    public MovieTexture movTexture;
    //float ftimeNow = 1;
    //public UISlider uisilder;
    //string strPlayState = "null";
    //public AudioSource audioSource;

    public Transform playButton; // 播放键
    public Transform pauseButton; // 暂停键

    void Start()
    {
        // 查找
        playButton = transform.FindChild("Sprite-play");
        pauseButton = transform.FindChild("Sprite-pause");
        movTexture.loop = true;// 循环播放
        //movTexture.Play(); // 添加后会一开始就播放

        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    //技能展示播放控制
    public void OnPlayClick()
    {
        // 如果没有播放开始播放，并隐藏播放按键，显示暂停键
        if (!movTexture.isPlaying)
        {
            movTexture.Play();
            playButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);

        }
        // 隐藏播放按键，显示暂停键
        else
        {
            movTexture.Stop();
            playButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
        }

    }

}

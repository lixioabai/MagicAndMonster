using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 音频资源管理器。 专门处理多个音源
/// </summary>
public class AudioManagerFIFO : MonoBehaviour {

    private static AudioManagerFIFO _instance;

    public static AudioManagerFIFO Instance()
    {

        if (_instance == null)
        {
            return _instance = new GameObject("AudioManagerFIFO").AddComponent<AudioManagerFIFO>();
        }
        else
        {
            return _instance;
        }
        
    }

    /// <summary>
    /// 队列集合
    /// </summary>
   public Queue<AudioClip> PlayList = new Queue<AudioClip>();

    /// <summary>
    /// 当前正在播放的音源
    /// </summary>
    public GameObject currentPlayAudioClip;

    /// <summary>
    /// 是否优先播放
    /// </summary>
    private bool FirstPlay = false;


    /// <summary>
    /// 创建并播放音源
    /// </summary>
    /// <param name="ac"></param>
    private void CreatAndPlay(AudioClip ac,bool isQueue=true)
    {
        if (ac == null) return;
      
        GameObject gameObject = new GameObject("One shot audio");
        currentPlayAudioClip = gameObject;
        if (Camera.main != null)
        {
            gameObject.transform.SetParent(Camera.main.transform, false);
        }
        else
        {
            Debug.Log("<Color=yellow>主相机丢失</Color>");
        }
        AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
        audioSource.clip = ac;
        audioSource.spatialBlend = 1f;
        audioSource.volume = 1;
        audioSource.Play();
       
        Object.Destroy(gameObject, ac.length * ((Time.timeScale >= 0.01f) ? Time.timeScale : 0.01f));
        if (isQueue)
        {
           
            ac = null;
        }

    }


    public void PlayInQueuen(string name)
    {

       AudioClip ac=Resources.Load<AudioClip>("Audio/"+name);
       PlayList.Enqueue(ac); //将要播放的音源加入队尾

    }

    /// <summary>
    /// 优先播放的音源
    /// </summary>
    public void PlayFirstAudio(string name)
    {
        AudioClip ac = Resources.Load<AudioClip>("Audio/" + name);
        CreatAndPlay(ac);
        FirstPlay = true;

    }


    void Update()
    {
        if (currentPlayAudioClip == null)
        {
            if (PlayList.Count >= 1)
            {

                AudioClip ac = PlayList.Peek(); //取出队列第一个元素，但是不移除
                CreatAndPlay(ac);
               
                PlayList.Dequeue(); //移除队列顶端 并返回顶端
            }
        }
    }
	
	
	
	
}

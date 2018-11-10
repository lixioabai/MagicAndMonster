using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager
{
    Vector3 PlayPos;

    private static AudioManager _instance;

    public static   AudioManager Instance()
    {
        if (_instance == null)
        {
            _instance = new AudioManager();

        }
      
        return _instance;
    }


    private static string audioTextPathPrefix = Application.dataPath + "\\GameEngine\\GameFromwork\\Resources\\";
    private const string audioTextPathMiddle = "audiolist";
    private const string audioTextPathPosfix = ".txt";
   
    public static string AudioTextPath
    {
        get
        {
           return audioTextPathPrefix + audioTextPathMiddle+ audioTextPathPosfix;
        }
    }
    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

    public bool isMute = false;

    public List<GameObject> CurrentplayList=new List<GameObject>();

    public void Awake()
    {
        LoadAudioClip();
        _instance = this;

       
    }

    public AudioManager()
    {
        LoadAudioClip();
    }


    public void Init()
    {
        LoadAudioClip();
    }



    private void LoadAudioClip()
    {
        audioClipDict = new Dictionary<string, AudioClip>();
       TextAsset ta=  Resources.Load<TextAsset>(audioTextPathMiddle);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyvalue = line.Split(',');
            string key = keyvalue[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalue[1]);
            audioClipDict.Add(key,value);
        }
    }

    public void Play(string name)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac,Vector3.zero,1);
            
        }

    }

    public void Play(string name,Vector3 postion)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, postion);
        }
    }


    public void Play(string name, Vector3 postion, float time)
    {

    }




    #region 音源播放控制器
    /// <summary>
    /// 销毁前面播放的音效
    /// </summary>
    /// <param name="name"></param>
    /// <param name="position"></param>
    /// <param name="volume"></param>
    public  void PlayClipAtPoint(string name, Vector3 position, float volume = 1.0f)
    {
       if (isMute) return;
       if (CurrentplayList.Count > 0)
       {
           for (int i = 0; i < CurrentplayList.Count; i++)
           {
               if (CurrentplayList[i] != null)
               {
                   Object.Destroy(CurrentplayList[i]);
               }
           }
       }

        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            GameObject gameObject = new GameObject("One shot audio");
            if (Camera.main != null && position != null)
            {
                gameObject.transform.position = Camera.main.transform.position;
            }
            else
            {
                gameObject.transform.position = position;
            }
            AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
            audioSource.clip = ac;
            audioSource.spatialBlend = 1f;
            audioSource.volume = volume;
            audioSource.Play();
            CurrentplayList.Add(gameObject);
            Object.Destroy(gameObject, ac.length * ((Time.timeScale >= 0.01f) ? Time.timeScale : 0.01f));
           
        }

    }

    public void PlayClipAtPoint(string name,float volume = 1.0f)
    {
        if (isMute) return;
        if (CurrentplayList.Count > 0)
        {
            for (int i = 0; i < CurrentplayList.Count; i++)
            {
                if (CurrentplayList[i] != null)
                {
                    Object.Destroy(CurrentplayList[i]);
                }
            }
        }

        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            GameObject gameObject = new GameObject("One shot audio");
            if (Camera.main != null)
            {
                gameObject.transform.SetParent( Camera.main.transform,false);
            }
            else
            {
                Debug.Log("<Color=yellow>主相机丢失</Color>");
            }
            AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
            audioSource.clip = ac;
            audioSource.spatialBlend = 1f;
            audioSource.volume = volume;
            audioSource.Play();
            CurrentplayList.Add(gameObject);
            Object.Destroy(gameObject, ac.length * ((Time.timeScale >= 0.01f) ? Time.timeScale : 0.01f));

        }

    }

    /// <summary>
    /// 播放音效不摧毁（生成在相机下）
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    public void PlayClipAtPointMutiply(string name, float volume = 1.0f)
    {
        if (isMute) return;

        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            GameObject gameObject = new GameObject("One shot audio");
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
            audioSource.volume = volume;
            audioSource.Play();
            
            Object.Destroy(gameObject, ac.length * ((Time.timeScale >= 0.01f) ? Time.timeScale : 0.01f));

        }

    }

    #endregion


  

}

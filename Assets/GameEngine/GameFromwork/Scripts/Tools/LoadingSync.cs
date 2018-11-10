using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 异步加载过渡场景
/// </summary>
public class LoadingSync : MonoBehaviour {

    //public Slider Prograss;
    private AsyncOperation async_Operation;
    public Image PrograssImg;
    void Start()
    {
        StartCoroutine(LoadScene());
    }

	void Update () 
    {
       // Prograss.value = async_Operation.progress;
        PrograssImg.fillAmount= async_Operation.progress;

    }

    IEnumerator LoadScene()
    {
        async_Operation = SceneManager.LoadSceneAsync(AppConfig.SceneName);
        yield return async_Operation;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// 挂载在UI上
/// </summary>
public class LocalLanguageUI : MonoBehaviour {

    public string key;
	void Start () {
        string value = LocalLanguageManager.Instance.GetValue(key);
        GetComponent<Text>().text = value;
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}

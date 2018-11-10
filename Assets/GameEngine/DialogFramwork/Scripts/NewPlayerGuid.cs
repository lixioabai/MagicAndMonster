using UnityEngine;
using System.Collections;

/// <summary>
/// 新手引导
/// </summary>
public class NewPlayerGuid : MonoBehaviour {


    private GameObject DialogWindow;
    private DialogSystem DialogMono;

   


    // Update is called once per frame
    void Start()
    {
        DialogWindow = GameObject.Find("Dialog");
        DialogMono = DialogWindow.GetComponent<DialogSystem>();
        DialogMono.DialogEnd += DialogEndListener;
        DialogMono.DialogStart += DialogStartListener;
        if (DialogWindow) DialogWindow.SetActive(false);

      
   

        //StartCoroutine(Note());
    }

 
    void Update()
    {
 
            if (DialogWindow) DialogWindow.SetActive(true);
    }

    public virtual void DialogEndListener(int stage)
    {
        if (!this.enabled)
            return;
        switch (stage)
        {
            case 0:
              
                break;
            case 1:
               
                break;
            case 2:
              
                break;
            default:
                break;
        }
    }

    public virtual void DialogStartListener(int stage)
    {
        if (!this.enabled)
            return;
        if (stage == 2)
        {
          
        }
    }
}

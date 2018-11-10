using UnityEngine;
using System.Collections;

public class EquipControl : MonoBehaviour
{

    public Transform weapon;
    public Transform clothing;
    public Transform shoes;
    public Transform casque;
    public Transform necklace;
    public Transform wrister;
    public Transform bloodBottle;
    public Transform speedUpMedicine;

    public bool show = false;

    void Start()
    {
        weapon.gameObject.SetActive(true);
        clothing.gameObject.SetActive(true);
        shoes.gameObject.SetActive(true);
        casque.gameObject.SetActive(true);
        necklace.gameObject.SetActive(true);
        wrister.gameObject.SetActive(true);
        bloodBottle.gameObject.SetActive(false);
        speedUpMedicine.gameObject.SetActive(false);
        show = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            OnCtrlButtonClick();
        }
    }

    public void OnCtrlButtonClick()
    {
        if (show)
        {
            weapon.gameObject.SetActive(false);
            clothing.gameObject.SetActive(false);
            shoes.gameObject.SetActive(false);
            casque.gameObject.SetActive(false);
            necklace.gameObject.SetActive(false);
            wrister.gameObject.SetActive(false);
            bloodBottle.gameObject.SetActive(true);
            speedUpMedicine.gameObject.SetActive(true);
            show = false;
        }
        else
        {
            weapon.gameObject.SetActive(true);
            clothing.gameObject.SetActive(true);
            shoes.gameObject.SetActive(true);
            casque.gameObject.SetActive(true);
            necklace.gameObject.SetActive(true);
            wrister.gameObject.SetActive(true);
            bloodBottle.gameObject.SetActive(false);
            speedUpMedicine.gameObject.SetActive(false);
            show = true;
        }
    }

}

using UnityEngine;
using System.Collections;

public class Skill_Down : MonoBehaviour
{

    void OnPress()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Singleton.skillUI.SkillDown(transform.parent.GetComponent<SkillCell>().skillID);
        }
    }

}

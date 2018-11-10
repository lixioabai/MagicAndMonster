using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {
    public int FlashState;
    public int movementState;
    public int attackState;
    public int skillsState;
    public int ishurtBool;
    public int isnohurtBool;
    public int zuoyouFloat;
    public int qianhouFloat;
    public int isskillBool;
    public int ismoveBool;
    public int skillingFloat;
    public int isattBool;
    public int isflashBool;
    public int flashFloat;
    void Awake()
    {
        FlashState = Animator.StringToHash("Base Layer.active.Flash");
        movementState = Animator.StringToHash("Base Layer.active.movement");
        attackState = Animator.StringToHash("Base Layer.active.attack");
        skillsState = Animator.StringToHash("Base Layer.active.skills");
        ishurtBool = Animator.StringToHash("ishurt");
        isnohurtBool = Animator.StringToHash("isnohurt");
        zuoyouFloat = Animator.StringToHash("zuoyou");
        qianhouFloat = Animator.StringToHash("qianhou");
        isskillBool = Animator.StringToHash("isskill");
        ismoveBool = Animator.StringToHash("ismove");
        skillingFloat = Animator.StringToHash("skilling");
        isattBool = Animator.StringToHash("isatt");
        isflashBool = Animator.StringToHash("isflash");
        flashFloat = Animator.StringToHash("flash");
    }
	void Start () {
	
	}
	void Update () {
	
	}
}

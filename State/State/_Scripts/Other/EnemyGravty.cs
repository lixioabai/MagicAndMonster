using UnityEngine;
using System.Collections;

public class EnemyGravty : MonoBehaviour {
    private CharacterController enemy;
    private float MoveSpeed = 50f;
    private float Gravity = 60.0f;
    private Vector3 moveDirection = Vector3.zero;
    void Awake()
    {
        enemy=GetComponent<CharacterController>();
    }
	void Start () {
	
	}
	void Update () {
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection.y -= Gravity * Time.deltaTime;
        enemy.Move(moveDirection * Time.deltaTime * MoveSpeed * 0.1f);
	}
}

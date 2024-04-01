using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public Rigidbody rb;                   // 플레이어를 이동시키기 위한 RigidBody
    public int moveSpeed = 5;              // 플레이어의 이동속도

    void Start()
    {
        rb = GetComponent<Rigidbody>();     // rb에 플레이어 오브젝트에 있는 RigidBody를 넣어줌
    }

    void Update()
    {
        // PlayerMove01();
        PlayerMove02();
    }

    public void PlayerMove01()              // 플레이어의 위치를 바뀌 이동하는 함수
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();              // 대각선 방향에서 가속되는것을 방지
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }

    public void PlayerMove02()              // 플레이어의 rigidBody컴포넌트의 이동속도를 바꿔 이동하는 함수
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();              // 대각선 방향에서 가속되는것을 방지

        rb.velocity = moveInput * moveSpeed;
    }

}
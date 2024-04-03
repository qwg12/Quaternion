using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public Rigidbody rb;                   // 플레이어를 이동시키기 위한 RigidBody
    public StatData player;
    public float attackCooldown;
    public float currentCooldown;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody>();     // rb에 플레이어 오브젝트에 있는 RigidBody를 넣어줌
        player = Managers.Data.Setting(true, 5, 5, 1, 1, 5);
    }

    void Update()
    {
        // PlayerMove01();
        PlayerMove02();
        if(Input.GetKeyDown (GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    public void PlayerMove01()              // 플레이어의 위치를 바뀌 이동하는 함수
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();              // 대각선 방향에서 가속되는것을 방지
        transform.position += moveInput * player.moveSpeed * Time.deltaTime;
    }

    public void PlayerMove02()              // 플레이어의 rigidBody컴포넌트의 이동속도를 바꿔 이동하는 함수
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();              // 대각선 방향에서 가속되는것을 방지

        rb.velocity = moveInput * player.moveSpeed;
    }

    public void FireProjectile()
    {
        GameObject temp = Managers.Pool.Pop(bullet);
        BuildCompression bc = temp.GetComponent<BuildCompression>();

        temp.transform.position = this.gameObject.transform.position;
        bc.direction = Vector3.forward;
        bc.damage = player.bulletDamage;
        bc.moveSpeed = player.bulletLevel;

        Managers.Data.Bullets.Add(bc);
    }

}
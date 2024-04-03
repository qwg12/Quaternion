using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public Rigidbody rb;                   // �÷��̾ �̵���Ű�� ���� RigidBody
    public StatData player;
    public float attackCooldown;
    public float currentCooldown;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody>();     // rb�� �÷��̾� ������Ʈ�� �ִ� RigidBody�� �־���
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

    public void PlayerMove01()              // �÷��̾��� ��ġ�� �ٲ� �̵��ϴ� �Լ�
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();              // �밢�� ���⿡�� ���ӵǴ°��� ����
        transform.position += moveInput * player.moveSpeed * Time.deltaTime;
    }

    public void PlayerMove02()              // �÷��̾��� rigidBody������Ʈ�� �̵��ӵ��� �ٲ� �̵��ϴ� �Լ�
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();              // �밢�� ���⿡�� ���ӵǴ°��� ����

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
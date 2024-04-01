using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public Rigidbody rb;                   // �÷��̾ �̵���Ű�� ���� RigidBody
    public int moveSpeed = 5;              // �÷��̾��� �̵��ӵ�

    void Start()
    {
        rb = GetComponent<Rigidbody>();     // rb�� �÷��̾� ������Ʈ�� �ִ� RigidBody�� �־���
    }

    void Update()
    {
        // PlayerMove01();
        PlayerMove02();
    }

    public void PlayerMove01()              // �÷��̾��� ��ġ�� �ٲ� �̵��ϴ� �Լ�
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();              // �밢�� ���⿡�� ���ӵǴ°��� ����
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }

    public void PlayerMove02()              // �÷��̾��� rigidBody������Ʈ�� �̵��ӵ��� �ٲ� �̵��ϴ� �Լ�
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();              // �밢�� ���⿡�� ���ӵǴ°��� ����

        rb.velocity = moveInput * moveSpeed;
    }

}
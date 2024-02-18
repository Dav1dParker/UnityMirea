using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // ���������� �� ������� �� Character Controller
    public CharacterController characterController;

    // �������� ��� ��������� �������� ������������
    public float speed = 12f;

    // �������� �������������� ���������� (g) ��� ������ ����������
    public float gravity = -9.81f;

    // ���������� ��� �������� �������� �������
    public Vector3 velocity;

    public Transform GroundCheck;

    // ���������� �� �����, �� ������� ����� ������������ ��������� ������
    public float groundDistance = 0.4f;

    // ����� ��� ������������� �����
    public LayerMask groundMask;

    // ���������� ��� �������� ��������� ���������� �� �����
    bool isGrounded;

    public float jumpForce = 1000;

    // Update is called once per frame
    void Update()
    {
        // ��������� ������������� ����� �������� � ������� WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // ������ ��������� ��������� �������, � ����������� �� ����, ����� ���������� �������� (x ��� z).
        //          (forward)
        //              z
        //(left)-x            +x(right)
        //              -z
        //          (backward)
        Vector3 move = transform.right * x + transform.forward * z;

        // ����� ������ Move() �� CC � �������� ��� ������������
        characterController.Move(move * speed * Time.deltaTime);

        // ��������� ���������� Y ������� ��������
        velocity.y += gravity * Time.deltaTime;

        // ����� ������ Move() �� CC � �������� ��� �������
        // �� ������ ������� ��������� ���������� ������� h = 1/2 * g * t^2
        // ��� h - ������, g - ��������� ���������� �������, t - �����
        characterController.Move((velocity*Time.deltaTime) / 2);

        // ���������� ���������� true, ���� ��������� ������, ��������� � GroundCheck � �������� groundDistance, �������������� �� ����� groundMask
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        // �������� ���������� ���������� isGrounded
        if (isGrounded && velocity.y < 0)
        {
            // ���� ���������� �������, �� �������� ������� ����������
            // 2f - ��� ��������, ������� �������� ����������� ��� �������� �������
            velocity.y = -2f;
        }

        // ��� ������� �� ������ � ���������� isGrounded �������, �� ������ ����� ������������
        Debug.Log(isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
}

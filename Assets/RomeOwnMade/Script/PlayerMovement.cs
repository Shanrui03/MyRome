using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Moving Speed")]
    public float speed = 12f;

    [Header("Gravity")]
    public float gravity = -9.81f;

    [Header("Jump Distance")]
    public float jumpHeight = 3f;

    private CharacterController controller;

    private Vector3 velocity;
    private bool isGround;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        movement();
    }
    void movement()
    {
        //x��z���ƶ���
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //���ݽ�ɫ�ĳ�����л���x����z����ƶ�   


        controller.Move(move * speed * Time.deltaTime);


        //����������y���ƶ���
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        //isGround = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);
        isGround = controller.isGrounded;

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //��Ծ
        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity); //v=sqrt��2gh����
        }

    }


}

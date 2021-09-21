using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.8f, negaGravity = 9.8f;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    bool isGround;
    Vector3 velocity;

    void Update()
    {
        float x = Input.GetAxis("Horizontal"), z = Input.GetAxis("Vertical");
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Vector3 move = transform.right * x + transform.forward * z; 

        if(isGround)
        {
            controller.Move(move * moveSpeed * Time.deltaTime);
            velocity.y = -2.9f;
        }
        velocity.y += gravity * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}

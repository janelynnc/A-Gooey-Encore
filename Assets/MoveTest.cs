using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 Jump = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * speed * Input.GetAxis("Vertical"));
        controller.SimpleMove(right * speed * Input.GetAxis("Horizontal"));

        if (controller.isGrounded && Input.GetKey(KeyCode.Space))
        {
            Jump.y = jumpSpeed;
        }
        Jump.y -= gravity * Time.deltaTime;
        controller.Move(Jump * Time.deltaTime);
    }
}

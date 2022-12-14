using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed,
                                   rb.velocity.y, joystick.Vertical * moveSpeed);


        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {   
            float targetAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "HiddenStair")
        {
            moveSpeed = 1.5f;
        }
        else
        {
            moveSpeed = 1f;
        }
    }
}
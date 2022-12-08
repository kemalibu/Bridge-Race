using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float moveSpeed = 5f;

    float verticalValue;

    private int steerValue;

    private void FixedUpdate()
    {
        MovementController();
    }


    private void MovementController()
    {
        transform.Translate(Vector3.forward * verticalValue * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(0f, steerValue * turnSpeed * Time.fixedDeltaTime, 0f);
    }

    public void VerticalValue(int value)
    {
        verticalValue = value;
    }

    public void SteerValue(int value)
    {
        steerValue = value;
    }
}

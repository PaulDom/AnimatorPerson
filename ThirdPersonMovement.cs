using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 9f;
    float targetMovingSpeed;

    public bool canRun = true;
    public bool isRunning;

    public KeyCode runningKey = KeyCode.LeftShift;
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        isRunning = canRun && Input.GetKey(runningKey);

        if (isRunning)
        {
            targetMovingSpeed = runSpeed;
        }
        else
        {
            targetMovingSpeed = speed;
        }

        playerRigidbody.velocity = transform.rotation * 
            new Vector3(Input.GetAxis("Horizontal"), playerRigidbody.velocity.y, Input.GetAxis("Vertical") * targetMovingSpeed);

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * (100f * Time.deltaTime), Space.Self);
 
    }



}

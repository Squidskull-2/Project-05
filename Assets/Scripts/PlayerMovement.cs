using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    private float ySpeed;
    private CharacterController charControl;

    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * moveSpeed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ySpeed = jumpSpeed;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        charControl.Move(velocity * Time.deltaTime);
    }
}

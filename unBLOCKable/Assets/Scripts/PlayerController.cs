using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    public Vector3 forwardSpeedV3 = new Vector3(0.5f, 0, 0);
    public Vector3 moveLeftDistanceV3 = new Vector3(0, 0, 1.00f);
    public Vector3 moveRightDistanceV3 = new Vector3(0, 0, -1.00f);
    public Vector3 moveUpDistanceV3 = new Vector3(0, 1.00f, 0);
    public Vector3 moveDownDistanceV3 = new Vector3(0, -1.00f, 0);
    public Vector3 moveForwardDistanceV3 = new Vector3(1.00f, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started the game");

        rb = GetComponent<Rigidbody>();

        Vector3 playerTransformPosition = transform.position;
    }
    void OnMove(InputValue movementValue)
    {
        Debug.Log("OnMove");

        //Vector2 movementVector = movementValue.Get<Vector2>();
        
        //movement = new Vector3(movementVector.x, 0.0f, 0.0f);


        
    }

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate Called");
        //rb.AddForce(movement * speed);
        transform.position += forwardSpeedV3;





    }

    private void OnMoveLeft() 
    {
        transform.position += new Vector3(0, 0, 1.00f);
        Debug.Log("OnMoveLeft");
    }

    private void OnMoveRight()
    {
        transform.position += moveRightDistanceV3;
        Debug.Log("OnMoveRight");

    }

    private void OnMoveUp()
    {
        transform.position += moveUpDistanceV3;

    }

    private void OnMoveDown()
    {
        transform.position += moveDownDistanceV3;

    }

    private void OnMoveForward()
    {
        transform.position += moveForwardDistanceV3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    private float movementX;
    private Vector3 movement;

    private Vector3 playerTransformPosition;




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
        transform.position += new Vector3(0.5f, 0, 0);





    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

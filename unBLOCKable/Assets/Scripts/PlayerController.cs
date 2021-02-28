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
    //public Vector3 moveUpDistanceV3 = new Vector3(0, 1.00f, 0);
    //public Vector3 moveDownDistanceV3 = new Vector3(0, -1.00f, 0);
    public Vector3 moveForwardDistanceV3 = new Vector3(1.00f, 0, 0);

    public float jumpPower = 1.00f;

    public GameManager GameManager;

    public GameObject[] StandardBlocks;

    private Vector3 leftRightVelocity = Vector3.zero;

    public Vector3 positionToMoveTo = new Vector3(1000.00f, 1000.00f, 1000.00f);

    private bool currentlyLerping = false;

    public static float lerpDurationOriginalValue = 0.01f;

    public float lerpDuration = lerpDurationOriginalValue;

    public GameObject TestCube;

    //Vector3 targetPosition = new Vector3(4.00f,1.00f,0.00f);
    Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Started the game");

        rb = GetComponent<Rigidbody>();

        //Vector3 playerTransformPosition = transform.position;
        Vector3 targetPosition = transform.position;


    }
    void OnMove(InputValue movementValue)
    {
        //Debug.Log("OnMove");
        
    }

    public Transform transformGetSet 
    {
        get 
        {
            return transform;
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate Called");
        //rb.AddForce(movement * speed);


        transform.position += forwardSpeedV3;




    }

    IEnumerator LerpPosition()
    {
        currentlyLerping = true;

        float time = 0;
        //Vector3 startPosition = transform.position;
        //Debug.Log(targetPosition);

        while (time < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position[0], transform.position[1], targetPosition[2]), time / lerpDuration);
            time += Time.deltaTime;
            yield return null;
            //Debug.Log("while loop ran");
        }
        
        transform.position = new Vector3(transform.position[0], transform.position[1], targetPosition[2]);
        currentlyLerping = false;
        lerpDuration = lerpDurationOriginalValue;

    }


    private void OnMoveLeft() 
    {
        //transform.position += new Vector3(0, 0, 1.00f);
        targetPosition = targetPosition + new Vector3(0, 0, 1.00f);
        Debug.Log(lerpDuration);

        if (currentlyLerping == true)
        {
            lerpDuration = lerpDuration + lerpDurationOriginalValue;
        }
        if (currentlyLerping == false) 
        {
            StartCoroutine(LerpPosition());

        }
        //Debug.Log("OnMoveLeft UPDATED");
    }

    private void OnMoveRight()
    {
        //transform.position += moveRightDistanceV3;
        //Debug.Log(targetPosition);
        targetPosition = targetPosition + moveRightDistanceV3;
        if (currentlyLerping == true) 
        {
            lerpDuration = lerpDuration + lerpDurationOriginalValue;
        }
        if (currentlyLerping == false)
        {

            StartCoroutine(LerpPosition());

        }

        //transform.position += Vector3.Lerp(transform.position, moveRightDistanceV3, 0.7f);
        //Debug.Log("OnMoveRight");
        

    }

    private void OnMoveUp()
    {
        //transform.position += moveUpDistanceV3;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

    }

    private void OnMoveDown()
    {
        //transform.position += moveDownDistanceV3;
        rb.AddForce(Vector3.down * jumpPower, ForceMode.Impulse);

    }

    private void OnMoveForward()
    {
        transform.position += moveForwardDistanceV3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider objectCollider)
    {
        //Debug.Log("TriggerActivated");
        if (objectCollider.gameObject.CompareTag("StandardBlockCollisionTriggerCollider"))
        {
            GameManager.playerCollidedWithWall();
        } else if (objectCollider.gameObject.CompareTag("CherryPickupTrigger"))
        {
            GameManager.Destroy(objectCollider.gameObject);
            GameManager.DisplayCherryPickupParticleEffect();
        }

    }
}

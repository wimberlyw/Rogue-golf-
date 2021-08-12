using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPoint : MonoBehaviour
{
    float xRot, yRot =0f;
    public Rigidbody ball;
    public float rotationSpeed = 5f;
    public ballLauncher BallLauncher;
    private bool canRotateCam =false;
    private Quaternion lerpedRot, stockQuat;
    float smooth = 30;
    

    // Update is called once per frame
    void Update()
    {

        getForward();

        isBallMoving();


        transform.position = ball.position;
        if(Input.GetMouseButton(0))        
        {
            if(BallLauncher.isShoot)
            {
                return;
            }
            else
            {
                xRot += Input.GetAxis("Mouse X")* rotationSpeed;
                yRot += Input.GetAxis("Mouse Y")* rotationSpeed;
                transform.rotation = Quaternion.Euler(-yRot, xRot, 0f);
            }
            
        }
        

    }

    Quaternion getForward()
    {

        if (Input.GetMouseButton(0))
        {
            stockQuat = transform.rotation;
        }
        return stockQuat;
    }
    bool isBallMoving()
    {
        if( ball.velocity.magnitude > .01f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void FixedUpdate()
    {


        if (ball.position.y > 2f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Vector3.up, Vector3.up),  Time.deltaTime);
            //lerpedRot = Quaternion.FromToRotation(Vector3.up, transform.forward);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, lerpedRot, smooth * Time.deltaTime);
            canRotateCam = true;
        }
        if (canRotateCam)
        {
            if (ball.position.y <= 2f)
            {
                lerpedRot = Quaternion.FromToRotation(Vector3.up, -transform.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lerpedRot, smooth * Time.deltaTime);


                if(ball.position.y<=.2f && this.transform.rotation.x != 0 && isBallMoving())
                {
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, stockQuat, 200 * Time.deltaTime);
                canRotateCam = false;
                }

                

            }

            

        }
        if (ball.position.y <= 0.2f && this.transform.rotation.x != 0 && isBallMoving())
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, stockQuat, smooth * 2* Time.deltaTime);
            canRotateCam = false;
        }

    }
    void Start()
    {
        stockQuat = transform.rotation;
    }
  
}


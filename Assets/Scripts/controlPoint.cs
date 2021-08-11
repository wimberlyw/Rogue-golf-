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
    void FixedUpdate()
    {

    
            if(ball.position.y>=4)
            {
                lerpedRot = Quaternion.FromToRotation(Vector3.up, transform.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lerpedRot, smooth * Time.deltaTime);
                canRotateCam = true;
            }
            if(canRotateCam)
            {
                if(ball.position.y<=4 && ball.position.y>1)
                {
                    lerpedRot = Quaternion.FromToRotation(Vector3.up, -transform.forward);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, lerpedRot, smooth * Time.deltaTime);
                    
                }
                if(ball.position.y<=1)
                {
                    canRotateCam = false;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, stockQuat, smooth * Time.deltaTime);
                }
            }
            if(ball.position.y<=1 && this.transform.rotation.x !=0)
                {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, stockQuat, smooth * Time.deltaTime);
                }

    }

    void Start()
    {
        stockQuat = transform.rotation;
    }
  
}


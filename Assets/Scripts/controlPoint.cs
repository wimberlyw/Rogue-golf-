using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPoint : MonoBehaviour
{
float xRot, yRot =0f;
public Rigidbody ball;
public float rotationSpeed = 5f;
public ballLauncher BallLauncher;

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
                transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
                }
            
        }
    }
}

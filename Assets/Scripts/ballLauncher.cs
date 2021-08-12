using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class ballLauncher : MonoBehaviour
{

    private Vector3 mousePressDownPos, mouseRealeasePos, currentMousePos, lineStartPos, lineEndPos, ballVel;
    public Rigidbody ballRB;
    public float forceMultiplier = .02f;
    public float maxForce = 8;
   // ballLine bl;
    private Camera cam;
    //public LineRenderer lr;
    public bool isShoot = false;
    public controlPoint ControlPoint;

     void Awake()
    {
        //lr = GetComponent<LineRenderer>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        
        cam = Camera.main;
        //bl = GetComponent<ballLine>();
    }

    void OnMouseDrag()
    {
        currentMousePos = Input.mousePosition;

        
        //currentMousePos.x *= -1 ;
        //currentMousePos.z = Vector3.Distance(lineStartPos, currentMousePos);
        
        
        //lr.SetPosition(1, currentMousePos );
        //Debug.Log(currentMousePos);
    }

    void OnMouseDown()
    {
        //lr.enabled=true;
        //lr.positionCount = 2;
        isShoot = true;
        mousePressDownPos = Input.mousePosition;
       
        //lineStartPos = ballRB.transform.position;
        //lr.SetPosition(0, lineStartPos);
    }

    void OnMouseUp()
    {    
        mouseRealeasePos = Input.mousePosition;
        ballVel = (mousePressDownPos - mouseRealeasePos);
        ballVel = new Vector3(0, ballVel.y * .008f, 0);
        Shoot((mousePressDownPos - mouseRealeasePos).magnitude);
        
    }
        
    void Shoot(float Force)
    {
        if(!isShoot)
            return;

        Vector3 totalForce = (ControlPoint.transform.forward + ballVel) * Force * forceMultiplier;
        //CLAMP EACH VECTOR DIRECTION FOR POWER
        totalForce.x = Mathf.Clamp(totalForce.x, -maxForce, maxForce);
        totalForce.y = Mathf.Clamp(totalForce.y, -maxForce, maxForce);
        totalForce.z = Mathf.Clamp(totalForce.z, -maxForce, maxForce);

        ballRB.AddForce(totalForce, ForceMode.Impulse);
        Debug.Log("Force: " + totalForce);
        isShoot = false;
        

    }

  
}

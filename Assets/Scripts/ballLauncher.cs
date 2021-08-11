using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class ballLauncher : MonoBehaviour
{

    private Vector3 mousePressDownPos, mouseRealeasePos, currentMousePos, lineStartPos, lineEndPos, ballVel;
    public Rigidbody ballRB;
    public float forceMultiplier = .02f;
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
        ballRB.AddForce((ControlPoint.transform.forward +ballVel)* Force * forceMultiplier, ForceMode.Impulse);
        isShoot = false;
        

    }

  
}

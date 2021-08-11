using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
//Camera Follows The Ball
    public static CamFollow instance;
    [SerializeField] private ActiveVectors activeVectors; //class that decides which axis to follow
   // [SerializeField] private CameraRotation cameraRotation;

    //public CameraRotation CameraRotation{ get{ return cameraRotation;} }
   
    private GameObject followTarget;
    private Vector3 offset;
    private Vector3 changePos;

    private void Awake()
    {
        if (instance ==null) instance = this;
        else Destroy(gameObject);
    }
    public void SetTarget(GameObject target)
    {
        followTarget= target;                                               //set target
        offset = followTarget.transform.position - transform.position;      //set offset
        changePos = transform.position;                                     //set changePos
    }

    private void LateUpdate()
    {   
        
        if(followTarget)                                                    //if target is present
        {
            if(activeVectors.x)                                             //if x axis is allowed
            {  
                changePos.x = followTarget.transform.position.x-offset.x;   //set the change pos x
            }
            if(activeVectors.y)
            {  
                changePos.y = followTarget.transform.position.y-offset.y;
            }
            if(activeVectors.z)
            {  
                changePos.z = followTarget.transform.position.z-offset.z;
            }
            transform.position = changePos;
        }
    }

    [System.Serializable]
    public class ActiveVectors
    {
        public bool x, y, z;
    }

    
}

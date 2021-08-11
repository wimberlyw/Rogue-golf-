using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallLayer : MonoBehaviour
{
    [SerializeField] private int LayerOnEnter;
    [SerializeField] private int LayerOnExit;
    public LevelManager levelManager;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.layer = LayerOnEnter;
            levelManager.SpawnLevel(1);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            other.gameObject.layer = LayerOnExit;
        }
    }
}

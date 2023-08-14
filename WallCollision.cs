using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public GameObject wall;
    private Vector3 initialPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == wall)
        {
            transform.position = initialPosition;
            
        }
    }
    
}

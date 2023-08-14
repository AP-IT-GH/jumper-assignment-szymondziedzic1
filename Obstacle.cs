using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Zie of de obstacle de muur aanraakt
        if (collision.gameObject.tag == "Wall")
        {
            // Reset de positie
            transform.position = initialPosition;
        }
    }
}

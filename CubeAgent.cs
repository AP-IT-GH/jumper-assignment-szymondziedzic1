using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using static UnityEngine.GraphicsBuffer;
using Unity.MLAgents.Sensors;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class CubeAgent : Agent
{
    public Rigidbody rb = null;
    public Transform obstacle;
    public Transform wall;
    public Transform reset = null;
    
    public float speedMultiplier = 1f;
    private Vector3 obstaclePosition;
    private Vector3 cubePosition;

    // Start is called before the first frame update
    
    public override void OnEpisodeBegin()
    {
        if (obstacle.localPosition.y < -1) EndEpisode();
        transform.position = cubePosition;
        obstacle.position = obstaclePosition;
    }

    public override void Initialize()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
        obstaclePosition = obstacle.position;
        cubePosition = transform.position;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(obstacle.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.y = actionBuffers.ContinuousActions[0];
        if(transform.position.y < 5)
            transform.Translate(controlSignal * speedMultiplier);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle") == true)
        {
            Debug.Log("The agent failed");
            SetReward(-0.5f);
            EndEpisode();
        }        
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {
            continuousActionsOut[0] = 1;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class WallCollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle") == true)
        {
            // Find the JumpingAgent agent in the scene and reward it
            CubeAgent agent = FindObjectOfType<CubeAgent>();
            if (agent != null)
            {
                Debug.Log("Obstacle touched the wall");
                agent.SetReward(1.0f);
                agent.EndEpisode();
            }
        }
    }
}

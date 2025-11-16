using System.Security.Principal;
using UnityEngine;

public class Obst : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    public Transform player;
    
    public Vector3 spwanPosition;
    public float coinChance = 0.05f;
    public float distanceBetweenObstacle = 10f;
    public float horizonDistance = 50f;


  
    void Update()
    {
        float distance = Vector3.Distance(player.position, spwanPosition);

        if (distance < horizonDistance)
        {
            int x = Random.Range(-3, 4);
            spwanPosition = new Vector3(x, -0.8f, spwanPosition.z + distanceBetweenObstacle);

            if (Random.value < coinChance)
    {
        Vector3 coinPosition = new Vector3(x, -0.8f, spwanPosition.z);
        Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    }
    else
    {
        Vector3 obstaclePosition = new Vector3(x, 1.5f, spwanPosition.z);
        Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);
    }
                
        }
            
        
    }
        
}


using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 200f;


    
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

  
    public void moveRoad()
    {
        GameObject moveRdRoad = roads[0];      
        GameObject lastRoad = roads[roads.Count - 1]; 

     float newZ = lastRoad.transform.position.z + offset;
    moveRdRoad.transform.position = new Vector3(0, moveRdRoad.transform.position.y, newZ);

       
    roads.Remove(moveRdRoad);
     Debug.Log("remove");
     roads.Add(moveRdRoad);
     
    }
}

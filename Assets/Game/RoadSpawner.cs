using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 200f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    // Update is called once per frame
    public void moveRoad()
    {
        GameObject moveRdRoad = roads[0];           // das erste Stück
        GameObject lastRoad = roads[roads.Count - 1]; // das aktuell letzte Stück

     float newZ = lastRoad.transform.position.z + offset;
    moveRdRoad.transform.position = new Vector3(0, moveRdRoad.transform.position.y, newZ);

        // Liste aktualisieren
    roads.Remove(moveRdRoad);
     Debug.Log("remove");
     roads.Add(moveRdRoad);
     
    }
}

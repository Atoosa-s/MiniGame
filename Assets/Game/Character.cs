using UnityEngine;

public class FollowWithoutRotation : MonoBehaviour
{
    public Transform Player; 
    public Vector3 offset;   


    void Start()
    {
       
        Invoke("RotateLeft", 5f);
    }


    void LateUpdate()
    {
        if (Player != null)
        {
            
            transform.position = Player.position + offset;
            
        }
    }
    void RotateLeft()
    {
  
        transform.Rotate(0, -180f, 0);
        Debug.Log("Charakter hat sich um 90° nach links gedreht!");
    }
}

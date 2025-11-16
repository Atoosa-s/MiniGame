using UnityEngine;

public class FollowWithoutRotation : MonoBehaviour
{
    public Transform Player; // Der Ball
    public Vector3 offset;   // Abstand vom Ball (z. B. über ihm)


    void Start()
    {
        // Nach 5 Sekunden einmalig RotateLeft() ausführen
        Invoke("RotateLeft", 3f);
    }


    void LateUpdate()
    {
        if (Player != null)
        {
            // Folge der Position des Balls
            transform.position = Player.position + offset;
            // Rotation bleibt gleich (also kein Mitdrehen)
        }
    }
    void RotateLeft()
    {
        // Sofortige 90°-Drehung nach links (um Y-Achse)
        transform.Rotate(0, -180f, 0);
        Debug.Log("Charakter hat sich um 90° nach links gedreht!");
    }
}

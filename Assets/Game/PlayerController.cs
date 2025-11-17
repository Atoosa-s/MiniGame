using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float sprintMultiplier;
    private Rigidbody rb;
    public SpawnManager spawnManager;

    public WinLose winLose;


    private int triggerCount = 0;

    public AudioManager audioManager;


  

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertival = Input.GetAxis("Vertical");

        CheckFallOut();

        float currentSpeed = speed;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentSpeed *= sprintMultiplier;

        }


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertival);

        rb.AddForce(movement * currentSpeed);


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SpawnTrigger"))
        {
            triggerCount++;
            Debug.Log("CountTrigger");
            spawnManager.SpawnTriggerEntered();

        }

        if (other.CompareTag("Box"))
        {
            audioManager.mCoin(audioManager.BoxTouch);
            winLose.boxHit();

        }

    }
    
    void CheckFallOut()
    {
         if (transform.position.y < -5f)
    {
        Debug.Log("Player ist raus gefallen!");
        Time.timeScale = 0f; 
        SceneManager.LoadScene(2);
        
    }
    }

    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;

    private float minSpeed = 13;
    private float maxSpeed = 17;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPosition = -6;

    private gameManager GameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {

        targetRb = GetComponent<Rigidbody>(); //Initialise Rigid Body of Targets
        targetRb.AddForce(RandomForce(), ForceMode.Impulse); //Throw upward with Random Force
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); //Throw upward with Random Torque/Spin
        transform.position = RandomSpawnPosition(); //Spawn at Random Position

        //Reference Game Manager Script
        GameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Throw Objects Up with Random Force
    Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    //Throw Objects Up with Random Torque/Spin
    float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }

    //Spawn Objects at Random Places
    Vector3 RandomSpawnPosition() {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition);
    }

    //Function to Detect Mouse Click and Destroy What is Clicked
    private void OnMouseDown() {

        if (GameManager.isGameActive) { //if Game is NOT over then allow player to play

            Destroy(gameObject);
            GameManager.UpdateScore(pointValue); //Update Score Based on Point Value of Each Target

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); //Play explosion effect when clicked
        }
    }

    //Function to Destroy When collider is Clicked
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")) {
            GameManager.GameOver();
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private Rigidbody rb;
    public Vector2 randomForce, randomTorque;
    public float xRange = 4.5f;
    [SerializeField] int scoreChange, livesChange;
    public GameObject explosionParticle;
    [SerializeField] Color myColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = myColor;
        //gets access to the current rigid body
        rb = GetComponent<Rigidbody>();

        //add a random upwards force
        rb.AddForce(Vector3.up * Random.Range(randomForce.x, randomForce.y), ForceMode.Impulse);

        //add a random rotation/torque
        rb.AddTorque(Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), Random.Range(randomTorque.x, randomTorque.y), ForceMode.Impulse);

        //random starting position
        transform.position = new Vector3(Random.Range(-xRange,xRange), -1, 0);
    }
    private void Update()
    {
        if (transform.position.y < -4) Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        FindFirstObjectByType<GameManager>().updateUI(scoreChange, livesChange);
        Destroy(Instantiate(explosionParticle, transform.position, Quaternion.identity), 5);

        Destroy(gameObject);
    }
    /*
     * Your journey with starting a studio as a student. What made you do it, How did you get a team together, etc
     * Continuing with Moss Monkey after uni, how does one approach publishers or funding, any tips?
     * How is the industry currently for indie game developers
     * Your experience with the Global Game Jam
     * Any tips or things to consider while participating in a game jam like this. Thinking about scope, ideation, project and time management
     * */
    
}

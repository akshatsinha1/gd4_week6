using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private Rigidbody rb;
    public Vector2 randomForce, randomTorque;
    public float xRange = 4.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        if (transform.tag == "Good") FindFirstObjectByType<GameManager>().score++;
        else FindFirstObjectByType<GameManager>().lives--;


        Destroy(gameObject);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float speed;
    float currentSpeed;

    private void Start()
    {
        speed = Random.Range(0.6f, .7f);
    }

    private void Update()
    {
        currentSpeed = manager.i.speed * speed;
        
        if (!AboutToCollide())
            transform.position += (transform.forward * currentSpeed) * Time.deltaTime;
        else //slow car if about to collide
            transform.position += (transform.forward * (currentSpeed - 2)) * Time.deltaTime;

        if (transform.position.z > 25)
        {
            Destroy(gameObject);
        }
    }

    private bool AboutToCollide()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 0, 0.5f), transform.forward, 1))
            return true;
        else
            return false;
    }
}

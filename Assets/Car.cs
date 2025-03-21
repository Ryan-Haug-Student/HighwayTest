using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float speed;

    private void Start()
    {
        speed = Random.Range(2f, 5f);
    }

    private void Update()
    {
        transform.position += (transform.forward * speed) * Time.deltaTime;

        if (transform.position.z > 25)
            Destroy(gameObject);
    }
}

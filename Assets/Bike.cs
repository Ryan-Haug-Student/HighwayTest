using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public float lean;
    public GameObject pivot;

    public Rigidbody rb;

    private void Update()
    {
        Lean();
        Move();

        transform.localPosition = new Vector3(0, .2f, 0);
        transform.localRotation = Quaternion.Euler(90, -90, -90);
    }

    private void Lean()
    {
        if (Input.GetKey(KeyCode.A) && lean > -35) //go left
            lean -= .2f;
        if (Input.GetKey(KeyCode.D) && lean < 35) //go right
            lean += .2f;

        pivot.transform.rotation = Quaternion.Euler(0, 0, lean);
    }

    private void Move()
    {
        if (lean < 0 && pivot.transform.position.x < 1.5f)
            pivot.transform.position += new Vector3(0.0002f * -lean, 0, 0);
        else if (lean > 0 && pivot.transform.position.x > -1.5f)
            pivot.transform.position += new Vector3(0.0002f * -lean, 0, 0);
    }
}

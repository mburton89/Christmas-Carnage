using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float movementSpeed;

    void Start()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            movementSpeed = -movementSpeed;
        }
    }

    void Update()
    {
        transform.position += Vector3.up * movementSpeed * Time.deltaTime;
    }
}

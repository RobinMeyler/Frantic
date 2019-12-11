using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformBehav : MonoBehaviour
{
    public float dropSpeed = 0;
    public float sideSpeed = 0;
    public float time = 0;
    int oop = 0;

    // Start is called before the first frame update
    void Start()
    {
        dropSpeed = -0.01f;
        sideSpeed = 0.01f;


    // Random start x logic
    // start y above screen
}

    // Update is called once per frame
    void Update()
    {
        // Side swaping logic
        // Drop speed increasing logic
        // Once below screen reset
        if(transform.position.x > 2.34 || transform.position.x < -2.34)
        {
            sideSpeed = -sideSpeed;
        }
        if (transform.position.y < -5.9)
        {
            float randX = Random.Range(-2.34f, 2.34f);
         
            transform.position = new Vector3(randX, 5.5f, 0);
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0,0,90);
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }

        }

        time += Time.deltaTime;

        if (time > 5)
        {
            Debug.Log(++oop);
            time = 0;
            dropSpeed = dropSpeed - 0.001f;
        }
        transform.position = transform.position + new Vector3(sideSpeed, dropSpeed, 0);
    }
}
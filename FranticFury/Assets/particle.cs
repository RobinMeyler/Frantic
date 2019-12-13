using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        if(player.GetComponent<PlayerBehaviour>().die == true)
        {
            GetComponent<ParticleSystem>().enableEmission = true;
        }
    }
}

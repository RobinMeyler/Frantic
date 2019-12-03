using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeBehaviour : MonoBehaviour
{
    private GameObject platform;
    public GameObject gameController;
    GameObject[] platforms;
    private float degrees = 0f;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        index = Random.Range(0, platforms.Length);
    }

    // Update is called once per frame
    void Update()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        this.transform.position = platforms[index].transform.position;
        degrees += 1;
        this.transform.eulerAngles = Vector3.forward * degrees;
    }
}

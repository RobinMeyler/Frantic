using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBehaviour : MonoBehaviour
{
    public GameObject platform;
    private GameObject temp;
    public GameObject[] platforms;

    public GameObject blade;
    public GameObject player;

    public Text text;
    private int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[4];

        // Initialise plats 
        Quaternion spawnRotation = Quaternion.identity;
        Vector3 spawnPosition = new Vector3(-2.21f, -4.68f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[0] = temp;

        spawnPosition = new Vector3(0, -3.2f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[1] = temp;

        spawnPosition = new Vector3(2.19f, -1.72f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[2] = temp;

        spawnPosition = new Vector3(-1.55f, -0.69f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[3] = temp;


        blade = Instantiate(blade);
        blade.GetComponent<BladeBehaviour>().setIndex(2);
        blade.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        
    }

    // Update is called once per frame
    void Update()
    {
        switch(stage)
        {
            case 0:
                // left n right
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    stage = 1; // next shtep
                }
                break;
            case 1:
                // jump to platform
                text.text = "Press the Up Arrow to jump up to the Platform!";
                if (platforms[1].GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
                {
                    stage = 2;
                }
                break;
            case 2:
                // avoid blade!
                text.text = "Blades are Dangerous, if you hit off of them you will not have a fun time :( Try avoid the Blade!";
                break;
        }
    }
}

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
    public int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[6];

        // Initialise plats 
        Quaternion spawnRotation = Quaternion.identity;
        Vector3 spawnPosition = new Vector3(-2.21f, -3.68f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[0] = temp;

        spawnPosition = new Vector3(0, -2.2f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[1] = temp;

        spawnPosition = new Vector3(2.19f, -0.72f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[2] = temp;

        spawnPosition = new Vector3(-1.75f, 0.7f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[3] = temp;

        spawnPosition = new Vector3(-2.65f, 2.0f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        temp.transform.Rotate(0, 0, 90);
        platforms[4] = temp;

        spawnPosition = new Vector3(1.95f, 2.8f, 0);
        temp = Instantiate(platform, spawnPosition, spawnRotation);
        platforms[5] = temp;


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
                if (platforms[3].GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
                {
                    stage = 3;
                }
                break;
            case 3:
                // wall jump!
                text.text = "You did it! Next is the Wall Jump, to do this, press the up arrow again when against a Wall!";
                if (platforms[5].GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
                {
                    stage = 4;
                }
                break;
            case 4:
                // complete!
                text.text = "Congratulations! you have completed the Tutorial";
                break;
        }
    }
}

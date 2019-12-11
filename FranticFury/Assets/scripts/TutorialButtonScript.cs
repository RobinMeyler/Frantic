using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialButtonScript : MonoBehaviour
{
    public Button thisButton;
    AudioSource clickObj;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = thisButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //clickObj.Play();
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}

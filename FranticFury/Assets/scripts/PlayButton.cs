using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour
{
    public Button thisButton;
    AudioSource clickObj;

    void Start()
    {
        Button btn = thisButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        //GameObject uiClick = GameObject.FindGameObjectWithTag("ClickFX");
        //clickObj = uiClick.GetComponent<AudioSource>();
    }

    void TaskOnClick()
    {
        //clickObj.Play();
        SceneManager.LoadScene("FranticFury", LoadSceneMode.Single);
    }
}

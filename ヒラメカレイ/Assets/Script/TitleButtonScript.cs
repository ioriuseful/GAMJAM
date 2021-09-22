using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtonScript : MonoBehaviour
{
    public Button startButton;
    public Button endButton;

    public GameObject sceneManagerOBJ;
    private SceneManagement sceneManagement;

    public AudioSource audioSource;
    public AudioClip ketteiSE;
    public AudioClip selectSE;

    private bool oneSound = false;

    private float tien = 1f;
    private bool tienFlag = false;

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(1920, 1080, false, 60);
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.Select();
        sceneManagement = sceneManagerOBJ.GetComponent<SceneManagement>();
        oneSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tien > 0)
        {
            tien -= Time.deltaTime;
        }
        else tienFlag = true;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            startButton.Select();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            endButton.Select();
        }
    }

    public void OnClickStartButton()
    {
        if (!tienFlag) return;
        sceneManagement.OnClickGameScene();
        if(!oneSound)
        {
            audioSource.PlayOneShot(ketteiSE);
            oneSound = true;
        }
       
    }

    public void OnClickEndButton()
    {
        if (!tienFlag) return;
        sceneManagement.OnClickEnd();
    }
}

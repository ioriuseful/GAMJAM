using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverButton : MonoBehaviour
{
    public Button titleButton;
    public Button endButton;

    public GameObject sceneManagerOBJ;
    private SceneManagement sceneManagement;

    public AudioSource audioSource;
    public AudioClip ketteiSE;
    public AudioClip selectSE;

    private bool oneSound = false;
    private float tien = 1f;
    private bool tienFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        titleButton.Select();
        sceneManagement = sceneManagerOBJ.GetComponent<SceneManagement>();
        oneSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tien > 0)
        {
            tien -= Time.deltaTime;
        }
        else tienFlag = true;
    }

    public void OnClickTitleButton()
    {
        if (!tienFlag) return;
        if (!oneSound)
        {
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(ketteiSE);
            oneSound = true;
        }
      
        sceneManagement.OnClickTitle();
    }

    public void OnClickEndButton()
    {
        if (!tienFlag) return;
        sceneManagement.OnClickEnd();
    }
}

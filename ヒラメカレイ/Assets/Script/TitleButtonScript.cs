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
    // Start is called before the first frame update
    void Start()
    {
        startButton.Select();
        sceneManagement = sceneManagerOBJ.GetComponent<SceneManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        sceneManagement.OnClickGameScene();
    }

    public void OnClickEndButton()
    {
        sceneManagement.OnClickEnd();
    }
}

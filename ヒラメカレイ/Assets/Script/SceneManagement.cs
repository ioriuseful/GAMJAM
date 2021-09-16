using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update

    private string sceneName = "";
    private bool clearFlag = false;

    public GameObject fade;
    private bool oneFadeFlag = false;

    public enum SceneNames
    {
        TitleScene,
        GameScene,
        ClearScene,
        GameOverScene,
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

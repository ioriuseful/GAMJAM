using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject vCamera;
    public GameObject vCamera2;
    private bool change = false;
    private float delay = 0;
    private const float delayTime = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delay > 0)
        {
            delay -= 1 * Time.deltaTime;
            if (delay < 0) delay = 0;
        }

        if(Input .GetKeyDown(KeyCode.Return) && delay == 0)
        {
            vCamera.SetActive(change);
            change = !change;
            delay = delayTime;
        }
    }


}

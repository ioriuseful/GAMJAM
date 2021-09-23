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
    private GameObject camaraTarget;
    public GameObject player;
    private GameObject gameManager;
    private Data data;
    private bool changeStartFlag = false;

    public AudioClip kaitenSE;
    public AudioSource audioSourse;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camaraTarget = GameObject.Find("CameraTarget");
        gameManager = GameObject.Find("DataOBJ");
        data = gameManager.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        if(delay > 0)
        {
            delay -= 1 * Time.deltaTime;
            if (delay < 0)
            {
                delay = 0;
                data.SetStageChangeFlag(change);
                changeStartFlag = false;
                data.SetStageMoveFlag(changeStartFlag);
            }
        }

        if(Input .GetKeyDown(KeyCode.Return) && delay == 0)
        {
            vCamera.SetActive(change);
            change = !change;
            delay = delayTime;
            changeStartFlag = true;
            data.SetStageMoveFlag(changeStartFlag);
            if(audioSourse != null)
            {
                audioSourse.volume = 0.8f;
                audioSourse.PlayOneShot(kaitenSE);
            }
        }

        float playerPosX = player.transform.position.x;
        camaraTarget.transform.position = new Vector3(playerPosX, camaraTarget.transform.position.y, camaraTarget.transform.position.z);
        vCamera.transform.position = new Vector3( camaraTarget.transform.position.x, camaraTarget.transform.position.y, vCamera.transform.position.z);
        vCamera2.transform.position = new Vector3( camaraTarget.transform.position.x, camaraTarget.transform.position.y, vCamera2.transform.position.z);

        //Debug.Log("----------" + data.GetStageMoveFlag());

    }


}

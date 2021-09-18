using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン遷移

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hit2");
    }

    void OntrigerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}

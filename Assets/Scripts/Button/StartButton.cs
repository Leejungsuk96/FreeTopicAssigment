using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnClickStartButton();
    }

    public void OnClickStartButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}

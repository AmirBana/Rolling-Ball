using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool startGame=false;
    public static Action start;
    public GameObject startPanel;
    public GameObject endPanel;
    void Start()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameOver == true)
        {
            endPanel.SetActive(true);
        }
    }
    public void StartGame()
    {
        startGame=true;
        start();
        startPanel.SetActive(false);
    }
    public void FadePanel()
    {
        endPanel.SetActive(false);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
        start = null;
    }
}

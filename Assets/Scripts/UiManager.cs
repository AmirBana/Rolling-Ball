using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool startGame=false;
    public static Action start;
    public GameObject startPanel;
    public GameObject endPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        startGame=true;
        start();
        startPanel.SetActive(false);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        SceneManager.LoadScene(1); //carregar level aqui
    }

    public void quitGame()
    {
        Application.Quit();
    }

}

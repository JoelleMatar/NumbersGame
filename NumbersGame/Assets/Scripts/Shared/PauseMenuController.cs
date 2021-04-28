﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject muteBtn, unmuteBtn;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        if (DontDestroy.isMuted == false)
        {
            muteBtn.SetActive(true);
            unmuteBtn.SetActive(false);
        }
        else
        {
            muteBtn.SetActive(false);
            unmuteBtn.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (DontDestroy.isMuted == false)
        {
            muteBtn.SetActive(true);
            unmuteBtn.SetActive(false);
        }
        else
        {
            muteBtn.SetActive(false);
            unmuteBtn.SetActive(true);
        }
        if (detectWin(SceneManager.GetActiveScene().buildIndex))
        {
			if(SceneManager.GetActiveScene().buildIndex == 4)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
            else pauseMenu.SetActive(true);
        }
    }

    public void showMenu()
    {
       pauseMenu.SetActive(true);
    }

    public void hideMenu()
    {
        pauseMenu.SetActive(false);
    }

    private bool detectWin (int index)
    {
        if (index == 1)
        {
            if (Number3.locked && Number5.locked && Number7.locked && Number10.locked) return true;
        }
        else if (index == 2)
        {
            if (Four.locked && Five.locked) return true;
        }
        else if (index == 3)
        {
            if (Koalas.count == 3) return true;
        }
        return false;
    }
}

using System.Collections;
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

        //HotCategory.full1 = false;
        //HotCategory.full2 = false;
        //HotCategory.full3 = false;
        //ColdCategory.full1 = false;
        //ColdCategory.full2 = false;
        //ColdCategory.full3 = false;

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
			if(SceneManager.GetActiveScene().buildIndex == 3)
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
            //if (Big.locked && Inside.locked && Slow.locked && Left.locked) return true;
        }
        else if (index == 3)
        {
            //if (CheckIntrus.intrus1 && CheckIntrus.intrus2 && CheckIntrus.intrus3) return true;
            //if (Single.intrus && Short.intrus && Light.intrus) return true;
        }
        return false;
    }
}

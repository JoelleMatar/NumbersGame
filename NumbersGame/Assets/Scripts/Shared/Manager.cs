using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static bool nb3 = true, nb5 = true, nb7 = true, nb10 = true;


    // Start is called before the first frame update
    //void Start()
    //{
    //    moving = false;
    //}
    public void playClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitClick()
    {
        Application.Quit();
        Debug.Log("Application quit");
    }

    public void restartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void homeClick()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayMusic()
    {
        //DontDestroy._audioSource.UnPause();
        DontDestroy._audioSource.mute = !DontDestroy._audioSource.mute;
        DontDestroy.isMuted = false;
    }

    public void StopMusic()
    {
        //DontDestroy._audioSource.Pause();
        DontDestroy._audioSource.mute = !DontDestroy._audioSource.mute;
        DontDestroy.isMuted = true;
    }
    

    //// Update is called once per frame
    //void Update()
    //{

    //}
}

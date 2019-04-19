using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    GameObject canv;
    
    private void Start()
    {
        canv = GameObject.Find("Canvas");
    }
    public void playgame()
    {

        Time.timeScale = 1f;
        canv.transform.Find("pausemenu").gameObject.SetActive(false);
        Health.healthvalue = 100;
        Score.scorevalue = 0;
        SceneManager.LoadScene(1);
    }

    public void startgame()
    {
        SceneManager.LoadScene(1);
    }
     public void quitgame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        canv.transform.Find("pausemenu").gameObject.SetActive(true);
        Time.timeScale = 0f;
        
        
    }

    public void resume()
    {
        canv.transform.Find("pausemenu").gameObject.SetActive(false);
        Time.timeScale = 1f;
        
    }
    public void restart()
    {
        SceneManager.LoadScene("Main");
        Score.scorevalue = 0;
        Health.healthvalue = 100;

    }

}

using UnityEngine;
using System.Collections;


public class Pauser : MonoBehaviour {
	
    private bool paused = false;

    public string levelName;

    public GameObject progressBar;
    public GameObject text;
    public GameObject startPanel;
    public GameObject loaderPanel;
    public GameObject pauseMenue;
    public GameObject exitMenue;

    private int _loadingProgress = 0;
    void Start()
    {
        exitMenue.SetActive(false);
        pauseMenue.SetActive(false);
        loaderPanel.SetActive(false);
        progressBar.SetActive(false);
        text.SetActive(false);
       // text.GetComponent<GUIText>();
    }
	

    public void PauseOn()
    {

        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            pauseMenue.SetActive(true);
        }
    }

    public void MainMenue()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Start");
    }
   
    public void ResumeGame()
    {
          
                Time.timeScale = 1;
                paused = false;
                pauseMenue.SetActive(false);
          
    }

    public void ExitBtn()
    {
        Time.timeScale = 0;
        exitMenue.SetActive(true);
    }

    public void ExitY()
    {
        Application.Quit();
    }

    public void ExitN()
    {
        Time.timeScale = 1;
        exitMenue.SetActive(false);
    }
    public void LoadLevel()
    {
        StartCoroutine(DisplayLoadingScreen(levelName));
    }

    public void ShowLoaderPanel()
    {
        startPanel.SetActive(false);
        loaderPanel.SetActive(true);
    }

    IEnumerator DisplayLoadingScreen(string level)
    {
        progressBar.SetActive(true);
        text.SetActive(true);
        startPanel.SetActive(false);
        loaderPanel.SetActive(false);

        progressBar.transform.localScale = new Vector3(_loadingProgress,progressBar.transform.localScale.y, progressBar.transform.localScale.z);

        //text.guiText.text = "Loading..." + _loadingProgress;

        AsyncOperation async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            _loadingProgress = (int)(async.progress * 100);
            progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
            yield return null;
        }

       
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public  class GameController : MonoBehaviour 
{
    public static GameController instance;



    public Text scoreText;
    public float score;
    public string path;

    void Awake ()
    {
         score = 0;
      
        instance = this;
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetFloat("Score");
        }

        //#if UNITY_EDITOR
        //        if (path == "")
        //        {

        //            path =Application.dataPath + "/Config/config.sg";
        //        }
        //#endif
        //        if (path == "")
        //        {

        //            path = Application.persistentDataPath + "/Config/config.json";
        //        }

        //        ReadScore();

        UpdateScore();
	}

    
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
       
    }

    void UpdateScore()
    {
        scoreText.text = "" + score;
    }

   public void SaveScoreAtFile()
    {
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.Save();
   //     StreamWriter sw = new StreamWriter(path);
   //     sw.Write(score);
   //     sw.Close();
    }

   // public void ReadScore()
   // {
   //     StreamReader sr = new StreamReader(path);
   //     if (sr != null)
   //     {
   //         while (!sr.EndOfStream)
   //         {
   //             score = System.Convert.ToSingle (sr.ReadLine());
   //         }
   //     }
   // }
}

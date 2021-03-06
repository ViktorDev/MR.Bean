﻿using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour
{
	public GameObject splash;
    public GameObject player;
    public Camera mainCamera;
    public GameController gameController;


    void Start()
    {
        gameController = GameController.instance;   
    }


    void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

            if (GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
            {
                GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
            }

             
            Instantiate(splash, col.transform.position, transform.rotation);

             gameController.SaveScoreAtFile();

           
            Destroy (col.gameObject);
            StartCoroutine("ReloadGame");
		}
		else
		{
			Instantiate(splash, col.transform.position, transform.rotation);
			Destroy (col.gameObject);	
		}
	}
	IEnumerator ReloadGame()
	{			
		yield return new WaitForSeconds(2);

		Application.LoadLevel(Application.loadedLevel);

	}

    
}

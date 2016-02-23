using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsPickUp : MonoBehaviour 
{
    public AudioClip coinPickUp;
    public int scoreValue;
    public GameController gameController;
    
	
    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        
	}

    void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(coinPickUp,transform.position);
            gameController.AddScore(scoreValue);

        }
    }

  
}

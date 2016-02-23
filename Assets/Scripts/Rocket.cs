using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
	public GameObject explosion;		


	void Start () 
	{
		
		Destroy(gameObject, 2);
	}


	void OnExplode()
	{
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		
		Instantiate(explosion, transform.position, randomRotation);
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		if(col.tag == "Enemy" || col.tag == "Enemy2")
		{
			
			if(col.tag == "Enemy")
				col.gameObject.GetComponent<Enemy>().Hurt();
			else
				col.gameObject.GetComponent<Enemy2>().Hurt();

		
			OnExplode();

			
			Destroy (gameObject);
		}
	
	
	}
}

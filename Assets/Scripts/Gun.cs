﻿using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public Rigidbody2D rocket;				
	public float speed = 20f;				


	private PlayerControl playerCtrl;		
	private Animator anim;					


	void Awake()
	{
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
	}

    public void Fire()
    {
        anim.SetTrigger("Shoot");
			GetComponent<AudioSource>().Play();

 //           if (playerCtrl.facingRight)
           
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
 
    }
}

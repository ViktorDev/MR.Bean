using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public AudioClip[] jumpClips;			
	public float jumpForce = 1000f;			
	public AudioClip[] taunts;				
	public float tauntProbability = 50f;	
	public float tauntDelay = 1f;

	private int tauntIndex;					
	private Transform groundCheck;			
	public bool grounded = true;			
	private Animator anim;					
    private bool isStart = false;


	void Awake()
	{
        
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
	}

    void Start()
    {
       
        StartCoroutine("StartGame");

    }


    void FixedUpdate()
    {
        if (isStart == true)
        {
          
            transform.Translate(Vector3.right * 0.2f);
            anim.SetFloat("Speed", 100f);
        }
    }

    public void Jump()
    {
        if (grounded)
        {
            
            anim.SetTrigger("Jump");

            int i = Random.Range(0, jumpClips.Length);
            AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            grounded = false;
        }

       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            grounded = true;
        }

       
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            gameObject.transform.position = new Vector3(-20, -6, -1);
        }
 
    }
	
	

	public IEnumerator Taunt()
	{
		float tauntChance = Random.Range(0f, 100f);
		if(tauntChance > tauntProbability)
		{
			yield return new WaitForSeconds(tauntDelay);

			if(!GetComponent<AudioSource>().isPlaying)
			{
				tauntIndex = TauntRandom();

				GetComponent<AudioSource>().clip = taunts[tauntIndex];
				GetComponent<AudioSource>().Play();
			}
		}
	}


	int TauntRandom()
	{
		int i = Random.Range(0, taunts.Length);

		if(i == tauntIndex)
			return TauntRandom();
		else
			return i;
	}

    IEnumerator StartGame()
    {
       yield return new WaitForSeconds(2f);
       
       isStart = true;

       
    }

    
}

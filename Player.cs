using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

		public float maxSpeed = 3;
		public float speed = 50f;
		public float jumpPower = 150f;

	public	Text counText;
		public	Text score;
		
		public bool jump = false;
		public bool grounded;

		private Rigidbody2D rb2d;
		private Animator anim;
		private int count;
		private int hiScoreCount;
		public Vector3 respawnPoint;
		public bool scoreIncreasing;
	public AudioSource jumpSound;

	void Start () 
	{
				rb2d = gameObject.GetComponent<Rigidbody2D>();
				anim = gameObject.GetComponent<Animator>();
				count = 0;
				SetCountText();
				SetCountText2();
		        respawnPoint = transform.position;

	}
	
	
	void Update ()
	{
		anim.SetBool("Grounded",grounded);
		anim.SetFloat("Speed", Mathf.Abs( Input.GetAxis("Horizontal")));


		if(Input.GetAxis("Horizontal")< -0.1f)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if(Input.GetAxis("Horizontal")> 0.1f)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		if(Input.GetButtonDown ("Jump")&& grounded)
		{
			jump = true;
			jumpSound.Play();
		}

	}

	void FixedUpdate ()

	{
		HandleLayers();

				float h = Input.GetAxis("Horizontal");

				rb2d.AddForce((Vector2.right * speed) * h);
		
		if(rb2d.velocity.x > maxSpeed)
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y); 
		}
		if(rb2d.velocity.x < -maxSpeed)
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}

		if(jump)
		{
			anim.SetTrigger("jump");
			rb2d.AddForce(new Vector2(0f, jumpPower));
			jump = false;
		}
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("pickup"))
		{		 
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
			SetCountText2();
		}
	}

	void SetCountText ()
	{
		counText.text = "count:"+ count.ToString();
		PlayerPrefs.SetInt("score", count);
		Debug.Log(PlayerPrefs.GetInt("score").ToString());
	}

	void SetCountText2 ()
	{	
		PlayerPrefs.GetInt("score").ToString();		
		score.text = PlayerPrefs.GetInt("score").ToString();
	}

	void HandleLayers()
	{
		if (!grounded)
		{
			anim.SetLayerWeight(1,1);
			
		}
		else
		{
			anim.SetLayerWeight(1,0);
		}
	}



}

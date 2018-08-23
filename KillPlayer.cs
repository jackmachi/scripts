using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public GameObject GameOver;

	void OnTriggerEnter2D( Collider2D other )
	{
	if (other.tag == "FallDetector") 
		{
			gameObject.SetActive(false);
			GameOver.SetActive(true);
			Time.timeScale = 0f;
		}
}

}

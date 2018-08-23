using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeMan : MonoBehaviour {

	public float startingTime;

	public GameObject Player;

	public GameObject GameOver;


	private Text theText;



	void Start () {
	
		theText = GetComponent<Text>();
		StartCoroutine("LoseTime");
	}

	void Update () {
	
		startingTime -= Time.deltaTime;
		theText.text = "" + Mathf.Round(startingTime);

		if (startingTime <= 0)
		{
			StopCoroutine("LoseTime");
			theText.text = "Times up!";
			Player.SetActive(false);

			GameOver.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			startingTime--;
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Restart : MonoBehaviour {

	public GameObject GameOver;
	//private gameMaster  gm;


	public	Text counText;
	 void start()
	{

	}
	//void saveScore()
	//{
	//	PlayerPrefs.SetInt("score", gm.score);
	//}
	public void redo()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	public void Quit()
	{
		Debug.Log ("Game Exited");
		Application.Quit();
	}
}

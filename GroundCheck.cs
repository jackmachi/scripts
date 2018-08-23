using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Player player;

	void start()
	{
		player = gameObject.GetComponentInParent<Player>();
	}
	void OntriggerEnter2D(Collider2D col)
	{
		player.grounded = true;
	}
	void OntriggerExit2D(Collider2D col)
	{
		player.grounded = false;
	}
} 
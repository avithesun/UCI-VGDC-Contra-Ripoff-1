using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlatformCollision : MonoBehaviour
{

	private BoxCollider2D parentPlatformCol;

	void Start()
	{
		parentPlatformCol = this.transform.parent.gameObject.GetComponent<BoxCollider2D> ();
	}

	void OnTriggerEnter2D(Collider2D col)//void OnCollisionEnter(Collision col)
	{
		GameObject hit = col.gameObject;
		if (hit != null && hit.CompareTag ("Player"))
			hit.GetComponent<PlayerMovement>().currentPlatform = this;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		GameObject hit = col.gameObject;
		if (hit != null && hit.CompareTag ("Player")) 
		{
			Physics2D.IgnoreCollision (parentPlatformCol, hit.GetComponent<BoxCollider2D> (), false);
			hit.GetComponent<PlayerMovement>().currentPlatform = null;
		}
	}

	public void DropThrough(Collider2D toIgnore)
	{
		Physics2D.IgnoreCollision (parentPlatformCol, toIgnore, true);
	}

}
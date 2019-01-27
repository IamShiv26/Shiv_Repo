using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {

	public int speed=10;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		countText.text = "Count: " + count.ToString ();
		winText.text = "";
	}
	// Update is called once per frame
	void FixedUpdate () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
		Vector3 v = new Vector3 (horizontal, 0, vertical);
		rb.AddForce (v*speed);
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up"))
			other.gameObject.SetActive (false);
		count++;
		countText.text = "Count: " + count.ToString ();
		if (count >= 9)
			winText.text = "You Win!!";
	}
}
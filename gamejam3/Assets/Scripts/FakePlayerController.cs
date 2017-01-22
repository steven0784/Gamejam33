using UnityEngine;
using System.Collections;

public class FakePlayerController : MonoBehaviour {

	public Sprite normal, up, down;
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
			transform.Translate (Vector3.up * Time.deltaTime * 3);
			gameObject.GetComponent<SpriteRenderer>().sprite = up;
		}
		if (Input.GetKey ("down")) {
			transform.Translate (Vector3.down * Time.deltaTime * 3);
			gameObject.GetComponent<SpriteRenderer>().sprite = down;
		}
		if (!(Input.GetKey ("down") ||Input.GetKey ("up"))) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = normal;
		}
		if (transform.position.x > 14) {
			Die ();
		}
		transform.Translate (Vector3.right * Time.deltaTime * 5);
	}

	void Die(){
		Application.LoadLevel ("GameOver");
	}
}

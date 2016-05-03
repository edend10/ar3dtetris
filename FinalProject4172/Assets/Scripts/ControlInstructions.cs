using UnityEngine;
using System.Collections;

public class ControlInstructions : MonoBehaviour {

	public bool next;

	public GameObject nextLabel;
	public GameObject prevLabel;

	public GameObject textLabel;

	TextMesh t;

	public static int n = 0;
	string[] texts;

	string t1 = "Because new is always better \n" +
		"(and seriously, how cool do you look with a Google Cardboard on?), \n" +
		"we decided to allow you awesome gamers to bring Tetris beyond your \n" +
		"screen and into the real world with this 3D, Augmented Reality \n" +
		"version of the classic Tetris!\n\n\n";

	string t2 = "Similarly to the original edition, \n" +
		"the goal here is to rotate and guide blocks down \n" +
		"to fill lines on the game board, except that \n" +
		"instead of lines you now have to fill whole squares! \n" +
		"\r\rYou didn't think it'd be that easy did you ;)\n\n\n";

	// Use this for initialization
	void Start () {
		t = textLabel.GetComponent<TextMesh> ();
		texts = new string[2];
		texts [0] = t1;
		texts [1] = t2;
		t.text = texts[n];
	}

	public void youAreSelected(){

		if (next) {
			prevLabel.SetActive (true);
			n = n+1;
			Debug.Log (n);
			t.text = texts [n];
			if (n == texts.Length - 1) {
				gameObject.SetActive (false);
			}
		} else {
			nextLabel.SetActive (true);
			n = n-1;
			Debug.Log (n);
			t.text = texts [n];
			if (n == 0) {
				gameObject.SetActive (false);
			}
		}

	}
}

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

	string t1 = "When the game starts, a block will\n" +
	     "appear above the game board. After a few\n" +
		 "seconds, it will start falling down.\n\n\n";

	string t2 = "To move/rotate it, simply move/rotate\n" +
	            "the wand in the corresponding direction.\n\n\n";

	string t3 = "Should you get lucky (and you probably will)\n" +
	            "you might see a flashing object from the sky.\n" +
	            "Grab it! It's a power up and it allows you to\n" +
	            "clear a whole plane. To select it, follow it\n" +
	            "with the cursor until its glow turns green.\n" +
	            "Then wait for the magic to happen.\n\n\n";

	string t4 = "If you feel lost at any point, select the\n" +
				"Help menu from the game board, and this\n"+
				"page will reappear.\n\n" + 
				"Have fun!\n\n\n";
	

	// Use this for initialization
	void Start () {
		t = textLabel.GetComponent<TextMesh> ();
		texts = new string[4];
		texts [0] = t1;
		texts [1] = t2;
		texts [2] = t3;
		texts [3] = t4;
		t.text = texts[n];
	}

	public void youAreSelected(){

		if (next) {
			prevLabel.SetActive (true);
			n = n+1;
			t.text = texts [n];
			if (n == texts.Length - 1) {
				gameObject.SetActive (false);
			}
		} else {
			nextLabel.SetActive (true);
			n = n-1;
			t.text = texts [n];
			if (n == 0) {
				gameObject.SetActive (false);
			}
		}

	}
}

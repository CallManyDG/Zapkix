using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextColorAnimation : MonoBehaviour {

	public float time;
	public Color firstColor;
	public Color secondColor;

	Color selectedColor;

	Text text;

	void Start(){
		this.text = this.gameObject.GetComponent<Text> ();
	}

	void Update(){
		selectedColor = Color.Lerp (firstColor, secondColor, Mathf.PingPong (Time.time, time));
		text.color = selectedColor;
	}
}

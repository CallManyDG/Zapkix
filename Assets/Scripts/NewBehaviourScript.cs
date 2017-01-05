using UnityEngine;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour {

	public GameObject circle;
	public GameObject square;

	RectTransform circleRT;
	RectTransform squareRT;


	float timer; 
	bool firstScaling;

	bool scaling;

	void Start(){
		circleRT = circle.GetComponent<RectTransform> ();
		squareRT = square.GetComponent<RectTransform> ();
		firstScaling = true;
		scaling = true;
	}

	void Update(){

		if (Input.GetMouseButtonDown (0)) {
			scaling = false;
			if ( !NormalCollisionDetection () || circleRT.sizeDelta.x <= 0f) {
				Debug.Log ("Lose");
			} else
				Debug.Log ("Win");
		} else if (!Input.GetMouseButtonDown (0) && scaling)
			ScaleDownCircle (200f, 0.005f); 

	}


	void ScaleDownCircle(float scaleDownSize, float time){
		if (firstScaling){
			timer = time;
			firstScaling = false;
		}

		timer -= Time.deltaTime;

		if (timer <= 0) {
			Vector2 scale = circleRT.sizeDelta;
			scale.x -= scaleDownSize * Time.deltaTime;
			scale.y -= scaleDownSize * Time.deltaTime;
			circleRT.sizeDelta = scale;
		}
	}

	public bool NormalCollisionDetection(){
		bool coll = false;

		float r = circleRT.sizeDelta.x / 2; // radius of Circle
		float a = squareRT.sizeDelta.x; // side 'a' of Square

		if (r <= (a / Mathf.Sqrt (2)) )
			coll = true;
		

		return coll;
	}
}

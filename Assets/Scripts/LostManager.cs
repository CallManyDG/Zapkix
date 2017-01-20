using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LostManager : MonoBehaviour {


	public PlayerScript ps;
	public Text points;

	void Update(){
		points.text = ps.points.ToString();
	}

	public void RepeatLevel(){
		ps.UIgameElements.SetActive (true);
		this.gameObject.SetActive (false);
		ps.points = 0;
		ps.isRunning = true;
		ps.level.Game ();

	}
}

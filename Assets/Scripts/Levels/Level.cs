using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Level {

	public string name;

	public float StartSpeed;
	public float IncreaseSpeed;

	public int HeighScore;

	public List<Color> Colors;
	public List<Forms> Forms;

	protected PlayerScript ps;

	// Add class member of Effects later

	public void Game(){
		OnGame ();
		ps.SpeedUpPlayer ();
	}

	protected virtual void OnGame(){
		
	}

}

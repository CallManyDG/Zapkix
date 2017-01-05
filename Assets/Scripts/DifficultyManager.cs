using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class DifficultyManager : MonoBehaviour {

	public Text difficultyText;
	public Text easyText;

	public GameObject EasyPicking;

	public GameObject EasyColorInfo;
	public GameObject EasyFormInfo;
	public GameObject MediumInfo;
	public GameObject HardInfo;


	string[] difficulty;
	string[] easyPicks;
	public string selectedDifficulty;
	public string selectedEasyPick;
	int selectionDif;
	int selectionEasyPick;

	void Start(){
		difficulty = new string[3];
		easyPicks = new string[2];

		difficulty [0] = "Easy";
		difficulty [1] = "Medium";
		difficulty [2] = "Hard";

		easyPicks [0] = "Colors";
		easyPicks [1] = "Forms";


		selectionDif = 0;
		selectedDifficulty = difficulty [0];
		selectedEasyPick = easyPicks [0];

		EasyPicking.gameObject.SetActive (true);
		InfoUpdate ();

		// Add bonuses for later
	}


	void Update(){
		difficultyText.text = selectedDifficulty;
		easyText.text = selectedEasyPick;
		if (selectedDifficulty == "Easy") 
			EasyPicking.gameObject.SetActive (true);
		else
			EasyPicking.gameObject.SetActive (false);
	}
		

	public void InfoUpdate(){
		EasyColorInfo.gameObject.SetActive (false);
		EasyFormInfo.gameObject.SetActive (false);
		MediumInfo.gameObject.SetActive (false);
		HardInfo.gameObject.SetActive (false);
		switch (selectedDifficulty) {
		case "Easy":
			if (selectedEasyPick == "Colors")
				EasyColorInfo.gameObject.SetActive (true);
			else if (selectedEasyPick == "Forms")
				EasyFormInfo.gameObject.SetActive (true);
			break;
		case "Medium":
			MediumInfo.gameObject.SetActive (true);
			break;
		case "Hard":
			HardInfo.gameObject.SetActive (true);
			break;
		}
	}



	public void IncreaseDif(){
		if (selectionDif < difficulty.Length - 1)
			selectionDif++;
		else
			selectionDif = 0;
		for (int i = 0; i < difficulty.Length; i++) {
			if (i == selectionDif)
				selectedDifficulty = difficulty [i];
		}

		InfoUpdate ();
	}

	public void DecreaseDif(){
		if (selectionDif > 0)
			selectionDif--;
		else
			selectionDif = difficulty.Length - 1;
		for (int i = 0; i < difficulty.Length; i++) {
			if (i == selectionDif)
				selectedDifficulty = difficulty [i];
		}

		InfoUpdate ();
	}



	public void IncreaseEasyPicks(){
		if (selectionEasyPick < easyPicks.Length - 1)
			selectionEasyPick++;
		else
			selectionEasyPick = 0;
		for (int i = 0; i < easyPicks.Length; i++) {
			if (i == selectionEasyPick)
				selectedEasyPick = easyPicks [i];
		}

		InfoUpdate ();
	}



	public void DecreaseEasyPicks(){
		if (selectionEasyPick > 0)
			selectionEasyPick--;
		else
			selectionEasyPick = easyPicks.Length - 1;
		for (int i = 0; i < easyPicks.Length; i++) {
			if (i == selectionEasyPick)
				selectedEasyPick = easyPicks [i];
		}

		InfoUpdate ();
	}
}

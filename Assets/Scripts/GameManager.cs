using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour {

	public DifficultyManager dm;
	public PlayerScript ps;
	public GameObject Player;
	public GameObject SelectingMenu;

	Level easyColor;
	Level easyForm;
	Level Medium;
	Level Hard;
	void Awake(){

	}




//	public void StartGame(){
//		Player.SetActive (true);
//
//		switch (dm.selectedDifficulty) {
//		case "Easy":
//			if (dm.selectedEasyPick == "Colors") {
//				//ps.game = () => ps.RefreshGame (true, 65, 55);
//				EasyLevelColorInit();
//				ps.level = easyColor;
//			} else if (dm.selectedEasyPick == "Forms") {
//				//ps.game = () => ps.RefreshGame (false, 65, 55);
//				EasyLevelFormsInit();
//				ps.level = easyForm;
//			}
//				
//			break;
//		case "Medium":
//			//ps.game = () => ps.RefreshGame (60f, 70f, 4, 3);
//			MediumLevelInit();
//			ps.level = Medium;
//			break;
//		case "Hard":
//			//ps.game = () => ps.RefreshGame (60f, 70f, 4, 5); // 4 Forms for now, later add next one Form
//			HardLevelInit();
//			ps.level = Hard;
//			break;
//		}
//		SelectingMenu.SetActive (false);
//	}

	/*--------------------------Initializing levels------------*/

}

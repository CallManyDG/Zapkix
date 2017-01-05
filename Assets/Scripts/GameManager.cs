using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public DifficultyManager dm;
	public PlayerScript ps;
	public GameObject Player;
	public GameObject SelectingMenu;

	void Start(){
		SelectingMenu.SetActive (true);
	}




	public void StartGame(){
		Player.SetActive (true);
		switch (dm.selectedDifficulty) {
		case "Easy":
			if (dm.selectedEasyPick == "Colors") {
				ps.game = () => ps.RefreshGame (true, 65, 55);
			} else if (dm.selectedEasyPick == "Forms") {
				ps.game = () => ps.RefreshGame (false, 65, 55);
			}
				
			break;
		case "Medium":
			ps.game = () => ps.RefreshGame (60f, 70f, 4, 3);
			break;
		case "Hard":
			ps.game = () => ps.RefreshGame (60f, 70f, 4, 5); // 4 Forms for now, later add next one Form
			break;
		}
		SelectingMenu.SetActive (false);
	}
}

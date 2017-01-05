using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GOscript : MonoBehaviour {

	public Color selectedColor;
	public Forms selectedForm;
	public PlayerScript ps;
	public bool resetScale;

	void Start(){
		resetScale = true;
	}

	void Update(){
		if((resetScale)) {
			//Debug.Log (selectedForm);
			if (this.gameObject.name == "PlayerGO") {
				Debug.Log ("User");
				ResetPlayer();
			} else {
				Debug.Log ("PC");
				ResetComputer ();
			}
			resetScale = false;
		}
		LoadForm ();
		LoadColor ();
	}

	void LoadColor(){
		if (selectedColor != null) {
			Image image = this.gameObject.GetComponent<Image> ();
			image.color = this.selectedColor;
		} else {
			Image image = this.gameObject.GetComponent<Image> ();
			image.color = Color.green;
		}

	}

	void LoadForm(){
		

		if (selectedForm != null) {
			Image image = this.gameObject.GetComponent<Image> ();

			Object[] sprites;
			sprites = Resources.LoadAll ("Sprites/Sprite_Sheet");

			foreach (var sprite in sprites) {
				if (sprite.name == selectedForm.ToString ()) {
					image.sprite = (Sprite)sprite;
					if (this.gameObject.name == "ComputerGO") {
						Debug.Log (selectedForm);
					}

				}
			}
		}
	
	}


	void ResetPlayer(){
		if (this.gameObject.name == "PlayerGO") {
			if (selectedForm == Forms.Rectangle) {
				ps.ResetScalePlayer (769, 1032);
			} else {
				ps.ResetScalePlayer (1068, 1071);
			}
		}
	}
	void ResetComputer(){
			if (selectedForm == Forms.Rectangle) {
				ps.ResetScaleComputer (216, 291);
			} else {
				ps.ResetScaleComputer (215, 215);
			}
	}

}

public enum Forms{
	Circle = 0,
	Square = 1,
	Triangle = 2,
	Rectangle = 3,
	NumberOfTypes = 4
}

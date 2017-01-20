using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InfoManager : MonoBehaviour {

	public Text title;
	public Text BestScore;



	public Level selectedLevel;
	public GameObject TypeSelection;
	public GameObject FormPrefab;
	public GameObject FormContainer;
	public GameObject ColorPrefab;
	public GameObject ColorContainer;
	public PlayerScript ps;
	public bool isInfoOpened;






	void Update(){
		if (selectedLevel != null ) {
			title.text = selectedLevel.name;
			BestScore.text = selectedLevel.HeighScore.ToString();

			if (isInfoOpened) {
				LoadForms ();
				LoadColors ();
				isInfoOpened = false;
			}
		}
	}

	public void StartGame(){
		ps.level = selectedLevel;
		selectedLevel.Game ();
		ps.isRunning = true;
		TypeSelection.SetActive (false);
		this.gameObject.SetActive (false);

	}



	void LoadColors(){
		foreach (Color color in selectedLevel.Colors) {
			GameObject formPrefab = GameObject.Instantiate (ColorPrefab);
			formPrefab.transform.SetParent (ColorContainer.transform, false);

			Image image = formPrefab.GetComponent<Image> ();
			image.color = color;

		}
	}



	void LoadForms(){
		foreach (Forms form in selectedLevel.Forms) {
			GameObject formPrefab = GameObject.Instantiate (FormPrefab);
			formPrefab.transform.SetParent (FormContainer.transform, false);

			Image image = formPrefab.GetComponent<Image> ();

			Object[] sprites;
			sprites = Resources.LoadAll ("Sprites/Sprite_Sheet");

			foreach (var sprite in sprites) {
				if (sprite.name == form.ToString ()) {
					image.sprite = (Sprite)sprite;
					int randomColor = Random.Range (0, ps.colors.colors.Count);
					image.color = ps.colors.colors [randomColor];
				}
			}
		
		}
	}
}

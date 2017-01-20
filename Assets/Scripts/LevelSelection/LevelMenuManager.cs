using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class LevelMenuManager : MonoBehaviour {

	public PlayerScript ps;
	public string selectedLevel;
	public bool Next;
	public Button nextButton;
	public GameObject InfoPanel;

	/*-----------Normal levels stage------------------*/


	public GameObject NormalLevelPrefab;
	public Transform NormalLevelParent;

	private List<NormalLevel> normalLevels;

	public NormalLevel selectedNormalLevel;


	/*-----------Bonus levels stage-------------------*/


	/*------------Own level stage---------------------*/


	/*-----------------Main functions------------------*/
	void Start(){
		normalLevels = new List<NormalLevel> ();
		AllNormalLevelsInit ();
		LoadNormalLevels ();
	}

	//				if (level.name == selectedLevel) {
	//					selectedNormalLevel = level;
	//					ps.level = selectedNormalLevel;
	//					selectedNormalLevel.Game ();
	//					ps.isRunning = true;
	//					this.gameObject.SetActive (false);
	//					Debug.Log (level.StartSpeed);

	void Update(){
		if (selectedLevel == "") {
			nextButton.interactable = false;
		} else {
			nextButton.interactable = true;
		}


		if (Next) {
			foreach (Transform tr in NormalLevelParent) {
				if (tr.gameObject.name != selectedLevel) {
					foreach (Transform trans in tr) {
						if (trans.name == "Shadow_Panel") {
							Image image = trans.GetComponent<Image> ();
							Color alphaImage = image.color;
							alphaImage.a = 0.45f;
							image.color = alphaImage;

						}

					}
				} else {
					foreach (Transform trans in tr) {
						if (trans.name == "Shadow_Panel") {
							Image image = trans.GetComponent<Image> ();
							Color alphaImage = image.color;
							alphaImage.a = 0f;
							image.color = alphaImage;

						}

					}
				}
			}

		}
	}




	/*----------------Normal level-----------------------------*/

	void LoadNormalLevels(){
		for(int i = 0; i < normalLevels.Count; i++){
			GameObject go = GameObject.Instantiate (NormalLevelPrefab);
			go.transform.SetParent (NormalLevelParent, false);
			LevelPrefabScript prefabScript = go.GetComponent<LevelPrefabScript> ();
			NormalLevel level = normalLevels [i];
			prefabScript.Level = normalLevels[i];
			go.name = normalLevels[i].name;
			Debug.Log (normalLevels[i].name);
			foreach (Transform tr in go.transform) {
				if (tr.name == "LevelName") {
					tr.gameObject.GetComponent<Text> ().text = normalLevels[i].name;

				}
			}


		}
	}

	public void LoadInfo(){
		InfoManager im = InfoPanel.GetComponent<InfoManager> ();
		im.selectedLevel = selectedNormalLevel;
		InfoPanel.SetActive (true);
		im.isInfoOpened = true;
	}

	#region inicializing levels

	void AllNormalLevelsInit(){
		EasyLevelColorInit ();
		EasyLevelFormsInit ();
		MediumLevelInit ();
		HardLevelInit ();
	}


	void EasyLevelColorInit(){
		normalLevels.Add(new EasyLevelColor {
			name = "Easy Colors",
			StartSpeed = 12,
			IncreaseSpeed = 0.05f,
			//			HeighScore = PlayerPrefs.GetInt("heigh score of each level;
			Colors = ps.colors.colors,
			Forms = new List<Forms>{
				Forms.Circle,
				Forms.Square,
				Forms.Triangle,
				Forms.Rectangle
			}

		});

//		EasyLevelColor easyColor = normalLevels.Add(new EasyLevelColor ());
//		easyColor.Colors = ps.colors.colors;
//
//		easyColor.Forms = new List<Forms> ();
//
//		easyColor.Forms.Add (Forms.Circle);
//		easyColor.Forms.Add (Forms.Square);
//		easyColor.Forms.Add (Forms.Triangle);
//		easyColor.Forms.Add (Forms.Rectangle);
	}

	void EasyLevelFormsInit(){
		normalLevels.Add(new EasyLevelForms {
			name = "Easy Forms",
			StartSpeed = 12f,
			IncreaseSpeed = 1f,
//			HeighScore = PlayerPrefs.GetInt("heigh score of each level;
			Colors = ps.colors.colors,
			Forms = new List<Forms>{
				Forms.Circle,
				Forms.Square,
				Forms.Triangle,
				Forms.Rectangle
			}

		});
//		easyForm.Colors = ps.colors.colors;
//
//		easyForm.Forms = new List<Forms> ();
//
//		easyForm.Forms.Add (Forms.Circle);
//		easyForm.Forms.Add (Forms.Square);
//		easyForm.Forms.Add (Forms.Triangle);
//		easyForm.Forms.Add (Forms.Rectangle);
	}

	void MediumLevelInit(){

		normalLevels.Add(new MediumLevel {
			name = "Medium",
			StartSpeed = 13f,
			IncreaseSpeed = 1.5f,
			//			HeighScore = PlayerPrefs.GetInt("heigh score of each level;
			Colors = new List<Color>{
				ps.colors.Cyan,
				ps.colors.Purple,
				ps.colors.Red,
				ps.colors.Green,
				ps.colors.Yellow
			},
			Forms = new List<Forms>{
				Forms.Circle,
				Forms.Square,
				Forms.Triangle,
				Forms.Rectangle
			}

		});




//		MediumLevel Medium = normalLevels.Add(new MediumLevel ());
//		Medium.Colors = new List<Color>();
//
//		Medium.Colors.Add (ps.colors.Cyan);
//		Medium.Colors.Add (ps.colors.Purple);
//		Medium.Colors.Add (ps.colors.Red);
//		Medium.Colors.Add (ps.colors.Green);
//		Medium.Colors.Add (ps.colors.Yellow);
//
//		Medium.Forms = new List<Forms> ();
//
//		Medium.Forms.Add (Forms.Circle);
//		Medium.Forms.Add (Forms.Square);
//		Medium.Forms.Add (Forms.Triangle);
//		Medium.Forms.Add (Forms.Rectangle);
	}

	void HardLevelInit(){
		normalLevels.Add(new HardLevel {
			name = "Hard",
			StartSpeed = 12f,
			IncreaseSpeed = 2f,
			//			HeighScore = PlayerPrefs.GetInt("heigh score of each level;
			Colors = ps.colors.colors,
			Forms = new List<Forms>{
				Forms.Circle,
				Forms.Square,
				Forms.Triangle,
				Forms.Rectangle
			}

		});





//
//		HardLevel Hard = normalLevels.Add(new HardLevel ());
//		Hard.Colors = ps.colors.colors;
//		Hard.Forms = new List<Forms> ();
//
//		Hard.Forms.Add (Forms.Circle);
//		Hard.Forms.Add (Forms.Square);
//		Hard.Forms.Add (Forms.Triangle);
//		Hard.Forms.Add (Forms.Rectangle);
	}


	#endregion


	/*----------------------*/
}

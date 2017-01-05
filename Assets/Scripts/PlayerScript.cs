using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	#region Variables
	/*-----------GameSpace--------*/
	public GameObject GameSpace;

	public Colors colors;

	/*--------Player------------*/
	public GameObject Player;
	RectTransform PlayerRT;
	GOscript playerInfo;

	/*--------Player values--------*/
	public int points;
	public int heighScore;


	Vector2 playerScale;
	float playerSpeed;

	/*---------computerGO------------*/

	public GameObject Computer;
	RectTransform ComputerRT;
	GOscript computerInfo;
	/*-----------Info variables------*/
	public Text Score;
	public Text HeighScore;

	/*-----Delegate Game-----*/
	public delegate void Game();

	public Game game;

	#endregion


	/*-------------Main functions-----------*/
	#region Main functions

	void Start(){
		PlayerRT = Player.GetComponent<RectTransform> ();
		ComputerRT = Computer.GetComponent<RectTransform> ();
		playerInfo = Player.GetComponent<GOscript> ();
		computerInfo = Computer.GetComponent<GOscript> ();

		game ();

		playerScale = PlayerRT.sizeDelta;
		points = 0;
		playerSpeed = 10f;

		computerInfo.resetScale = true;
		playerInfo.resetScale = true;
	}


	void Update(){
		if (points == 0) {
			playerSpeed = 10f;
		}
		ScaleDownPlayer (playerSpeed, 0.005f);

		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePos = Input.mousePosition;
			RaycastHit2D ray = Physics2D.Raycast (mousePos, Vector3.zero);
			if (ray.transform != null) {
				if (ray.collider.gameObject == GameSpace) {

					bool winState = PlayerWins ();
					if (winState == true) {
						// Statement for win
						points++;
						game ();
					} else if (PlayerWins () == false) {
						// Statement for again Level or exit game to Main Menu
						points = 0;
						game ();
					}
				}
			}
		} else if (IsPlayerScaleOnZero ()) {
			if( (playerInfo.selectedColor != computerInfo.selectedColor) || (playerInfo.selectedForm != computerInfo.selectedForm) ){
				points++;
				game ();
			}else {
				// Statement for again Level or exit game to Main Menu
				points = 0;
				game ();

			}
		}

		/*-------updating info-----*/
		Score.text = points.ToString ();

	}

	#endregion





	/*------------PlayerGO functions-----------------*/
	#region Scaling Player

	float timer;
	bool firstScaling;



	void ScaleDownPlayer(float scaleDownSize, float time){
		if (firstScaling){
			timer = time;
			firstScaling = false;
		}

		timer -= Time.deltaTime;

		if (timer <= 0) {
			Vector2 scale = PlayerRT.sizeDelta;


			if (playerInfo.selectedForm == Forms.Rectangle) {
				float scaleX = playerScale.x;
				float scaleY = playerScale.y;

				float c = scaleX / scaleY;
				scale.x -= (scaleDownSize * c);
				scale.y -= scaleDownSize;
			} else {
				scale.x -= scaleDownSize;
				scale.y -= scaleDownSize;
			}
				
			PlayerRT.sizeDelta = scale;
		}
	}

	public void ResetScalePlayer(int witdh, int heigh){
		Vector2 v2 = new Vector2 ();
			
		v2.x = witdh;
		v2.y = heigh;
//			v2.x = 1068;
//			v2.y = 1071;

		PlayerRT.sizeDelta = v2;
	}
	public void ResetScaleComputer (int width, int height){
		Vector2 v2 = new Vector2 ();
		v2.x = width;
		v2.y = height;
		ComputerRT.sizeDelta = v2;
	}
	
	#endregion


	/*----------------Player input-----------------*/
	#region Player Input

	bool NextLevel(){
		bool next = false;

		float playerScaleX = PlayerRT.sizeDelta.x;
		float playerScaleY = PlayerRT.sizeDelta.y;

		float compScaleX = ComputerRT.sizeDelta.x;
		float compScaleY = ComputerRT.sizeDelta.y;
		if (playerScaleX <= compScaleX || playerScaleY <= compScaleY) {
			next = true;
		}

		return next;
	}

	bool IsPlayerScaleOnZero(){
		bool isScaleZero = false;

		float playerScaleX = PlayerRT.sizeDelta.x;
		float playerScaleY = PlayerRT.sizeDelta.y;

		if (playerScaleX <= 0 || playerScaleY <= 0)
			isScaleZero = true;

		return isScaleZero;
	}

	#endregion

	/*----------------Game state---------------------*/
	bool PlayerWins(){
		bool win = true;
		if (playerInfo.selectedForm != computerInfo.selectedForm || playerInfo.selectedColor != computerInfo.selectedColor || !NextLevel ()) {
			win = false;
		} else
			win = true;

		return win;
	}

	/*----------------GOscript state-----------------*/				

	void ChangeColor(GOscript go, int maxColors){
		int randomColor = Random.Range (0, maxColors);
		go.selectedColor = colors.colors [randomColor];
	}

	void ChangeForm(GOscript go, int maxForms){
		int randomForm = Random.Range (0, maxForms);
		go.selectedForm = (Forms)randomForm;


	}
	/*-----------------Game functions----------------*/


	void SpeedUpPlayer(){
		bool canBeSpeededUp = false;
		int score = points;
		if (score != 0 && /*score % 2 == 0 && */score % 5 == 0 )
			canBeSpeededUp = true;

		if (canBeSpeededUp) {
			playerSpeed += 1f;
		}

	}


	public void RefreshGame(float FormPercent, float ColorPercent, int Forms, int Colors){

		// 
		int randomPercentageForm = Random.Range (0, 100);
		int randomPercentageColor = Random.Range (0, 100);

		if (randomPercentageForm < FormPercent) {
			// same Form for Player as for Computer
			int randomForm = Random.Range(0, Forms);
			playerInfo.selectedForm = (Forms)randomForm;
			computerInfo.selectedForm = (Forms)randomForm;
		} else {
			// another Form for Player as for Computer
			Here:{
				int randomForm1 = Random.Range (0, Forms);
				int randomForm2 = Random.Range (0, Forms);
				if (randomForm2 == randomForm1) {
					goto Here;
					Debug.Log ("Here");
				}
				else {
					playerInfo.selectedForm = (Forms)randomForm1;
					computerInfo.selectedForm = (Forms)randomForm2;
				}
			}
		}


		if (randomPercentageColor < ColorPercent) {
			// same Color for Player as for Computer
			int randomColor= Random.Range(0, Colors);
			playerInfo.selectedColor = colors.colors[randomColor];
			computerInfo.selectedColor = colors.colors[randomColor];
		} else {
			// another Color for Player as for Computer
			Here2:{
				int randomColor1 = Random.Range (0, Colors);
				int randomColor2 = Random.Range (0, Colors);
				if (randomColor2 == randomColor1) {
					goto Here2;
					Debug.Log ("Here2");
				}
				else {
					playerInfo.selectedColor = colors.colors [randomColor1];
					computerInfo.selectedColor = colors.colors [randomColor2];
				}
			}
		}
			
		playerInfo.resetScale = true;
		computerInfo.resetScale = true;
		SpeedUpPlayer ();
	}

	public void RefreshGame(bool color, float FormPercent, float ColorPercent){
		if (color == true) {
			// Changing only color and select randomly a Form (both Player and Computer)... This Form will be same until the end
			int randomForm = Random.Range(0,(int)Forms.NumberOfTypes);
			playerInfo.selectedForm = (Forms)randomForm;
			computerInfo.selectedForm = (Forms)randomForm;

			int randomPercentageColor = Random.Range (0, 100);
			if (randomPercentageColor < ColorPercent) {
				int randomColor= Random.Range(0, colors.colors.Count);
				playerInfo.selectedColor = colors.colors[randomColor];
				computerInfo.selectedColor = colors.colors[randomColor];
			} else {
				Here3:
				{
					int randomColor1 = Random.Range (0, colors.colors.Count);
					int randomColor2 = Random.Range (0, colors.colors.Count);
					if (randomColor2 == randomColor1) {
						goto Here3;
						Debug.Log ("Here3");
					} else {
						
						playerInfo.selectedColor = colors.colors [randomColor1];
						computerInfo.selectedColor = colors.colors [randomColor2];
				
					}
				}
			}
		} else {

			int randomColor = Random.Range(0,colors.colors.Count);
			playerInfo.selectedColor = colors.colors[randomColor];
			computerInfo.selectedColor = colors.colors[randomColor];

			int randomPercentageForm = Random.Range (0, 100);

			if (randomPercentageForm < FormPercent) {
				// same Form for Player as for Computer
				int randomForm = Random.Range(0, (int)Forms.NumberOfTypes);
				playerInfo.selectedForm = (Forms)randomForm;
				computerInfo.selectedForm = playerInfo.selectedForm;
			} else {
				// another Form for Player as for Computer
				Here4:{
					int randomForm1 = Random.Range (0, (int)Forms.NumberOfTypes);
					int randomForm2 = Random.Range (0, (int)Forms.NumberOfTypes);
					if (randomForm2 == randomForm1) {
						goto Here4;
						Debug.Log ("Here4");
					}
					else {
						playerInfo.selectedForm = (Forms)randomForm1;
						computerInfo.selectedForm = (Forms)randomForm2;
					}
				}
			}
		}


		playerInfo.resetScale = true;
		computerInfo.resetScale = true;
		SpeedUpPlayer ();
	}

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	#region Variables
	/*-----------GameSpace--------*/
	public bool isRunning;


	public GameObject GameSpace;

	public Colors colors;

	/*--------Player------------*/
	public GameObject Player;
	RectTransform PlayerRT;
	public GOscript playerInfo;

	/*--------Player values--------*/
	public int points;
	public int heighScore;


	Vector2 playerScale;
	float playerSpeed;

	/*---------computerGO------------*/

	public GameObject Computer;
	RectTransform ComputerRT;
	public GOscript computerInfo;
	/*-----------Info variables------*/
	public Text Score;
	public Text HeighScore;

	public GameObject lostPanel;
	public GameObject UIgameElements;

	/*-----Delegate Game-----*/

	public Level level;

	#endregion


	/*-------------Main functions-----------*/
	#region Main functions


	void Start(){
		isRunning = false;
		
		PlayerRT = Player.GetComponent<RectTransform> ();
		ComputerRT = Computer.GetComponent<RectTransform> ();
		playerInfo = Player.GetComponent<GOscript> ();
		computerInfo = Computer.GetComponent<GOscript> ();

		playerScale = PlayerRT.sizeDelta;
		points = 0;
	}


	void Update(){
		if (isRunning) {
			if (points == 0) {
				playerSpeed = level.StartSpeed;
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
							//game ();
							level.Game ();
						} else if (PlayerWins () == false) {
							// Statement for again Level or exit game to Main Menu
							this.isRunning = false;
							lostPanel.SetActive(true);
							UIgameElements.SetActive (false);
						}
					}
				}
			} else if (IsPlayerScaleOnZero ()) {
				if ((playerInfo.selectedColor != computerInfo.selectedColor) || (playerInfo.selectedForm != computerInfo.selectedForm)) {
					level.Game ();
				} else {
					// Statement for again Level or exit game to Main Menu
					this.isRunning = false;
					lostPanel.SetActive(true);
					UIgameElements.SetActive (false);
				}
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


	/*-----------------Game functions----------------*/


	public void SpeedUpPlayer(){
		playerSpeed += level.IncreaseSpeed;

	}
		
}

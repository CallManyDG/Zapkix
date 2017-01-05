using UnityEngine;
using System.Collections;


public class ChangeScreen : MonoBehaviour {


	public void ChangeScene(string scene){
		Application.LoadLevel (scene);
	}
}

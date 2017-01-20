using UnityEngine;
using System.Collections;

public class LevelPrefabScript : MonoBehaviour {

	public GameObject parent;
	public NormalLevel Level;

	void Start(){
		parent = GameObject.Find("TypeSelection_Panel");
	}

	public void OnClick(){
		LevelMenuManager lm = parent.GetComponent<LevelMenuManager> ();
		if (lm != null) {
			lm.selectedNormalLevel = Level;
			lm.selectedLevel = this.gameObject.name;
			lm.Next = true;
		}
	}
}

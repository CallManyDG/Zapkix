using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Colors : MonoBehaviour {

	public Color Red;
	public Color Green;
	public Color Blue;
	public Color Yellow;
	public Color Pink;
	public Color Cyan;
	public Color Purple;

	public List<Color> colors = new List<Color>();

	void Awake(){
		colors.Add (Red);
		colors.Add (Green);
		colors.Add (Blue);
		colors.Add (Yellow);
		colors.Add (Pink);
		colors.Add (Cyan);
		colors.Add (Purple);
	}



}

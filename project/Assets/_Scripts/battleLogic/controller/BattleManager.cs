using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 *  Desmond
 * controlling battle scene and AI logic of game characters
 * */
public class BattleManager : MonoBehaviour {

	// Use this for initialization
	public GameObject heroTemplate;

	List<HeroRobot> heros =new List<HeroRobot>();

	void Start () {
		GameObject obj=(GameObject)Instantiate (heroTemplate,new Vector3(0,0,0),Quaternion.identity);
		heros.Add(obj.GetComponent<HeroRobot>());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateSetting : MonoBehaviour {

    public Text DateText1;
    public Text DateText2;

	// Use this for initialization
	void Start () {
        DateText1.text = System.DateTime.Now.ToString("yy   MM   dd");
        DateText2.text = System.DateTime.Now.ToString("yy     MM    dd");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerHero : MonoBehaviour {

    private UISprite sprite;

    private void Awake()
    {
        sprite = this.GetComponent<UISprite>();
        string heroName = PlayerPrefs.GetString("AIhero");
        sprite.spriteName = heroName;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

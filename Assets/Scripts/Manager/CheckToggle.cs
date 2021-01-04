using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckToggle : MonoBehaviour {

	// Activarea/dezactivarea surselor de sunet din clasa GameManager
	void Awake () {
        var toggle = GetComponent<UnityEngine.UI.Toggle>();

        if (GameManager.soundOn == false)
        {
            toggle.isOn = false;
            GameManager.soundOn = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

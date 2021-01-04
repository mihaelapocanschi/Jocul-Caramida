using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {



	//Adaugam gravitatie pentru fiecare obstacol in parte.
	void Start () {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 20f;
    }
	
	// Distrugem obstacolul dupa ce nu se mai vede pe ecran
	void Update () {
        if (transform.position.y <= -6f)
            Destroy(gameObject);
	}
}

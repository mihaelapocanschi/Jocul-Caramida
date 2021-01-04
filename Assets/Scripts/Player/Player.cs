using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

//Controlul jucatorului
public class Player : MonoBehaviour {


    public GameManager gameManager = new GameManager();
    public float speed = 15f;
    float width = 4.5f;

    Rigidbody2D rb;

	// Initializam componenta Rigidbody2D
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Control jucator cu ajutorul tastelor
	void FixedUpdate () {
        float horiz = CrossPlatformInputManager.GetAxis("Horizontal") * Time.fixedDeltaTime;

        Vector2 newPosition = rb.position + Vector2.right * horiz * speed;

        newPosition.x = Mathf.Clamp(newPosition.x, -width, width);
        rb.MovePosition(newPosition);
    }

    //Daca jucatorul atinge ceva, este game over
    void OnCollisionEnter2D()
    {
        if (!GameManager.end)
            gameManager.EndGame();

    }

    //Daca trece cu bine de acele obstacole, atunci primeste un punct in plus
    void OnTriggerEnter2D()
    {
        if(!GameManager.end)
        gameManager.AddScore();

    }
}

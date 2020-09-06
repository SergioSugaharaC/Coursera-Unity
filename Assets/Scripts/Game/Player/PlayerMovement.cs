using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{
    [SerializeField] private float speed = 8.0f;
    private Rigidbody2D body;

    void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        HeroFly();
        if(Input.GetKeyDown(KeyCode.Space)) FireBullet();
    }

    void HeroFly(){
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical > 0)
            body.velocity = new Vector2(0.0f, speed);
        else if (vertical < 0)
            body.velocity = new Vector2(0.0f, -speed);
        else 
            body.velocity = Vector2.zero;
    }

    void FireBullet(){
        GameController.instance.PlayerFire(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "CandyBullet") SceneManager.LoadScene("GameOver");
    }
}

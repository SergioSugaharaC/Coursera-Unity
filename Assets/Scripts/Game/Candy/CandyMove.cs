using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    float fireRate = 2.0f;
    float elapsed = 0.0f;

    // Start is called before the first frame update
    void Start(){
        body = GetComponent<Rigidbody2D>();
        speed = speed == 0 ? -4 : -speed;
    }

    // Update is called once per frame
    void Update(){
        body.velocity = new Vector2(speed, 0.0f);

        elapsed += Time.deltaTime;
        if(elapsed >= fireRate){
            GameController.instance.CandyFire(transform.position);
            elapsed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerBullet"){
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    [SerializeField] private float force = 5.0f;

    private Rigidbody2D body;
    private Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible(){ gameObject.SetActive(false); }

    public void Shooting(string dir){
        Color col = dir == "L" ? Color.red : Color.yellow;
        gameObject.GetComponent<SpriteRenderer>().color = col;

        gameObject.tag = dir == "L" ? "CandyBullet" : "PlayerBullet";
        
        Vector2 direction = dir == "L" ? new Vector2(-1, 0) : new Vector2(1, 0); 
        body = gameObject.GetComponent<Rigidbody2D>();
        body.velocity = direction * force;
    }
}

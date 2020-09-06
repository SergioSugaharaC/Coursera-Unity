using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour{
    private List<string> tags = new List<string>() { "Candy", "Bullet"};

    // Start is called before the first frame update
    void Start(){
        
    }

    void OnTriggerEnter2D(Collider2D other){
        GameObject go = other.gameObject;
        if (tags.IndexOf(go.tag) > -1){
            go.SetActive(false);
        }
    }
}

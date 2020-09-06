using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float MinY, MaxY;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        MaxY = bounds.y;
        MinY = -MaxY;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < MinY){
            Vector3 temp = transform.position;
            temp.y = MinY;
            transform.position = temp;
        }

        if (transform.position.y > MaxY){
            Vector3 temp = transform.position;
            temp.y = MaxY;
            transform.position = temp;
        }
    }
}

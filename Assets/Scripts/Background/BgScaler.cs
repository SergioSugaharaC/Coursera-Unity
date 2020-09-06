using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScaler : MonoBehaviour
{
    // Variables
    private float height;
    private float width;
    private Vector3 ObjSize;

    // Start is called before the first frame update
    void Start(){
        height = Camera.main.orthographicSize * 2f;
        width = height * Screen.width / Screen.height;
        ObjSize = GetComponent<Renderer>().bounds.size;
        transform.position = new Vector3(0.0f, 0.0f, 1.0f);
        transform.localScale = new Vector3(width, height, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Vector3 temp = transform.localScale;
        float width = sr.sprite.bounds.size.x;

        float worldH = Camera.main.orthographicSize * 2f;
        float worldW = worldH / Screen.height * Screen.width;

        temp.x = worldW / width;
        transform.localScale = temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

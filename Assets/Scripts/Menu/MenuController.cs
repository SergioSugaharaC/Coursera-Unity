using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Menu Buttons")]
    public Button BtnPlay;

    // Start is called before the first frame update
    void Start(){
        BtnPlay.onClick.AddListener(() => goGame());
    }

    void goGame(){
        //print("Play");
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update(){
        
    }
}

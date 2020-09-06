using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Button BtnPlay;

    // Start is called before the first frame update
    void Start(){
        BtnPlay.onClick.AddListener(() => goMenu());
    }

    void goMenu(){
        SceneManager.LoadScene("Menu");
    }
}

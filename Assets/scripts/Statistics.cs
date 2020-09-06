using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour{
    static int[][] matchWinners;

    public static int[][] MatchWinners { get { return matchWinners; } }

    private void Awake(){
        EventManager.AddGameOverListener(HandleGameOverEvent);
        EventManager.AddTestOverListener(HandleTestOverEvent);

        matchWinners = new int[6][];
        for (int i = 0; i < matchWinners.Length; i++)
            matchWinners[i] = new int[] { 0, 0 };
        
        DontDestroyOnLoad(gameObject);
    }

    void HandleGameOverEvent(PlayerName player, int currentMatch){
        matchWinners[currentMatch][(int)player]++;
    }

    void HandleTestOverEvent(){
        SceneManager.LoadScene("statistics");
    }
}
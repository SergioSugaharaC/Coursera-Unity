﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays the statistics
/// </summary>
public class StatisticsDisplay : MonoBehaviour{
    [SerializeField] Text easyEasyPlayer1Wins;
    [SerializeField] Text easyEasyPlayer2Wins;

    [SerializeField] Text mediumMediumPlayer1Wins;
    [SerializeField] Text mediumMediumPlayer2Wins;

    [SerializeField] Text hardHardPlayer1Wins;
    [SerializeField] Text hardHardPlayer2Wins;

    [SerializeField] Text easyMediumPlayer1Wins;
    [SerializeField] Text easyMediumPlayer2Wins;

    [SerializeField] Text easyHardPlayer1Wins;
    [SerializeField] Text easyHardPlayer2Wins;

    [SerializeField] Text mediumHardPlayer1Wins;
    [SerializeField] Text mediumHardPlayer2Wins;

    int[][] statistics;

    /// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        statistics = Statistics.MatchWinners;

        easyEasyPlayer1Wins.text = statistics[0][0].ToString();
        easyEasyPlayer2Wins.text = statistics[0][1].ToString();

        mediumMediumPlayer1Wins.text = statistics[1][0].ToString();
        mediumMediumPlayer2Wins.text = statistics[1][1].ToString();

        hardHardPlayer1Wins.text = statistics[2][0].ToString();
        hardHardPlayer2Wins.text = statistics[2][1].ToString();

        easyMediumPlayer1Wins.text = statistics[3][0].ToString();
        easyMediumPlayer2Wins.text = statistics[3][1].ToString();

        easyHardPlayer1Wins.text = statistics[4][0].ToString();
        easyHardPlayer2Wins.text = statistics[4][1].ToString();

        mediumHardPlayer1Wins.text = statistics[5][0].ToString();
        mediumHardPlayer2Wins.text = statistics[5][1].ToString();

    }
}

using System;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private TextMeshProUGUI textTMP;

    private int _score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        textTMP = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        textTMP.text = "SCORE: " + Convert.ToString(_score);
    }
}

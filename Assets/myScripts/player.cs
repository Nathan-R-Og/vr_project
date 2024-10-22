using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public List<Gun> guns = new List<Gun>();
    public float score = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreBox;
    public TextMeshProUGUI largestComboBox;
    public int comboCount = 0;
    public int largestComboCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (scoreBox != null)
        {
            scoreBox.text = "Score: "+score.ToString()+"\nCombo: "+comboCount.ToString();
        }

    }

    public void AddCombo()
    {
        comboCount++;
        if (comboCount > largestComboCount)
        {
            largestComboCount = comboCount;
            if (largestComboBox != null)
            {
                largestComboBox.text = "Largest Combo: " + largestComboCount.ToString();
            }
        }
    }

    public void LoseCombo()
    {
        comboCount = 0;
    }

}

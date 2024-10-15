using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField]
    private InputActionReference move, look, jump, fire;
    public List<Gun> guns = new List<Gun>();
    public float score = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreBox;
    public int comboCount = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < guns.Count; i++)
        {
            //Debug.Log(guns[i].name);
        }
        if (scoreBox != null)
        {
            scoreBox.text = "Score: "+score.ToString()+"\nCombo: "+comboCount.ToString();
        }
    }

    public void AddCombo()
    {
        comboCount++;
    }

    public void LoseCombo()
    {
        comboCount = 0;
    }

}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField]
    private InputActionReference move, look, jump, fire;
    public List<Gun> guns = new List<Gun>();
    public float score = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < guns.Count; i++)
        {
            Debug.Log(guns[i].name);
        }
    }


}

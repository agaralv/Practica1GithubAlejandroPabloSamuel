using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textP1;
    [SerializeField] private TextMeshProUGUI textP2;
    internal void setPoints(int playerNumber, int Points)
    {
        if (playerNumber == 1)
        {
            textP1.text = Points.ToString();
        }
        else if (playerNumber == 2)
        {
            textP2.text = Points.ToString();
        }
    }
    void Awake()
    {
        GameManager.Instance.HUDManager = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}

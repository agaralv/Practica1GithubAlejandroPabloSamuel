using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.name.Equals("paredde"))
        {
            GameManager.Instance.AddPoint(1);
        }
        if (this.name.Equals("parediz"))
        {
            GameManager.Instance.AddPoint(2);
        }
    }
}

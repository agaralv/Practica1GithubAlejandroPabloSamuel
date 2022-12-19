using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayers : MonoBehaviour
{
    private Rigidbody2D _rigigbody2D;
    [SerializeField] private float speed;
    void Start()
    {
        _rigigbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (tag == "P1")
            {
                _rigigbody2D.velocity = new Vector2(0, speed);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (tag == "P1")
            {
                _rigigbody2D.velocity = new Vector2(0, - speed);
            }
        } else
        {
            if (tag == "P1")
            {
                _rigigbody2D.velocity = new Vector2(0, 0);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (tag == "P2")
            {
                _rigigbody2D.velocity = new Vector2(0, speed);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (tag == "P2")
            {
                _rigigbody2D.velocity = new Vector2(0, - speed);
            }
        }
        else
        {
            if (tag == "P2")
            {
                _rigigbody2D.velocity = new Vector2(0, 0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _pointsPlayer1 = 0;
    private int _pointsPlayer2 = 0;
    private HUDManager _HUDManager;
    public HUDManager HUDManager
    { 
        get => _HUDManager;
        set => _HUDManager = value;
    }
    private Pelota _ball;
    public Pelota Ball
    {
        get => _ball;
        set => _ball = value;
    }
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get => _instance;
    }
    private GameManager()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    void Awake()
    {
        if (_instance != null)
        {
            if (_instance != null)
            {
                Destroy(this);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        _HUDManager.setPoints(1,0);
        _HUDManager.setPoints(2,0);
    }
    public void AddPoint(int player)
    {
        if (player == 1)
        {
            _pointsPlayer1++;
            if (_HUDManager != null)
            {
                _HUDManager.setPoints(1, _pointsPlayer1);
            }
        }
        else if (player == 2)
        {
            _pointsPlayer2++;
            if (_HUDManager != null)
            {
                _HUDManager.setPoints(2, _pointsPlayer2);
            }
        }
        if(_ball != null)
        {
            _ball.Launch();
        }
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
    }
}

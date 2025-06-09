using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }

            return _instance;
        }
    }
    
    private Character _player;
    public Character Player
    {
        get { return _player; }
    }
    
    [SerializeField] private CharacterData playerData;
    
    [SerializeField] private ItemData[] itemData;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
        
        //test
        _player = new GameObject("Player").AddComponent<Character>();
        SetData();
    }
    
    public void SetData()
    {
        _player.SetData(playerData, itemData);
    }
    
}

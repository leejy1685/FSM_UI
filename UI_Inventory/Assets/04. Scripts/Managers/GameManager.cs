using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//<Summary>
//게임의 흐름을 관리하는 클래스
//</Summary>
public class GameManager : MonoBehaviour
{
    //싱글톤 화
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
    
    //필드
    private Character _player;
    
    //직렬화 데이터
    [SerializeField] private CharacterData playerData;
    [SerializeField] private ItemData[] itemData;
    [SerializeField] private ItemData testItem;
    
    //프로퍼티
    public Character Player
    {
        get { return _player; }
    }
    
    private void Awake()
    {
        //싱글톤 할당
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        //캐릭터를 찾아서 데이터 할당
        _player = FindAnyObjectByType<Character>();
        SetData();
    }

    //데이터 할당
    public void SetData()
    {
        _player.SetData(playerData, itemData);
    }
    
    //아이템 장착 처리
    public void EquipItem(ItemData item)
    {
        //장착
        _player.Equip(item);
        
        //UI 갱신
        UIManager.Instance.UpdateUI();
    }

    //아이템 장착 해제 처리
    public void UnequipItem(ItemData item)
    {
        _player.Unequip(item.type);
        
        UIManager.Instance.UpdateUI();
    }
    
}

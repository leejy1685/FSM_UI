using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Character", menuName = "New Character")]
public class Character : ScriptableObject
{
    [Header("PlayerInfo")]
    public string grade;
    public string name;
    public int level;
    public int exp;
    public int maxExp;
    public string desc;
    public int gold;

    [Header("Status")]
    public int atk;
    public int def;
    public int hp;
    public int cri;
    
    
    
}

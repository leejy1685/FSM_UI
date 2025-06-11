using UnityEngine;


//<Summary>
//캐릭터의 정보를 보유하는 클래스
//</Summary>
[CreateAssetMenu (fileName = "Character", menuName = "New Character")]
public class CharacterData : ScriptableObject
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

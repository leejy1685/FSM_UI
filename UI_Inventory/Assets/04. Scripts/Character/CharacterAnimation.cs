using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    
    private const string JUMP = "IsJump";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        _animator.SetTrigger(JUMP);
    }

    public float AnimationLength()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).length;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    private Animator _animator;
    void Awake()
    {
        _animator=GetComponent<Animator>();
    }
}

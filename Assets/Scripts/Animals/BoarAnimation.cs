using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoarAnimation : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        
    }
    public void BoarWalk(bool isWalk)
    {
        _animator.SetBool("IsWalk",isWalk);
    }
    public void BoarRun(bool isRun)
    {
        _animator.SetBool("IsRun",isRun);
    }
    public void BoarAttack(bool isAttack)
    {
        _animator.SetBool("IsAttack",isAttack);
    }
    public void BoarDead(bool isDead)
    {
        _animator.SetBool("Dead",isDead);
    }
    public void BoarHit(bool isHit)
    {
        _animator.SetBool("Hit",isHit);
    }
}//Class

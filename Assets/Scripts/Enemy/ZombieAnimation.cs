using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    
    [SerializeField] PlayerShoot _playerShoot;
    private Animator _anmator;
    private void Awake()
    {
        _anmator = GetComponent<Animator>();
    }//Awake
    private void Start()
    {
        
    }//Start


    private void Update()
    {
        
      
        
    }//Update
    public void ZombieRun(bool isRun)
    {
        if(isRun == true)
        {
            _anmator.SetBool("ZombieWalk",true);
        }
        else
        {
            _anmator.SetBool("ZombieWalk",false);
        }

    }//EnemyRun
    public void ZombieAttack(bool isAttack)
    {
        if(isAttack == true)
        {
            _anmator.SetBool("ZombieAttack",true);
        }
        else
        {
            _anmator.SetBool("ZombieAttack",false);
        }
    }//ZombieAttack
    public void LZombieAttack(bool isLAttack)
    {
        if(isLAttack == true)
        {
            _anmator.SetBool("ZombieLAttack",true);
        }
        else
        {
            _anmator.SetBool("ZombieLAttack",false);
        }

    }//LZombieAttack
    public void RZombieAttack(bool isRAttack)
    {
        if(isRAttack == true)
        {
            _anmator.SetBool("ZombieRAttack",true);
        }
        else
        {
            _anmator.SetBool("ZombieRAttack",false);
        }

    }//RZombieAttack

    public void ZombieNormalHit(bool isNormalHit)
    {
        if(isNormalHit == true)
        {
            _anmator.SetTrigger("NormalHit");
        }
        else
        {
            
        }
    }//ZombieNormalHit
    public void ZombieHeadHit(bool isHeadHit)
    {
        if(isHeadHit == true)
        {
            _anmator.SetTrigger("HeadHit");
            
        }
        else
        {
            
        }

    }//ZombieHeadHit
}//Class

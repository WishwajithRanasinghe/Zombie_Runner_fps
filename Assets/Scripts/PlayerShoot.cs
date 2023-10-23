using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float _fireRange= 100f;
    [SerializeField] private Animator _animator;
    [SerializeField] private ShotgunAnimaton _shotgun;
  

    private bool _iscanFire;
    private void Awake()
    {
        //_animator = GetComponent<Animator>();


    }//Awake
    
    private void Update()
    {
        ShotgunFire();
        
        
    }//Update
    private void ShotgunFire()
    {
        _iscanFire = _shotgun.iscanFire; 
        if(_iscanFire == true)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
                _animator.SetBool("ShotgunFire",true);

            }
            else
            {   
                _animator.SetBool("ShotgunFire",false);
            }
        }

    }//ShotgunFire
    private void Shoot()
    {
        RaycastHit _hit;
        Physics.Raycast(transform.position,transform.forward, out _hit,_fireRange);
        if(_hit.transform == null )
        {
           return;
        }

        if(_hit.transform.tag == "Enemy")
        {
            _hit.transform.gameObject.GetComponent<EnemyHelth>().EnemyDamage(25);
            _hit.transform.gameObject.GetComponent<ZombieAnimation>().ZombieNormalHit(true);
            _hit.transform.gameObject.GetComponent<ZombieAnimation>().ZombieNormalHit(false);
        }

        if(_hit.transform.tag == "ZombieHead")
        {
            _hit.transform.gameObject.GetComponentInParent<EnemyHelth>().EnemyDamage(50);
            _hit.transform.gameObject.GetComponentInParent<ZombieAnimation>().ZombieHeadHit(true);
            _hit.transform.gameObject.GetComponentInParent<ZombieAnimation>().ZombieHeadHit(false);
            //_hit.transform.gameObject.GetComponent<EnemyHelth>().EnemyDamage(50);
            //_hit.transform.gameObject.GetComponent<ZombieAnimation>().ZombieHeadHit(true);
        }
        else
        {
            //_hit.transform.gameObject.GetComponent<ZombieAnimation>().ZombieHeadHit(false);
             
        }
        

        

    }//Shoot
  
}//Calss

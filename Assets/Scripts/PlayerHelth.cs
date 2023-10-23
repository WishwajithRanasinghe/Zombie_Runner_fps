using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelth : MonoBehaviour
{
    [SerializeField] private float _playerHelth = 100;
    [SerializeField] private float _damageAmount = 20;
    [SerializeField] private float _helthRegenTime = 3f;
    
    private float _startHelth;
    private float _startHelthRegenTime; 
    private bool _isAttack = false;
    private bool _run;
    private void Start()
    {
        _startHelthRegenTime = _helthRegenTime;
        _startHelth = _playerHelth;
    }//Start

    private void Update()
    {
        _run = GetComponent<Player>()._isRun;
        HelthRegenarat();
        
        
    }//Update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "enemy")
        {
            PlayerDamage();
            _isAttack = true;
            _helthRegenTime = _startHelthRegenTime;
        }
        else 
        {
            _isAttack = false;
            
        }

    }//OnCollisionEnter
    private void PlayerDamage()
    {
        _playerHelth -= _damageAmount;
    }//PlayerDamage
    private void HelthRegenarat()
    {
        if(_isAttack == false)
        {
            _helthRegenTime -= Time.deltaTime;
            if(_helthRegenTime <= 0)
            {
                _helthRegenTime = 0;
            }
        }
        if(_run == false && _isAttack == false)
        {
            _playerHelth += Time.deltaTime*2;
            if(_playerHelth >= _startHelth)
            {
                _playerHelth = _startHelth;
            }
        }

    }

}//Class

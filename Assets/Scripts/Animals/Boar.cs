using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boar : MonoBehaviour
{
    private GameObject _player;
    private int _currentPos;
    private float _playerDistance = Mathf.Infinity;
    private NavMeshAgent _navmesh;
    [SerializeField] private float _stopTime = 5f,_startStopTime;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private float _runSpeed = 10f,_walkSpeed = 2f;   
    [SerializeField] private float _miniDistance = 1.5f;
    [SerializeField] private float _health = 100f;
    private BoarAnimation _animation;
    [SerializeField] private Transform[] _walkPos;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _navmesh = GetComponent<NavMeshAgent>();
        _navmesh.stoppingDistance = _miniDistance;
        _navmesh.speed = _walkSpeed;
        _animation = GetComponent<BoarAnimation>();
        _startStopTime = _stopTime;
        _currentPos = 0;
        
    }//Start


    private void Update()
    {
        if(_player == null) return;
        _playerDistance = Vector3.Distance(_player.transform.position,transform.position);
        if(_maxDistance >= _playerDistance)
        {
            if(_navmesh.enabled == false) return;
            _navmesh.stoppingDistance = _miniDistance;
            _navmesh.speed = _runSpeed;
            _animation.BoarWalk(false);
            CheasPlayer();
            
        }
        else
        {
            if(_navmesh.enabled == false) return;
            _animation.BoarRun(false);
            _navmesh.stoppingDistance = 0;
            _navmesh.speed = _walkSpeed;
            NormalWalk();
        }

        
        if(_health <=0)
        {
            _animation.BoarWalk(false);
            _animation.BoarRun(false);
            _animation.BoarAttack(false);
            _animation.BoarDead(true);
            _navmesh.enabled = false;
            Destroy(this.gameObject,10f);
        }
    }//Update
    private void NormalWalk()
    {
        
        Vector3 boarPos = transform.position;

        if(new Vector3(boarPos.x,_walkPos[_currentPos].position.y,boarPos.z) != _walkPos[_currentPos].position)
        {
            if(_navmesh.enabled == false) return;
            _navmesh.SetDestination(_walkPos[_currentPos].position);
            _animation.BoarWalk(true);
            _animation.BoarHit(false);
        }
        else
        {
            _stopTime -= Time.deltaTime;
            _animation.BoarWalk(false);
            _animation.BoarRun(false);
            _animation.BoarAttack(false);
            _animation.BoarHit(false);
            if(_stopTime <=0)
            {
                
                _currentPos = (_currentPos + 1)% _walkPos.Length;
                _stopTime = _startStopTime;
            }
            
        }

    }
    private void CheasPlayer()
    {
        if(_maxDistance >= _playerDistance)
        {
           
            _navmesh.SetDestination(_player.transform.position);
            _animation.BoarRun(true);
            _animation.BoarHit(false);
        }
        else
        {
            _animation.BoarRun(false);
            _navmesh.speed = _walkSpeed;
        }
        if(_miniDistance >= _playerDistance)
        {
            _animation.BoarRun(false);
            _animation.BoarAttack(true);
            _animation.BoarHit(false);
        }
        else
        {
            _animation.BoarAttack(false);
            _animation.BoarHit(false);
        }

    }
    public void BoarHealth(float damage)
    {
        _health -= damage;
        _animation.BoarHit(true);
        _animation.BoarWalk(false);
        _animation.BoarRun(false);
        _animation.BoarAttack(false);
        
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,_maxDistance);
        Gizmos.color = Color.grey;
    }
}//Class

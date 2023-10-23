using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private float _cheasDistance = 30f;
    [SerializeField] private float _miniDistance =2f;
    [SerializeField] private Transform[] _rayLeftPos,_rayRightPos;
    [SerializeField] private float _ditack = 7f;
    private float _maxDistance = Mathf.Infinity;
    private NavMeshAgent _navMeshA;
    private GameObject _player;
    private ZombieAnimation _zScript;
    private RaycastHit _hitLeft;
    private RaycastHit _hitRight;


    private void Awake()
    {
        _navMeshA = GetComponent<NavMeshAgent>();    
        _zScript = GetComponent<ZombieAnimation>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }//Awake
    private void Start()
    {

        
    }//Start
    private void Update()
    {
        
        
        if(_player == null){return;}
        RayCast();
        _maxDistance = Vector3.Distance(transform.position,_player.transform.position);
        if(_maxDistance <= _cheasDistance)
        {
            EnemyFallow();
            _zScript.ZombieAttack(false);
        }
        else
        {
            _zScript.ZombieRun(false);
        }
        if(_maxDistance <= _miniDistance)
        {
            EnemyStop();
            ZombieAttack();  
        }
        
        
        
        
        
    }//Update
    private void ZombieAttack()
    {
        if(!(_hitRight.transform.tag == "Player" && _hitLeft.transform.tag == "Player"))
        {
            if(_hitLeft.transform.tag == "Player")
            {
                _zScript.LZombieAttack(true);
            }
            else
            {
                _zScript.LZombieAttack(false);
            }
            if(_hitRight.transform.tag == "Player")
            {
                _zScript.RZombieAttack(true);
            }
            else
            {
                _zScript.RZombieAttack(false);
            }

        }
        
        if(_hitRight.transform.tag == "Player" && _hitLeft.transform.tag == "Player")
        {
            _zScript.ZombieAttack(true);
        }
        else
        {
            _zScript.ZombieAttack(false);
        }

    }
    private void EnemyFallow()
    {
        _zScript.ZombieRun(true);
        _navMeshA.enabled = true;
        _navMeshA.SetDestination(_player.transform.position);
    }//EnemyFallow
    private void EnemyStop()
    {
        _zScript.ZombieRun(false);
        _navMeshA.enabled = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,_cheasDistance);
        Gizmos.color =  Color.red;
    }
    private void RayCast()
    {
        
        //left
        Physics.Raycast(_rayLeftPos[0].position,_rayLeftPos[0].forward,out _hitLeft,_ditack);
        Debug.DrawRay(_rayLeftPos[0].position,_rayLeftPos[0].forward,Color.green,_ditack);
        Physics.Raycast(_rayLeftPos[1].position,_rayLeftPos[1].forward,out _hitLeft,_ditack);
        Debug.DrawRay(_rayLeftPos[1].position,_rayLeftPos[1].forward,Color.green,_ditack);
        Physics.Raycast(_rayLeftPos[2].position,_rayLeftPos[2].forward,out _hitLeft,_ditack);
        Debug.DrawRay(_rayLeftPos[2].position,_rayLeftPos[2].forward,Color.green,_ditack);
        //right
        Physics.Raycast(_rayRightPos[0].position,_rayRightPos[0].forward,out _hitRight,_ditack);
        Debug.DrawRay(_rayRightPos[0].position,_rayRightPos[0].forward,Color.red,_ditack);
        Physics.Raycast(_rayRightPos[1].position,_rayRightPos[1].forward,out _hitRight,_ditack);
        Debug.DrawRay(_rayRightPos[1].position,_rayRightPos[1].forward,Color.red,_ditack);
        Physics.Raycast(_rayRightPos[2].position,_rayRightPos[2].forward,out _hitRight,_ditack);
        Debug.DrawRay(_rayRightPos[2].position,_rayRightPos[2].forward,Color.red,_ditack);
        

    }
}//Class

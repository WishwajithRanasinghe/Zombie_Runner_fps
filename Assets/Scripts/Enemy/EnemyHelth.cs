using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelth : MonoBehaviour
{
    [SerializeField] private int _enemyHelth = 100;
    //[SerializeField] private Collider _head;

    private void Update()
    {
        if(_enemyHelth <= 0)
        {
            _enemyHelth = 0;
            Destroy(this.gameObject);
        }
    }//Update 
    public void EnemyDamage(int damageAmount)
    {
        _enemyHelth -= damageAmount;
    }

}//Class

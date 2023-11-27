using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoraSound : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip _attack,_dead,_eating;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }
    public void Eating(bool isEting)
    {
        if(isEting == true)
        {
            _audio.clip = _eating;
            _audio.loop = true;

        }
    }

    public void Attack()
    {
        _audio.PlayOneShot(_attack);

    }
    public void Dead(bool isDead)
    {
        _audio.PlayOneShot(_dead);
    }
}

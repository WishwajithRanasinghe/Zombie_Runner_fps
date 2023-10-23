using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAnimaton : MonoBehaviour
{
    [SerializeField] private AudioClip _shotgunFire,_shotgunPump01;
    [SerializeField] private ParticleSystem _muzzelFlash;
    public bool iscanFire;
    private AudioSource _shotgunSource;
    
    private void Awake()
    {
        _shotgunSource = GetComponent<AudioSource>();
    }//Awake
    private void Start()
    {
        iscanFire = true;
    }//Start
    
    void Update()
    {
        
    }
    public void FireSound()
    {
        _shotgunSource.PlayOneShot(_shotgunFire);
        _muzzelFlash.Play();
        iscanFire = false;

    }//FireSound
    public void SellSpawner()
    {
        

    }//SellSpawner
    public void LoadSound()
    {
        _shotgunSource.PlayOneShot(_shotgunPump01);
    }//LoadSound
    public void FireFinsh()
    {
        iscanFire = true;

    }
}

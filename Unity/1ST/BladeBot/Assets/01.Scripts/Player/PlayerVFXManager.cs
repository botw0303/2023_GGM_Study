using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVFXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _blades;
    [SerializeField] private VisualEffect _footStep;

    private AttackState _atkState;

    private void Awake()
    {
        _atkState = transform.Find("States").GetComponent<AttackState>();
        _atkState.OnAttackStart += PlayBlade;
        _atkState.OnAttackEnd += StopBlade;
    }

    public void UpdateFootStep(bool state)
    {
        if (state)
            _footStep.Play();
        else 
            _footStep.Stop();
    }

    private void StopBlade()
    {
        foreach (ParticleSystem p in _blades)
        {
            p.Simulate(0);
            p.Stop();
        }
    }

    private void PlayBlade(int combo)
    {
        _blades[combo - 1].Play();
    }
}

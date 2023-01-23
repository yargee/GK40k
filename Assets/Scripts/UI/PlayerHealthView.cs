using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _player.HitTaken += OnHitTaken;
    }

    private void OnDisable()
    {
        _player.HitTaken -= OnHitTaken;
    }

    private void OnHitTaken(int damage)
    {
        _slider.value -= damage;
    }
}

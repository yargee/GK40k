using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armory : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<ArmoryButton> _buttons = new List<ArmoryButton>();

    private void OnEnable()
    {
        foreach(var button in _buttons)
        {
            button.Clicked += _player.ChangeWeapon;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.Clicked -= _player.ChangeWeapon;
        }
    }
}

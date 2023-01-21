using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ArmoryButton : MonoBehaviour
{
    [SerializeField] private Constants.Weapons _weapon;

    private Button _button;

    public event UnityAction<int> Clicked;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => Clicked?.Invoke((int)_weapon));
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}

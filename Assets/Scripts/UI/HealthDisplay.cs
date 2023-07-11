using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthDisplay;

    private void OnEnable()
    {
        _player.OnHealthChange += UpdateHealthDisplay;   
    }

    private void OnDisable()
    {
        _player.OnHealthChange -= UpdateHealthDisplay;
    }

    private void UpdateHealthDisplay(int health)
    {
        _healthDisplay.text = health.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _mover.TryMoveUp();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            _mover.TryMoveDown();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
   
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

    }

    public void TryMoveUp()
    {
        TrySetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        TrySetNextPosition(-_stepSize);
    }

    private void TrySetNextPosition(float stepSize)
    {
        float nextStep = Mathf.Clamp(_targetPosition.y + stepSize, _minHeight, _maxHeight);
        _targetPosition = new Vector2(_targetPosition.x, nextStep);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    [Space]
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _ponitB;
    [Space]
    [SerializeField] private float TimeLimit;

    private int _direction = 1;
    private float _time;

    void Update()
    {
        _time += Time.deltaTime * _direction;
        if (_time < 0 && _direction < 0 || 
            _time > TimeLimit && _direction > 0)
        {
            _direction = -_direction;
        }

        float progress = Mathf.InverseLerp(0, TimeLimit, _time);
        _platform.transform.position = Vector2.Lerp(_pointA.position, _ponitB.position, progress);
    }
}

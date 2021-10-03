using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsObserver : MonoBehaviour
{
    internal List<WheelsMaterialController> Wheels = new List<WheelsMaterialController>();

    private int _wheelsAmountForFreeze = 2;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    internal void UpdatePhysicMaterial()
    {
        if (Wheels.Count == _wheelsAmountForFreeze)
        {
            foreach (var wheel in Wheels)
            {
                wheel.Rb.velocity = new Vector2(0, wheel.Rb.velocity.y);
            }
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
    }
}

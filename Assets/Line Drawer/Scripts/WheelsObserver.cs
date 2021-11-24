using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsObserver : MonoBehaviour
{
    [SerializeField] internal List<WheelsMaterialController> Wheels = new List<WheelsMaterialController>();

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    internal void StopWheelsSpeed(bool force = false)
    {
        foreach (var wheel in Wheels)
        {
            if (wheel.IsFreezeLineContacted == false && !force)
                return;
        }

        foreach (var wheel in Wheels)
        {
            wheel.Rb.velocity = new Vector2(0, wheel.Rb.velocity.y);
            wheel.IsFreezeLineContacted = false;
        }
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    internal void Freeze()
    {
        AudioManager.Instance.PlaySound(SoundFX.hold);
        foreach (var wheel in Wheels)
        {
            Debug.Log("freezzee");
            wheel.Rb.velocity = Vector2.zero;
            wheel.Rb.angularVelocity = 0;
            //wheel.Rb.isKinematic = true;
        }
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0;
        //_rb.isKinematic = true;
    }

    internal void UnFreeze()
    {
        foreach (var wheel in Wheels)
        {
            //wheel.Rb.isKinematic = false;
        }
        //_rb.isKinematic = false;
    }
}

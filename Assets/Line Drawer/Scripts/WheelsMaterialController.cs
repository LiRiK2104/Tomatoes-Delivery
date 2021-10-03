using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsMaterialController : MonoBehaviour
{
    [SerializeField] internal WheelsObserver WheelsObserver;
    private bool _isFreezeLineContacted = false;

    internal Rigidbody2D Rb { get; private set; }


    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Freezing Line" && !_isFreezeLineContacted)
        {
            _isFreezeLineContacted = true;
            WheelsObserver?.Wheels.Add(this);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Freezing Line" && _isFreezeLineContacted)
        {
            _isFreezeLineContacted = false;
            WheelsObserver?.Wheels.Remove(this);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Freezing Line" && _isFreezeLineContacted)
        {
            WheelsObserver.UpdatePhysicMaterial();
        }
    }
}

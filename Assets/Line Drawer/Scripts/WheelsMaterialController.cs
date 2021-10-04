using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsMaterialController : MonoBehaviour
{
    [SerializeField] internal WheelsObserver WheelsObserver;
    internal bool IsFreezeLineContacted = false;

    internal Rigidbody2D Rb { get; private set; }


    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Freezing Line" && !IsFreezeLineContacted)
        {
            IsFreezeLineContacted = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Freezing Line" && IsFreezeLineContacted)
        {
            WheelsObserver.StopWheelsSpeed();
        }
    }
}

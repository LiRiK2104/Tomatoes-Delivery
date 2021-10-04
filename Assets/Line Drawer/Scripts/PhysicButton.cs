using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicButton : MonoBehaviour
{
    public UnityEvent Function;

    private bool _click = false;

    private void OnMouseDown()
    {
        _click = true;
    }

    private void OnMouseUp()
    {
        if (_click)
        {
            Function.Invoke();
        }
        _click = false;
    }
}

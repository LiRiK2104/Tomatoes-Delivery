using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] private float _forceAttraction;

    private CircleCollider2D _magnetField;
    private List<Rigidbody2D> _objectsInField = new List<Rigidbody2D>();
    private bool _isStopMagniting = false;
    private bool _isFreezeObject = false;


    private void Awake()
    {
        _magnetField = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Magnetic"))
            return;

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null && !_objectsInField.Contains(rb))
        {
            _objectsInField.Add(rb);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Magnetic"))
            return;

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null && _objectsInField.Contains(rb))
        {
            _objectsInField.Remove(rb);
        }
    }

    private void FixedUpdate()
    {
        if (!_isStopMagniting)
        {
            foreach (var item in _objectsInField)
            {
                if (Vector2.Distance(transform.position, item.position) < 0.5f && !_isFreezeObject)
                {
                    item.gameObject.GetComponent<WheelsObserver>().Freeze();
                    item.gameObject.transform.SetParent(transform);
                    _isFreezeObject = true;
                    _isStopMagniting = true;
                }
                else 
                {
                    item.AddForce(_forceAttraction * (transform.position - item.gameObject.transform.position), ForceMode2D.Force);
                }
            }
        }
    }

    public void PushLeft()
    {
        StartCoroutine("StopMagneting");
        foreach (var item in _objectsInField)
        {
            item.gameObject.GetComponent<WheelsObserver>().UnFreeze();
            item.gameObject.transform.SetParent(null);
            item.AddForce(Vector2.left * 20, ForceMode2D.Impulse);
        }
        _isFreezeObject = false;
    }

    public void PushRight()
    {
        StartCoroutine("StopMagneting");
        foreach (var item in _objectsInField)
        {
            item.gameObject.GetComponent<WheelsObserver>().UnFreeze();
            item.gameObject.transform.SetParent(null);
            item.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
        }
        _isFreezeObject = false;
    }

    IEnumerator StopMagniting()
    {
        _isStopMagniting = true;
        yield return new WaitForSeconds(1);
        _isStopMagniting = false;
    }
}

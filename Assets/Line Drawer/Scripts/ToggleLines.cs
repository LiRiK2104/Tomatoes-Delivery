using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLines : ToggleItem
{
    [SerializeField] private GameObject _linePrefab;


    protected override void Custom(bool value)
    {
        LinesDrawer.Instance.LinePrefab = _linePrefab;
        AudioManager.Instance?.PlayClick();
    }
}

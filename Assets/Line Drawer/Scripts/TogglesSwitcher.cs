using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TogglesSwitcher : MonoBehaviour
{
    internal List<ToggleItem> Toggles = new List<ToggleItem>();

   /* private void Start()
    {
        SwitchToggle(Toggles[0]);
    }*/

    internal void SwitchToggle(ToggleItem toggleItem)
    {
        if (!Toggles.Contains(toggleItem))
            return;

        foreach (var toggle in Toggles)
        {
            toggle.Set(false);
        }
        toggleItem.Set(true);
    }
}

public abstract class ToggleItem : MonoBehaviour
{
    [SerializeField] protected TogglesSwitcher _togglesSwitcher;
    [SerializeField] protected GameObject _showHideObject;


    private void Awake()
    {
        if (_togglesSwitcher != null)
        {
            _togglesSwitcher.Toggles.Add(this);
        }
    }

    public void SwitchToggle()
    {
        _togglesSwitcher?.SwitchToggle(this);
    }

    public void Set(bool value)
    {
        _showHideObject?.SetActive(value);
        Custom(value);
    }

    protected abstract void Custom(bool value);
}

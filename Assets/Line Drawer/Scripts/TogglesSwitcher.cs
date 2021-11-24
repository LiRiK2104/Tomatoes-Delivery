using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TogglesSwitcher : MonoBehaviour
{
    internal List<ToggleItem> Toggles = new List<ToggleItem>();

    private void Start()
    {
        IEnumerable<ToggleItem> sortedToggles = from item in Toggles
            orderby item._order ascending
                            select item;
        Toggles = sortedToggles.ToList();
        Debug.Log(Toggles.Count);
        SwitchToggle(Toggles[0]);
    }

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
    public int _order;


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

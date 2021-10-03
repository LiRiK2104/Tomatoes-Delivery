using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    internal static UIManager Instance;

    [SerializeField] private Text _quantityText;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal void ChangeQuantity(int currentTomatoesQuantity)
    {
        if (TomatoSpawner.Instance != null)
        {
            _quantityText.text = string.Format("{0}/{1}", currentTomatoesQuantity, TomatoSpawner.Instance.TomatoesQuantity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    internal static UIManager Instance;

    [SerializeField] private Text _quantityText;
    [SerializeField] private GameObject tutor;

    internal List<GameObject> tomatoes = new List<GameObject>();


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

    internal void ChangeTomatoesAmount()
    {
        if (TomatoSpawner.Instance != null)
        {
            if (_quantityText != null)
            {
                _quantityText.text = string.Format("{0}/{1}", tomatoes.Count, TomatoSpawner.Instance.TomatoesQuantity);
            }

            if (EasterTomatoUnlocker.Instance != null)
            {
                EasterTomatoUnlocker.Instance.Add();
            }
        }
    }

    public void OpenTutor()
    {
        AudioManager.Instance.PlayClick();
        tutor.SetActive(true);
    }
}

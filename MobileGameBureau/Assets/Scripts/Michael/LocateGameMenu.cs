using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class LocateGameMenu : MonoBehaviour
{
    [Header("UI Tabs")]
    [SerializeField] private List<GameObject> outGameTabs;

    [Header("Knoppen")]
    [SerializeField] private List<Button> bottomButtons;

    private void Start()
    {
        outGameTabs[2].SetActive(true);
    }

    private void Awake()
    {
        // shop
        bottomButtons[0].onClick.AddListener(() =>
        {
            for (int i = 0; i < outGameTabs.Count; i++)
            {
                outGameTabs[i].SetActive(false);
            }
            outGameTabs[0].SetActive(true);
        });

        // achievements
        bottomButtons[1].onClick.AddListener(() =>
        {
            for (int i = 0; i < outGameTabs.Count; i++)
            {
                outGameTabs[i].SetActive(false);
            }
            outGameTabs[1].SetActive(true);
        });

        // home
        bottomButtons[2].onClick.AddListener(() =>
        {
            for (int i = 0; i < outGameTabs.Count; i++)
            {
                outGameTabs[i].SetActive(false);
            }
            outGameTabs[2].SetActive(true);
        });

        // pass
        bottomButtons[3].onClick.AddListener(() =>
        {
            for (int i = 0; i < outGameTabs.Count; i++)
            {
                outGameTabs[i].SetActive(false);
            }
            outGameTabs[3].SetActive(true);
        });

        //owned vehicles
        bottomButtons[4].onClick.AddListener(() =>
        {
            for (int i = 0; i < outGameTabs.Count; i++)
            {
                outGameTabs[i].SetActive(false);
            }
            outGameTabs[4].SetActive(true);
        });
    }
}

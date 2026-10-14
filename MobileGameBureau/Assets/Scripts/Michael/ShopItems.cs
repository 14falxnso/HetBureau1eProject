using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    [Header("Categories")]
    [SerializeField] private List<GameObject> categoryScrollView;

    [Header("Category Buttons")]
    [SerializeField] private List<Button> categoryButtons;

    private void Awake()
    {
        // coin shop
        categoryButtons[0].onClick.AddListener(() =>
        {
            for (int i = 0; i < categoryScrollView.Count; i++)
            {
                categoryScrollView[i].SetActive(false);
            }
            categoryScrollView[0].SetActive(true);
        });

        // bundle shop
        categoryButtons[1].onClick.AddListener(() =>
        {
            for (int i = 0; i < categoryScrollView.Count; i++)
            {
                categoryScrollView[i].SetActive(false);
            }
            categoryScrollView[1].SetActive(true);
        });

        // ability
        categoryButtons[2].onClick.AddListener(() =>
        {
            for (int i = 0; i < categoryScrollView.Count; i++)
            {
                categoryScrollView[i].SetActive(false);
            }
            categoryScrollView[2].SetActive(true);
        });
    }

    

}

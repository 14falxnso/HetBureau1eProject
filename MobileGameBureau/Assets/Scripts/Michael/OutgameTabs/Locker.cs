using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    [SerializeField] private List<RenderTexture> vehicleRenders;
    [SerializeField] private RawImage carShow;

    [SerializeField] private Button goLeftButton;
    [SerializeField] private Button goRightButton;

    private int currentIndex = 0;

    private void Start()
    {
        goLeftButton.onClick.AddListener(GoLeftShower);
        goRightButton.onClick.AddListener(GoRightShower);

        carShow.texture = vehicleRenders[currentIndex];
    }

    private void GoLeftShower()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = vehicleRenders.Count - 1;
        }

        carShow.texture = vehicleRenders[currentIndex];
    }

    private void GoRightShower()
    {
        currentIndex++;

        if (currentIndex >= vehicleRenders.Count)
        {
            currentIndex = 0;
        }

        carShow.texture = vehicleRenders[currentIndex];
    }
}
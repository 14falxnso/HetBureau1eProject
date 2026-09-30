using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    [SerializeField] private List<RenderTexture> vehicleRenders;
    [SerializeField] private RawImage carShow;

    [SerializeField] private Button goLeftButton;
    [SerializeField] private Button goRightButton;

    public void ButtonCheck()
    {
        goLeftButton.onClick.AddListener(() => GoLeftShower());
        goRightButton.onClick.AddListener(() => GoRightShower());
    }

    private void GoLeftShower()
    {
        for (int i = 0; i < vehicleRenders.Count; i--)
        {
           carShow.texture = vehicleRenders[i];
        }
    }

    private void GoRightShower() 
    {
        for (int i = 0; i < vehicleRenders.Count; i++)
        {
            carShow.texture = vehicleRenders[i];
        }
    }
}

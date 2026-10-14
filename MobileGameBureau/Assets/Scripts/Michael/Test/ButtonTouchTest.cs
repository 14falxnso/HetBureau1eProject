
using UnityEngine;
using UnityEngine.UI;

public class ButtonTouchTest : MonoBehaviour
{
    public Button button;

    void Start()
    {
        //button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                Debug.Log("BUTTON CLICKED!");
            });
        }
        else
        {
            Debug.LogError("Geen Button-component gevonden!");
        }
    }
}

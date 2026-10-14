using TMPro;
using UnityEngine;

public class HomeMenuScript : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI coinText;

    [SerializeField] private TextMeshProUGUI shopCoinsText;

    [Header("Links")]
    [SerializeField] private TestStats testStatsScript;


    public void UpdateMoneyTexts()
    {
        shopCoinsText.text = testStatsScript.testMoney.ToString();
        coinText.text = testStatsScript.testMoney.ToString();
    }
}

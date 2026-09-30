using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseAchievements : MonoBehaviour
{
    public int level = 1;
    public float currentAmount = 0;
    public float minAmount;
    public float maxAmount;
    public float multiplier = 1.4f;

    [Header("Sea alive veld")]
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Start()
    {
        currentAmount = 0;
        minAmount = currentAmount;
        
        progressBar.fillAmount = currentAmount;
        levelText.text = level+ "";
        // als de player is ingeladen, laad progressie in
    }

    private void Update()
    {
        progressBar.fillAmount = currentAmount / maxAmount;
    }

    public void ClaimAchievement()
    {
        if (currentAmount == maxAmount)
        {
            // geef rewards
            level++;
            levelText.text = level + "";
            maxAmount *= multiplier;
            currentAmount = minAmount;
            progressBar.fillAmount = 0;
        }
    }

}

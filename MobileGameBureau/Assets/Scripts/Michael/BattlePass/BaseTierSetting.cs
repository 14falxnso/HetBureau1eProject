using UnityEngine;

public class BaseTierSetting : MonoBehaviour
{
    public bool paid;

    [Header("Info")]
    public int coinAmount;
    public int life;
    public int xpBoost;
    public int lessWaitTime;

    [Header("Objects")]
    public GameObject carPowerUp; 
    public GameObject carSkin; 
    public GameObject icon; 
    public GameObject powerUp;
    public GameObject themeBackground;
}

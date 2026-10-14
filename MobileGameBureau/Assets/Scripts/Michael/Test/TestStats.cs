using System.Security.Cryptography;
using UnityEngine;

public class TestStats : MonoBehaviour
{
    public int testLives;
    public int testMoney;

    public void MoneyReward(int amount)
    {
        testMoney += amount;
    }

    public void LivesReward(int amount)
    {
        testLives += amount;
    }
}

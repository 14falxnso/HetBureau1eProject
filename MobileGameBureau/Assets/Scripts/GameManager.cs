using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[Serializable]
public class Order
{
    public GameObject canvas;
    public TMP_Text numberText;
    public Image itemImage;
    public TMP_Text countText;
    public GameObject[] kgIcons;

    [NonSerialized] public int weight, remaining, reserved;
    public int Open => remaining - reserved; // items not yet claimed by a vehicle
}

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] TMP_Text timerText;
    [SerializeField] float startTime = 60f;

    [Header("Orders")]
    [SerializeField] Order[] orders; // closest -> farthest
    [SerializeField] Sprite[] itemSprites;
    [SerializeField] Vector2Int itemCountRange = new(2, 7); // max exclusive

    [Header("Result")]
    [SerializeField] GameObject resultPanel;
    [SerializeField] TMP_Text resultText;

    public Vector3 location;

    static readonly string[] Triggers = { "GoShort", "GoNormal", "GoLong" };

    float timeLeft;
    int lastSecond = -1;
    bool gameOver;

    public bool IsPlaying => !gameOver && Time.timeScale > 0f;

    void Start()
    {
        timeLeft = startTime;
        UpdateTimerText(Mathf.CeilToInt(timeLeft));

        foreach (var o in orders) SetupOrder(o);
        Play("SharpPlop");
    }

    void Update()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            UpdateTimerText(0);
            EndGame(false);
            return;
        }

        int seconds = Mathf.CeilToInt(timeLeft);
        if (seconds != lastSecond) UpdateTimerText(seconds);
    }

    void UpdateTimerText(int seconds)
    {
        lastSecond = seconds;
        timerText.text = $"{seconds / 60}:{seconds % 60:00}";
    }

    void EndGame(bool won)
    {
        gameOver = true;
        Time.timeScale = 0f;
        Play(won ? "Win" : "Lose");
        resultText.text = won ? "All orders completed!\nYou win!" : "Time's up!\nYou failed!";
        resultPanel.SetActive(true);
    }

    public void OpenPanel(GameObject panel)
    {
        if (gameOver) return;
        panel.SetActive(true);
        Time.timeScale = 0f;
        Play("SoftPlop");
    }

    public void ClosePanel(GameObject panel)
    {
        if (gameOver) return;
        panel.SetActive(false);
        Time.timeScale = 1f;
        Play("SoftPlop");
    }

    void SetupOrder(Order o)
    {
        o.weight = Random.Range(1, 4);
        o.remaining = Random.Range(itemCountRange.x, itemCountRange.y);
        o.reserved = 0;

        o.numberText.text = $"Order: {Random.Range(1000, 10000)}";
        o.itemImage.sprite = itemSprites[Random.Range(0, itemSprites.Length)];
        o.countText.text = $"{o.remaining}x";

        for (int i = 0; i < o.kgIcons.Length; i++)
            o.kgIcons[i].SetActive(i < o.weight);

        o.canvas.SetActive(true);
    }

    public void OnClickSpawnVechile(GameObject vehiclePrefab)
    {
        if (gameOver) return;

        int target = Array.FindIndex(orders, o => o.Open > 0);
        if (target < 0) return;

        Order o = orders[target];
        int carry = Mathf.Min(vehiclePrefab.GetComponent<Vehicle>().capacity / o.weight, o.Open);
        if (carry == 0) return; // item too heavy for this vehicle

        o.reserved += carry;

        Vehicle v = Instantiate(vehiclePrefab.GetComponent<Vehicle>(), location, Quaternion.identity);
        v.Init(this, target, carry);
        v.GetComponent<Animator>().SetTrigger(Triggers[target]);
    }

    public void Deliver(int index, int amount)
    {
        if (gameOver) return;

        Order o = orders[index];
        o.reserved -= amount;
        o.remaining -= amount;
        o.countText.text = $"{o.remaining}x";

        if (o.remaining > 0) return;

        o.canvas.SetActive(false);
        if (Array.TrueForAll(orders, x => x.remaining <= 0)) EndGame(true);
    }

    static void Play(string sound) => AudioManager.Instance.PlaySound(sound);
}
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
    public int Open => remaining - reserved;
}

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] Order[] orders;
    [SerializeField] Sprite[] itemSprites;
    [SerializeField] Vector2Int itemCountRange = new(2, 7); // max exclusive

    public Vector3 location;

    static readonly string[] Triggers = { "GoShort", "GoNormal", "GoLong" };

    [SerializeField] float startTime = 60f;

    float timeLeft;
    int lastSecond = -1;
    bool timeUp;

    public bool IsPlaying => Time.timeScale > 0f;

    void Start()
    {
        timeLeft = startTime;
        UpdateTimerText(Mathf.CeilToInt(timeLeft));
        foreach (var o in orders) SetupOrder(o);
    }
    void Update()
    {
        if (timeUp) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            timeUp = true;
            UpdateTimerText(0);
            TimeUp();
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
    void TimeUp()
    {
        Debug.Log("Time's up!");
    }

    public void OpenPanel(GameObject panel) { panel.SetActive(true); Time.timeScale = 0f; }
    public void ClosePanel(GameObject panel) { panel.SetActive(false); Time.timeScale = 1f; }

    void SetupOrder(Order o)
    {
        o.weight = Random.Range(1, 4);
        o.remaining = Random.Range(itemCountRange.x, itemCountRange.y);
        o.reserved = 0;

        o.numberText.text = $"Order: {Random.Range(1000, 10000)}";
        o.itemImage.sprite = itemSprites[Random.Range(0, itemSprites.Length)];
        for (int i = 0; i < o.kgIcons.Length; i++) o.kgIcons[i].SetActive(i < o.weight);

        o.countText.text = $"{o.remaining}x";
        o.canvas.SetActive(true);
    }

    public void OnClickSpawnVechile(GameObject vehiclePrefab)
    {
        int target = Array.FindIndex(orders, o => o.Open > 0);
        if (target < 0) return;

        Order o = orders[target];
        int carry = Mathf.Min(vehiclePrefab.GetComponent<Vehicle>().capacity / o.weight, o.Open);
        if (carry == 0) return;

        o.reserved += carry;

        GameObject v = Instantiate(vehiclePrefab, location, Quaternion.identity);
        v.GetComponent<Vehicle>().Init(this, target, carry);
        v.GetComponent<Animator>().SetTrigger(Triggers[target]);
    }

    public void Deliver(int index, int amount)
    {
        Order o = orders[index];
        o.reserved -= amount;
        o.remaining -= amount;
        o.countText.text = $"{o.remaining}x";

        if (o.remaining <= 0) o.canvas.SetActive(false);
    }
}
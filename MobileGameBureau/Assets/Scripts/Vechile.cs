using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public int capacity = 3; // kg: bike 2, car 4, truck 6, etc.

    GameManager gm;
    int orderIndex, amount;

    public void Init(GameManager manager, int index, int items)
    {
        gm = manager;
        orderIndex = index;
        amount = items;
    }

    public void Arrive()
    {
        gm.Deliver(orderIndex, amount);
        GetComponent<Animator>().SetTrigger("Leave");
    }

    public void Despawn() => Destroy(gameObject);
}
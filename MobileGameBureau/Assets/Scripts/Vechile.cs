using System.Collections;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public int capacity = 3;

    GameManager gm;
    int orderIndex, amount;

    public void Init(GameManager manager, int index, int items)
    {
        gm = manager;
        orderIndex = index;
        amount = items;
    }

    public void Arrive() => StartCoroutine(DeliverRoutine());

    IEnumerator DeliverRoutine()
    {
        var wait = new WaitForSeconds(0.3f);

        for (int i = 0; i < amount; i++)
        {
            gm.Deliver(orderIndex, 1);
            AudioManager.Instance.PlaySound("SharpPlop");
            yield return wait;
        }

        GetComponent<Animator>().SetTrigger("Leave");
        yield return new WaitForSeconds(5f);
        Despawn();
    }

    public void Despawn() => Destroy(gameObject);
}
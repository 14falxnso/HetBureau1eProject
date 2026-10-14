using System.Collections;
using UnityEngine;
public class Delay : MonoBehaviour
{
    public static Delay Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public IEnumerator DelayforSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}

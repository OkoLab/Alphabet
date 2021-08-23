using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public IEnumerator Wait(float seconds)
    {

        yield return new WaitForSeconds(seconds); // таймер, через n секунд
    }
}

using System.Collections;
using TMPro;
using UnityEngine;

public class SleepCoroutine : MonoBehaviour
{
    public void SleepAndReset(float timer, TextMeshProUGUI codeText)
    {
        StartCoroutine(SleepTimer(timer, codeText));
    }

    private IEnumerator SleepTimer(float timer, TextMeshProUGUI codeText)
    {
        yield return new WaitForSeconds(timer);

        codeText.text = "";
    }
}

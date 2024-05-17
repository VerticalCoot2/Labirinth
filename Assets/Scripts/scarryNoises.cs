using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scarryNoises : MonoBehaviour
{
    int random;
    private void Awake()
    {
        StartCoroutine(noiseMaker());
    }
    IEnumerator noiseMaker()
    {
        while (true)
        {
            random = Random.Range(15, 120);
            yield return new WaitForSeconds(random + 3);
            FindFirstObjectByType<AudioManager>().PlayScarryNoise();
        }
    }
}

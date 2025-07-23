using System.Collections;
using UnityEngine;

public class ObjectFlicker : MonoBehaviour
{
    private Renderer objectRenderer;

    public float minOnTime = 0.1f;
    public float maxOnTime = 0.5f;
    public float minOffTime = 0.05f;
    public float maxOffTime = 0.2f;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // L'oggetto visibile
            objectRenderer.enabled = true;
            float onTime = Random.Range(minOnTime, maxOnTime);
            yield return new WaitForSeconds(onTime);

            // L'oggetto invisibile
            objectRenderer.enabled = false;
            float offTime = Random.Range(minOffTime, maxOffTime);
            yield return new WaitForSeconds(offTime);
        }
    }
}
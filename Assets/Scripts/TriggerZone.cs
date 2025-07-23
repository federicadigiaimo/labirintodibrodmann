using UnityEngine;
using System.Collections;

public class ObjectActivatorTrigger : MonoBehaviour
{
    [Header("Oggetti da Attivare")]
    public GameObject oggettoVisivo;

    public GameObject oggettoUditivo;

    [Header("Impostazioni di Attivazione")]
    public float activeDuration = 5.0f;
    public bool deactivateOnStart = true;
    public bool singleUse = false;

    private bool hasBeenUsed = false;

    void Start()
    {
        // Disattiva entrambi gli oggetti all'inizio, se richiesto
        if (deactivateOnStart)
        {
            if (oggettoVisivo != null) oggettoVisivo.SetActive(false);
            if (oggettoUditivo != null) oggettoUditivo.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (!singleUse || !hasBeenUsed))
        {
            StartCoroutine(ActivateAndDeactivate());

            if (singleUse)
            {
                hasBeenUsed = true;
            }
        }
    }

    private IEnumerator ActivateAndDeactivate()
    {
        if (oggettoVisivo != null)
        {
            oggettoVisivo.SetActive(true);
            Debug.Log($"Attivato: {oggettoVisivo.name}");
        }
        if (oggettoUditivo != null)
        {
            oggettoUditivo.SetActive(true);
            Debug.Log($"Attivato: {oggettoUditivo.name}");
        }

        yield return new WaitForSeconds(activeDuration);

        if (oggettoVisivo != null)
        {
            oggettoVisivo.SetActive(false);
            Debug.Log($"Disattivato: {oggettoVisivo.name}");
        }
        if (oggettoUditivo != null)
        {
            oggettoUditivo.SetActive(false);
            Debug.Log($"Disattivato: {oggettoUditivo.name}");
        }
    }
}
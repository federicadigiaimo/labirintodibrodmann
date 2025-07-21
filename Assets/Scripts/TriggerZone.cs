using UnityEngine;
using System.Collections;

public class ObjectActivatorTrigger : MonoBehaviour
{
    [Header("Oggetti da Attivare")]
    [Tooltip("L'oggetto visivo che verrà attivato/disattivato.")]
    public GameObject oggettoVisivo;

    [Tooltip("L'oggetto uditivo (o un altro oggetto) che verrà attivato/disattivato.")]
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
            // Avvia la coroutine UNA SOLA VOLTA
            StartCoroutine(ActivateAndDeactivate());

            if (singleUse)
            {
                hasBeenUsed = true;
            }
        }
    }

    private IEnumerator ActivateAndDeactivate()
    {
        // --- FASE 1: ATTIVAZIONE ---
        // Attiva ogni oggetto solo se è stato assegnato
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

        // --- FASE 2: ATTESA ---
        yield return new WaitForSeconds(activeDuration);

        // --- FASE 3: DISATTIVAZIONE ---
        // Disattiva ogni oggetto solo se è stato assegnato
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
using UnityEngine;

public class TriggerBlocker : MonoBehaviour
{
    // 1. Dichiara la variabile 'duration' qui, fuori dal metodo.
    // La parola chiave 'public' la rende visibile nell'Inspector.
    public int dur = 5; // Ho aggiunto un valore di default (5 secondi)

    // La tua variabile per il VisionBlocker
    public VisionBlocker blocker;

    // Il metodo OnTriggerEnter rimane quasi invariato
    void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che è entrato nel trigger è il Player
        if (other.CompareTag("Player"))
        {
            // 2. Ora usa la variabile 'duration' che hai definito sopra.
            // Non devi dichiararla di nuovo qui.
            Debug.Log($"Attivato: {blocker.name}");
            blocker.ShowBlocker(dur);
        }
    }
}
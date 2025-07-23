using UnityEngine;
using System.Collections; // Necessario per usare le Coroutine (i timer)

public class ActivateObjectAndPlayAudio : MonoBehaviour
{
    [Header("Oggetto da Gestire")]
    [Tooltip("Trascina qui l'oggetto genitore che deve essere attivato (es. 'SistemaAudioRotante').")]
    public GameObject objectToActivate;

    [Header("Impostazioni Audio")]
    [Tooltip("Il secondo da cui deve iniziare l'audio.")]
    public float startTimeInSeconds = 0f;

    // ----- NUOVA SEZIONE -----
    [Header("Impostazioni Durata")]
    [Tooltip("Durata in secondi dell'effetto. Imposta a 0 per non fermarlo mai.")]
    public float durationInSeconds = 10f; // Default a 10 secondi
    // -------------------------

    [Header("Impostazioni Trigger")]
    [Tooltip("Il tag dell'oggetto che attiva l'evento.")]
    public string triggerTag = "Player";

    private bool hasBeenActivated = false;

    void Start()
    {
        if (objectToActivate == null)
        {
            Debug.LogError("Oggetto da attivare non assegnato!", this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag) && !hasBeenActivated)
        {
            if (objectToActivate == null) return;

            // Invece di eseguire tutto qui, avviamo la Coroutine che gestisce l'intero ciclo di vita
            StartCoroutine(ActivateAndDeactivateAfterTime());
        }
    }

    // ----- NUOVA FUNZIONE (LA COROUTINE) -----
    private IEnumerator ActivateAndDeactivateAfterTime()
    {
        // 1. Assicurati che l'evento accada una sola volta
        hasBeenActivated = true;
        Debug.Log("Giocatore ha attivato la scena! L'effetto durerà " + durationInSeconds + " secondi.");

        // 2. Attiva l'oggetto e fai partire l'audio (come prima)
        objectToActivate.SetActive(true);
        AudioSource audio = objectToActivate.GetComponentInChildren<AudioSource>();

        if (audio != null)
        {
            audio.time = startTimeInSeconds;
            audio.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource non trovato nell'oggetto attivato!", objectToActivate);
        }

        // 3. Se la durata è positiva, ASPETTA.
        // Se la durata è 0 o negativa, il codice si fermerà qui e l'oggetto resterà attivo.
        if (durationInSeconds > 0)
        {
            // Questa è la magia: la funzione si mette in pausa qui per tot secondi senza bloccare il gioco.
            yield return new WaitForSeconds(durationInSeconds);

            // 4. Dopo aver aspettato, DISATTIVA l'oggetto.
            Debug.Log("Durata terminata. Disattivo l'oggetto.");
            objectToActivate.SetActive(false);
        }
    }
    // -----------------------------------------
}
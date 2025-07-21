using UnityEngine;

public class ActivateObjectAndPlayAudio : MonoBehaviour
{
    [Header("Oggetto da Gestire")]
    [Tooltip("Trascina qui l'oggetto genitore che deve essere attivato (es. 'SistemaAudioRotante').")]
    public GameObject objectToActivate;

    [Header("Impostazioni Audio")]
    [Tooltip("Il secondo da cui deve iniziare l'audio.")]
    public float startTimeInSeconds = 0f;

    [Header("Impostazioni Trigger")]
    [Tooltip("Il tag dell'oggetto che attiva l'evento.")]
    public string triggerTag = "Player";

    private bool hasBeenActivated = false;

    void Start()
    {
        // Controllo di sicurezza all'avvio
        if (objectToActivate == null)
        {
            Debug.LogError("Oggetto da attivare non assegnato!", this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag) && !hasBeenActivated)
        {
            // Se l'oggetto non è stato assegnato, non fare nulla
            if (objectToActivate == null) return;

            Debug.Log("Giocatore ha attivato la scena!");

            // 1. Attiva l'intero GameObject (il sistema rotante appare e inizia a girare)
            objectToActivate.SetActive(true);

            // 2. Trova l'AudioSource all'interno dell'oggetto appena attivato
            // GetComponentInChildren lo cercherà tra tutti i suoi figli (troverà quello su "OrbitaAudio")
            AudioSource audio = objectToActivate.GetComponentInChildren<AudioSource>();

            if (audio != null)
            {
                // 3. Imposta il tempo di inizio e fai partire l'audio
                audio.time = startTimeInSeconds;
                audio.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource non trovato nell'oggetto attivato!", objectToActivate);
            }

            // 4. Assicurati che questo evento accada una sola volta
            hasBeenActivated = true;
        }
    }
}
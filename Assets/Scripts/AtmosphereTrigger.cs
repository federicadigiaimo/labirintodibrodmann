using System.Collections;
using UnityEngine;

public class AtmosphereTrigger : MonoBehaviour
{
    [Header("Riferimenti della Scena")]
    public Light mainLight; // Trascina qui la tua Directional Light

    [Header("Impostazioni Effetto Cupo")]
    public float effectDuration = 5.0f; // Durata dell'effetto in secondi
    public Color gloomyLightColor = new Color(0.4f, 0.4f, 0.6f); // Un blu/grigio freddo
    public float gloomyLightIntensity = 0.3f;
    public Color gloomyAmbientColor = new Color(0.1f, 0.1f, 0.15f);

    // Variabili private per salvare i valori originali
    private Color originalLightColor;
    private float originalLightIntensity;
    private Color originalAmbientColor;
    private bool isEffectActive = false;

    // Questo metodo viene chiamato quando un altro collider ENTRA nel trigger
    private void OnTriggerEnter(Collider other)
    {
        // Controlla se a entrare è il giocatore e se l'effetto non è già attivo
        if (other.GetComponentInParent<OVRCameraRig>() != null && !isEffectActive)
        {
            // Avvia la Coroutine che gestisce l'effetto
            StartCoroutine(ActivateGloomEffect());
        }
    }

    private IEnumerator ActivateGloomEffect()
    {
        isEffectActive = true;
        Debug.Log("Effetto cupo ATTIVATO!");

        // 1. SALVA le impostazioni di luce attuali
        originalLightColor = mainLight.color;
        originalLightIntensity = mainLight.intensity;
        originalAmbientColor = RenderSettings.ambientLight;

        // 2. APPLICA le nuove impostazioni "cupe"
        mainLight.color = gloomyLightColor;
        mainLight.intensity = gloomyLightIntensity;
        RenderSettings.ambientLight = gloomyAmbientColor;

        // 3. ASPETTA per la durata specificata
        yield return new WaitForSeconds(effectDuration);

        // 4. RIPRISTINA le impostazioni originali
        Debug.Log("Effetto cupo TERMINATO. Ripristino le luci originali.");
        mainLight.color = originalLightColor;
        mainLight.intensity = originalLightIntensity;
        RenderSettings.ambientLight = originalAmbientColor;

        // 5. Permetti all'effetto di essere riattivato
        isEffectActive = false;
    }
}
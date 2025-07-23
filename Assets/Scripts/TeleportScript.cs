using UnityEngine;

public class VRTeleporter : MonoBehaviour
{
    [Tooltip("L'oggetto vuoto che rappresenta la destinazione (posizione E rotazione).")]
    public Transform destination;

    [Tooltip("Il tag dell'oggetto principale del giocatore (es. XR Origin).")]
    private string playerTag = "Player";


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter attivato da: " + other.name);

        Transform playerRoot = other.transform.root;

        Debug.Log("Oggetto Root rilevato: " + playerRoot.name + " | Tag di questo oggetto: '" + playerRoot.tag + "'");

        if (playerRoot.CompareTag(playerTag))
        {
            Debug.Log("Controllo del Tag SUPERATO. Procedo al teletrasporto.");

            if (destination == null)
            {
                Debug.LogError("Destinazione non impostata! Assegna un Transform nello script VRTeleporter.");
                return;
            }

            TeleportPlayer(playerRoot.gameObject);
        }
        else
        {
            Debug.LogError("ERRORE: Il controllo del Tag è FALLITO. L'oggetto root non ha il tag '" + playerTag + "'.");
        }
    }

    private void TeleportPlayer(GameObject playerRigObject)
    {
        CharacterController cc = playerRigObject.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
        }
        playerRigObject.transform.position = destination.position;

        playerRigObject.transform.rotation = destination.rotation;

        if (cc != null)
        {
            cc.enabled = true;
        }

        Debug.Log(playerRigObject.name + " è stato teletrasportato e ruotato verso " + destination.name);
    }
}
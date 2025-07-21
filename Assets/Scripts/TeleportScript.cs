using UnityEngine;

public class VRTeleporter : MonoBehaviour // Rinominato per chiarezza
{
    [Tooltip("L'oggetto vuoto che rappresenta la destinazione (posizione E rotazione).")]
    public Transform destination;

    [Tooltip("Il tag dell'oggetto principale del giocatore (es. XR Origin).")]
    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        // Troviamo l'oggetto "root" del giocatore. Questo è fondamentale in VR.
        // Se il trigger viene toccato dalla mano o da un collider figlio,
        // vogliamo teletrasportare l'intero rig, non solo la mano!
        Transform playerRoot = other.transform.root;

        if (playerRoot.CompareTag(playerTag))
        {
            if (destination == null)
            {
                Debug.LogError("Destinazione non impostata! Assegna un Transform nello script VRTeleporter.");
                return;
            }

            TeleportPlayer(playerRoot.gameObject);
        }
    }

    private void TeleportPlayer(GameObject playerRigObject)
    {
        // Cerchiamo il CharacterController sul rig principale.
        CharacterController cc = playerRigObject.GetComponent<CharacterController>();

        // Disabilitiamo temporaneamente il controller per evitare conflitti.
        if (cc != null)
        {
            cc.enabled = false;
        }

        // --- LA LOGICA CHIAVE DEL TELETRASPORTO ---

        // Spostiamo la POSIZIONE del rig del giocatore.
        playerRigObject.transform.position = destination.position;

        // Impostiamo la ROTAZIONE del rig del giocatore.
        // Questo allinea il "davanti" del giocatore con il "davanti" della destinazione.
        playerRigObject.transform.rotation = destination.rotation;

        // -----------------------------------------

        // Riabilitiamo il Character Controller dopo il teletrasporto.
        if (cc != null)
        {
            cc.enabled = true;
        }

        Debug.Log(playerRigObject.name + " è stato teletrasportato e ruotato verso " + destination.name);
    }
}
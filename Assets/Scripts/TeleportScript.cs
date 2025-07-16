using UnityEngine;

public class SimpleTeleporter : MonoBehaviour
{

    public Transform destination;

    private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (destination == null)
            {
                Debug.LogError("Destinazione non impostata per il teletrasporto! Assegna un Transform nello script SimpleTeleporter.");
                return; 
            }

            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject playerObject)
    {
        CharacterController cc = playerObject.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
        }

        playerObject.transform.position = destination.position;

        if (cc != null)
        {
            cc.enabled = true;
        }

        Debug.Log(playerObject.name + " è stato teletrasportato a " + destination.name);
    }
}
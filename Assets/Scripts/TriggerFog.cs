using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject oggettoDaAttivare;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oggettoDaAttivare.SetActive(true);
            Debug.Log("Il giocatore è entrato nell'area!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oggettoDaAttivare.SetActive(false);
            Debug.Log("Il giocatore è uscito dall'area.");
        }
    }
}

using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject oggettoDaAttivareVisivo;
    public GameObject oggettoDaAttivareUditivo;


    void Start()
    {
        oggettoDaAttivareVisivo.SetActive(false);
        oggettoDaAttivareUditivo.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oggettoDaAttivareVisivo.SetActive(true);
            oggettoDaAttivareUditivo.SetActive(true);
            Debug.Log("Il giocatore � entrato nell'area.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oggettoDaAttivareVisivo.SetActive(false);
            oggettoDaAttivareUditivo.SetActive(false);
            Debug.Log("Il giocatore � uscito dall'area.");
        }
    }
}

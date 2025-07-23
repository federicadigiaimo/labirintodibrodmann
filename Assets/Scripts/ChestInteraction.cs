using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            Debug.Log("Mano del giocatore ha toccato lo scrigno! Apro...");

            animator.SetTrigger("OpenChest");

            GetComponent<Collider>().enabled = false;
        }
    }
}
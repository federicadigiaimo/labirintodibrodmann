using UnityEngine;

public class OrbitaAttornoAPunto : MonoBehaviour
{
    public Transform centro;         // Punto attorno al quale orbitare
    public float velocit� = 50f;     // Velocit� di rotazione in gradi/secondo
    public float durata = 5f;        // Durata dell'orbita

    private float timer = 0f;

    void Update()
    {
        if (timer < durata)
        {
            transform.RotateAround(centro.position, Vector3.up, velocit� * Time.deltaTime);
            timer += Time.deltaTime;
        }
    }
}
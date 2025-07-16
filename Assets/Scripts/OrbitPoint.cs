using UnityEngine;

public class OrbitaAttornoAPunto : MonoBehaviour
{
    public Transform centro;         // Punto attorno al quale orbitare
    public float velocità = 50f;     // Velocità di rotazione in gradi/secondo
    public float durata = 5f;        // Durata dell'orbita

    private float timer = 0f;

    void Update()
    {
        if (timer < durata)
        {
            transform.RotateAround(centro.position, Vector3.up, velocità * Time.deltaTime);
            timer += Time.deltaTime;
        }
    }
}
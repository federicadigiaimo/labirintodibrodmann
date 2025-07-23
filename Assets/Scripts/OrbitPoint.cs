using UnityEngine;

public class OrbitaAttornoAPunto : MonoBehaviour
{
    public Transform centro;
    public float velocit� = 50f;
    public float durata = 5f;

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
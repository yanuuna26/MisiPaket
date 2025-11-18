using UnityEngine;

public class EfekDebu : MonoBehaviour
{
    public GameObject partikelDebu;
    private bool isGrounded = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("meja") && isGrounded == false)
        {
            Debug.Log("efek terpanggil");
            Vector3 posisi = collision.contacts[0].point;

            Instantiate(partikelDebu, posisi, Quaternion.identity);

            isGrounded = true;
        }
    }
}


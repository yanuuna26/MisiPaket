using UnityEngine;

public class efekDebu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject dropDustPrefab;
    private bool isGrounded = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("meja") && isGrounded == false)
        {
            Vector3 pos = col.GetContact(0).point;

            // Pastikan efek berada di depan kamera 2D
            pos.z = -1f;

            // Munculkan efek debu
            Instantiate(dropDustPrefab, pos, Quaternion.identity);

            isGrounded = true;
        }
    }
}

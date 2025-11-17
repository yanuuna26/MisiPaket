using UnityEngine;

public class BoxMoveHorizontal : MonoBehaviour
{
    public float kecepatan = 3f;
    public bool isMoveRight = true;
    public bool isDropped = false;
    public bool isGrounded = false;
    public System.Action setelahJatuh;

    void Update()
    {
        if (!isDropped)
        {
            float dir = isMoveRight ? 1f : -1f;
            transform.Translate(Vector3.right * dir * kecepatan * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Tabrakan dengan: " + col.collider.name);

        if (col.collider.CompareTag("tembok"))
        {
            isMoveRight = !isMoveRight;
        }
        Debug.Log(isDropped);
        if (col.collider.CompareTag("lantai") && isGrounded==false)
        {
            Debug.Log("jatuh");
            isGrounded = true;
            setelahJatuh?.Invoke();
        }
    }
}

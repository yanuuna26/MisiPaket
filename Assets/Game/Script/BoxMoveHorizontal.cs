using UnityEngine;

public class BoxMoveHorizontal : MonoBehaviour
{
    public float kecepatan = 3f;
    public bool isMoveRight = true;
    public bool isDropped = false;
    public bool isGrounded = false;
    public bool isGameOver = false;
    public System.Action setelahJatuh;
    public BoxSpawner boxSpawner;
    //GameObject spritePrefab;
    //GameObject spawnedImage;
    //public GameObject onoff;

    void Start()
    {
        GameObject _boxSpawner = GameObject.FindGameObjectWithTag("boxGameOver");
        boxSpawner = _boxSpawner.GetComponent<BoxSpawner>();
    }
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
        if (col.collider.CompareTag("meja") && isGrounded == false)
        {
            if(isGameOver) return;
            Debug.Log("jatuh");
            isGrounded = true;
            setelahJatuh?.Invoke();
            boxSpawner.addScore(10);

        }
        if (isDropped && col.collider.CompareTag("tembok"))
        {
            isGameOver = true;
            Debug.Log("Game over.....");
            //spawnedImage = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
            boxSpawner.onoff.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

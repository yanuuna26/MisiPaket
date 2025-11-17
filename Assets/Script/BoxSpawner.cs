using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject boxPrefab;
    public GameObject currentBox;
    private Rigidbody2D rb; 
    public Vector3 spawnPoint;
    public float baseSpeed;
    public float currentSpeed;
    public bool isDropped;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnNewBox();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnNewBox()
    {
        isDropped = false;
        // Titik tengah atas (X=0.5, Y=1)
        Vector3 topCenter = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 10f));
        // Z harus diisi positive distance dari kamera agar terlihat → 10f biasanya cukup.
        currentBox = Instantiate(boxPrefab, topCenter, Quaternion.identity);
        rb = currentBox.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;   // Tidak jatuh dulu

        //UpdateSpeed(GameManager.Instance.skor);
    }

    void MoveHorizontal(){}

    void DetectInput(){}

    void DropBox(){}

    void UpdateSpeed(int score){}
}

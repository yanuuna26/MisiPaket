using System.Collections;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject boxPrefab;
    public GameObject currentBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnNewBox();
        // MoveHorizontal();
        //StartCoroutine(waktuSpawnBox());
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void SpawnNewBox()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.90f, 10f));

        currentBox = Instantiate(boxPrefab, pos, Quaternion.identity);

        // Reset status movement dan fisika box
        BoxMoveHorizontal bm = currentBox.GetComponent<BoxMoveHorizontal>();
        bm.isDropped = false;
        bm.isMoveRight = true;

        Rigidbody2D rb = currentBox.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        bm.setelahJatuh = () => SpawnNewBox();
    }


    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DropBox();
        }
    }

    void DropBox()
    {
        BoxMoveHorizontal bm = currentBox.GetComponent<BoxMoveHorizontal>();
        bm.isDropped = true;

        Rigidbody2D rb = currentBox.GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }

    void UpdateSpeed(int score) { }

}

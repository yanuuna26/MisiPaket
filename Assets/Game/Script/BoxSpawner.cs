using System.Collections;
using TMPro;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject boxPrefab;
    public GameObject currentBox;
    public GameObject onoff;
    public TMP_Text skorText;
    public TMP_Text highSkorText;
    public TMP_Text yourSkorText;
    


    public AudioSource suaraPaket;

    public float kecepatan = 0f;
    public int skor = 0, highSkor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnNewBox();
        // MoveHorizontal();
        //StartCoroutine(waktuSpawnBox());
        if (PlayerPrefs.HasKey("highskor"))
        {
            highSkor = PlayerPrefs.GetInt("highskor");
        }
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
        if (suaraPaket != null)
        {
            suaraPaket.Play();
        }

        // Reset status movement dan fisika box
        BoxMoveHorizontal bm = currentBox.GetComponent<BoxMoveHorizontal>();
        bm.isDropped = false;
        bm.isMoveRight = true;
        kecepatan += 1;
        bm.kecepatan = kecepatan;

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

    public void addScore(int score)
    {
        skor = skor + score;
        skorText.text = skor.ToString();
    }

    public void tampilSkor()
    {
        yourSkorText.gameObject.SetActive(true);
        yourSkorText.SetText("Your Score \n" + skor);
    }

    public void setHighSkor()
    {
        if (highSkor <= skor)
        {
            highSkor = skor;
            PlayerPrefs.SetInt("highskor", highSkor);
            PlayerPrefs.Save();
        }
        highSkorText.gameObject.SetActive(true);
        highSkorText.SetText("High Score \n" + highSkor);
    }

}

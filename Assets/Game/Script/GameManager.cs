using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject boxNow;
    public GameObject currentBox;
    public GameObject gameoverimg, highScoreImg, yourScoreImg;
    public GameObject RestartButton;
    public GameObject ExitButton;
    public TMP_Text skorText;
    public TMP_Text HiskorText;
    public TMP_Text yourScoreText;
    public AudioSource suaraPaket;    
    public AudioSource dropBoxSound;
    public AudioSource gameOverSound;

    public float kecepatan = 0f;
    public int highscore = 0;
    public int skor = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        SpawnNewBox();
        if(suaraPaket != null)
        {
            suaraPaket.Play();
        }
        //MoveHorizontal();
        //StartCoroutine(waktuSpawnBox());
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
            HiskorText.text = highscore.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
        
    }
    public void SimpanHighScore()
    {
        if  (skor > highscore)
        {
        highscore = skor;
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.Save();
        HiskorText.text = "High Score : " + highscore.ToString();
        }
        //PlayerPrefs.DeleteKey("highscore");
    }
    void SpawnNewBox()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.90f, 10f));

        currentBox = Instantiate(boxNow, pos, Quaternion.identity);
        

        // Reset status movement dan fisika box
        BoxPrefabs bm = currentBox.GetComponent<BoxPrefabs>();
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
        BoxPrefabs bm = currentBox.GetComponent<BoxPrefabs>();
        bm.isDropped = true;

        Rigidbody2D rb = currentBox.GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }

    public void addScore(int score)
    {   
        skor = skor + score;
        skorText.text = skor.ToString();
    }

    void UpdateSpeed(int score) { }

}

using UnityEngine;
using UnityEngine.UIElements;

public class BoxPrefabs : MonoBehaviour
{
    public float kecepatan = 1f;
    public bool isMoveRight = true;
    public bool isDropped = false;
    public bool isGrounded = false;
    public bool isGameOver = false;
    public System.Action setelahJatuh;
    public GameManager gameManager;
    //GameObject spritePrefab;
    //GameObject spawnedImage;
    //public GameObject onoff;

    void Start()
    {
        GameObject _gameManager = GameObject.FindGameObjectWithTag("boxGameOver");
        gameManager = _gameManager.GetComponent<GameManager>();
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
            gameManager.addScore(10);

        }
        if (isDropped && col.collider.CompareTag("tembok"))
        {
            isGameOver = true;
            Debug.Log("Game over.....");
            //spawnedImage = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
            gameManager.gameoverimg.SetActive(true);
            gameManager.highScoreImg.SetActive(true);
            gameManager.HiskorText.gameObject.SetActive(true);
            gameManager.yourScoreImg.gameObject.SetActive(true);
            gameManager.yourScoreText.gameObject.SetActive(true);
            gameManager.yourScoreText.text = gameManager.skor.ToString();
            gameManager.RestartButton.SetActive(true);
            gameManager.gameOverSound.Play();
            Time.timeScale = 0f;
        }
    }
}

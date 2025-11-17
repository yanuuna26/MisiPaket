//main menu
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     // Fungsi untuk tombol Start
    public void OnClickStart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Fungsi untuk tombol Credit
    public void OnClickCredit()
    {
        SceneManager.LoadScene("Credits");
    }

    // Fungsi untuk tombol Exit
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Keluar Aplikasi...");
    }

    public void exitCredit()
    {
        SceneManager.LoadScene("MainMenu");
    }   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

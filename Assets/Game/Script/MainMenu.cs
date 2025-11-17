using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject tombolMain;

    public void loadGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void loadCredit()
    {
        //SceneManager.LoadScene("GamePlay");
        Debug.Log("Load Credit");
    }
    
    public void loadExit()
    {
        //SceneManager.LoadScene("GamePlay");
        Debug.Log("Exit....");
    }

}

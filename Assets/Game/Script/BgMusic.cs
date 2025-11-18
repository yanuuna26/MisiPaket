using UnityEngine;

public class BgMusic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private static BgMusic instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance = null;
    public IGameApp GameApp;
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            GameApp = new GameApp();
            GameApp.StartApp();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

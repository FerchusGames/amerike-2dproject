using System;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }
    private IGameApp GameApp;
    
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

    private void OnApplicationQuit()
    {
        GameApp.Dispose();
    }
}

using System;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }
    private IGameApp _gameApp;
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _gameApp = new GameApp();
            _gameApp.StartApp().Forget();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        _gameApp.Dispose();
    }
}

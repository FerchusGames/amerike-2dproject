using System.Threading;
using Character.Controllers;
using Character.Models;
using Character.Views;
using DefaultNamespace;
using UnityEngine;

public class GameApp : IGameApp
{
    private CancellationTokenSource _gameTokenSource = new();

    public void StartApp()
    {
        ICharacterView characterView = GameObject.Find("CharacterBase").GetComponent<CharacterView>();
        ICharacterData characterData = new CharacterData();
        
        ICharacterBaseController characterBaseController =
            new CharacterBaseController(characterView, characterData, _gameTokenSource.Token);
    }

    public void Dispose()
    {
        _gameTokenSource?.Cancel();
        _gameTokenSource?.Dispose();
        _gameTokenSource = null;
    }
}

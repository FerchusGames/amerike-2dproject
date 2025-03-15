using System.Threading;
using Character.Controllers;
using Character.Models;
using Character.Views;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using Utilities.AddressableLoader;

public class GameApp : IGameApp
{
    private CancellationTokenSource _gameTokenSource = new();

    public async UniTaskVoid StartApp()
    {
        var characterView = 
            await AddressableLoader.InstantiateAsync<ICharacterView>("basePlayer");
        ICharacterData characterData = new CharacterDataDummy();
        
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

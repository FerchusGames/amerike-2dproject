using System.Threading;
using Character.Controllers;
using Character.Models;
using Character.Views;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using Utilities.AddressableLoader;
using Utilities.DataAPI;

struct CharacterDataByStyleName
{
    public string styleName;
}

public class GameApp : IGameApp
{
    private CancellationTokenSource _gameTokenSource = new();
    
    public async UniTaskVoid StartApp()
    {
        var characterView = await AddressableLoader.InstantiateAsync<ICharacterView>("basePlayer");

        var characterDataQueryByStyleName = @"query Query($styleName: String!) {
          CharacterDataByStyleName(styleName: $styleName) {
            jumpForce
            moveSpeed
            styleName
          }
        }";
        
        var characterDataByStyleNameVariables = new CharacterDataByStyleName()
        {
            styleName = "basePlayer"
        };

        var fullQueryCharacterData = new GraphQlQuery()
        {
            query = characterDataQueryByStyleName,
            variables = characterDataByStyleNameVariables
        };
        
        ICharacterData characterData = await GraphqlUtils.GetModel<CharacterData>(
            fullQueryCharacterData, 
            "Query", 
            "CharacterDataByStyleName",
            _gameTokenSource.Token);
        
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

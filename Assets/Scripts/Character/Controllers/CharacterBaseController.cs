using System.Threading;
using Character.Models;
using Character.Views;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Character.Controllers
{
    public class CharacterBaseController : ICharacterBaseController
    {
        private ICharacterView _characterView;
        private ICharacterData _characterData;
        private CancellationTokenRegistration _cancellationTokenRegistration;
        
        public CharacterBaseController(ICharacterView characterView, ICharacterData characterData, CancellationToken gameToken)
        {
            _characterView = characterView;
            _characterData = characterData;
            _cancellationTokenRegistration = gameToken.Register(Dispose);
            
            MovementCycleTask(gameToken).Forget();
        }

        {
            

        public void Dispose()
        {
            _cancellationTokenRegistration.Dispose();
        }
    }
}
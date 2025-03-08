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

        private async UniTaskVoid MovementCycleTask(CancellationToken gameToken)
        {
            var transform = _characterView.Transform;
            var moveSpeed = 3f;

            while (!gameToken.IsCancellationRequested)
            {
                var direction = _characterView.Direction;
                var horizontal = direction.x;

                var flipX = _characterView.IsSpriteFlipped;
                flipX = horizontal < 0 || horizontal == 0 && flipX; 
                _characterView.IsSpriteFlipped = flipX;
                _characterView.MoveState = Mathf.Abs((int) horizontal);
                    
                transform.Translate(Vector2.right * horizontal * Time.deltaTime);
                await UniTask.NextFrame();
            }
        }

        public void Dispose()
        {
            _cancellationTokenRegistration.Dispose();
        }
    }
}
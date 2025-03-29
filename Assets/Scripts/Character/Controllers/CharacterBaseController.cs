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
        
        private Rigidbody2D Rigidbody2D => _characterView.Rigidbody2D;
        private ForceMode2D JumpForceMode => ForceMode2D.Impulse;
        private Vector2 RunDirection => Vector2.right;
        private Vector2 JumpDirection => Vector2.up;
        private Transform Transform => _characterView.Transform;
        
        private float jumpForce;
        private float moveSpeed;
        
        public CharacterBaseController(ICharacterView characterView, ICharacterData characterData, CancellationToken gameToken)
        {
            _characterView = characterView;
            _characterData = characterData;
            _cancellationTokenRegistration = gameToken.Register(Dispose);
            
            _characterView.OnJumpButtonDown += Jump;
            
            jumpForce = characterData.JumpForce;
            moveSpeed = characterData.MoveSpeed;
            
            MovementCycleTask(gameToken).Forget();
        }

        public void Dispose()
        {
            _characterView.OnJumpButtonDown -= Jump;
            _cancellationTokenRegistration.Dispose();
        }
        
        private async UniTaskVoid MovementCycleTask(CancellationToken gameToken)
        {
            while (!gameToken.IsCancellationRequested)
            {
                var direction = _characterView.Direction;
                var horizontal = direction.x;

                var flipX = _characterView.IsSpriteFlipped;
                flipX = horizontal < 0 || horizontal == 0 && flipX; 
                _characterView.IsSpriteFlipped = flipX;
                _characterView.MoveState = Mathf.Abs((int) horizontal);
                    
                Transform.Translate(RunDirection * horizontal * moveSpeed * Time.deltaTime);
                await UniTask.NextFrame();
            }
        }

        private void Jump()
        {
            Rigidbody2D.AddForce(JumpDirection * jumpForce, JumpForceMode);
        }
    }
}
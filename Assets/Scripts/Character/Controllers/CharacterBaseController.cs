using Character.Models;
using Character.Views;

namespace Character.Controllers
{
    public class CharacterBaseController : ICharacterBaseController
    {
        private ICharacterView _characterView;
        private ICharacterData _characterData;
        
        public CharacterBaseController(ICharacterView characterView, ICharacterData characterData)
        {
            _characterView = characterView;
            _characterData = characterData;
        }

        public void StartCharacter()
        {
            
        }
    }
}
namespace Character.Models
{
    public class CharacterDataDummy : ICharacterData
    {
        public string StyleName => "basePlayer";
        public float MoveSpeed => 5f;
        public float JumpForce => 3f;
    }
}
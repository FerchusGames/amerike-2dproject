namespace Character.Models
{
    public interface ICharacterData
    {
        string StyleName { get; }
        float MoveSpeed { get; }
        float JumpForce { get; }
    }
}
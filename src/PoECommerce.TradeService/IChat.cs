namespace PoECommerce.PathOfExile
{
    public interface IChat
    {
        void Write(string command);

        void DoNotDisturb(string message);
        void AwayFromKeyboard(string message);

        void KickFromParty(string characterName);
        void InviteToParty(string characterName);
        void Ignore(string characterName);

        void OpenPrivateMessage(string characterName);
        void WritePrivateMessage(string characterName, string text);
    }
}

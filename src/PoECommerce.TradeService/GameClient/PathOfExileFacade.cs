using System;
using System.Threading.Tasks;
using PoECommerce.PathOfExile.GameClient.Abstractions;
using PoECommerce.PathOfExile.Models.Trade.Items;

namespace PoECommerce.PathOfExile.GameClient
{
    internal class PathOfExileFacade : IPathOfExileFacade
    {
        private readonly IPathOfExileInput _pathOfExileInput;
        private readonly IPathOfExileProcessHook _pathOfExileProcessHook;
        private readonly Func<Task<string>> _copyFromClipboard;
        public IChat Chat { get; }

        public PathOfExileFacade(IChat chat, IPathOfExileInput pathOfExileInput, IPathOfExileProcessHook pathOfExileProcessHook, Func<Task<string>> copyFromClipboard)
        {
            _pathOfExileInput = pathOfExileInput;
            _pathOfExileProcessHook = pathOfExileProcessHook;
            _copyFromClipboard = copyFromClipboard;
            Chat = chat;
        }

        public async Task<Item> GetItemOnCursor()
        {
            if (!_pathOfExileProcessHook.IsLaunched())
            {
                return null;
            }

            if (!_pathOfExileProcessHook.FocusGameWindow())
            {
                return null;
            }

            _pathOfExileInput.CopyItemToClipboard();

            try
            {

                string itemText = await _copyFromClipboard();

                if (string.IsNullOrEmpty(itemText))
                {
                    return null;
                }

                string[] lines = itemText.Split(Environment.NewLine);

                if (lines.Length <= 1)
                {
                    return null;
                }

                if (!lines[0].StartsWith("Rarity:"))
                {
                    return null;
                }

                Item item = new Item();

                if (lines[0].EndsWith("Unique"))
                {
                    item.Name = lines[1];
                    item.TypeName = lines[2];
                }
                else
                {
                    return null;
                }

                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
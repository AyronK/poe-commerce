using System;
using PoECommerce.PathOfExile.GameClient.Abstractions;
using PoECommerce.PathOfExile.Models.Trade.Items;

namespace PoECommerce.PathOfExile.GameClient
{
    internal class PathOfExileFacade : IPathOfExileFacade
    {
        private readonly IPathOfExileInput _pathOfExileInput;
        private readonly Func<string> _copyFromClipboard;
        public IChat Chat { get; }

        public PathOfExileFacade(IChat chat, IPathOfExileInput pathOfExileInput, Func<string> copyFromClipboard)
        {
            _pathOfExileInput = pathOfExileInput;
            _copyFromClipboard = copyFromClipboard;
            Chat = chat;
        }

        public Item GetItemOnCursor()
        {
            _pathOfExileInput.CopyItemToClipboard();
            try
            {

                string itemText = _copyFromClipboard();

                if (string.IsNullOrEmpty(itemText))
                {
                    return null;
                }

                string[] lines = itemText.Split('\n');

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
using System.Text;

namespace PoECommerce.Core.Model.Data
{
    public class Item
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public bool IsProphecy { get; set; }

        public ItemCategory ItemCategory { get; set; }

        public bool IsUnique { get; set; }

        /// <summary>
        ///     E.g. map origins (atlasofworlds, theawakening).
        /// </summary>
        public string Disclaimer { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Name != null)
            {
                sb.Append(Name).Append(" ");
            }

            sb.Append(Type);

            if (Disclaimer != null)
            {
                sb.Append(" ").Append("(").Append(Disclaimer).Append(")");
            }

            return sb.ToString();
        }
    }

    public enum ItemCategory
    {
        Accessory,
        Armour,
        DivinationCard,
        Currency,
        Flask,
        Gem,
        Jewel,
        NormalMap,
        ShapedMap,
        ElderMap,
        BlightedMap,
        Weapon,
        Leaguestone,
        Prophecy,
        CapturedBeast,
        Fragment,
        Oil,
        Incubator,
        Scarab,
        Resonator,
        Fossil,
        Vial,
        Net,
        Essence,
        Misc
    }
}
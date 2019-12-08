namespace PoECommerce.Core.Model.Search
{
    public class MiscellaneousFilter
    {
        public FilterMagnitude Quality { get; set; } = new FilterMagnitude();
        public FilterMagnitude GemLevel { get; set; } = new FilterMagnitude();
        public FilterMagnitude ItemLevel { get; set; } = new FilterMagnitude();
        public FilterMagnitude GemLevelProgress { get; set; } = new FilterMagnitude();
        public bool? Shaper { get; set; }
        public bool? Fractured { get; set; }
        public bool? AlternateArt { get; set; }
        public bool? Corrupted { get; set; }
        public bool? Crafted { get; set; }
        public bool? Enchanted { get; set; }
        public bool? Elder { get; set; }
        public bool? Synthesised { get; set; }
        public bool? Identified { get; set; }
        public bool? Mirrored { get; set; }
        public bool? Veiled { get; set; }
        public FilterMagnitude TalismanTier { get; set; } = new FilterMagnitude();
    }
}
using System;
using Microsoft.AspNetCore.Components;
using PoECommerce.Core.Model.Search;

namespace PoECommerce.Client.Components.Trade.Filters
{
    public class MiscellaneousFilterContainerBase : ComponentBase
    {
        [Parameter]
        public MiscellaneousFilter Filter { get; set; }

        public FilterMagnitude Quality
        {
            get => Filter.Quality;
            set
            {
                Filter.Quality = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude GemLevel
        {
            get => Filter.GemLevel;
            set
            {
                Filter.GemLevel = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude ItemLevel
        {
            get => Filter.ItemLevel;
            set
            {
                Filter.ItemLevel = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude GemLevelProgress
        {
            get => Filter.GemLevelProgress;
            set
            {
                Filter.GemLevelProgress = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string ShaperValue
        {
            get => Shaper.ToString();
            set => Shaper = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Shaper
        {
            get => Filter.Shaper;
            set
            {
                Filter.Shaper = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string FracturedValue
        {
            get => Fractured.ToString();
            set => Fractured = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Fractured
        {
            get => Filter.Fractured;
            set
            {
                Filter.Fractured = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string AlternateArtValue
        {
            get => AlternateArt.ToString();
            set => AlternateArt = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? AlternateArt
        {
            get => Filter.AlternateArt;
            set
            {
                Filter.AlternateArt = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string CorruptedValue
        {
            get => Corrupted.ToString();
            set => Corrupted = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Corrupted
        {
            get => Filter.Corrupted;
            set
            {
                Filter.Corrupted = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string CraftedValue
        {
            get => Crafted.ToString();
            set => Crafted = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Crafted
        {
            get => Filter.Crafted;
            set
            {
                Filter.Crafted = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string EnchantedValue
        {
            get => Enchanted.ToString();
            set => Enchanted = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Enchanted
        {
            get => Filter.Enchanted;
            set
            {
                Filter.Enchanted = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string ElderValue
        {
            get => Elder.ToString();
            set => Elder = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Elder
        {
            get => Filter.Elder;
            set
            {
                Filter.Elder = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string SynthesisedValue
        {
            get => Synthesised.ToString();
            set => Synthesised = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Synthesised
        {
            get => Filter.Synthesised;
            set
            {
                Filter.Synthesised = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string IdentifiedValue
        {
            get => Identified.ToString();
            set => Identified = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Identified
        {
            get => Filter.Identified;
            set
            {
                Filter.Identified = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string MirroredValue
        {
            get => Mirrored.ToString();
            set => Mirrored = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Mirrored
        {
            get => Filter.Mirrored;
            set
            {
                Filter.Mirrored = value;
                OnChange?.Invoke(Filter);
            }
        }

        public string VeiledValue
        {
            get => Veiled.ToString();
            set => Veiled = bool.TryParse(value, out bool boolValue) ? boolValue : (bool?)null;
        }

        public bool? Veiled
        {
            get => Filter.Veiled;
            set
            {
                Filter.Veiled = value;
                OnChange?.Invoke(Filter);
            }
        }

        public FilterMagnitude TalismanTier
        {
            get => Filter.TalismanTier;
            set
            {
                Filter.TalismanTier = value;
                OnChange?.Invoke(Filter);
            }
        }

        [Parameter]
        public Action<MiscellaneousFilter> OnChange { get; set; }
    }
}
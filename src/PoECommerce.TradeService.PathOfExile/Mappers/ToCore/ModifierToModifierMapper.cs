using System;
using PoECommerce.Core;
using PoECommerce.PathOfExile.Models.Data;
using PoECommerce.PathOfExile.Models.Enums;

namespace PoECommerce.TradeService.PathOfExile.Mappers.ToCore
{
    internal class ModifierToModifierMapper : IModelMapper<Modifier, Core.Model.Data.Modifier>, IModelMapper<ModifierType, Core.Model.Data.ModifierType>
    {
        public Core.Model.Data.Modifier Map(Modifier mapOperand)
        {
            return new Core.Model.Data.Modifier
            {
                Id = mapOperand.Id,
                Text = mapOperand.Text,
                Type = Map(mapOperand.Type)
            };
        }

        public Core.Model.Data.ModifierType Map(ModifierType mapOperand)
        {
            switch (mapOperand)
            {
                case ModifierType.Implicit:
                    return Core.Model.Data.ModifierType.Implicit;
                case ModifierType.Explicit:
                    return Core.Model.Data.ModifierType.Explicit;
                case ModifierType.Crafted:
                    return Core.Model.Data.ModifierType.Crafted;
                case ModifierType.Fractured:
                    return Core.Model.Data.ModifierType.Fractured;
                case ModifierType.Veiled:
                    return Core.Model.Data.ModifierType.Veiled;
                case ModifierType.Monster:
                    return Core.Model.Data.ModifierType.Monster;
                case ModifierType.Enchant:
                    return Core.Model.Data.ModifierType.Enchant;
                case ModifierType.Delve:
                    return Core.Model.Data.ModifierType.Delve;
                case ModifierType.Pseudo:
                    return Core.Model.Data.ModifierType.Pseudo;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mapOperand), mapOperand, null);
            }
        }
    }
}
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
    public class FearEmitter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FEAR Emitter");
            Tooltip.SetDefault("Restricts non-boss enemies from going through certain region");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Излучатель страха");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Не позволяет враждебным НПС - не-боссам пересечь зону страха");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "恐惧发射源");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "限制非boss敌人经过这片区域");
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 7;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.FearEmitter>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            	.AddIngredient(ItemID.MechanicalBatteryPiece)
            	.AddIngredient(ItemID.SoulofFright, 15)
				.AddIngredient(ItemID.Wire, 150)
            	.AddTile(TileID.MythrilAnvil)
            	.Register();
        }
    }
}

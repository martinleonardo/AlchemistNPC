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
    public class MolecularReplicator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molecular Replicator");
            Tooltip.SetDefault("Restores life of nearby friendly NPCs while placed");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Молекулярный Репликатор");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Восстанавливает жизни дружественных НПС когда установлен");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "分子复制器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置时回复附近友善NPC的生命");
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
			Item.createTile = TileType<Tiles.MolecularReplicator>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            	.AddIngredient(ItemID.MechanicalWheelPiece)
				.AddIngredient(ItemID.MechanicalWagonPiece)
            	.AddIngredient(ItemID.MechanicalBatteryPiece)
            	.AddIngredient(ItemID.MartianConduitPlating, 50)
				.AddIngredient(ItemID.Wire, 100)
            	.AddIngredient(ItemID.ShinyStone)
            	.AddTile(TileID.MythrilAnvil)
            	.Register();
        }
    }
}

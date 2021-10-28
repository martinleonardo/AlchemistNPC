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
    public class ImmortalityFieldProjector : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Immortality Field Projector");
            Tooltip.SetDefault("Makes town NPCs instantly respawn after being killed"
			+"\nMight need to take some time to enable the field");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Излучатель Поля Бессмертия");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мгновенно возрождает убитых городских НПС\nМожет требовать некоторого времени для активации поля");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "稳恒场源投影仪");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "城镇NPC死亡时立即重生\n启用场地可能需要一些时间");
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
			Item.createTile = TileType<Tiles.ImmortalityFieldProjector>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            	.AddIngredient(ItemID.MechanicalBatteryPiece)
            	.AddIngredient(ItemID.LunarBar, 16)
				.AddIngredient(ItemID.Wire, 200)
				.AddIngredient(ModContent.ItemType<Items.Materials.ChromaticCrystal>(), 5)
				.AddIngredient(ModContent.ItemType<Items.Materials.SunkroveraCrystal>(), 5)
				.AddIngredient(ModContent.ItemType<Items.Materials.NyctosythiaCrystal>(), 5)
            	.AddTile(TileID.LunarCraftingStation)
            	.Register();
        }
    }
}

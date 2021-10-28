using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Equippable
{
	public class Barrage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armor's module ''Barrage''");
			Tooltip.SetDefault("Follows any attack with some energy shots"
			+"\nDeals 1/4 of current weapon's damage"
			+"\nDoes not require any ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Броневой модуль ''Шквал''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сопровождает любую атаку кратким залпом энегетическими снарядами\nНаносит 1/4 от урона оружия в руках\nНе требует боеприпасов");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "护甲模块 “弹幕网”");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "任何攻击后附着能量弹\n产生当前武器1/4的伤害\n无需消耗任何弹药");
		}
	
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 10;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().Barrage = true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("AlchemistNPC:Tier3Bar", 15)
				.AddIngredient(ModContent.ItemType<Items.Materials.DivineLava>(), 99)
				.AddIngredient(2882)
				.AddIngredient(ItemID.Nanites, 99)
				.AddTile(TileType<Tiles.MateriaTransmutator>())
				.Register();
		}
	}
}
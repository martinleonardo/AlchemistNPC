using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class TerrarianA : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Terrarian-A (V-05-516)");
			Tooltip.SetDefault("''Angela's actions have rewrote the understandings of souls themselves''\n[c/FF0000:EGO Gift]\nIncreases invincility after taking damage\nBlocks 33% of contact damage at daytime\nBlocks 33% of projectile damage at night");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Terrarian-A (V-05-516)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Действия Анджелы переписали само понимание душ''\n[c/FF0000:Э.П.О.С. Дар]\nУвеличивает период неуязвимости после получения урона\nПоглощает 33% контактного урона в дневное вермя\nПоглощает 33% урона от снарядов ночью");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Terrarian-A (V-05-516)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''Angela的行为改写了对灵魂本身的理解''\n[c/FF0000:EGO 礼物]\n增加受伤无敌帧\n白天时阻挡33%接触伤害\n夜晚时阻挡33%抛射物伤害");
        }
	
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 8;
			Item.accessory = true;
			Item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).TerrarianBlock = true;
			player.longInvince = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CrossNecklace, 1)
				.AddIngredient(ItemID.SoulofLight, 30)
				.AddIngredient(ItemID.SoulofNight, 30)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
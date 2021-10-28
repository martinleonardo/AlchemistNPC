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
	public class MasterYoyoBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Master Yoyo Bag");
			Tooltip.SetDefault("Increases melee damage and melee speed by 15%"
			+"\nGives effects of Fire Gauntlet, Yoyo Glove and Counterweight"
			+"\nGreatly increases max range of any yoyo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Мастера Йо-йо");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает урон и скорость атаки в ближнем бою на 15%\nДаёт эффекты Огненной Рукавицы, Перчатки Йо-йо и Противовеса\nЗначительно увеличивает максимальную дальность любого йо-йо");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "大师悠悠包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加15%近战伤害和近战速度\n获得火焰拳套，悠悠手套和配重球地效果\n极大提升悠悠球最大范围");
		}
	
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 100000;
			Item.rare = 8;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().MasterYoyoBag = true;
			player.counterWeight = 556 + Main.rand.Next(6);
			player.yoyoGlove = true;
			player.yoyoString = true;
            player.GetDamage(DamageClass.Melee) += 0.15f;
			if (player.HeldItem.channel) player.meleeSpeed += 1.15f;
			else player.meleeSpeed += 0.15f;
			player.kbGlove = true;
			player.magmaStone = true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.YoyoBag)
				.AddIngredient(ItemID.FireGauntlet)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
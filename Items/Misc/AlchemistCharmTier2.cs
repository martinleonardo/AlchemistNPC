using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class AlchemistCharmTier2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 2");
			Tooltip.SetDefault("While this is in your inventory, you have a moderate chance not to consume potion"
			+"\nAllows to use potions from Piggy Bank by Quick Buff"
			+"\nAlchemist, Brewer and Young Brewer are providing 25% discount"
			+"\nBuffs duration is 25% longer");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Алхимика Второго Уровня");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеет средний шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 25%\nДлительность баффов увеличена на 25%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炼金师符咒 T-2");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置物品栏中时, 概率不消耗药剂"
			+"\n'快速增益'键能够使用猪猪储蓄罐中的药剂"
			+"\n炼金师, 药剂师和年轻药剂师提供25%折扣"
			+"\nBuff持续时间增加25%");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 2000000;
			Item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AlchemistCharmTier2 = true;
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DistantPotionsUse = true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "AlchemistCharmTier1")
				.AddRecipeGroup("AlchemistNPC:EvilBar", 15)
				.AddRecipeGroup("AlchemistNPC:EvilComponent", 20)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}

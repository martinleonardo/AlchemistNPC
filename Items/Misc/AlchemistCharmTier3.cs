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
	public class AlchemistCharmTier3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 3");
			Tooltip.SetDefault("While this is in your inventory, you have a high chance not to consume potion"
			+"\nAllows to use potions from Piggy Bank by Quick Buff"
			+"\nAlchemist, Brewer and Young Brewer are providing 35% discount"
			+"\nBuffs duration is 35% longer");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Алхимика Третьего Уровня");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеет большой шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 35%\nДлительность баффов увеличена на 35%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炼金师符咒 T-3");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置物品栏中时, 大概率不消耗药剂"
			+"\n'快速增益'键能够使用猪猪储蓄罐中的药剂"
			+"\n炼金师, 药剂师和年轻药剂师提供35%折扣"
			+"\nBuff持续时间增加35%");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 3000000;
			Item.rare = 7;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AlchemistCharmTier3 = true;
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DistantPotionsUse = true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "AlchemistCharmTier2")
				.AddRecipeGroup("AlchemistNPC:Tier3Bar", 10)
				.AddRecipeGroup("AlchemistNPC:HardmodeComponent", 20)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}

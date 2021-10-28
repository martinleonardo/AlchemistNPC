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
	public class AlchemistCharmTier1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 1");
			Tooltip.SetDefault("While this is in your inventory, you have a low chance not to consume potion"
			+"\nAlchemist, Brewer and Young Brewer are providing 10% discount"
			+"\nBuffs duration is 10% longer");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Алхимика Первого Уровня");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеет малый шанс не потратить зелье\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 10%\nДлительность баффов увеличена на 10%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炼金师符咒 T-1");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置物品栏中时, 小概率不消耗药剂"
			+"\n炼金师, 药剂师和年轻药剂师提供10%折扣"
			+"\nBuff持续时间增加10%");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 0;
			Item.rare = 3;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AlchemistCharmTier1 = true;
		}
	}
}

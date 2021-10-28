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
	public class ScreamingHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Screaming Head");
			Tooltip.SetDefault("Someone's screaming head\nBreaks concentration");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кричащая голова");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чья-то кричащая голова\nНарушает концентрацию");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "尖啸之颅");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "某人的尖叫的脑袋\n使你精神不集中");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 0;
			Item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
			player.silence = true;
		}
	}
}

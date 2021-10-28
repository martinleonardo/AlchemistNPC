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
	public class BoomBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boom Box");
			Tooltip.SetDefault("While this is in your inventory, your last inventory slot plays music boxes passively");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бумбокс");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, ваш последний слот инвентаря позволяет пассивно играть музыкальным шкатулкам");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Boom音乐盒");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放在你的背包里时，你的最后一个背包栏可以播放音乐盒");
    }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 250000;
			Item.rare = 4;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).BoomBox = true;
		}
	}
}

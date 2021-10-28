using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class BrainOfCthulhuBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain of Cthulhu booster");
			Tooltip.SetDefault("Increases max amount of minions by 1, Heartreach effect");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Мозга Ктулху");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает максимальной количество прислужников на 1, сердца притягиваются к игроку");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之脑增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加1召唤物上限，获得心之彼端效果");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}

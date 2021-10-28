using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class GolemBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem booster");
			Tooltip.SetDefault("Increases attack speed by 10% and increases melee knockback");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Голема");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает скорсть атаки на 10% и усиливает отбрасывание в ближнем бою");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "石巨人增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加10%攻击速度，提升近战击退力");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool CanUseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().GolemBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().GolemBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().GolemBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().GolemBooster = 0;
				return true;
			}
			return false;
		}
	}
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	class Fuaran : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fuaran");
			Tooltip.SetDefault("Permanently increases maximum mana by 100. Can only be used once.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Фуаран");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает максимальную ману на 100. Может быть использован только 1 раз.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔泉书");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "永久增加100法力上限. 只能使用一次.");

        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.value = 5000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statManaMax >= 200 && player.GetModPlayer<AlchemistNPCPlayer>().Fuaran < 1;
		}

		public override bool? UseItem(Player player)
		{
			player.statManaMax2 += 100;
			player.statMana += 100;
			player.GetModPlayer<AlchemistNPCPlayer>().Fuaran += 1;
			return true;
		}
	}
}

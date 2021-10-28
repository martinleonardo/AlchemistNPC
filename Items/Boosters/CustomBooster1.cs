using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class CustomBooster1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Custom Booster 1");
			Tooltip.SetDefault("Gives Shine and Nightvision effects");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выборочный усилитель 1");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт эффекты Свечения и Ночного Зрения");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "普通增益容器1号");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "给予发光和夜视效果");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 = 0;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.Boosters.BrokenBooster1>(), 1)
				.AddIngredient(ItemID.ShinePotion, 30)
				.AddIngredient(ItemID.NightOwlPotion, 30)
				.AddRecipeGroup("IronBar", 10)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}

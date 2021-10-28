using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class MGB : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("17mm Round");
			Tooltip.SetDefault("Requred to shoot from ''Meat Grinder''");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "17mm патрон");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Необходим для стрельбы из ''Мясорубки''");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "17mm 子弹");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''绞肉机'' 射击所需");
        }

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 22;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = 11;
			Item.shoot = 638;
			Item.ammo = Item.type;
		}
	}
}

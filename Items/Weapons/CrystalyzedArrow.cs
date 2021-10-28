using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CrystalyzedArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Explodes to shards on hit.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кристальные стрелы");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Разрываются на осколки при попадании");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "晶尘箭");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "爆炸变成致命碎片.");
        }

		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 18;
			Item.height = 38;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10;
			Item.rare = 2;
			Item.shoot = ProjectileType<Projectiles.CrystalyzedArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 16f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe(150)
				.AddIngredient(ItemID.WoodenArrow, 150)
				.AddIngredient(null, "CrystalDust", 3)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}

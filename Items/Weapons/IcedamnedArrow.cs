using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class IcedamnedArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The unusual usage of cursed materials.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Стрела Проклятого Льда");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Необычное использование Проклятого Материала");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "冰咒箭");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "被诅咒材料的独特用法");
        }

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10;
			Item.rare = 2;
			Item.shoot = ProjectileType<Projectiles.IcedamnedArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 16f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe(150)
				.AddIngredient(ItemID.WoodenArrow, 150)
				.AddIngredient(null, "CursedIce", 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}

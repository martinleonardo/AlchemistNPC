using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class SeepingArrowInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seeping Arrow");
			Tooltip.SetDefault("The unusual usage of cursed materials\nInfinite");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Проникающая стрела");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Необычное использование Проклятого Материала\nБесконечна");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炽焚箭 (无限)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "被诅咒材料的独特用法\n无限");
        }

		public override void SetDefaults()
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 1;
			Item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10;
			Item.rare = 2;
			Item.shoot = ProjectileType<Projectiles.SeepingArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 16f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "SeepingArrow", 3996)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}

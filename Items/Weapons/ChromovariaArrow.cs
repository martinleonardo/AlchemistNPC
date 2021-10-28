using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ChromovariaArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The worthy usage of Hallowed material"
			+"\nReleases heavy damaging light beams and inflicts Daybroken debuff");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хромоварийная стрела");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Достойное применение Святого материала\nВыпускает наносящие значительный урон лучи света и накладывает мощный дебафф");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炫彩箭");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神圣材料的合理使用\n释放出粗大的破坏光束并给予破晓Debuff");
        }

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10;
			Item.rare = 10;
			Item.shoot = ProjectileType<Projectiles.ChromovariaArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 12f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe(150)
				.AddIngredient(null, "CrystalyzedArrow", 150)
				.AddIngredient(null, "ChromaticCrystal", 1)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}

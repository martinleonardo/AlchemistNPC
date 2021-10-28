using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class NyctosythiaArrowInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Arrow");
			Tooltip.SetDefault("These arrows consume any form of light."
			+"\nPhases through walls, releases homing projectiles on enemy/wall impact"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Никтосифиевая стрела");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эти стрелы поглощают любой свет.\nПроходят сквозь стены, выпускают самонаводящиеся снаряды при попадании в противника/cтену\nБесконечна");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "夜蛾箭");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这些箭消耗任意形式的光\n可穿墙, 第一次撞击墙壁或敌人后释放追踪敌人的子弹\n无限");
        }

		public override void SetDefaults()
		{
			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 1;
			Item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = 10;
			Item.shoot = ProjectileType<Projectiles.NyctosythiaArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 12f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "NyctosythiaArrow", 3996)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}

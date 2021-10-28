using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CrystalDustBulletInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Dust Bullet");
			Tooltip.SetDefault("Explodes into even deadlier shards"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пули с кристальной пылью");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Разрываются на ещё более смертоносные осколки при попадании\nБесконечная");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "晶尘弹 (无限)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "爆炸变成致命碎片\n无限");
        }    
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = 8;
			Item.shoot = ProjectileType<Projectiles.CrystalDust>();
			Item.shootSpeed = 16f; 
			Item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.Weapons.CrystalDustBullet>(), 3996)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}

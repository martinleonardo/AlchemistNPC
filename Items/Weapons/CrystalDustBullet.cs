using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CrystalDustBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Dust Bullet");
			Tooltip.SetDefault("Explodes into even deadlier shards");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пули с кристальной пылью");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Разрываются на ещё более смертоносные осколки при попадании");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "晶尘弹");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "爆炸变成致命碎片");
        }    
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = 8;
			Item.shoot = ProjectileType<Projectiles.CrystalDust>();
			Item.shootSpeed = 16f; 
			Item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(ItemID.CrystalBullet, 100)
				.AddIngredient(null, "CrystalDust", 2)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}

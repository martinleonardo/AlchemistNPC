using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class SunkroveraBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunkrovera Bullet");
			Tooltip.SetDefault("Its glow makes you chill."
			+"\nReleases life stealing projectiles on enemy/wall impact");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кровавые пули");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Её сияние вызывает у вас дрожь.\nВыпускает похищающие жизнь снаряды при попадании во врага/стену");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "森克罗维拉弹");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "即便是带着它你也能感受到那份...压力\n击中墙壁或敌人后释放可以汲取生命的子弹");
        }    
		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = 10;
			Item.shoot = ProjectileType<Projectiles.SunkroveraBullet>();
			Item.shootSpeed = 16f; 
			Item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(ItemID.MoonlordBullet, 100)
				.AddIngredient(null, "SunkroveraCrystal", 1)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}

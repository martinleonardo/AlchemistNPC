using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class NyctosythiaBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Bullet");
			Tooltip.SetDefault("Don't keep them close."
			+"\nPhases through walls, releases homing projectiles on enemy/wall impact");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Никтосифиевая пуля");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чем дальше держать их от себя, тем лучше.\nПроходят сквозь стены, выпускают самонаводящиеся снаряды при попадании в противника/cтену");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "夜蛾弹");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "最好尽可能快的抓住它\n可穿墙, 第一次撞击墙壁或敌人后释放追踪敌人的子弹");
        }    
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = 10;
			Item.shoot = ProjectileType<Projectiles.NyctosythiaBullet>();
			Item.shootSpeed = 16f; 
			Item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(ItemID.MoonlordBullet, 100)
				.AddIngredient(null, "NyctosythiaCrystal", 1)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}

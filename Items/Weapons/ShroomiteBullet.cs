using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ShroomiteBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enhanced Shroomite Bullet");
			Tooltip.SetDefault("Releases electric cloud, which shoots electric beams to enemies"
			+"\nSpeeds up over time");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Улучшенная Грибная Пуля");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выпускает электрическое облако, стреляющее электическими лучами\nСо временем ускоряется");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "强化型菱形弹");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "释放出电云, 电云会向敌人发射电束\n越飞越快");
        }    
		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = 11;
			Item.shoot = ProjectileType<Projectiles.ShroomiteBullet>();
			Item.shootSpeed = 24f; 
			Item.ammo = AmmoID.Bullet; //
		}	
		
		public override void AddRecipes()
		{
			CreateRecipe(333)
				.AddIngredient(ItemID.ShroomiteBar, 3)
				.AddIngredient(ItemID.MartianConduitPlating, 3)
				.AddIngredient(ItemID.MoonlordBullet, 333)
				.AddIngredient(null, "ChromaticCrystal", 1)
				.AddIngredient(null, "NyctosythiaCrystal", 1)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ShroomiteBulletInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enhanced Shroomite Bullet");
			Tooltip.SetDefault("Releases electric cloud, which shoots electric beams to enemies"
			+"\nSpeeds up over time"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Улучшенная Грибная Пуля");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выпускает электрическое облако, стреляющее электическими лучами\nСо временем ускоряется\nБесконечна");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "强化型菱形弹 (无限)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "释放出电云, 电云会向敌人发射电束\n越飞越快\n无限");
        }    
		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = 11;
			Item.shoot = ProjectileType<Projectiles.ShroomiteBullet>();
			Item.shootSpeed = 24f; 
			Item.ammo = AmmoID.Bullet; //
		}	
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "ShroomiteBullet", 3996)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}

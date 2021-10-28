using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ShroomiteArrowInfinite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enhanced Shroomite Arrow");
			Tooltip.SetDefault("Releases electric cloud, which shoots electric beams to enemies"
			+"\nSpeeds up over time"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Улучшенная Грибная стрела");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выпускает электрическое облако, стреляющее электическими лучами\nСо временем ускоряется\nБесконечна");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "强化型菱形箭 (无限)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "释放出电云, 电云会向敌人发射电束\n越飞越快\n无限");
        }

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 1;
			Item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = 11;
			Item.shoot = ProjectileType<Projectiles.ShroomiteArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 12f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "ShroomiteArrow", 3996)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}

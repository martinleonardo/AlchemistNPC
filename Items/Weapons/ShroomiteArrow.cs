using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ShroomiteArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enhanced Shroomite Arrow");
			Tooltip.SetDefault("Releases electric cloud, which shoots electric beams to enemies"
			+"\nSpeeds up over time");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Улучшенная Грибная стрела");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выпускает электрическое облако, стреляющее электическими лучами\nСо временем ускоряется");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "强化型菱形箭");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "释放出电云, 电云会向敌人发射电束\n越飞越快");
        }

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = 11;
			Item.shoot = ProjectileType<Projectiles.ShroomiteArrow>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 12f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}
		
		public override void AddRecipes()
		{
			CreateRecipe(333)
				.AddIngredient(ItemID.ShroomiteBar, 3)
				.AddIngredient(ItemID.MartianConduitPlating, 3)
				.AddIngredient(ItemID.MoonlordArrow, 333)
				.AddIngredient(null, "ChromaticCrystal", 1)
				.AddIngredient(null, "NyctosythiaCrystal", 1)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}

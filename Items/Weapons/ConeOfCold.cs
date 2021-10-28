using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class ConeOfCold : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cone of Cold");
			Tooltip.SetDefault("Magic spell which releases cone of arctic cold"
			+"\nMay slowdown or freeze normal enemies in place");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Конус Холода");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магическое заклинание, испускающие конус арктического холода\nМожет замедлить или заморозить обычных противников");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "冰锥术");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "释放极寒冰锥的魔咒"
			+"\n概率缓慢或冻结普通敌人");
        }

		public override void SetDefaults()
		{
			Item.damage = 23;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.rare = 5;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 12;
			Item.UseSound = SoundID.Item20;
			Item.useStyle = 5;
			Item.shootSpeed = 12f;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.autoReuse = true;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.shoot = ProjectileType<Projectiles.ConeOfColdProjectile>();
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed3 = velocity.RotatedByRandom(MathHelper.ToRadians(10));
			Vector2 perturbedSpeed4 = velocity.RotatedByRandom(MathHelper.ToRadians(15));
			Vector2 perturbedSpeed5 = velocity.RotatedByRandom(MathHelper.ToRadians(15));
			Vector2 perturbedSpeed6 = velocity.RotatedByRandom(MathHelper.ToRadians(20));
			Vector2 perturbedSpeed7 = velocity.RotatedByRandom(MathHelper.ToRadians(20));
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float speedX = perturbedSpeed.X;
			float speedY = perturbedSpeed.Y;
			float speedX2 = perturbedSpeed2.X;
			float speedY2 = perturbedSpeed2.Y;
			float speedX3 = perturbedSpeed3.X;
			float speedY3 = perturbedSpeed3.Y;
			float speedX4 = perturbedSpeed4.X;
			float speedY4 = perturbedSpeed4.Y;
			float speedX5 = perturbedSpeed5.X;
			float speedY5 = perturbedSpeed5.Y;
			float speedX6 = perturbedSpeed6.X;
			float speedY6 = perturbedSpeed6.Y;
			float speedX7 = perturbedSpeed7.X;
			float speedY7 = perturbedSpeed7.Y;
			Projectile.NewProjectile(source, vector.X, vector.Y+4, speedX2, speedY2, ProjectileType<Projectiles.ConeOfColdProjectile>(), damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, vector.X, vector.Y, speedX, speedY, ProjectileType<Projectiles.ConeOfColdProjectile>(), damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, vector.X, vector.Y-4, speedX3, speedY3, ProjectileType<Projectiles.ConeOfColdProjectile>(), damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, vector.X, vector.Y-8, speedX4, speedY4, ProjectileType<Projectiles.ConeOfColdProjectile>(), damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, vector.X, vector.Y+8, speedX5, speedY5, ProjectileType<Projectiles.ConeOfColdProjectile>(), damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, vector.X, vector.Y-12, speedX6, speedY6, ProjectileType<Projectiles.ConeOfColdProjectile>(), damage, knockback, player.whoAmI);
			Projectile.NewProjectile(source, vector.X, vector.Y+12, speedX7, speedY7, ProjectileType<Projectiles.ConeOfColdProjectile>(), damage, knockback, player.whoAmI);
			return true;
		}
		
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SpellTome)
				.AddIngredient(ItemID.FrostCore)
				.AddIngredient(ItemID.SoulofLight, 10)
				.AddIngredient(ItemID.SoulofNight, 10)
				.AddIngredient(ItemID.IceBlock, 50)
				.AddIngredient(ItemID.SnowBlock, 50)
				.AddTile(TileID.Bookcases)
				.Register();
		}
	}
}

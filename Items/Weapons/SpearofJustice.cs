using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class SpearofJustice : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 175;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ProjectileType<Projectiles.SpearofJustice>();
			Item.shootSpeed = 32f;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2 && player.statMana < 200)
			{
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.damage = 175;
				Item.shootSpeed = 32f;
				Item.shoot = ProjectileType<Projectiles.SpearofJustice>();
			}
			if (player.altFunctionUse == 2 && player.statMana > 200)
			{
				Item.useTime = 90;
				Item.useAnimation = 90;
				Item.damage = 200;
				Item.shootSpeed = 64f;
				Item.shoot = ProjectileType<Projectiles.SpearofJusticeG>();
			}
			if (player.altFunctionUse != 2)
			{
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.damage = 175;
				Item.shootSpeed = 32f;
				Item.shoot = ProjectileType<Projectiles.SpearofJustice>();
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				if (player.statMana > 390)
					{
					Projectile.NewProjectile(source, position.X, position.Y-20, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-40, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-60, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-80, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-100, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-120, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+20, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+40, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+60, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+80, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+100, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+120, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y-15, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y-30, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y-45, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y-60, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y-75, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y-90, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y+15, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y+30, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y+45, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y+60, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y+75, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X-50, position.Y+90, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					player.statMana -= 390;
					}
				if (player.statMana > 200)
					{
					Projectile.NewProjectile(source, position.X, position.Y-15, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-30, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-45, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-60, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-75, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y-90, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+15, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+30, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+45, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+60, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+75, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					Projectile.NewProjectile(source, position.X, position.Y+90, velocity.X, velocity.Y, ProjectileType<Projectiles.SpearofJusticeG>(), damage, knockback, player.whoAmI);
					player.statMana -= 200;
					}
			}
			return true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spear of Justice");
			Tooltip.SetDefault("Its strike can destroy everything in its way"
			+"\nVery own spear of a [c/FF0000:True Hero]"
			+"\nHas alternative attack mode on right-click"
			+"\n200 or 400 mana is required for using alternative attack");
			
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Копье Правосудия");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Его удары могут уничтожить все на своем пути\nКопье истинного героя\nИмеет альтернативную атаку (правая кнопка мыши)\nДля ее использования нужно 200 или 400 маны");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "正义之矛");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "它的攻击可以摧毁沿途的一切\n一个[c/FF0000:真英雄]特有的矛\n右键会有特殊的攻击方式\n特殊攻击需要200/400法力");
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "SoulEssence", 7)
				.AddIngredient(null, "HateVial")
				.AddIngredient(3543)
				.AddIngredient(null, "EmagledFragmentation", 300)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}

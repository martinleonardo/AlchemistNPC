using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class BallisticNebularDestroyer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ballistic Nebular Destroyer");
			Tooltip.SetDefault("Shoots spread of Vortex Rockets"
			+ "\n25% chance to not consume ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Баллистический Уничтожитель Туманностей");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Стреляет веером Вихревых Ракет\n25% шанс не потратить патроны");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星云狂怒毁灭者");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "发射出分裂的星璇弹\n25%的几率不消耗弹药");
        }

		public override void SetDefaults()
		{
			Item.damage = 70;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 100000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.VortexBeater)
				.AddIngredient(ItemID.FragmentNebula, 30)
				.AddIngredient(ItemID.LunarBar, 15) 
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 5);
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
				int numberProjectiles = 3 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
					{
					Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(15));
					Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.VortexBeaterRocket, damage, knockback, player.whoAmI);
					}
			return false;
		}
	}
}

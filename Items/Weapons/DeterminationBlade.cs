using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class DeterminationBlade : ModItem
	{
		public static int count = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Determination Blade");
			Tooltip.SetDefault("Contains Determination of 7 souls"
			+"\nAttacks build Hate" 
			+"\nAfter a certain amount of hits, right-clicking will release the Hate");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Клинок Решимости");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хранит в себе Решимость семи душ\nАтаки заряжают Ненависть\nПосле определённого количества ударов вы можете её выпустить, нажав правую кнопку мыши");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "决绝之剑");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "七魂之决绝蕴于此剑\n攻击增加仇恨\n攻击达到一定次数后, 右键释放仇恨.");
        }

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee;
			Item.damage = 99;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.value = 1000000;
			Item.rare = 10;
            Item.knockBack = 8;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.DBD>();
			Item.shootSpeed = 9f;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void UpdateInventory(Player player)
		{
			if (AlchemistNPC.DTH >= 10)
			{
			player.AddBuff(ModContent.BuffType<Buffs.Hate>(), 2);
			}
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2 && (AlchemistNPC.DTH < 10))
			{
				return false;
			}
			if (player.altFunctionUse == 2 && (AlchemistNPC.DTH >= 10))
			{
				Item.shoot = ProjectileType<Projectiles.DTH>();
				AlchemistNPC.DTH = 0;
			}
			if (player.altFunctionUse == 0){
			switch (count)
			{
				case 0:
				Item.shoot = ProjectileType<Projectiles.DBD>();
				count++;
				break;

				case 1:
				Item.shoot = ProjectileType<Projectiles.DBPV>();
				count++;
				break;
				
				case 2:
				Item.shoot = ProjectileType<Projectiles.DBJ>();
				count++;
				break;
				
				case 3:
				Item.shoot = ProjectileType<Projectiles.DBB>();
				count++;
				break;
				
				case 4:
				Item.shoot = ProjectileType<Projectiles.DBP>();
				count++;
				break;
				
				case 5:
				Item.shoot = ProjectileType<Projectiles.DBI>();
				count++;
				break;
				
				case 6:
				Item.shoot = ProjectileType<Projectiles.DBK>();
				count = 0;
				break;
			}
			
		}
		return true;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (count == 3)
			{
				Item.shoot = ProjectileType<Projectiles.DBJ>();
				int numberProjectiles = 3 + Main.rand.Next(3);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(5));
					Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<Projectiles.DBJ>(), damage*2, knockback, player.whoAmI);
				}
			}
			if (count == 4)
			{
				Item.shoot = ProjectileType<Projectiles.DBB>();
				int numberProjectiles = 2 + Main.rand.Next(2);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
					Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<Projectiles.DBB>(), damage*2, knockback, player.whoAmI);
				}
			}
			return true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "SoulEssence", 7)
				.AddIngredient(null, "HateVial")
				.AddIngredient(ItemID.TerraBlade)
				.AddIngredient(null, "EmagledFragmentation", 300)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}

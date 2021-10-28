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
	public class BloodthirstyBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodthirsty Blade");
			Tooltip.SetDefault("Becomes stronger the more enemies are defeated by it"
			+"\nKilling boss gives bigger damage boost"
			+"\nBlue Slimes and Spiked Blue Slimes will not give the weapon boosts"
			+"\nDoes not getting any benefits from bonus damage/critical strike chance"
			+"\nDamage is capped until entering Hardmode (36) and beating Moon Lord (99)"
			+"\nReaching 36, 64 and 100 damage makes special things to happen");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кровожадный Клинок");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чем больше врагов побеждено им, тем сильнее он становится\nУбийство босса даёт больший бонус к урону\nСиние и Синие шипастные слизни не дают бонуса к урону\nНе получает никаких бонусов по урону и шансу критического удара\nУрон ограничен до Хардмода (36) и победы над Лунным Лордом (99)\nДостижение 36, 64 и 100 урона производит особые изменения с мечом");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "渴血刃");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "用它杀死敌人会使它变得更强大"
			+"\n杀死Boss获得更大的伤害提升"
			+"\n蓝色史莱姆和蓝色尖刺史莱姆不会给予武器提升"
			+"\n不获得任何伤害/暴击率增益"
			+"\n困难模式前伤害上限为36, 月球领主前为99"
			+"\n伤害达到36, 64和100时会发生一些特殊的事情");
        }

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.crit = 50;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.value = 100000;
			Item.rare = 4;
            Item.knockBack = 8;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.5f;
		}

		public override void UpdateInventory(Player player)
		{
			Item.damage = 10 + (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).BBP/100);
			if (Item.damage >= 36)
			{
				Item.shoot = ProjectileType<Projectiles.SB>();
				Item.shootSpeed = 12f;
			}
			if (!Main.hardMode)
			{
				if (Item.damage > 36)
				{
					Item.damage = 36;
				}
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				Item.useTime = 15;
				Item.useAnimation = 15;
				if (Item.damage > 99)
				{
					Item.damage = 99;
				}
			}
			if (NPC.downedMoonlord)
			{
				Item.useTime = 10;
				Item.useAnimation = 10;
			}
		}
		
		public override void HoldItem(Player player)
		{
			Item.damage = 10 + (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).BBP/100);
			if (Item.damage >= 36)
			{
				Item.shoot = ProjectileType<Projectiles.SB>();
				Item.shootSpeed = 12f;
			}
			if (!Main.hardMode)
			{
				if (Item.damage > 36)
				{
					Item.damage = 36;
				}
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				Item.useTime = 15;
				Item.useAnimation = 15;
				if (Item.damage > 99)
				{
					Item.damage = 99;
				}
			}
			if (NPC.downedMoonlord)
			{
				Item.useTime = 10;
				Item.useAnimation = 10;
			}
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Item.damage = 10 + (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).BBP/100);
			if (Item.damage >= 64)
			{
				Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10));
				Vector2 perturbedSpeed2 = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10));
				float speedX = perturbedSpeed.X;
				float speedY = perturbedSpeed.Y;
				float speedX2 = perturbedSpeed2.X;
				float speedY2 = perturbedSpeed2.Y;
				Projectile.NewProjectile(source, position.X, position.Y+4, speedX, speedY, ProjectileType<Projectiles.SB>(), damage/2, knockback, player.whoAmI);
				Projectile.NewProjectile(source, position.X, position.Y-4, speedX2, speedY2, ProjectileType<Projectiles.SB>(), damage/2, knockback, player.whoAmI);
			}
			if (Item.damage > 99)
			{
				Vector2 perturbedSpeed3 = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(15));
				Vector2 perturbedSpeed4 = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(15));
				float speedX3 = perturbedSpeed3.X;
				float speedY3 = perturbedSpeed3.Y;
				float speedX4 = perturbedSpeed4.X;
				float speedY4 = perturbedSpeed4.Y;
				Projectile.NewProjectile(source, position.X, position.Y+5, speedX3, speedY3, ProjectileType<Projectiles.SB>(), damage/2, knockback, player.whoAmI);
				Projectile.NewProjectile(source, position.X, position.Y-5, speedX4, speedY4, ProjectileType<Projectiles.SB>(), damage/2, knockback, player.whoAmI);
			}
			damage /= 2;
			return true;
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			string text1;
			if(Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
			{
				text1 = "渴血指数为" + ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).BBP;
			}
			else
			{
				text1 = "Bloodthirsty Blade points are " + ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).BBP;
			}
			TooltipLine line = new TooltipLine(Mod, "text1", text1);
			tooltips.Insert(1,line);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BloodButcherer)
				.AddIngredient(ItemID.Vertebrae, 15)
				.AddIngredient(ItemID.TissueSample, 10)
				.AddIngredient(ItemID.Deathweed, 5)
				.AddTile(TileID.DemonAltar)
				.Register();
			CreateRecipe()
				.AddIngredient(ItemID.LightsBane)
				.AddIngredient(ItemID.RottenChunk, 15)
				.AddIngredient(ItemID.ShadowScale, 10)
				.AddIngredient(ItemID.Deathweed, 5)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}

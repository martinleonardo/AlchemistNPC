using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class SwordofArachna : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword of Arachna");
			Tooltip.SetDefault("Infects enemies on first hit, releases spiders on second");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Меч Арахны");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Заражает противников при первом ударе, выпускает пауков при втором");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蛛王剑");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第一次击中感染敌人, 第二次释放蜘蛛");
		}

		public override void SetDefaults()
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Melee;
			Item.crit = 10;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.value = 10000;
			Item.rare = 2;
            Item.knockBack = 4;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.5f;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (target.HasBuff(ModContent.BuffType<Buffs.Infested>()))
			{
				Vector2 vel2 = new Vector2(-1, -1);
				vel2 *= 3f;
				int p1 = Projectile.NewProjectile(target.GetProjectileSpawnSource(), target.position.X-30, target.position.Y-30, vel2.X, vel2.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p1].usesLocalNPCImmunity = true;
				Main.projectile[p1].localNPCHitCooldown = 1;
				Vector2 vel4 = new Vector2(1, -1);
				vel4 *= 3f;
				int p2 = Projectile.NewProjectile(target.GetProjectileSpawnSource(), target.position.X+30, target.position.Y-30, vel4.X, vel4.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p2].usesLocalNPCImmunity = true;
				Main.projectile[p2].localNPCHitCooldown = 1;
				Vector2 vel6 = new Vector2(0, -1);
				vel6 *= 3f;
				int p3 = Projectile.NewProjectile(target.GetProjectileSpawnSource(), target.position.X, target.position.Y-30, vel6.X, vel6.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p3].usesLocalNPCImmunity = true;
				Main.projectile[p3].localNPCHitCooldown = 1;
				Vector2 vel7 = new Vector2(-1, 0);
				vel7 *= 3f;
				int p4 = Projectile.NewProjectile(target.GetProjectileSpawnSource(), target.position.X-30, target.position.Y, vel7.X, vel7.Y, 379, damage/2, 0, Main.myPlayer);
				Main.projectile[p4].usesLocalNPCImmunity = true;
				Main.projectile[p4].localNPCHitCooldown = 1;
				Vector2 vel8 = new Vector2(1, 0);
				vel8 *= 3f;
				int p5 = Projectile.NewProjectile(target.GetProjectileSpawnSource(), target.position.X+30, target.position.Y, vel8.X, vel8.Y, 379 ,damage/2, 0, Main.myPlayer);
				Main.projectile[p5].usesLocalNPCImmunity = true;
				Main.projectile[p5].localNPCHitCooldown = 1;
				player.ClearBuff(BuffType<Buffs.Infested>());
			}
			else target.AddBuff(ModContent.BuffType<Buffs.Infested>(), 180);
		}
	}
}

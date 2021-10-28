using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class HolyAvenger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''Cera Sumat'', Holy Avenger");
			Tooltip.SetDefault("[c/00FF00:Legendary Sword] of Old Duke Ehld."
			+"\nTrue Melee sword"
			+"\nInflicts Curse of Light debuff"
			+"\nMakes enemies take 20% more damage from player"
			+"\n25% to take only half of the damage from debuffed enemy"
			+"\n[c/00FF00:Stats are growing up through progression]"
			+"\nBoosted stats will be shown after the first swing");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Сера Сумат'', Святой Мститель");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "[c/00FF00:Легендарный Меч] Старого Графа Эхлда\nОслабляет противников при ударе\nПротивники получают на 20% больше урона\n25% шанс получить половину урона от ослабленных противников\n[c/00FF00:Показатели увеличивается по мере прохождения]");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''塞拉苏门'', 神圣复仇者");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "老公爵埃尔德的[c/00FF00:传奇之剑]"
			+"\n纯近战剑"
			+"\n造成诅咒之光Debuff"
			+"\n来自玩家的攻击对敌人多造成20%伤害"
			+"\n来自带有诅咒之光Debuff敌人的攻击有25%概率只造成一半伤害"
			+"\n[c/00FF00:属性随进程成长]"
			+"\n提升过后的属性将会在使用后显示");

		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Muramasa);
			Item.damage = 14;
			Item.DamageType = DamageClass.Melee;
			Item.width = 78;
			Item.height = 78;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(platinum: 1);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)
		{
			if (!Main.hardMode)
			{
				Item.autoReuse = false;
			}
			Item.useTime = 15;
			Item.useAnimation = 15;
			if (NPC.downedSlimeKing)
			{
				Item.damage = 16;
			}
			if (NPC.downedBoss1)
			{
				Item.damage = 18;
			}
			if (NPC.downedBoss2)
			{
				Item.damage = 22;
			}
			if (NPC.downedQueenBee)
			{
				Item.damage = 26;
			}
			if (NPC.downedBoss3)
			{
				Item.damage = 30;
			}
			if (Main.hardMode)
			{
				Item.damage = 36;
				Item.useTime = 10;
				Item.useAnimation = 10;
				Item.autoReuse = true;
			}
			if (NPC.downedMechBossAny)
			{
				Item.damage = 44;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				Item.damage = 52;
			}
			if (NPC.downedPlantBoss)
			{
				Item.damage = 64;
			}
			if (NPC.downedGolemBoss)
			{
				Item.damage = 72;
			}
			if (NPC.downedFishron)
			{
				Item.damage = 81;
			}
			if (NPC.downedAncientCultist)
			{
				Item.damage = 90;
			}
			if (NPC.downedMoonlord)
			{
				Item.damage = 100;
			}
			return true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Dusts.JustitiaPale>());
			}
		}

		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 81;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.buffImmune[ModContent.BuffType<Buffs.CurseOfLight>()] = false;
			target.AddBuff(ModContent.BuffType<Buffs.CurseOfLight>(), 300);
			if (Main.hardMode && !NPC.downedMechBossAny)
			{
				Vector2 vel1 = new Vector2(0, 0);
				vel1 *= 0f;
				Projectile.NewProjectile(target.GetProjectileSpawnSource(), target.position.X, target.position.Y, vel1.X, vel1.Y, ProjectileType<Projectiles.ExplosionAvenger>(), damage/4, 0, Main.myPlayer);
			}
			if (Main.hardMode && NPC.downedMechBossAny && !NPC.downedGolemBoss)
			{
				Vector2 vel1 = new Vector2(0, 0);
				vel1 *= 0f;
				Projectile.NewProjectile(target.GetProjectileSpawnSource(), target.position.X, target.position.Y, vel1.X, vel1.Y, ProjectileType<Projectiles.ExplosionAvenger>(), damage/3, 0, Main.myPlayer);
			}
			if (Main.hardMode && NPC.downedGolemBoss)
			{
				Vector2 vel1 = new Vector2(0, 0);
				vel1 *= 0f;
				Projectile.NewProjectile(target.GetProjectileSpawnSource(), target.position.X, target.position.Y, vel1.X, vel1.Y, ProjectileType<Projectiles.ExplosionAvenger>(), damage/2, 0, Main.myPlayer);
			}
		}
	}
}

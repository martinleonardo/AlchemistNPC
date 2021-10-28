using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Audio;

namespace AlchemistNPC.Buffs
{
	public class ProjCounter : ModBuff
	{
		public static int counter = 0;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Globe 199");
			Description.SetDefault("Destroys nearby hostile projectiles"+"\nCooldown depends on progression");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Шар 199");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Уничтожает любые вражеские снаряды\nВремя перезарядки зависит от прогресса");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "球体 199");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "摧毁附近的敌方抛射物\n冷却时间由游戏进程而定");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			int timeValue = 600;
			if (NPC.downedSlimeKing)
			{
				timeValue = 575;
			}
			if (NPC.downedBoss1)
			{
				timeValue = 550;
			}
			if (NPC.downedBoss2)
			{
				timeValue = 525;
			}
			if (NPC.downedQueenBee)
			{
				timeValue = 500;
			}
			if (NPC.downedBoss3)
			{
				timeValue = 450;
			}
			if (Main.hardMode)
			{
				timeValue = 400;
			}
			if (NPC.downedMechBossAny)
			{
				timeValue = 350;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				timeValue = 325;
			}
			if (NPC.downedPlantBoss)
			{
				timeValue = 300;
			}
			if (NPC.downedGolemBoss)
			{
				timeValue = 275;
			}
			if (NPC.downedFishron)
			{
				timeValue = 250;
			}
			if (NPC.downedAncientCultist)
			{
				timeValue = 210;
			}
			if (NPC.downedMoonlord)
			{
				timeValue = 180;
			}
			player.AddBuff(ModContent.BuffType<Buffs.ProjCounter>(), 2);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Globe199>()] <= 0)
			{
				Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X-15, player.position.Y-100, 0f, 0f, ModContent.ProjectileType<Projectiles.Globe199>(), 0, 0, player.whoAmI);
			}
			counter++;
			for (int i = 0; i < 1000; i++)
            {
                Projectile target = Main.projectile[i];

                float shootToX = target.position.X + target.width * 0.5f - player.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - player.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 130f && !target.friendly && target.active && target.hostile)
                {
                    if (counter > timeValue)
                    {
						player.AddBuff(ModContent.BuffType<Buffs.GuarantCrit>(), 2);
						((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).GC = true;
						Terraria.Audio.SoundEngine.PlaySound(SoundID.Item93.WithVolume(.6f), player.position);
                        Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center.X, player.Center.Y, 0f, 0f, ModContent.ProjectileType<Projectiles.Counter>(), 0, 6, Main.myPlayer, 0f, 0f);
                        counter = 0;
                    }
                }
			}
		}
	}
}

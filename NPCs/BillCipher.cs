using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPC;
using AlchemistNPC.NPCs;
using Terraria.GameContent.ItemDropRules;

namespace AlchemistNPC.NPCs
{
    [AutoloadBossHead]
    class BillCipher : ModNPC
    {
        public static int introduction = 0;
        public static int counter = 0;
        public static int counter2 = 0;
        public static int counter3 = 0;
        public static int counter4 = 0;
        public static int counter5 = 0;

        public override void SetDefaults()
        {
            NPC.boss = true;
            NPC.width = 82;
            NPC.height = 70;
            NPC.damage = 800;
            NPC.defense = 20;
            NPC.lifeMax = 333333;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 333f;
            NPC.knockBackResist = -1;
            NPC.aiStyle = 5;
            NPC.noTileCollide = true;
            NPC.noGravity = true;
            AIType = 9;
            Music = MusicID.Boss2;
            BossBag = ModContent.ItemType<Items.Misc.BillCipherBag>();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bill Cipher");
            Main.npcFrameCount[NPC.type] = 6;
        }

        public override void BossHeadRotation(ref float rotation)
        {
            rotation = 0;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 0f;
        }

        public override void AI()
        {
            if (!ModGlobalNPC.bsu)
            {
                Main.NewText("Use Dimensional Rift to summon boss properly", 150, 100, 30);
                NPC.CloneDefaults(-66);
            }
            Player player = Main.player[(int)Player.FindClosest(NPC.position, NPC.width, NPC.height)];
            Main.dayTime = false;
            // UPDATE TO 1.4
            //Main.monolithType = 3;
            player.ManageSpecialBiomeVisuals("Solar", true, player.Center);
            Main.time = 0.0;
            counter4++;
            if (NPC.life < NPC.lifeMax && counter4 >= 2)
            {
                NPC.life++;
                counter4 = 0;
            }
            if (NPC.velocity.X < 0)
            {
                NPC.rotation = 1.25f;
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.rotation = -1.25f;
                NPC.spriteDirection = 1;
            }
            if (introduction >= 300)
            {
                counter5++;
                if (counter5 == 1)
                {
                    Vector2 delta = player.Center - NPC.Center;
                    float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                    if (magnitude > 0)
                    {
                        delta *= (5f / magnitude);
                    }
                    else
                    {
                        delta = new Vector2(0f, 5f);
                    }
                    delta *= 2f;
                    NPC.velocity = delta;
                }
                if (counter5 == 60)
                {
                    Vector2 delta = player.Center - NPC.Center;
                    float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                    if (magnitude > 0)
                    {
                        delta *= (5f / magnitude);
                    }
                    else
                    {
                        delta = new Vector2(0f, 5f);
                    }
                    delta *= 2f;
                    NPC.velocity = delta;
                }
                if (counter5 == 120)
                {
                    Vector2 delta = player.Center - NPC.Center;
                    float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                    if (magnitude > 0)
                    {
                        delta *= (5f / magnitude);
                    }
                    else
                    {
                        delta = new Vector2(0f, 5f);
                    }
                    delta *= 2f;
                    NPC.velocity = delta;
                }
                if (counter5 == 600)
                {
                    counter5 = 0;
                }
            }
            float TPX = NPC.position.X + NPC.width * 0.5f - player.Center.X;
            float TPY = NPC.position.Y + NPC.height * 0.5f - player.Center.Y;
            float distance = (float)Math.Sqrt(TPX * TPX + TPY * TPY);
            if (player.name == "Bill")
            {
                if (introduction < 1)
                {
                    Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat1"), 10, 255, 10);
                    Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat2"), 10, 255, 10);
                    player.QuickSpawnItem(ModContent.ItemType<Items.Misc.BillCipherBag>());
                }
                NPC.boss = false;
                NPC.velocity = new Vector2(0, -10);
                NPC.velocity *= 3f;

            }
            if (distance > 2500f && introduction >= 300)
            {
                Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.BillCipherChat3"), 10, 255, 10);
                switch (Main.rand.Next(2))
                {
                    case 0:
                        NPC.Center = player.Center - new Vector2(350, 100);
                        break;
                    case 1:
                        NPC.Center = player.Center - new Vector2(-350, -100);
                        break;
                }
            }
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("AbyssalShell")] = true;
                NPC.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("AParalyzed")] = true;
                NPC.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("Paralyzed")] = true;
            }
			*/
            NPC.buffImmune[ModContent.BuffType<Buffs.ArmorDestruction>()] = true;
            NPC.buffImmune[ModContent.BuffType<Buffs.Twilight>()] = true;
            NPC.buffImmune[ModContent.BuffType<Buffs.Electrocute>()] = true;
            NPC.buffImmune[ModContent.BuffType<Buffs.Patience>()] = true;
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("CalamityMod") != null)
            {
                NPC.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("SilvaStun")] = true;
                NPC.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("GlacialState")] = true;
                NPC.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("ExoFreeze")] = true;
                NPC.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("MarkedforDeath")] = true;
            }
			*/
            int damage1 = 150;
            int damage2 = 125;
            int damage3 = 200;
            if (introduction < 300)
            {
                NPC.dontTakeDamage = true;
            }
            if (NPC.life > NPC.lifeMax / 2 && !player.dead && !NPC.GetGlobalNPC<ModGlobalNPC>().intermission1)
            {
                introduction++;

                if (introduction > 300)
                {
                    NPC.dontTakeDamage = false;
                    if (counter2 >= 20)
                    {
                        counter2 = 0;
                        Vector2 delta = player.Center - NPC.Center;
                        float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                        if (magnitude > 0)
                        {
                            delta *= (5f / magnitude);
                        }
                        else
                        {
                            delta = new Vector2(0f, 5f);
                        }
                        delta *= 2f;
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta.X, delta.Y, ProjectileType<Projectiles.DeadlyLaser>(), 250, 0, Main.myPlayer);
                    }
                    if (counter >= 45)
                    {
                        counter = 0;
                        Vector2 delta = player.Center - NPC.Center;
                        float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                        if (magnitude > 0)
                        {
                            delta *= 5f / magnitude;
                        }
                        else
                        {
                            delta = new Vector2(0f, 5f);
                        }
                        delta *= 1.5f;
                        Vector2 delta2 = delta.RotatedByRandom(MathHelper.ToRadians(15));
                        Vector2 delta3 = delta.RotatedByRandom(MathHelper.ToRadians(15));
                        Vector2 delta4 = delta.RotatedByRandom(MathHelper.ToRadians(20));
                        Vector2 delta5 = delta.RotatedByRandom(MathHelper.ToRadians(20));
                        Vector2 delta6 = delta.RotatedByRandom(MathHelper.ToRadians(25));
                        Vector2 delta7 = delta.RotatedByRandom(MathHelper.ToRadians(25));
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta.X, delta.Y, 100, damage1, 0, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta2.X, delta2.Y, 100, damage1, 0, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta3.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta4.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta5.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta6.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta7.X, delta3.Y, 100, damage1, 0, Main.myPlayer);
                    }
                    counter++;
                    counter2++;
                }
            }
            if (NPC.life < NPC.lifeMax / 2 && NPC.life > NPC.lifeMax * 0.15f && !player.dead && !NPC.GetGlobalNPC<ModGlobalNPC>().intermission2)
            {
                player.AddBuff((ModContent.BuffType<Buffs.Madness>()), 2);
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
                if (ModLoader.GetMod("CalamityMod") != null)
                {
                    if (CalamityModRevengeance)
                    {
                        counter3++;
                        if (counter3 <= 900)
                        {
                            player.gravDir = -1f;
                        }
                        if (counter3 > 900 && counter3 <= 1800)
                        {
                            player.gravDir = 1f;
                        }
                        if (counter3 > 1800)
                        {
                            counter3 = 0;
                        }
                    }
                }
				*/
                if (counter >= 30)
                {
                    counter = 0;
                    Vector2 delta = player.Center - NPC.Center;
                    float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                    if (magnitude > 0)
                    {
                        delta *= (5f / magnitude);
                    }
                    else
                    {
                        delta = new Vector2(0f, 5f);
                    }
                    delta *= 1.5f;
                    Vector2 delta2 = delta.RotatedByRandom(MathHelper.ToRadians(30));
                    Vector2 delta3 = delta.RotatedByRandom(MathHelper.ToRadians(30));
                    Vector2 delta4 = delta.RotatedByRandom(MathHelper.ToRadians(20));
                    Vector2 delta5 = delta.RotatedByRandom(MathHelper.ToRadians(20));
                    Vector2 delta6 = delta.RotatedByRandom(MathHelper.ToRadians(10));
                    Vector2 delta7 = delta.RotatedByRandom(MathHelper.ToRadians(10));
                    Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta.X, delta.Y, ProjectileType<Projectiles.DeadlyLaser>(), 250, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta2.X, delta2.Y, 100, damage2, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta3.X, delta3.Y, 100, damage2, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta4.X, delta4.Y, 100, damage2, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta5.X, delta5.Y, 100, damage2, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta6.X, delta7.Y, ProjectileType<Projectiles.DeadlyLaser>(), 250, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, delta6.X, delta7.Y, ProjectileType<Projectiles.DeadlyLaser>(), 250, 0, Main.myPlayer);
                }
                counter++;
            }
            if (NPC.life < NPC.lifeMax * 0.15f && !player.dead)
            {
                player.AddBuff((ModContent.BuffType<Buffs.Madness>()), 2);
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
                if (ModLoader.GetMod("CalamityMod") != null)
                {
                    if (CalamityModRevengeance)
                    {
                        counter3++;
                        if (counter3 <= 900)
                        {
                            player.gravDir = -1f;
                        }
                        if (counter3 > 900 && counter3 <= 1800)
                        {
                            player.gravDir = 1f;
                        }
                        if (counter3 > 1800)
                        {
                            counter3 = 0;
                        }
                    }
                }
				*/
                if (counter2 >= 20)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int dustType = Main.rand.Next(51, 54);
                        int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
                        Dust dust = Main.dust[dustIndex];
                        dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                        dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                        dust.scale *= 0.8f;
                        dust.noGravity = true;
                    }
                }
                if (counter2 >= 40)
                {
                    Terraria.Audio.SoundEngine.PlaySound(2, (int)NPC.position.X, (int)NPC.position.Y, 62);
                    counter2 = 0;
                    Vector2 delta = player.Center - NPC.Center;
                    float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                    if (magnitude > 0)
                    {
                        delta *= (5f / magnitude);
                    }
                    else
                    {
                        delta = new Vector2(0f, 5f);
                    }
                    delta *= 6f;
                    float numberProjectiles = 15;
                    float rotation = MathHelper.ToRadians(2);
                    delta += Vector2.Normalize(new Vector2(delta.X, delta.Y)) * 45f;
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 perturbedSpeed = new Vector2(delta.X, delta.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center.X, NPC.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<Projectiles.Vaporizer>(), damage3, 0, player.whoAmI);
                    }
                }
                counter2++;
            }
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("CalamityMod") != null)
            {
                if (CalamityModRevengeance)
                {
                    RnAReset(player);
                }
            }
			*/
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).CursedMirror == true)
            {
                NPC.reflectsProjectiles = true;
            }
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).CursedMirror == false)
            {
                NPC.reflectsProjectiles = false;
            }
        }

		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
        private void RnAReset(Player player)
        {
            CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            CalamityPlayer.rage = 0;
            CalamityPlayer.adrenaline = 0;
        }
		*/

        public override void ModifyHitPlayer(Player player, ref int damage, ref bool crit)
        {
            player.buffImmune[ModContent.BuffType<Buffs.MindBurn>()] = false;
            player.AddBuff(ModContent.BuffType<Buffs.MindBurn>(), 1200);
        }

        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).Voodoo == true)
            {
                player.statLife--;
                PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                if (Main.rand.Next(2) == 0)
                    damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
                if (player.statLife <= 0)
                    player.KillMe(damageSource, 1.0, 0, false);
                player.lifeRegenCount = 0;
                player.lifeRegenTime = 0;
            }
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            Player player = Main.player[(int)Player.FindClosest(NPC.position, NPC.width, NPC.height)];
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).Voodoo == true)
            {
                player.statLife--;
                PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                if (Main.rand.Next(2) == 0)
                    damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
                if (player.statLife <= 0)
                    player.KillMe(damageSource, 1.0, 0, false);
                player.lifeRegenCount = 0;
                player.lifeRegenTime = 0;
            }
        }

		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
        public bool CalamityModRevengeance
        {
            get { return CalamityMod.World.CalamityWorld.revenge; }
        }
        private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		*/

        const int Frame_P11 = 0;
        const int Frame_P12 = 1;
        const int Frame_P13 = 2;
        const int Frame_P21 = 3;
        const int Frame_P22 = 4;
        const int Frame_P23 = 5;

        public override void FindFrame(int frameHeight)
        {
            if (!NPC.GetGlobalNPC<ModGlobalNPC>().phase2)
            {
                NPC.frameCounter++;
                if (NPC.frameCounter < 100)
                {
                    NPC.frame.Y = Frame_P11 * frameHeight;
                }
                else if (NPC.frameCounter < 115)
                {
                    NPC.frame.Y = Frame_P12 * frameHeight;
                }
                else if (NPC.frameCounter < 120)
                {
                    NPC.frame.Y = Frame_P13 * frameHeight;
                }
                else if (NPC.frameCounter < 125)
                {
                    NPC.frame.Y = Frame_P12 * frameHeight;
                }
                else
                {
                    NPC.frameCounter = 0;
                }
            }
            if (NPC.GetGlobalNPC<ModGlobalNPC>().phase2)
            {
                NPC.frameCounter++;
                if (NPC.frameCounter < 100)
                {
                    NPC.frame.Y = Frame_P21 * frameHeight;
                }
                else if (NPC.frameCounter < 115)
                {
                    NPC.frame.Y = Frame_P22 * frameHeight;
                }
                else if (NPC.frameCounter < 120)
                {
                    NPC.frame.Y = Frame_P23 * frameHeight;
                }
                else if (NPC.frameCounter < 125)
                {
                    NPC.frame.Y = Frame_P22 * frameHeight;
                }
                else
                {
                    NPC.frameCounter = 0;
                }
            }
        }

        public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            if (NPC.life > NPC.lifeMax / 10)
            {
                damage /= 10;
            }
            if (NPC.life < NPC.lifeMax / 10)
            {
                damage /= 20;
            }
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (NPC.life > NPC.lifeMax / 10)
            {
                damage /= 10;
            }
            if (NPC.life < NPC.lifeMax / 10)
            {
                damage /= 20;
            }
            if (projectile.type == ProjectileType<Projectiles.QuantumDestabilizer>())
            {
                damage *= 5;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(BossBag));
            if (!Main.expertMode)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.GoldenKnuckles>(), 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.WrathOfTheCelestial>(), 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.LaserCannon>(), 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Equippable.GrapplingHookGunItem>(), 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.BillSoul>(), 1));
                npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 1, 25, 25));
            }
        }
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		public override void OnKill()
		{
			Mod ALIB = ModLoader.GetMod("AchievementLib");
            if (ALIB != null)
            {
                ALIB.Call("UnlockGlobal", "AlchemistNPC", "The deal is off!");
            }
		}
		*/

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.SuperHealingPotion;
        }
    }
}
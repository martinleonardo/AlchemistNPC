using Terraria.Utilities;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPC.Interface;
using AlchemistNPC;
using Terraria.UI;
using Terraria.Audio;
using Terraria.DataStructures;

namespace AlchemistNPC.Items
{
    public class AlchemistGlobalItem : GlobalItem
    {
        public static bool on = false;
        public static bool stop = false;
        public static bool Luck = false;
        public static bool Luck2 = false;
        public static bool Menacing = false;
        public static bool Lucky = false;
        public static bool Violent = false;
        public static bool Warding = false;
        public static bool PerfectionToken = false;

        public override void HoldItem(Item item, Player player)
        {
            if (item.type == ItemID.WaterGun && NPC.AnyNPCs(NPCType<NPCs.Knuckles>()))
			{
				item.damage = 1;
			}
			for (int j = 0; j < Main.player[Main.myPlayer].inventory.Length; j++)
			{
				if (Main.player[Main.myPlayer].inventory[j].type == ModContent.ItemType<Items.Misc.DimensionalCasket>())
				{
					if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
					{
						Main.soundVolume = AlchemistNPC.volume; 
						DimensionalCasketUI.k = -1;
						DimensionalCasketUI.forcetalk = false;
					}
					if (DimensionalCasketUI.forcetalk == true)
					{
						if(Main.soundVolume != 0f)	AlchemistNPC.volume = Main.soundVolume;
						Main.soundVolume = 0f; 
						Main.player[Main.myPlayer].SetTalkNPC(DimensionalCasketUI.k);
					}
				}
			}
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).BoomBox)
            {
                if (player.inventory[49].createTile != -1 && player.inventory[49].accessory)
                {
                    bool r = false;
                    player.ApplyEquipFunctional(player.inventory[49], r);
                }
            }
            // BUG: Tracking is broken
            /*
			if (player.accCritterGuide && AlchemistNPC.modConfiguration.LifeformAnalyzer)
			{
				if(Main.GameUpdateCount % 60 == 0) 
				{
					for (int v = 0; v < 200; ++v)
					{
						NPC npc = Main.npc[v];
						if (npc.active && npc.rarity >= 1)
						{
							float num102 = 6f;
							float num103 = npc.Center.X + npc.width * 0.5f - player.Center.X;
							float num104 = npc.Center.Y + npc.height * 0.5f - player.Center.Y;
							float num105 = (float)Math.Sqrt((double)(num103 * num103 + num104 * num104));
							num105 = num102 / num105;
							num103 *= num105;
							num104 *= num105;
							Projectile.NewProjectile(npc.GetProjectileSpawnSource(), player.Center.X, player.Center.Y, num103, num104, ProjectileType<Projectiles.LocatorProjectile>(), 0, 0f, player.whoAmI, v, 0f);
						}
					}
				}
			}
			*/
            if (item.type == ModContent.ItemType<Items.Misc.LuckCharm>())
            {
                Luck = true;
            }
            if (item.type == ModContent.ItemType<Items.Misc.LuckCharmT2>())
            {
                Luck = true;
                Luck2 = true;
            }
            if (item.type == ModContent.ItemType<Items.Misc.PerfectionToken>())
            {
                PerfectionToken = true;
            }
            if (item.type == ModContent.ItemType<Items.Misc.MenacingToken>())
            {
                Menacing = true;
            }
            if (item.type == ModContent.ItemType<Items.Misc.LuckyToken>())
            {
                Lucky = true;
            }
            if (item.type == ModContent.ItemType<Items.Misc.ViolentToken>())
            {
                Violent = true;
            }
            if (item.type == ModContent.ItemType<Items.Misc.WardingToken>())
            {
                Warding = true;
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			Mod ALIB = ModLoader.GetMod("AchievementLib");
			if(ALIB != null)
			{
				if (item.type == ModContent.ItemType<Items.Placeable.Wellcheers>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Well, cheers!");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.SpearofJustice>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Spear of Justice");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.EyeOfJudgement>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "if you keep going the way you are now...");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.EyeOfJudgementP>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "you're gonna have a bad time.");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.MagicWand>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Don't worry, mom, I can handle it...");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.DarkMagicWand>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Dip down!");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.MarcoMagicWand>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Forbidden magic");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.PandoraPF422>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Pandora's Box");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.PortalGun>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Now you're thinking...");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.TurretStaff>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "Artificial unintelligence");
				}
				if (item.type == ModContent.ItemType<Items.Weapons.Akumu>())
				{
					ALIB.Call("UnlockGlobal", "AlchemistNPC", "The only thing to FEAR");
				}
			}
			*/
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (Luck == true && PerfectionToken == false)
            {
                if (item.DamageType == DamageClass.Melee)
                {
                    if (Main.rand.Next(10) == 0)
                        return 59;

                    if (Main.rand.Next(20) == 0)
                        return 81;
                }
                if (item.DamageType == DamageClass.Ranged && !item.consumable)
                {
                    if (Main.rand.Next(10) == 0)
                        return 20;

                    if (Main.rand.Next(20) == 0)
                        return 82;
                }
                if (item.DamageType == DamageClass.Magic)
                {
                    if (Main.rand.Next(10) == 0)
                        return 28;

                    if (Main.rand.Next(20) == 0)
                        return 83;
                }
                if (item.DamageType == DamageClass.Summon)
                {
                    if (Main.rand.Next(10) == 0)
                        return 57;

                    if (Main.rand.Next(20) == 0)
                        return 83;
                }
                if (item.DamageType == DamageClass.Throwing && !item.consumable)
                {
                    if (Main.rand.Next(10) == 0)
                        return 20;

                    if (Main.rand.Next(20) == 0)
                        return 82;
                }
            }
            if (Luck2 == true && !Menacing && !Lucky && !Violent && !Warding)
            {
                if (item.accessory)
                {
                    if (Main.rand.Next(10) == 0)
                        return 72;

                    else if (Main.rand.Next(10) == 0)
                        return 68;

                    else if (Main.rand.Next(10) == 0)
                        return 65;
                }
            }
            if (PerfectionToken == true)
            {
                if (item.type == ModContent.ItemType<Items.Weapons.LastTantrum>())
                {
                    return 59;
                }
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (item.type == ModLoader.GetMod("CalamityMod").ItemType("P90"))
					{
						return 57;
					}
					if (item.type == ModLoader.GetMod("CalamityMod").ItemType("ColdheartIcicle"))
					{
						return 15;
					}
					if (item.type == ModLoader.GetMod("CalamityMod").ItemType("HalibutCannon"))
					{
						return 17;
					}
				}
				*/
                if (item.damage > 3 && item.useTime <= 4 && item.useAnimation <= 4 && item.maxStack == 1)
                {
                    return PrefixType<Prefixes.AncientPrefix>();
                }
                if (item.damage > 3 && item.DamageType == DamageClass.Melee && item.maxStack == 1)
                {
                    return PrefixType<Prefixes.PrimalPrefix>();
                }
                if (item.damage > 3 && item.DamageType == DamageClass.Magic && item.maxStack == 1)
                {
                    return PrefixType<Prefixes.ArcanaPrefix>();
                }
                if (item.damage > 3 && item.DamageType == DamageClass.Summon && item.maxStack == 1)
                {
                    return PrefixType<Prefixes.DemiurgicPrefix>();
                }
                if (item.damage > 3 && (item.DamageType == DamageClass.Ranged || item.DamageType == DamageClass.Throwing) && item.maxStack == 1)
                {
                    return PrefixType<Prefixes.ImmortalPrefix>();
                }
                if (item.damage > 3)
                {
                    if (item.DamageType == DamageClass.Melee)
                    {
                        return 81;
                    }
                    if (item.DamageType == DamageClass.Ranged && !item.consumable && item.useTime <= 3)
                    {
                        return 59;
                    }
                    if (item.DamageType == DamageClass.Ranged && !item.consumable && item.knockBack <= 0)
                    {
                        return 60;
                    }
                    if (item.DamageType == DamageClass.Ranged && !item.consumable && item.knockBack > 0)
                    {
                        return 82;
                    }
                    if (item.DamageType == DamageClass.Magic && item.knockBack <= 0)
                    {
                        return 60;
                    }
                    if (item.DamageType == DamageClass.Magic && item.useTime <= 2)
                    {
                        return 59;
                    }
                    if (item.DamageType == DamageClass.Magic && item.mana <= 4)
                    {
                        return 59;
                    }
                    if (item.DamageType == DamageClass.Magic && item.knockBack > 0)
                    {
                        return 83;
                    }
                    if (item.DamageType == DamageClass.Summon)
                    {
                        return 83;
                    }
                    if (item.DamageType == DamageClass.Throwing && !item.consumable && item.useTime <= 3)
                    {
                        return 59;
                    }
                    if (item.DamageType == DamageClass.Throwing && !item.consumable)
                    {
                        return 82;
                    }
                }
            }
            if (item.accessory)
            {
                if (Menacing)
                {
                    return 72;
                }
                if (Lucky)
                {
                    return 68;
                }
                if (Violent)
                {
                    return 80;
                }
                if (Warding)
                {
                    return 65;
                }
            }
            return -1;
        }

        public override bool PreReforge(Item item)
        {
            Player player = Main.player[Main.myPlayer];
            if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Misc.PerfectionToken>()) && item.damage > 3)
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == ModContent.ItemType<Items.Misc.PerfectionToken>())
                    {
                        inventory[k].stack--;
                        return true;
                    }
                }
            }
            if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Misc.MenacingToken>()))
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == ModContent.ItemType<Items.Misc.MenacingToken>())
                    {
                        inventory[k].stack--;
                        return true;
                    }
                }
            }
            if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Misc.LuckyToken>()))
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == ModContent.ItemType<Items.Misc.LuckyToken>())
                    {
                        inventory[k].stack--;
                        return true;
                    }
                }
            }
            if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Misc.ViolentToken>()))
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == ModContent.ItemType<Items.Misc.ViolentToken>())
                    {
                        inventory[k].stack--;
                        return true;
                    }
                }
            }
            if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Misc.WardingToken>()))
            {
                Item[] inventory = Main.player[Main.myPlayer].inventory;
                for (int k = 0; k < inventory.Length; k++)
                {
                    if (inventory[k].type == ModContent.ItemType<Items.Misc.WardingToken>())
                    {
                        inventory[k].stack--;
                        return true;
                    }
                }
            }
            return base.PreReforge(item);
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AlchemistCharmTier4 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
				Mod Calamity = ModLoader.GetMod("CalamityMod");
				if (Calamity != null)
				{
					if ((bool)Calamity.Call("Downed", "supreme calamitas"))
					{
						return false;
					}
				}
				*/
                if (Main.rand.NextFloat() >= .25f)
                {
                    return false;
                }
            }

            else if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AlchemistCharmTier3 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(2) == 0)
                    return false;
            }

            else if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AlchemistCharmTier2 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(4) == 0)
                    return false;
            }

            else if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AlchemistCharmTier1 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(10) == 0)
                    return false;
            }
            return true;
        }

        public override bool CanConsumeAmmo(Item item, Player player)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.DemonSlayer>()))
            {
                return Main.rand.NextFloat() >= .25f;
            }
            return true;
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).GolemBooster == 1 && item.useTime > 3)
            {
                return 1.1f;
            }
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).Symbiote == true && item.useTime > 3)
            {
                if (!Main.hardMode)
                {
                    return 1.1f;
                }
                if (Main.hardMode && !NPC.downedMoonlord)
                {
                    return 1.15f;
                }
                if (NPC.downedMoonlord)
                {
                    return 1.2f;
                }
            }
            return base.UseTimeMultiplier(item, player);
        }

        public override bool Shoot(Item item, Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            if (player.HasBuff(ModContent.BuffType<Buffs.DemonSlayer>()) && item.DamageType == DamageClass.Throwing && Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(source, position.X, position.Y - 12, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            }
            if (modPlayer.Rampage == true && type == 14)
            {
                type = ProjectileType<Projectiles.Chloroshard>();
            }
            if (modPlayer.Rampage == true && type == 1)
            {
                type = ProjectileType<Projectiles.ChloroshardArrow>();
            }
            if (modPlayer.DeltaRune && item.DamageType == DamageClass.Melee && Main.rand.NextBool(20))
            {
                Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileType<Projectiles.RedWave>(), 1111, 1f, player.whoAmI);
            }
            if (modPlayer.DeltaRune && item.DamageType == DamageClass.Magic && Main.rand.NextBool(30))
            {
                float numberProjectiles = 9;
                float rotation = MathHelper.ToRadians(8);
                Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .5f;
                    Projectile.NewProjectile(source, vector.X, vector.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<Projectiles.MM>(), 1337, knockback, player.whoAmI);
                }
            }
            if (modPlayer.Barrage)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item91.WithVolume(.6f), player.position);
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                int p = Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<Projectiles.EnergyBall>(), item.damage / 5, 1f, player.whoAmI);
                if (item.useTime > 10)
                {
                    Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(4));
                    Vector2 perturbedSpeed3 = velocity.RotatedByRandom(MathHelper.ToRadians(4));
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, ProjectileType<Projectiles.EnergyBall>(), item.damage / 4, 1f, player.whoAmI);
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed3.X, perturbedSpeed3.Y, ProjectileType<Projectiles.EnergyBall>(), item.damage / 4, 1f, player.whoAmI);
                }
            }
            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }

        public override bool? UseItem(Item item, Player player)
        {
            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            if (modPlayer.Barrage && item.damage > 0 && Main.GameUpdateCount % 6 == 0)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item91.WithVolume(.6f), player.position);
                float num1 = 9f;
                Vector2 vector2 = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
                float f1 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                float f2 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                if ((double)player.gravDir == -1.0)
                    f2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
                float num4 = (float)Math.Sqrt((double)f1 * (double)f1 + (double)f2 * (double)f2);
                float num5;
                if (float.IsNaN(f1) && float.IsNaN(f2) || (double)f1 == 0.0 && (double)f2 == 0.0)
                {
                    f1 = (float)player.direction;
                    f2 = 0.0f;
                    num5 = num1;
                }
                else
                    num5 = num1 / num4;
                float SpeedX = f1 * num5;
                float SpeedY = f2 * num5;
                Vector2 perturbedSpeed = new Vector2(SpeedX, SpeedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(player.GetProjectileSource_Item(item), vector2.X, vector2.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileType<Projectiles.EnergyBall>(), item.damage / 5, 1f, player.whoAmI);
            }
            if (item.type == ItemID.BugNet || item.type == ItemID.GoldenBugNet)
            {
                for (int v = 0; v < 200; ++v)
                {
                    NPC npc = Main.npc[v];
                    if (npc.active && npc.townNPC)
                    {
                        if (AlchemistNPC.modConfiguration.CatchNPC)
                        {
                            if (npc.type == NPCType<NPCs.Alchemist>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.AlchemistHorcrux>();
                            }
                            if (npc.type == NPCType<NPCs.Brewer>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.BrewerHorcrux>();
                            }
                            if (npc.type == NPCType<NPCs.Architect>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.ArchitectHorcrux>();
                            }
                            if (npc.type == NPCType<NPCs.Jeweler>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.JewelerHorcrux>();
                            }
                            if (npc.type == NPCType<NPCs.Operator>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.APMC>();
                            }
                            if (npc.type == NPCType<NPCs.OtherworldlyPortal>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.NotesBook>();
                            }
                            if (npc.type == NPCType<NPCs.Explorer>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.RealityPiercer>();
                            }
                            if (npc.type == NPCType<NPCs.Musician>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.MusicianHorcrux>();
                            }
                            if (npc.type == NPCType<NPCs.Tinkerer>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.TinkererHorcrux>();
                            }
                        }
                        if (!AlchemistNPC.modConfiguration.CatchNPC)
                        {
                            if (npc.type == NPCType<NPCs.Alchemist>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == NPCType<NPCs.Brewer>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == NPCType<NPCs.Architect>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == NPCType<NPCs.Jeweler>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == NPCType<NPCs.Operator>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == NPCType<NPCs.OtherworldlyPortal>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == NPCType<NPCs.Explorer>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == NPCType<NPCs.Musician>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == NPCType<NPCs.Tinkerer>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                        }
                    }
                }
            }
            if (modPlayer.DeltaRune && item.DamageType == DamageClass.Melee && Main.rand.NextBool(100))
            {
                float num1 = 9f;
                Vector2 vector2 = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
                float f1 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                float f2 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                if ((double)player.gravDir == -1.0)
                    f2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
                float num4 = (float)Math.Sqrt((double)f1 * (double)f1 + (double)f2 * (double)f2);
                float num5;
                if (float.IsNaN(f1) && float.IsNaN(f2) || (double)f1 == 0.0 && (double)f2 == 0.0)
                {
                    f1 = (float)player.direction;
                    f2 = 0.0f;
                    num5 = num1;
                }
                else
                    num5 = num1 / num4;
                float SpeedX = f1 * num5;
                float SpeedY = f2 * num5;
                Projectile.NewProjectile(player.GetProjectileSource_Item(item), vector2.X, vector2.Y, SpeedX, SpeedY, ProjectileType<Projectiles.RedWave>(), 1111, 1f, player.whoAmI);
            }
            if (modPlayer.KeepBuffs == 1 && (item.buffTime > 0))
            {
                if (modPlayer.AlchemistCharmTier4)
                {
                    player.AddBuff(item.buffType, item.buffTime * 2 + ((item.buffTime * 2) / 2), true);
                }
                else if (modPlayer.AlchemistCharmTier3)
                {
                    player.AddBuff(item.buffType, item.buffTime * 2 + (((item.buffTime * 2) / 20) * 7), true);
                }
                else if (modPlayer.AlchemistCharmTier2)
                {
                    player.AddBuff(item.buffType, item.buffTime * 2 + ((item.buffTime * 2) / 4), true);
                }
                else if (modPlayer.AlchemistCharmTier1)
                {
                    player.AddBuff(item.buffType, item.buffTime * 2 + ((item.buffTime * 2) / 10), true);
                }
                else player.AddBuff(item.buffType, item.buffTime * 2, true);
            }
            if (modPlayer.KeepBuffs == 0 && (item.buffTime > 0))
            {
                if (modPlayer.AlchemistCharmTier4)
                {
                    player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 2), true);
                }
                else if (modPlayer.AlchemistCharmTier3)
                {
                    player.AddBuff(item.buffType, item.buffTime + ((item.buffTime / 20) * 7), true);
                }
                else if (modPlayer.AlchemistCharmTier2)
                {
                    player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 4), true);
                }
                else if (modPlayer.AlchemistCharmTier1)
                {
                    player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 10), true);
                }
            }
            return base.UseItem(item, player);
        }

        public override void PickAmmo(Item weapon, Item item, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Bullet && player.GetModPlayer<AlchemistNPCPlayer>().Rampage)
            {
                type = ProjectileType<Projectiles.Chloroshard>();
            }
            if (type == 1 && player.GetModPlayer<AlchemistNPCPlayer>().Rampage)
            {
                type = ProjectileType<Projectiles.ChloroshardArrow>();
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string BillCipher = Language.GetTextValue("Mods.AlchemistNPC.BillCipher");
            string Knuckles = Language.GetTextValue("Mods.AlchemistNPC.Knuckles");
            //SBMW:Vanilla
            string KingSlime = Language.GetTextValue("Mods.AlchemistNPC.KingSlime");
            string EyeofCthulhu = Language.GetTextValue("Mods.AlchemistNPC.EyeofCthulhu");
            string EaterOfWorlds = Language.GetTextValue("Mods.AlchemistNPC.EaterOfWorlds");
            string BrainOfCthulhu = Language.GetTextValue("Mods.AlchemistNPC.BrainOfCthulhu");
            string QueenBee = Language.GetTextValue("Mods.AlchemistNPC.QueenBee");
            string Skeletron = Language.GetTextValue("Mods.AlchemistNPC.Skeletron");
            string WallOfFlesh = Language.GetTextValue("Mods.AlchemistNPC.WallOfFlesh");
            string QueenSlime = Language.GetTextValue("Mods.AlchemistNPC.QueenSlime");
            string Destroyer = Language.GetTextValue("Mods.AlchemistNPC.Destroyer");
            string Twins = Language.GetTextValue("Mods.AlchemistNPC.Twins");
            string SkeletronPrime = Language.GetTextValue("Mods.AlchemistNPC.SkeletronPrime");
            string Plantera = Language.GetTextValue("Mods.AlchemistNPC.Plantera");
            string EmpressOfLight = Language.GetTextValue("Mods.AlchemistNPC.EmpressOfLight");
            string Golem = Language.GetTextValue("Mods.AlchemistNPC.Golem");
            string Betsy = Language.GetTextValue("Mods.AlchemistNPC.Betsy");
            string DukeFishron = Language.GetTextValue("Mods.AlchemistNPC.DukeFishron");
            string MoonLord = Language.GetTextValue("Mods.AlchemistNPC.MoonLord");
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            //SBMW:CalamityMod
            string DesertScourge = Language.GetTextValue("Mods.AlchemistNPC.DesertScourge");
            string Crabulon = Language.GetTextValue("Mods.AlchemistNPC.Crabulon");
            string HiveMind = Language.GetTextValue("Mods.AlchemistNPC.HiveMind");
            string Perforator = Language.GetTextValue("Mods.AlchemistNPC.Perforator");
            string SlimeGod = Language.GetTextValue("Mods.AlchemistNPC.SlimeGod");
            string Cryogen = Language.GetTextValue("Mods.AlchemistNPC.Cryogen");
            string BrimstoneElemental = Language.GetTextValue("Mods.AlchemistNPC.BrimstoneElemental");
            string AquaticScourge = Language.GetTextValue("Mods.AlchemistNPC.AquaticScourge");
            string Calamitas = Language.GetTextValue("Mods.AlchemistNPC.Calamitas");
            string AstrageldonSlime = Language.GetTextValue("Mods.AlchemistNPC.AstrageldonSlime");
            string AstrumDeus = Language.GetTextValue("Mods.AlchemistNPC.AstrumDeus");
            string Leviathan = Language.GetTextValue("Mods.AlchemistNPC.Leviathan");
            string PlaguebringerGoliath = Language.GetTextValue("Mods.AlchemistNPC.PlaguebringerGoliath");
            string Ravager = Language.GetTextValue("Mods.AlchemistNPC.Ravager");
            string Providence = Language.GetTextValue("Mods.AlchemistNPC.Providence");
            string Polterghast = Language.GetTextValue("Mods.AlchemistNPC.Polterghast");
			string OldDuke = Language.GetTextValue("Mods.AlchemistNPC.OldDuke");
            string DevourerofGods = Language.GetTextValue("Mods.AlchemistNPC.DevourerofGods");
            string Bumblebirb = Language.GetTextValue("Mods.AlchemistNPC.Bumblebirb");
            string Yharon = Language.GetTextValue("Mods.AlchemistNPC.Yharon");

            //SBMW:ThoriumMod
			string DarkMage = Language.GetTextValue("Mods.AlchemistNPC.DarkMage");
			string Ogre = Language.GetTextValue("Mods.AlchemistNPC.Ogre");
            string ThunderBird = Language.GetTextValue("Mods.AlchemistNPC.ThunderBird");
            string QueenJellyfish = Language.GetTextValue("Mods.AlchemistNPC.QueenJellyfish");
			string CountEcho = Language.GetTextValue("Mods.AlchemistNPC.CountEcho");
            string GraniteEnergyStorm = Language.GetTextValue("Mods.AlchemistNPC.GraniteEnergyStorm");
            string TheBuriedChampion = Language.GetTextValue("Mods.AlchemistNPC.TheBuriedChampion");
            string TheStarScouter = Language.GetTextValue("Mods.AlchemistNPC.TheStarScouter");
            string BoreanStrider = Language.GetTextValue("Mods.AlchemistNPC.BoreanStrider");
            string CoznixTheFallenBeholder = Language.GetTextValue("Mods.AlchemistNPC.CoznixTheFallenBeholder");
            string TheLich = Language.GetTextValue("Mods.AlchemistNPC.TheLich");
            string AbyssionTheForgottenOne = Language.GetTextValue("Mods.AlchemistNPC.AbyssionTheForgottenOne");
            string TheRagnarok = Language.GetTextValue("Mods.AlchemistNPC.TheRagnarok");
			
			//ElementsAwoken
			string Wasteland = Language.GetTextValue("Mods.AlchemistNPC.Wasteland");
			string Infernace = Language.GetTextValue("Mods.AlchemistNPC.Infernace");
			string ScourgeFighter = Language.GetTextValue("Mods.AlchemistNPC.ScourgeFighter");
			string Regaroth = Language.GetTextValue("Mods.AlchemistNPC.Regaroth");
			string TheCelestials = Language.GetTextValue("Mods.AlchemistNPC.TheCelestials");
			string Permafrost = Language.GetTextValue("Mods.AlchemistNPC.Permafrost");
			string Obsidious = Language.GetTextValue("Mods.AlchemistNPC.Obsidious");
			string Aqueous = Language.GetTextValue("Mods.AlchemistNPC.Aqueous");
			string TempleKeepers = Language.GetTextValue("Mods.AlchemistNPC.TempleKeepers");
			string Guardian = Language.GetTextValue("Mods.AlchemistNPC.Guardian");
			string Volcanox = Language.GetTextValue("Mods.AlchemistNPC.Volcanox");
			string VoidLevi = Language.GetTextValue("Mods.AlchemistNPC.VoidLevi");
			string Azana = Language.GetTextValue("Mods.AlchemistNPC.Azana");
			string Ancients = Language.GetTextValue("Mods.AlchemistNPC.Ancients");
			
			//Redemption
			string KingChicken = Language.GetTextValue("Mods.AlchemistNPC.KingChicken");
			string ThornBane = Language.GetTextValue("Mods.AlchemistNPC.ThornBane");
			string TheKeeper = Language.GetTextValue("Mods.AlchemistNPC.TheKeeper");
			string XenoCrystal = Language.GetTextValue("Mods.AlchemistNPC.XenoCrystal");
			string IEye = Language.GetTextValue("Mods.AlchemistNPC.IEye");
			string KingSlayer = Language.GetTextValue("Mods.AlchemistNPC.KingSlayer");
			string V1 = Language.GetTextValue("Mods.AlchemistNPC.V1");
			string V2 = Language.GetTextValue("Mods.AlchemistNPC.V2");
			string V3 = Language.GetTextValue("Mods.AlchemistNPC.V3");
			string PZ = Language.GetTextValue("Mods.AlchemistNPC.PZ");
			string ThornRematch = Language.GetTextValue("Mods.AlchemistNPC.ThornRematch");
			string Nebuleus = Language.GetTextValue("Mods.AlchemistNPC.Nebuleus");
			
			//SacredTools
			string Decree = Language.GetTextValue("Mods.AlchemistNPC.Decree");
			string FlamingPumpkin = Language.GetTextValue("Mods.AlchemistNPC.FlamingPumpkin");
            string Jensen = Language.GetTextValue("Mods.AlchemistNPC.Jensen");
			string Araneas = Language.GetTextValue("Mods.AlchemistNPC.Araneas");
			string Raynare = Language.GetTextValue("Mods.AlchemistNPC.Raynare");
			string Primordia = Language.GetTextValue("Mods.AlchemistNPC.Primordia");
            string Abaddon = Language.GetTextValue("Mods.AlchemistNPC.Abaddon");
            string Araghur = Language.GetTextValue("Mods.AlchemistNPC.Araghur");
            string Lunarians = Language.GetTextValue("Mods.AlchemistNPC.Lunarians");
            string Challenger = Language.GetTextValue("Mods.AlchemistNPC.Challenger");
			string Spookboi = Language.GetTextValue("Mods.AlchemistNPC.Spookboi");
			
			//SpiritMod
			string Scarabeus = Language.GetTextValue("Mods.AlchemistNPC.Scarabeus");
            string Bane = Language.GetTextValue("Mods.AlchemistNPC.Bane");
			string Flier = Language.GetTextValue("Mods.AlchemistNPC.Flier");
            string Raider = Language.GetTextValue("Mods.AlchemistNPC.Raider");
            string Infernon = Language.GetTextValue("Mods.AlchemistNPC.Infernon");
            string Dusking = Language.GetTextValue("Mods.AlchemistNPC.Dusking");
            string EtherialUmbra = Language.GetTextValue("Mods.AlchemistNPC.EtherialUmbra");
			string IlluminantMaster = Language.GetTextValue("Mods.AlchemistNPC.IlluminantMaster");
			string Atlas = Language.GetTextValue("Mods.AlchemistNPC.Atlas");
			string Overseer = Language.GetTextValue("Mods.AlchemistNPC.Overseer");
			
			//Enigma
			string Sharkron = Language.GetTextValue("Mods.AlchemistNPC.Sharkron");
            string Hypothema = Language.GetTextValue("Mods.AlchemistNPC.Hypothema");
			string Ragnar = Language.GetTextValue("Mods.AlchemistNPC.Ragnar");
            string AnDio = Language.GetTextValue("Mods.AlchemistNPC.AnDio");
            string Annihilator = Language.GetTextValue("Mods.AlchemistNPC.Annihilator");
            string Slybertron = Language.GetTextValue("Mods.AlchemistNPC.Slybertron");
            string SteamTrain = Language.GetTextValue("Mods.AlchemistNPC.SteamTrain");
			
			//pinky
			string SunlightTrader = Language.GetTextValue("Mods.AlchemistNPC.SunlightTrader");
            string THOFC = Language.GetTextValue("Mods.AlchemistNPC.THOFC");
			string MythrilSlime = Language.GetTextValue("Mods.AlchemistNPC.MythrilSlime");
            string Valdaris = Language.GetTextValue("Mods.AlchemistNPC.Valdaris");
            string Gatekeeper = Language.GetTextValue("Mods.AlchemistNPC.Gatekeeper");
			
			//AAMod
			string Monarch = Language.GetTextValue("Mods.AlchemistNPC.Monarch");
            string Grips = Language.GetTextValue("Mods.AlchemistNPC.Grips");
			string Broodmother = Language.GetTextValue("Mods.AlchemistNPC.Broodmother");
            string Hydra = Language.GetTextValue("Mods.AlchemistNPC.Hydra");
			string Serpent = Language.GetTextValue("Mods.AlchemistNPC.Serpent");
            string Djinn = Language.GetTextValue("Mods.AlchemistNPC.Djinn");
			string Retriever = Language.GetTextValue("Mods.AlchemistNPC.Retriever");
			string RaiderU = Language.GetTextValue("Mods.AlchemistNPC.RaiderU");
			string Orthrus = Language.GetTextValue("Mods.AlchemistNPC.Orthrus");
			string EFish = Language.GetTextValue("Mods.AlchemistNPC.EFish");
			string Nightcrawler = Language.GetTextValue("Mods.AlchemistNPC.Nightcrawler");
			string Daybringer = Language.GetTextValue("Mods.AlchemistNPC.Daybringer");
			string Yamata = Language.GetTextValue("Mods.AlchemistNPC.Yamata");
			string Akuma = Language.GetTextValue("Mods.AlchemistNPC.Akuma");
			string Zero = Language.GetTextValue("Mods.AlchemistNPC.Zero");
			string Shen = Language.GetTextValue("Mods.AlchemistNPC.Shen");
			string ShenGrips = Language.GetTextValue("Mods.AlchemistNPC.ShenGrips");
			*/

            if (item.type == ModContent.ItemType<Items.Misc.KnucklesBag>())
            {
                TooltipLine line = new TooltipLine(Mod, "Knuckles", Knuckles);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ModContent.ItemType<Items.Misc.BillCipherBag>())
            {
                TooltipLine line = new TooltipLine(Mod, "BillCipher", BillCipher);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.KingSlimeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "KingSlime", KingSlime);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "EyeofCthulhu", EyeofCthulhu);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.EaterOfWorldsBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "EaterOfWorlds", EaterOfWorlds);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.BrainOfCthulhuBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "BrainOfCthulhu", BrainOfCthulhu);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.QueenBeeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "QueenBeeBossBag", QueenBee);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.SkeletronBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Skeletron", Skeletron);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "WallOfFleshBoss", WallOfFlesh);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.QueenSlimeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "QueenSlime", QueenSlime);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.DestroyerBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Destroyer", Destroyer);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.TwinsBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Twins", Twins);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.SkeletronPrimeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "SkeletronPrime", SkeletronPrime);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.PlanteraBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Plantera", Plantera);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.FairyQueenBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Empress of Light", EmpressOfLight);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.GolemBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Golem", Golem);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.BossBagBetsy)
            {
                TooltipLine line = new TooltipLine(Mod, "Betsy", Betsy);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.FishronBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "DukeFishron", DukeFishron);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.MoonLordBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "MoonLord", MoonLord);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "DesertScourge", DesertScourge);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Crabulon", Crabulon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "HiveMind", HiveMind);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Perforator", Perforator);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "SlimeGod", SlimeGod);

                line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Cryogen", Cryogen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "BrimstoneElemental", BrimstoneElemental);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "AquaticScourge", AquaticScourge);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Calamitas", Calamitas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "AstrageldonSlime", AstrageldonSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "AstrumDeus", AstrumDeus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Leviathan", Leviathan);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "PlaguebringerGoliath", PlaguebringerGoliath);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Ravager", Ravager);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Providence", Providence);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Polterghast", Polterghast);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("OldDukeBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "OldDuke", OldDuke);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "DevourerofGods", DevourerofGods);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Bumblebirb", Bumblebirb);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("YharonBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Yharon", Yharon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "DarkMage", DarkMage);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Ogre", Ogre);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "ThunderBird", ThunderBird);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "QueenJellyfish", QueenJellyfish);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("CountBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "CountEcho", CountEcho);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "GraniteEnergyStorm", GraniteEnergyStorm);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "TheBuriedChampion", TheBuriedChampion);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "TheStarScouter", TheStarScouter);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "BoreanStrider", BoreanStrider);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "CoznixTheFallenBeholder", CoznixTheFallenBeholder);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("LichBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "TheLich", TheLich);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "AbyssionTheForgottenOne", AbyssionTheForgottenOne);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("RagBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "TheRagnarok", TheRagnarok);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("AAMod") != null)
			{
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("MonarchBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Monarch", Monarch);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Grips", Grips);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("BroodBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Broodmother", Broodmother);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("HydraBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Hydra", Hydra);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("SerpentBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Serpent", Serpent);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("DjinnBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Djinn", Djinn);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("RetrieverBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Retriever", Retriever);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("RaiderBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "RaiderU", RaiderU);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("OrthrusBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Orthrus", Orthrus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("EFishBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "EFish", EFish);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("DBBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Daybringer", Daybringer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("NCBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Nightcrawler", Nightcrawler);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("YamataBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Yamata", Yamata);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("AkumaBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Akuma", Akuma);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("ZeroBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Zero", Zero);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("ShenCache")))
				{
				TooltipLine line = new TooltipLine(Mod, "Shen", Shen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripSBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "ShenGrips", ShenGrips);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("ElementsAwoken") != null)
			{
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Wasteland", Wasteland);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Infernace", Infernace);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "ScourgeFighter", ScourgeFighter);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Regaroth", Regaroth);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("TheCelestialBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "TheCelestials", TheCelestials);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Permafrost", Permafrost);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Obsidious", Obsidious);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Aqueous", Aqueous);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "TempleKeepers", TempleKeepers);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Guardian", Guardian);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("VolcanoxBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Volcanox", Volcanox);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "VoidLevi", VoidLevi);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Azana", Azana);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Ancients", Ancients);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("KingChickenBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "KingChicken", KingChicken);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("ThornBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "ThornBane", ThornBane);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("TheKeeperBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "TheKeeper", TheKeeper);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "XenoCrystal", XenoCrystal);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("InfectedEyeBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "IEye", IEye);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("SlayerBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "KingSlayer", KingSlayer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("VlitchCleaverBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "V1", V1);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("VlitchGigipedeBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "V2", V2);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("OmegaOblitBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "V3", V3);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("PZBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "PZ", PZ);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("ThornPZBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "ThornRematch", ThornRematch);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Redemption").ItemType("NebBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Nebuleus", Nebuleus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("SacredTools") != null)
			{
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("DecreeBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Decree", Decree);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "FlamingPumpkin", FlamingPumpkin);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Jensen", Jensen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("AraneasBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Araneas", Araneas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2")))
				{
				TooltipLine line = new TooltipLine(Mod, "Raynare", Raynare);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PrimordiaBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Primordia", Primordia);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("OblivionBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Abaddon", Abaddon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SerpentBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Araghur", Araghur);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("LunarBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Lunarians", Lunarians);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Challenger", Challenger);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SpookboiBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Spookboi", Spookboi);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("SpiritMod") != null)
			{
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs")))
				{
				TooltipLine line = new TooltipLine(Mod, "Scarabeus", Scarabeus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Bane", Bane);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Flier", Flier);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Raider", Raider);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Infernon", Infernon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Dusking", Dusking);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "EqualityComparer", EtherialUmbra);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "IlluminantMaster", IlluminantMaster);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Atlas", Atlas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Overseer", Overseer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("Laugicality") != null)
			{
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Sharkron", Sharkron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Hypothema", Hypothema);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Ragnar", Ragnar);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "AnDio", AnDio);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Annihilator", Annihilator);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Slybertron", Slybertron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "SteamTrain", SteamTrain);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("pinkymod") != null)
			{
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("STBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "SunlightTrader", SunlightTrader);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "THOFC", THOFC);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("MythrilBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "MythrilSlime", MythrilSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("Valdabag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Valdaris", Valdaris);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag")))
				{
				TooltipLine line = new TooltipLine(Mod, "Gatekeeper", Gatekeeper);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			*/
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && Main.rand.Next(150) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Equippable.TimeTwistBraclet>());
            }
            if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Equippable.SuspiciousLookingScythe>());
            }
            if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Equippable.HeartofYuiS>());
            }
            if (Main.hardMode && context == "bossBag" && Main.rand.Next(150) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Misc.StatsChecker>());
            }
            if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(200) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.BanHammer>());
            }
            if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.PinkGuyHead>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.PinkGuyBody>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.PinkGuyLegs>());
            }
            if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.BlackCatHead>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.BlackCatBody>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.BlackCatLegs>());
            }
            if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.Skyline222Hair>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.Skyline222Body>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.Skyline222Legs>());
            }
            if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(150) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.somebody0214Hood>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.somebody0214Robe>());
            }
            if (NPC.downedPlantBoss && context == "bossBag" && Main.rand.Next(250) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.BloodMoonCirclet>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.BloodMoonDress>());
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.BloodMoonStockings>());
            }
            if (NPC.downedMoonlord && context == "bossBag" && Main.rand.Next(300) == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<Items.Armor.StrangeTopHat>());
            }
        }

        public override void VerticalWingSpeeds(Item item, Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            if (modPlayer.BetsyBooster == 1)
            {
                maxCanAscendMultiplier += 1f;
                maxAscentMultiplier += 1f;
            }
        }

        public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)
        {
            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            if (modPlayer.BetsyBooster == 1)
            {
                speed += 0.1f;
                acceleration += 0.1f;
            }
            if (player.HasBuff(ModContent.BuffType<Buffs.Exhausted>()))
            {
                speed *= 0.8f;
                acceleration *= 0.8f;
            }
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).chargetime >= 390)
            {
                speed *= 0.75f;
                acceleration *= 0.75f;
            }
            else if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).chargetime >= 210)
            {
                speed *= 0.9f;
                acceleration *= 0.9f;
            }
        }

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
    }
}

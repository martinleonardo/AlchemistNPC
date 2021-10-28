using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Linq;
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
using AlchemistNPC.Interface;
using AlchemistNPC.Items;
using AlchemistNPC.Mounts;

namespace AlchemistNPC
{
    public class AlchemistNPCPlayer : ModPlayer
    {
        public int Shield = 0;
        public int Timer = 0;
        public int fc = 0;
        public bool Barrage = false;
        public bool Blinker = false;
        public bool BoomBox = false;
        public bool MasterYoyoBag = false;
        public bool TimeTwist = false;
        public bool HPJ = false;
        public bool DeltaRune = false;
        public bool PB4K = false;
        public bool PH = false;
        public bool DistantPotionsUse = false;
        public bool Voodoo = false;
        public bool CursedMirror = false;
        public bool ShieldBelt = false;
        public bool MysticAmuletMount = false;
        public bool TerrarianBlock = false;
        public bool Luck = false;
        public bool Illuminati = false;
        public bool AutoinjectorMK2 = false;
        public bool AlchemistCharmTier1 = false;
        public bool AlchemistCharmTier2 = false;
        public bool AlchemistCharmTier3 = false;
        public bool AlchemistCharmTier4 = false;
        public bool BeeHeal = false;
        public bool Pandora = false;
        public bool TS = false;
        public bool Symbiote = false;
        public bool Akumu = false;
        public bool DriedFish = false;
        public bool SolarFish = false;
        public bool NebulaFish = false;
        public bool VortexFish = false;
        public bool StardustFish = false;
        public bool MiniShark = false;
        public bool Manna = false;
        public bool Traps = false;
        public bool Yui = false;
        public bool YuiS = false;
        public bool Extractor = false;
        public bool Scroll = false;
        public bool EyeOfJudgement = false;
        public bool LaetitiaSet = false;
        public bool LaetitiaGift = false;
        public bool SFU = false;
        public bool SF = false;
        public bool PGSWear = false;
        public bool RevSet = false;
        public bool XtraT = false;
        public bool BuffsKeep = false;
        public bool MemersRiposte = false;
        public bool ModPlayer = true;
        public bool lf = false;
        public bool GC = false;
        public int lamp = 0;
        public bool ParadiseLost = false;
        public bool Rampage = false;
        public bool LilithEmblem = false;
        public bool trigger = true;
        public bool turret = false;
        public bool watchercrystal = false;
        public bool devilsknife = false;
        public bool uw = false;
        public bool grimreaper = false;
        public bool snatcher = false;
        public bool rainbowdust = false;
        public bool sscope = false;
        public bool lwm = false;
        public bool DB = false;
        public bool GlobalTeleporter = false;
        public bool GlobalTeleporterUp = false;
        public bool MeatGrinderOnUse = false;

        public bool AllDamage10 = false;
        public bool AllCrit10 = false;
        public bool Defense8 = false;
        public bool DR10 = false;
        public bool Regeneration = false;
        public bool Lifeforce = false;
        public bool MS = false;

        public int DisasterGauge = 0;
        public int chargetime = 0;
        public int MeatGrinderUsetime = 0;

        private const int maxBBP = -1;
        public int BBP = 0;
        private const int maxRCT1 = -1;
        public int RCT1 = 0;
        private const int maxRCT2 = -1;
        public int RCT2 = 0;
        private const int maxRCT3 = -1;
        public int RCT3 = 0;
        private const int maxRCT4 = -1;
        public int RCT4 = 0;
        private const int maxRCT5 = -1;
        public int RCT5 = 0;
        private const int maxRCT6 = -1;
        public int RCT6 = 0;
        private const int maxSnatcherCounter = -1;
        public int SnatcherCounter = 0;
        private const int maxLifeElixir = 2;
        public int LifeElixir = 0;
        private const int maxFuaran = 1;
        public int Fuaran = 0;
        private const int maxKeepBuffs = 1;
        public int KeepBuffs = 0;
        private const int maxWellFed = 1;
        public int WellFed = 0;
        private const int maxBillIsDowned = 1;
        public int BillIsDowned = 0;

        private const int maxKingSlimeBooster = 1;
        public int KingSlimeBooster = 0;
        private const int maxEyeOfCthulhuBooster = 1;
        public int EyeOfCthulhuBooster = 0;
        private const int maxEaterOfWorldsBooster = 1;
        public int EaterOfWorldsBooster = 0;
        private const int maxBrainOfCthulhuBooster = 1;
        public int BrainOfCthulhuBooster = 0;
        private const int maxQueenBeeBooster = 1;
        public int QueenBeeBooster = 0;
        private const int maxSkeletronBooster = 1;
        public int SkeletronBooster = 0;
        private const int maxWoFBooster = 1;
        public int WoFBooster = 0;
        private const int maxDarkMageBooster = 1;
        public int DarkMageBooster = 0;
        private const int maxDestroyerBooster = 1;
        public int DestroyerBooster = 0;
        private const int maxCustomBooster1 = 1;
        public int CustomBooster1 = 0;
        private const int maxCustomBooster2 = 1;
        public int CustomBooster2 = 0;
        private const int maxPrimeBooster = 1;
        public int PrimeBooster = 0;
        private const int maxTwinsBooster = 1;
        public int TwinsBooster = 0;
        private const int maxPlanteraBooster = 1;
        public int PlanteraBooster = 0;
        private const int maxIceGolemBooster = 1;
        public int IceGolemBooster = 0;
        private const int maxPigronBooster = 1;
        public int PigronBooster = 0;
        private const int maxOgreBooster = 1;
        public int OgreBooster = 0;
        private const int maxGolemBooster = 1;
        public int GolemBooster = 0;
        private const int maxBetsyBooster = 1;
        public int BetsyBooster = 0;
        private const int maxGSummonerBooster = 1;
        public int GSummonerBooster = 0;
        private const int maxFishronBooster = 1;
        public int FishronBooster = 0;
        private const int maxMartianSaucerBooster = 1;
        public int MartianSaucerBooster = 0;
        private const int maxCultistBooster = 1;
        public int CultistBooster = 0;
        private const int maxMoonLordBooster = 1;
        public int MoonLordBooster = 0;

        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        public override void ResetEffects()
        {
            if (AlchemistNPCWorld.foundAntiBuffMode)
            {
                Player.AddBuff(ModContent.BuffType<Buffs.AntiBuff>(), 2);
            }
            if (Shield < 0)
            {
                Shield = 0;
            }
            Item.potionDelay = 3600;
            Barrage = false;
            Blinker = false;
            BoomBox = false;
            MasterYoyoBag = false;
            TimeTwist = false;
            HPJ = false;
            DeltaRune = false;
            PH = false;
            PB4K = false;
            DistantPotionsUse = false;
            CursedMirror = false;
            Voodoo = false;
            ShieldBelt = false;
            MysticAmuletMount = false;
            Luck = false;
            TerrarianBlock = false;
            AlchemistGlobalItem.Luck = false;
            AlchemistGlobalItem.Luck2 = false;
            AlchemistGlobalItem.PerfectionToken = false;
            AlchemistGlobalItem.Menacing = false;
            AlchemistGlobalItem.Lucky = false;
            AlchemistGlobalItem.Violent = false;
            AlchemistGlobalItem.Warding = false;
            AlchemistNPC.BastScroll = false;
            AlchemistNPC.Stormbreaker = false;
            MeatGrinderOnUse = false;
            AlchemistCharmTier1 = false;
            AlchemistCharmTier2 = false;
            AlchemistCharmTier3 = false;
            AlchemistCharmTier4 = false;
            Illuminati = false;
            BeeHeal = false;
            Pandora = false;
            TS = false;
            Symbiote = false;
            DriedFish = false;
            SolarFish = false;
            NebulaFish = false;
            VortexFish = false;
            StardustFish = false;
            MiniShark = false;
            Manna = false;
            Akumu = false;
            AutoinjectorMK2 = false;
            EyeOfJudgement = false;
            LaetitiaSet = false;
            LaetitiaGift = false;
            Scroll = false;
            SFU = false;
            SF = false;
            XtraT = false;
            RevSet = false;
            MemersRiposte = false;
            PGSWear = false;
            Extractor = false;
            ParadiseLost = false;
            Rampage = false;
            LilithEmblem = false;
            turret = false;
            watchercrystal = false;
            devilsknife = false;
            uw = false;
            grimreaper = false;
            snatcher = false;
            rainbowdust = false;
            sscope = false;
            lwm = false;
            Yui = false;
            YuiS = false;
            Traps = false;
            GlobalTeleporter = false;
            GlobalTeleporterUp = false;

            AllDamage10 = false;
            AllCrit10 = false;
            Defense8 = false;
            DR10 = false;
            Regeneration = false;
            Lifeforce = false;
            MS = false;

            Player.statLifeMax2 += LifeElixir * 50;
            Player.statManaMax2 += Fuaran * 100;

            if (KeepBuffs == 1)
            {
                BuffsKeep = true;
                Player.pStone = true;
            }
            if (KeepBuffs == 0)
            {
                BuffsKeep = false;
            }
            if (WellFed == 1)
            {
                Player.AddBuff(BuffID.WellFed, 2);
            }
            if (BillIsDowned == 1)
            {
                Player.AddBuff(ModContent.BuffType<Buffs.DemonSlayer>(), 2);
            }
            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    ShopChangeUI.visible = false;
                    ShopChangeUIA.visible = false;
                    ShopChangeUIO.visible = false;
                    ShopChangeUIM.visible = false;
                    ShopChangeUIT.visible = false;
                }
            }
            if (AlchemistNPC.modConfiguration.CoinsDrop)
            {
                if (ShopChangeUIO.visible)
                {
                    CoinsConvertMenu.visible = true;
                }
                else CoinsConvertMenu.visible = false;
            }
            if (Player.talkNPC == -1)
            {
                for (int index1 = 0; index1 < 40; ++index1)
                {
                    if (Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier1>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier2>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier3>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier4>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier5>() || Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier6>())
                    {
                        Player.bank3.item[index1].TurnToAir();
                    }
                }
            }
        }

        public override void PostBuyItem(NPC vendor, Item[] shopInventory, Item item)
        {
            bool Casket = false;
            for (int j = 0; j < Player.inventory.Length; j++)
            {
                if (Player.inventory[j].type == ModContent.ItemType<Items.Misc.DimensionalCasket>())
                {
                    Casket = true;
                    break;
                }
            }
            if (vendor.type == NPCType<NPCs.Operator>() || Casket)
            {
                for (int index1 = 0; index1 < 40; ++index1)
                {
                    if (Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier1>())
                    {
                        RCT1 = Player.bank3.item[index1].stack;
                        continue;
                    }
                    if (Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier2>())
                    {
                        RCT2 = Player.bank3.item[index1].stack;
                        continue;
                    }
                    if (Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier3>())
                    {
                        RCT3 = Player.bank3.item[index1].stack;
                        continue;
                    }
                    if (Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier4>())
                    {
                        RCT4 = Player.bank3.item[index1].stack;
                        continue;
                    }
                    if (Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier5>())
                    {
                        RCT5 = Player.bank3.item[index1].stack;
                        continue;
                    }
                    if (Player.bank3.item[index1].type == ModContent.ItemType<Items.Misc.ReversivityCoinTier6>())
                    {
                        RCT6 = Player.bank3.item[index1].stack;
                        break;
                    }
                }
            }
        }

        public static void ConvertCoins(int tier = 0)
        {
            Player player = Main.LocalPlayer;
            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            switch (tier)
            {
                case 0: break;
                case 1: modPlayer.RCT2 -= 1; modPlayer.RCT1 += 2; break;
                case 2: modPlayer.RCT3 -= 1; modPlayer.RCT2 += 2; break;
                case 3: modPlayer.RCT4 -= 1; modPlayer.RCT3 += 2; break;
                case 4: modPlayer.RCT5 -= 1; modPlayer.RCT4 += 2; break;
                case 5: modPlayer.RCT6 -= 1; modPlayer.RCT5 += 2; break;
            }
        }

        public override bool CanBeHitByProjectile(Projectile projectile)
        {
            if (Player.HasBuff(ModContent.BuffType<Buffs.Akumu>()) || Player.HasBuff(ModContent.BuffType<Buffs.TrueAkumu>()))
            {
                return false;
            }
            return true;
        }

        public override void clientClone(ModPlayer clientClone)
        {
            AlchemistNPCPlayer clone = clientClone as AlchemistNPCPlayer;
            clone.RCT1 = RCT1;
            clone.RCT2 = RCT2;
            clone.RCT3 = RCT3;
            clone.RCT4 = RCT4;
            clone.RCT5 = RCT5;
            clone.RCT6 = RCT6;
            clone.BBP = BBP;
            clone.SnatcherCounter = SnatcherCounter;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.LifeAndManaSync);
            packet.Write((byte)Player.whoAmI);
            packet.Write(LifeElixir);
            packet.Write(Fuaran);
            packet.Write(KeepBuffs);
            packet.Write(WellFed);
            packet.Write(BillIsDowned);
            packet.Write(RCT1);
            packet.Write(RCT2);
            packet.Write(RCT3);
            packet.Write(RCT4);
            packet.Write(RCT5);
            packet.Write(RCT6);
            packet.Write(BBP);
            packet.Write(SnatcherCounter);

            packet.Write(KingSlimeBooster);
            packet.Write(EyeOfCthulhuBooster);
            packet.Write(EaterOfWorldsBooster);
            packet.Write(BrainOfCthulhuBooster);
            packet.Write(QueenBeeBooster);
            packet.Write(SkeletronBooster);
            packet.Write(WoFBooster);
            packet.Write(DarkMageBooster);
            packet.Write(CustomBooster1);
            packet.Write(CustomBooster2);
            packet.Write(DestroyerBooster);
            packet.Write(PrimeBooster);
            packet.Write(TwinsBooster);
            packet.Write(IceGolemBooster);
            packet.Write(PigronBooster);
            packet.Write(OgreBooster);
            packet.Write(PlanteraBooster);
            packet.Write(GolemBooster);
            packet.Write(BetsyBooster);
            packet.Write(GSummonerBooster);
            packet.Write(FishronBooster);
            packet.Write(MartianSaucerBooster);
            packet.Write(CultistBooster);
            packet.Write(MoonLordBooster);
            packet.Send(toWho, fromWho);
        }

        public override void OnEnterWorld(Player player)
        {
            string enterText = Language.GetTextValue("Mods.AlchemistNPC.enterText");
            if (AlchemistNPC.modConfiguration.StartMessage)
            {
                Main.NewText(enterText, 0, 255, 255);
            }
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            AlchemistNPCPlayer clone = clientPlayer as AlchemistNPCPlayer;
            if (clone.BBP != BBP || clone.SnatcherCounter != SnatcherCounter || clone.RCT1 != RCT1 || clone.RCT2 != RCT2 || clone.RCT3 != RCT3 || clone.RCT4 != RCT4 || clone.RCT5 != RCT5 || clone.RCT6 != RCT6)
            {
                var packet = Mod.GetPacket();
                packet.Write((byte)AlchemistNPC.AlchemistNPCMessageType.SyncPlayerVariables);
                packet.Write((byte)Player.whoAmI);
                packet.Write(RCT1);
                packet.Write(RCT2);
                packet.Write(RCT3);
                packet.Write(RCT4);
                packet.Write(RCT5);
                packet.Write(RCT6);
                packet.Write(BBP);
                packet.Write(SnatcherCounter);
                packet.Send();
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag["LifeElixir"] = LifeElixir;
            tag["Fuaran"] = Fuaran;
            tag["KeepBuffs"] = KeepBuffs;
            tag["WellFed"] = WellFed;
            tag["BillIsDowned"] = BillIsDowned;
            tag["RCT1"] = RCT1;
            tag["RCT2"] = RCT2;
            tag["RCT3"] = RCT3;
            tag["RCT4"] = RCT4;
            tag["RCT5"] = RCT5;
            tag["RCT6"] = RCT6;
            tag["BBP"] = BBP;
            tag["SnatcherCounter"] = SnatcherCounter;

            tag["KingSlimeBooster"] = KingSlimeBooster;
            tag["EyeOfCthulhuBooster"] = EyeOfCthulhuBooster;
            tag["EaterOfWorldsBooster"] = EaterOfWorldsBooster;
            tag["BrainOfCthulhuBooster"] = BrainOfCthulhuBooster;
            tag["QueenBeeBooster"] = QueenBeeBooster;
            tag["SkeletronBooster"] = SkeletronBooster;
            tag["WoFBooster"] = WoFBooster;
            tag["DarkMageBooster"] = DarkMageBooster;
            tag["CustomBooster1"] = CustomBooster1;
            tag["CustomBooster2"] = CustomBooster2;
            tag["DestroyerBooster"] = DestroyerBooster;
            tag["PrimeBooster"] = PrimeBooster;
            tag["TwinsBooster"] = TwinsBooster;
            tag["IceGolemBooster"] = IceGolemBooster;
            tag["PigronBooster"] = PigronBooster;
            tag["OgreBooster"] = OgreBooster;
            tag["PlanteraBooster"] = PlanteraBooster;
            tag["GolemBooster"] = GolemBooster;
            tag["BetsyBooster"] = BetsyBooster;
            tag["GSummonerBooster"] = GSummonerBooster;
            tag["FishronBooster"] = FishronBooster;
            tag["MartianSaucerBooster"] = MartianSaucerBooster;
            tag["CultistBooster"] = CultistBooster;
            tag["MoonLordBooster"] = MoonLordBooster;
        }

        public override void LoadData(TagCompound tag)
        {
            LifeElixir = tag.GetInt("LifeElixir");
            Fuaran = tag.GetInt("Fuaran");
            KeepBuffs = tag.GetInt("KeepBuffs");
            WellFed = tag.GetInt("WellFed");
            BillIsDowned = tag.GetInt("BillIsDowned");
            RCT1 = tag.GetInt("RCT1");
            RCT2 = tag.GetInt("RCT2");
            RCT3 = tag.GetInt("RCT3");
            RCT4 = tag.GetInt("RCT4");
            RCT5 = tag.GetInt("RCT5");
            RCT6 = tag.GetInt("RCT6");
            BBP = tag.GetInt("BBP");
            SnatcherCounter = tag.GetInt("SnatcherCounter");

            KingSlimeBooster = tag.GetInt("KingSlimeBooster");
            EyeOfCthulhuBooster = tag.GetInt("EyeOfCthulhuBooster");
            EaterOfWorldsBooster = tag.GetInt("EaterOfWorldsBooster");
            BrainOfCthulhuBooster = tag.GetInt("BrainOfCthulhuBooster");
            QueenBeeBooster = tag.GetInt("QueenBeeBooster");
            SkeletronBooster = tag.GetInt("SkeletronBooster");
            WoFBooster = tag.GetInt("WoFBooster");
            DarkMageBooster = tag.GetInt("DarkMageBooster");
            CustomBooster1 = tag.GetInt("CustomBooster1");
            CustomBooster2 = tag.GetInt("CustomBooster2");
            DestroyerBooster = tag.GetInt("DestroyerBooster");
            PrimeBooster = tag.GetInt("PrimeBooster");
            TwinsBooster = tag.GetInt("TwinsBooster");
            IceGolemBooster = tag.GetInt("IceGolemBooster");
            PigronBooster = tag.GetInt("PigronBooster");
            OgreBooster = tag.GetInt("OgreBooster");
            PlanteraBooster = tag.GetInt("PlanteraBooster");
            GolemBooster = tag.GetInt("GolemBooster");
            BetsyBooster = tag.GetInt("BetsyBooster");
            GSummonerBooster = tag.GetInt("GSummonerBooster");
            FishronBooster = tag.GetInt("FishronBooster");
            MartianSaucerBooster = tag.GetInt("MartianSaucerBooster");
            CultistBooster = tag.GetInt("CultistBooster");
            MoonLordBooster = tag.GetInt("MoonLordBooster");
        }

        public override void AnglerQuestReward(float quality, List<Item> rewardItems)
        {
            if (DriedFish)
            {
                Item vobla = new Item();
                vobla.SetDefaults(ModContent.ItemType<Items.Weapons.DriedFish>());
                vobla.stack = 1;
                rewardItems.Add(vobla);
            }
            if (SolarFish)
            {
                Item solar = new Item();
                solar.SetDefaults(ItemID.FragmentSolar);
                solar.stack = 25;
                rewardItems.Add(solar);
            }
            if (NebulaFish)
            {
                Item nebula = new Item();
                nebula.SetDefaults(ItemID.FragmentNebula);
                nebula.stack = 25;
                rewardItems.Add(nebula);
            }
            if (VortexFish)
            {
                Item vortex = new Item();
                vortex.SetDefaults(ItemID.FragmentVortex);
                vortex.stack = 25;
                rewardItems.Add(vortex);
            }
            if (StardustFish)
            {
                Item stardust = new Item();
                stardust.SetDefaults(ItemID.FragmentStardust);
                stardust.stack = 25;
                rewardItems.Add(stardust);
            }
            if (MiniShark)
            {
                Item minishark = new Item();
                minishark.SetDefaults(ItemID.Minishark);
                minishark.stack = 1;
                rewardItems.Add(minishark);
            }
            if (Manna)
            {
                Item manna = new Item();
                manna.SetDefaults(ModContent.ItemType<Items.Misc.MannafromHeaven>());
                manna.stack = 1;
                rewardItems.Add(manna);
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType)
        {
            if (questFish == ModContent.ItemType<Items.QuestFishes.MutantFish>() && Main.rand.Next(8) == 0)
            {
                caughtType = ModContent.ItemType<Items.QuestFishes.MutantFish>();
            }
            if (Player.ZoneTowerSolar && questFish == ModContent.ItemType<Items.QuestFishes.SolarFish>() && Main.rand.Next(5) == 0)
            {
                caughtType = ModContent.ItemType<Items.QuestFishes.SolarFish>();
            }
            if (Player.ZoneTowerNebula && questFish == ModContent.ItemType<Items.QuestFishes.NebulaFish>() && Main.rand.Next(5) == 0)
            {
                caughtType = ModContent.ItemType<Items.QuestFishes.NebulaFish>();
            }
            if (Player.ZoneTowerVortex && questFish == ModContent.ItemType<Items.QuestFishes.VortexFish>() && Main.rand.Next(5) == 0)
            {
                caughtType = ModContent.ItemType<Items.QuestFishes.VortexFish>();
            }
            if (Player.ZoneTowerStardust && questFish == ModContent.ItemType<Items.QuestFishes.StardustFish>() && Main.rand.Next(5) == 0)
            {
                caughtType = ModContent.ItemType<Items.QuestFishes.StardustFish>();
            }
            if (Player.ZoneBeach && questFish == ModContent.ItemType<Items.QuestFishes.MiniShark>() && Main.rand.Next(8) == 0)
            {
                caughtType = ModContent.ItemType<Items.QuestFishes.MiniShark>();
            }
            if (Player.ZoneDesert && questFish == ModContent.ItemType<Items.QuestFishes.MosesFish>() && Main.rand.Next(20) == 0 && power < 55)
            {
                caughtType = ModContent.ItemType<Items.QuestFishes.MosesFish>();
            }
            if (Player.ZoneDesert && questFish == ModContent.ItemType<Items.QuestFishes.MosesFish>() && Main.rand.Next(10) == 0 && power >= 55)
            {
                caughtType = ModContent.ItemType<Items.QuestFishes.MosesFish>();
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (target.friendly == false)
            {
                if (GSummonerBooster == 1)
                {
                    target.buffImmune[153] = false;
                    target.AddBuff(153, 300);
                }
                if (BetsyBooster == 1)
                {
                    target.buffImmune[189] = false;
                    target.AddBuff(189, 300);
                }
                if (Illuminati)
                {
                    target.buffImmune[BuffID.Midas] = false;
                    target.AddBuff(BuffID.Midas, 600);
                }
                if (Player.HasBuff(ModContent.BuffType<Buffs.RainbowFlaskBuff>()))
                {
                    target.buffImmune[BuffID.BetsysCurse] = false;
                    target.buffImmune[BuffID.Ichor] = false;
                    target.buffImmune[BuffID.Daybreak] = false;
                    target.AddBuff(ModContent.BuffType<Buffs.Corrosion>(), 600);
                    target.AddBuff(BuffID.BetsysCurse, 600);
                    target.AddBuff(BuffID.Ichor, 600);
                    target.AddBuff(BuffID.Daybreak, 600);
                }
                if (Player.HasBuff(ModContent.BuffType<Buffs.BigBirdLamp>()))
                {
                    target.AddBuff(BuffID.Ichor, 600);
                    if (NPC.downedPlantBoss) target.buffImmune[BuffID.Ichor] = false;
                    if (NPC.downedGolemBoss) target.AddBuff(BuffID.BetsysCurse, 600);
                    if (NPC.downedMoonlord) target.buffImmune[BuffID.BetsysCurse] = false;
                }
                if (Scroll)
                {
                    if (target.type != NPCType<NPCs.Knuckles>())
                    {
                        target.buffImmune[ModContent.BuffType<Buffs.ArmorDestruction>()] = false;
                        target.AddBuff(ModContent.BuffType<Buffs.ArmorDestruction>(), 600);
                        target.defense = 0;
                    }
                }
                if (Player.HasBuff(ModContent.BuffType<Buffs.ExplorersBrew>()))
                {
                    target.AddBuff(ModContent.BuffType<Buffs.Electrocute>(), 600);
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (target.friendly == false)
            {
                if (GSummonerBooster == 1)
                {
                    target.buffImmune[153] = false;
                    target.AddBuff(153, 300);
                }
                if (BetsyBooster == 1)
                {
                    target.buffImmune[189] = false;
                    target.AddBuff(189, 300);
                }
                if (Illuminati)
                {
                    target.buffImmune[BuffID.Midas] = false;
                    target.AddBuff(BuffID.Midas, 600);
                }
                if (Player.HasBuff(ModContent.BuffType<Buffs.RainbowFlaskBuff>()))
                {
                    target.buffImmune[BuffID.BetsysCurse] = false;
                    target.buffImmune[BuffID.Ichor] = false;
                    target.buffImmune[BuffID.Daybreak] = false;
                    target.AddBuff(ModContent.BuffType<Buffs.Corrosion>(), 600);
                    target.AddBuff(BuffID.BetsysCurse, 600);
                    target.AddBuff(BuffID.Ichor, 600);
                    target.AddBuff(BuffID.Daybreak, 600);
                }
                if (Player.HasBuff(ModContent.BuffType<Buffs.BigBirdLamp>()))
                {
                    target.AddBuff(BuffID.Ichor, 600);
                    if (NPC.downedPlantBoss) target.buffImmune[BuffID.Ichor] = false;
                    if (NPC.downedGolemBoss) target.AddBuff(BuffID.BetsysCurse, 600);
                    if (NPC.downedMoonlord) target.buffImmune[BuffID.BetsysCurse] = false;
                }
                if (proj.DamageType == DamageClass.Throwing && Scroll)
                {
                    if (target.type != NPCType<NPCs.Knuckles>())
                    {
                        target.buffImmune[ModContent.BuffType<Buffs.ArmorDestruction>()] = false;
                        target.AddBuff(ModContent.BuffType<Buffs.ArmorDestruction>(), 600);
                    }
                }
                if ((proj.type == ProjectileID.Electrosphere) && XtraT)
                {
                    target.AddBuff(ModContent.BuffType<Buffs.Electrocute>(), 600);
                }
                if (Player.HasBuff(ModContent.BuffType<Buffs.ExplorersBrew>()))
                {
                    target.AddBuff(ModContent.BuffType<Buffs.Electrocute>(), 600);
                }
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (Player.HasBuff(ModContent.BuffType<Buffs.TrueUganda>()))
            {
                damageSource = PlayerDeathReason.ByCustomReason(Player.name + " DIDN NO DE WEI!");
            }
            if (NPC.AnyNPCs(NPCType<NPCs.Knuckles>()))
            {
                damageSource = PlayerDeathReason.ByCustomReason(Player.name + " DIDN NO DE WEI!");
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                Mod ALIB = ModLoader.GetMod("AchievementLib");
                if (ALIB != null)
                {
                    ALIB.Call("UnlockGlobal", "AlchemistNPC", "You don't know da wae!");
                }
                */
            }
            if (NPC.AnyNPCs(NPCType<NPCs.BillCipher>()))
            {
                damageSource = PlayerDeathReason.ByCustomReason(Player.name + " was evaporated by the new master of this world.");
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                Mod ALIB = ModLoader.GetMod("AchievementLib");
                if (ALIB != null)
                {
                    ALIB.Call("UnlockGlobal", "AlchemistNPC", "If you will excuse me...");
                }
                */
            }
            if (Illuminati && !Player.HasBuff(ModContent.BuffType<Buffs.IlluminatiCooldown>()) && !Player.HasBuff(ModContent.BuffType<Buffs.MindBurn>()) && !Player.HasBuff(ModContent.BuffType<Buffs.TrueUganda>()))
            {
                Player.statLife = 1;
                return false;
            }
            return true;
        }

        public override void OnRespawn(Player player)
        {
            if (NPC.AnyNPCs(NPCID.Nurse) && AlchemistNPCWorld.foundPHD && (player == Main.player[Main.myPlayer]))
            {
                int num1 = Player.statLifeMax2 - Player.statLife;
                int num2 = (int)((double)num1 * 0.75);
                if (num2 < 1)
                {
                    num2 = 1;
                }
                HealingUI.visible = true;
                if (Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
                {
                    Main.NewText("[c/00FF00:护士]: 您需要支付" + Math.Truncate((double)num2 / 100) + "银" + (num2 - (Math.Truncate((double)num2 / 100) * 100)) + "铜作为医疗费.", 0, 0, 0);
                }
                else
                {
                    Main.NewText("[c/00FF00:Nurse]: You need " + Math.Truncate((double)num2 / 100) + " silver coins and " + (num2 - (Math.Truncate((double)num2 / 100) * 100)) + " copper coins to pay the doctor's fee.", 0, 0, 0);
                }
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (GlobalTeleporter || GlobalTeleporterUp)
            {
                bool allow = true;
                for (int v = 0; v < 200; ++v)
                {
                    NPC npc = Main.npc[v];
                    if (npc.active && npc.boss)
                    {
                        allow = false;
                        break;
                    }
                }
                if (GlobalTeleporterUp && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                {
                    int mapWidth = Main.maxTilesX * 16;
                    int mapHeight = Main.maxTilesY * 16;
                    Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

                    cursorPosition.X -= Main.screenWidth / 2;
                    cursorPosition.Y -= Main.screenHeight / 2;

                    Vector2 mapPosition = Main.mapFullscreenPos;
                    Vector2 cursorWorldPosition = mapPosition;

                    cursorPosition /= 16;
                    cursorPosition *= 16 / Main.mapFullscreenScale;
                    cursorWorldPosition += cursorPosition;
                    cursorWorldPosition *= 16;

                    cursorWorldPosition.Y -= Player.height;
                    if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
                    else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
                    if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
                    else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

                    Player.Teleport(cursorWorldPosition, 0, 0);
                    NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)cursorWorldPosition.X, (float)cursorWorldPosition.Y, 1, 0, 0);
                    Main.mapFullscreen = false;

                    for (int index = 0; index < 120; ++index)
                        Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
                }
                if (GlobalTeleporter && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                {
                    int mapWidth = Main.maxTilesX * 16;
                    int mapHeight = Main.maxTilesY * 16;
                    Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

                    cursorPosition.X -= Main.screenWidth / 2;
                    cursorPosition.Y -= Main.screenHeight / 2;

                    Vector2 mapPosition = Main.mapFullscreenPos;
                    Vector2 cursorWorldPosition = mapPosition;

                    cursorPosition /= 16;
                    cursorPosition *= 16 / Main.mapFullscreenScale;
                    cursorWorldPosition += cursorPosition;
                    cursorWorldPosition *= 16;

                    cursorWorldPosition.Y -= Player.height;
                    if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
                    else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
                    if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
                    else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

                    Player.Teleport(cursorWorldPosition, 0, 0);
                    NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)cursorWorldPosition.X, (float)cursorWorldPosition.Y, 1, 0, 0);
                    Main.mapFullscreen = false;
                    Item[] inventory = Player.inventory;
                    for (int k = 0; k < inventory.Length; k++)
                    {
                        if (inventory[k].type == ModContent.ItemType<Items.Misc.GlobalTeleporter>())
                        {
                            inventory[k].stack--;
                            break;
                        }
                    }
                    for (int index = 0; index < 120; ++index)
                        Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
                }
            }
            if (AlchemistNPC.LampLight.JustPressed)
            {
                if (lamp == 0 && trigger)
                {
                    trigger = false;
                    lamp++;
                    lf = true;
                }
                if (lamp == 1 && !trigger && !lf)
                {
                    trigger = true;
                    lamp = 0;
                }
                lf = false;
            }
            if (Blinker)
            {
                if (Timer < 60) Timer++;
                if (Timer >= 60)
                {
                    if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[2] > 0)
                    {
                        Terraria.Audio.SoundEngine.PlaySound(2, (int)Player.position.X, (int)Player.position.Y, 15);
                        Timer = 0;
                        Vector2 pp = new Vector2(Player.position.X + 300, Player.position.Y);
                        if (!Collision.SolidCollision(pp, Player.width, Player.height))
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                Player.position.X += 50;
                                for (int index = 0; index < 30; ++index)
                                    Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
                            }
                            if (Player.velocity.X < 0) Player.velocity.X *= -1;
                            Player.velocity.X += 6f;
                        }
                        else
                        {
                            if (Player.velocity.X < 0) Player.velocity.X *= -1;
                            Player.velocity.X += 16f;
                        }
                    }
                    if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[3] > 0)
                    {
                        Terraria.Audio.SoundEngine.PlaySound(2, (int)Player.position.X, (int)Player.position.Y, 15);
                        Timer = 0;
                        Vector2 pp = new Vector2(Player.position.X - 300, Player.position.Y);
                        if (!Collision.SolidCollision(pp, Player.width, Player.height))
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                Player.position.X -= 50;
                                for (int index = 0; index < 30; ++index)
                                    Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
                            }
                            if (Player.velocity.X > 0) Player.velocity.X *= -1;
                            Player.velocity.X += -6f;
                        }
                        else
                        {
                            if (Player.velocity.X > 0) Player.velocity.X *= -1;
                            Player.velocity.X += -16f;
                        }

                    }
                }

            }
            if (AlchemistNPC.PipBoyTP.JustPressed && PB4K)
            {
                PipBoyTPMenu.visible = true;
            }
            if (DistantPotionsUse && PlayerInput.Triggers.Current.QuickBuff)
            {
                LegacySoundStyle type1 = (LegacySoundStyle)null;
                for (int index1 = 0; index1 < 40; ++index1)
                {
                    if (Player.CountBuffs() == 22)
                        return;
                    if (Player.bank.item[index1].stack > 0 && Player.bank.item[index1].type > 0 && (Player.bank.item[index1].buffType > 0 && Player.bank.item[index1].DamageType != DamageClass.Summon) && Player.bank.item[index1].buffType != 90)
                    {
                        // IMPLEMENT WHEN WEAKREFERENCES FIXED
                        /*
						if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (Player.bank.item[index1].buffType == ModLoader.GetMod("CalamityMod").BuffType("AbsoluteRage"))
							{
								for (int v = 0; v < 200; ++v)
								{
									NPC npc = Main.npc[v];
									if (npc.active && npc.boss)
									{
										return;
									}
								}
								CalamityRage(player);
							}
						}
						*/
                        int type2 = Player.bank.item[index1].buffType;
                        bool flag = true;
                        for (int index2 = 0; index2 < 22; ++index2)
                        {
                            if (type2 == 27 && (Player.buffType[index2] == type2 || Player.buffType[index2] == 101 || Player.buffType[index2] == 102))
                            {
                                flag = false;
                                break;
                            }
                            if (Player.buffType[index2] == type2)
                            {
                                flag = false;
                                break;
                            }
                            if (Main.meleeBuff[type2] && Main.meleeBuff[Player.buffType[index2]])
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (Main.lightPet[Player.bank.item[index1].buffType] || Main.vanityPet[Player.bank.item[index1].buffType])
                        {
                            for (int index2 = 0; index2 < 22; ++index2)
                            {
                                if (Main.lightPet[Player.buffType[index2]] && Main.lightPet[Player.bank.item[index1].buffType])
                                    flag = false;
                                if (Main.vanityPet[Player.buffType[index2]] && Main.vanityPet[Player.bank.item[index1].buffType])
                                    flag = false;
                            }
                        }
                        if (Player.bank.item[index1].mana > 0 & flag)
                        {
                            if (Player.statMana >= (int)((double)Player.bank.item[index1].mana * (double)Player.manaCost))
                            {
                                Player.manaRegenDelay = (int)Player.maxRegenDelay;
                                Player.statMana = Player.statMana - (int)((double)Player.bank.item[index1].mana * (double)Player.manaCost);
                            }
                            else
                                flag = false;
                        }
                        if (Player.whoAmI == Main.myPlayer && Player.bank.item[index1].type == 603 && !Main.runningCollectorsEdition)
                            flag = false;
                        if (type2 == 27)
                        {
                            type2 = Main.rand.Next(3);
                            if (type2 == 0)
                                type2 = 27;
                            if (type2 == 1)
                                type2 = 101;
                            if (type2 == 2)
                                type2 = 102;
                        }
                        if (flag)
                        {
                            type1 = Player.bank.item[index1].UseSound;
                            int time1 = Player.bank.item[index1].buffTime;
                            if (time1 == 0)
                                time1 = 3600;
                            if (KeepBuffs == 1)
                            {
                                time1 *= 2;
                            }
                            if (AlchemistCharmTier4)
                            {
                                time1 += time1 / 2;
                            }
                            else if (AlchemistCharmTier3)
                            {
                                time1 += (time1 / 20) * 7;
                            }
                            else if (AlchemistCharmTier2)
                            {
                                time1 += time1 / 4;
                            }
                            else if (AlchemistCharmTier1)
                            {
                                time1 += time1 / 10;
                            }

                            Player.AddBuff(type2, time1, true);

                            if (Player.bank.item[index1].consumable)
                            {
                                if (AlchemistCharmTier4 == true)
                                {
                                    // IMPLEMENT WHEN WEAKREFERENCES FIXED
                                    /*
                                    Mod Calamity = ModLoader.GetMod("CalamityMod");
                                    if (Calamity != null)
                                    {
                                        if ((bool)Calamity.Call("Downed", "supreme calamitas"))
                                        {
                                        }
                                        else if (Main.rand.NextFloat() >= .25f)
                                        {
                                        }
                                        else
                                        {
                                            --Player.bank.item[index1].stack;
                                        }
                                    }
                                    else */
                                    if (Main.rand.NextFloat() >= .25f)
                                    {
                                    }
                                    else
                                    {
                                        --Player.bank.item[index1].stack;
                                    }
                                }

                                else if (AlchemistCharmTier3 == true)
                                {
                                    if (Main.rand.Next(2) == 0)
                                    {
                                    }
                                    else
                                    {
                                        --Player.bank.item[index1].stack;
                                    }
                                }

                                else if (AlchemistCharmTier2 == true)
                                {
                                    if (Main.rand.Next(4) == 0)
                                    {
                                    }
                                    else
                                    {
                                        --Player.bank.item[index1].stack;
                                    }
                                }

                                else if (AlchemistCharmTier1 == true)
                                {
                                    if (Main.rand.Next(10) == 0)
                                    {
                                    }
                                    else
                                    {
                                        --Player.bank.item[index1].stack;
                                    }
                                }
                                else
                                {
                                    --Player.bank.item[index1].stack;
                                }
                                if (Player.bank.item[index1].stack <= 0)
                                    Player.bank.item[index1].TurnToAir();
                            }
                        }
                    }
                }
                if (type1 == null)
                    return;
                Terraria.Audio.SoundEngine.PlaySound(type1, Player.position);
                Recipe.FindRecipes();
            }
            if (AlchemistNPC.DiscordBuff.JustPressed)
            {
                if (Main.myPlayer == Player.whoAmI && Player.HasBuff(ModContent.BuffType<Buffs.DiscordBuff>()))
                {
                    Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    if (!Collision.SolidCollision(vector2, Player.width, Player.height))
                    {
                        Player.Teleport(vector2, 1, 0);
                        NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)vector2.X, (float)vector2.Y, 1, 0, 0);
                        if (Player.chaosState)
                        {
                            Player.statLife = Player.statLife - Player.statLifeMax2 / 3;
                            PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                            if (Main.rand.Next(2) == 0)
                                damageSource = PlayerDeathReason.ByOther(Player.Male ? 14 : 15);
                            if (Player.statLife <= 0)
                                Player.KillMe(damageSource, 1.0, 0, false);
                            Player.lifeRegenCount = 0;
                            Player.lifeRegenTime = 0;
                        }
                        Player.AddBuff(88, 600, true);
                        Player.AddBuff(164, 60, true);
                    }
                }
                if (Main.myPlayer == Player.whoAmI && Player.HasBuff(ModContent.BuffType<Buffs.TrueDiscordBuff>()))
                {
                    Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    if (!Collision.SolidCollision(vector2, Player.width, Player.height))
                    {
                        Player.Teleport(vector2, 1, 0);
                        NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)vector2.X, (float)vector2.Y, 1, 0, 0);
                        if (Player.chaosState)
                        {
                            Player.statLife = Player.statLife - Player.statLifeMax2 / 7;
                            PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                            if (Main.rand.Next(2) == 0)
                                damageSource = PlayerDeathReason.ByOther(Player.Male ? 14 : 15);
                            if (Player.statLife <= 0)
                                Player.KillMe(damageSource, 1.0, 0, false);
                            Player.lifeRegenCount = 0;
                            Player.lifeRegenTime = 0;
                        }
                        Player.AddBuff(88, 360, true);
                    }
                }
            }
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        private void CalamityRage(Player player)
        {
            CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = Player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            CalamityPlayer.rage = CalamityPlayer.rageMax;
        }
		*/
        /*public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ModContent.ItemType<Items.Misc.AntiBuffItem>());
            item.stack = 1;
            itemsByMod["AlchemistNPC"].Add(item);
        }*/

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            return new[] {
                new Item(ModContent.ItemType<Items.Misc.AntiBuffItem>())
            };
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (Player.HasBuff(ModContent.BuffType<Buffs.GuarantCrit>()) && crit)
            {
                damage *= 2;
                GC = false;
            }
            if (Player.HasBuff(ModContent.BuffType<Buffs.ExecutionersEyes>()) && crit && Main.rand.Next(20) == 0)
            {
                damage *= 2;
            }
            if (MemersRiposte && crit)
            {
                damage *= 2;
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (Player.HeldItem.type == ModContent.ItemType<Items.Weapons.Penetrator>() && crit)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        damage += damage / 2;
                        break;
                    case 1:
                        damage += damage;
                        break;
                    case 2:
                        damage += (damage / 2) * 3;
                        break;
                    case 3:
                        damage += damage * 2;
                        break;
                }
            }
            if (Player.HasBuff(ModContent.BuffType<Buffs.GuarantCrit>()) && crit)
            {
                damage *= 2;
                GC = false;
            }
            if (Player.HasBuff(ModContent.BuffType<Buffs.ExecutionersEyes>()) && crit && Main.rand.Next(20) == 0)
            {
                damage *= 2;
            }
            if (MemersRiposte && crit)
            {
                damage *= 2;
            }
            if (proj.type == ProjectileType<Projectiles.DemonicBullet>() && crit && Main.rand.Next(200) == 0)
            {
                damage = 33333;
            }
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (SnatcherCounter >= 12500 && Player.HasBuff(ModContent.BuffType<Buffs.Snatcher>()))
            {
                Projectile.NewProjectile(Player.GetProjectileSource_Buff(ModContent.BuffType<Buffs.Snatcher>()), npc.Center.X, npc.Center.Y, 0f, 0f, ProjectileType<Projectiles.Returner2>(), damage * 10, 0, Player.whoAmI);
            }
            if (QueenBeeBooster == 1)
            {
                var hornet = new List<int>();
                for (int k = -65; k < -56; k++)
                {
                    hornet.Add(k);
                }
                for (int j = -21; j < -18; j++)
                {
                    hornet.Add(j);
                }
                hornet.Add(42);
                hornet.Add(176);
                for (int l = 231; l < 235; l++)
                {
                    hornet.Add(l);
                }
                hornet.Add(210);
                hornet.Add(211);
                for (int choose = 0; choose < hornet.Count; choose++)
                {
                    if (npc.type == hornet[choose])
                    {
                        damage /= 2;
                    }
                }
            }
            if (SkeletronBooster == 1)
            {
                var skeleton = new List<int>();
                for (int a = -53; a < -46; a++)
                {
                    skeleton.Add(a);
                }
                for (int b = 201; b < 203; b++)
                {
                    skeleton.Add(b);
                }
                for (int c = 291; c < 293; c++)
                {
                    skeleton.Add(c);
                }
                for (int d = 322; d < 324; d++)
                {
                    skeleton.Add(d);
                }
                for (int e = 449; e < 452; e++)
                {
                    skeleton.Add(e);
                }
                skeleton.Add(-15);
                skeleton.Add(21);
                skeleton.Add(77);
                skeleton.Add(110);
                skeleton.Add(481);
                skeleton.Add(566);
                skeleton.Add(567);
                for (int choose1 = 0; choose1 < skeleton.Count; choose1++)
                {
                    if (npc.type == skeleton[choose1])
                    {
                        damage /= 2;
                    }
                }
            }
            if (CultistBooster == 1)
            {
                var pillare = new List<int>();
                for (int a1 = 402; a1 < 429; a1++)
                {
                    pillare.Add(a1);
                }
                for (int choose2 = 0; choose2 < pillare.Count; choose2++)
                {
                    if (npc.type == pillare[choose2])
                    {
                        damage -= damage / 3;
                    }
                }
            }
            if (MoonLordBooster == 1)
            {
                damage -= damage / 10;
            }
            if (npc.type == NPCType<NPCs.BillCipher>())
            {
                Player.AddBuff(ModContent.BuffType<Buffs.MindBurn>(), 1200);
            }
            if (TerrarianBlock && Main.dayTime)
            {
                damage -= damage / 3;
            }
            if (Illuminati)
            {
                Vector2 vel = new Vector2(0, -1);
                vel *= 0f;
                Projectile.NewProjectile(npc.GetProjectileSpawnSource(), Player.Center.X, Player.Center.Y, vel.X, vel.Y, ProjectileType<Projectiles.IlluminatiFreeze>(), 0, 0, Player.whoAmI);
            }
            if (MemersRiposte)
            {
                Vector2 vel = new Vector2(0, -1);
                vel *= 0f;
                Projectile.NewProjectile(npc.GetProjectileSpawnSource(), Player.Center.X, Player.Center.Y, vel.X, vel.Y, ProjectileType<Projectiles.Returner>(), damage * 5, 0, Player.whoAmI);
            }
            if (Shield > 0)
            {
                int damage2 = damage;
                damage -= Shield;
                Shield -= damage2;
            }
            if (Player.HasBuff(ModContent.BuffType<Buffs.Judgement>()))
            {
                if (Main.rand.Next(3) == 0)
                {
                    damage = 2;
                }
            }
            if (ParadiseLost)
            {
                damage -= 100;
            }
        }

        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            if (QueenBeeBooster == 1)
            {
                if (proj.type == ProjectileID.Stinger)
                {
                    damage /= 2;
                }
            }
            if (CultistBooster == 1)
            {
                var pillarp = new List<int>();
                pillarp.Add(537);
                pillarp.Add(538);
                pillarp.Add(539);
                for (int a1 = 573; a1 < 581; a1++)
                {
                    pillarp.Add(a1);
                }
                pillarp.Add(607);
                pillarp.Add(629);
                for (int choose = 0; choose < pillarp.Count; choose++)
                {
                    if (proj.type == pillarp[choose])
                    {
                        damage -= damage / 3;
                    }
                }
            }
            if (MoonLordBooster == 1)
            {
                damage -= damage / 10;
            }
            if (TerrarianBlock && !Main.dayTime)
            {
                damage -= damage / 3;
            }
            if (Illuminati)
            {
                Vector2 vel = new Vector2(0, -1);
                vel *= 0f;
                Projectile.NewProjectile(proj.GetProjectileSource_FromThis(), Player.Center.X, Player.Center.Y, vel.X, vel.Y, ProjectileType<Projectiles.IlluminatiFreeze>(), 0, 0, Player.whoAmI);
            }
            if (MemersRiposte)
            {
                Vector2 vel = new Vector2(0, -1);
                vel *= 0f;
                Projectile.NewProjectile(proj.GetProjectileSource_FromThis(), Player.Center.X, Player.Center.Y, vel.X, vel.Y, ProjectileType<Projectiles.Returner>(), damage * 5, 0, Player.whoAmI);
            }
            if (Shield > 0)
            {
                int damage2 = damage;
                damage -= Shield;
                Shield -= damage2;
            }
            if (Player.HasBuff(ModContent.BuffType<Buffs.Judgement>()))
            {
                if (Main.rand.Next(3) == 0)
                {
                    damage = 2;
                }
            }
            if (ParadiseLost)
            {
                damage -= 100;
            }
        }

        //public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        public override void UpdateEquips()
        {
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            Mod Calamity = ModLoader.GetMod("CalamityMod");
            if (Calamity != null)
            {
                if (!Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("HolyWrathBuff")) && AllDamage10) Player.GetDamage(DamageClass.Generic) += 0.1f;
                if (!Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("ProfanedRageBuff")) && AllCrit10)
                {
                    Player.GetCritChance(DamageClass.Melee) += 10;
                    Player.GetCritChance(DamageClass.Ranged) += 10;
                    Player.GetCritChance(DamageClass.Magic) += 10;
                    Player.GetCritChance(DamageClass.Throwing) += 10;
                    if (ModLoader.GetMod("ThoriumMod") != null)
                    {
                        ThoriumBoosts(player);
                    }
                    if (ModLoader.GetMod("Redemption") != null)
                    {
                        RedemptionBoost(player);
                    }
                    Calamity.Call("AddRogueCrit", player, 10);
                }
                if (!Player.HasBuff(ModContent.BuffType<Buffs.CalamityComb>()) && !Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Cadence")) && Regeneration) Player.lifeRegen += 4;
                if (!Player.HasBuff(ModContent.BuffType<Buffs.CalamityComb>()) && !Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Cadence")) && Lifeforce)
                {
                    Player.lifeForce = true;
                    Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
                }
            }
            if (ModLoader.GetMod("CalamityMod") == null)
            {
                if (AllDamage10) Player.GetDamage(DamageClass.Generic) += 0.1f;
                if (AllCrit10)
                {
                    Player.GetCritChance(DamageClass.Melee) += 10;
                    Player.GetCritChance(DamageClass.Ranged) += 10;
                    Player.GetCritChance(DamageClass.Magic) += 10;
                    Player.GetCritChance(DamageClass.Throwing) += 10;
                    if (ModLoader.GetMod("ThoriumMod") != null)
                    {
                        ThoriumBoosts(player);
                    }
                    if (ModLoader.GetMod("Redemption") != null)
                    {
                        RedemptionBoost(player);
                    }
                }
                if (Regeneration) Player.lifeRegen += 4;
                if (Lifeforce)
                {
                    Player.lifeForce = true;
                    Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
                }
            }
            */
            // DELETE THIS SECTION AFTER IMPLEMENTING COMMENTED OUT CODE
            if (AllDamage10) Player.GetDamage(DamageClass.Generic) += 0.1f;
            if (AllCrit10)
            {
                Player.GetCritChance(DamageClass.Melee) += 10;
                Player.GetCritChance(DamageClass.Ranged) += 10;
                Player.GetCritChance(DamageClass.Magic) += 10;
                Player.GetCritChance(DamageClass.Throwing) += 10;
            }
            if (Regeneration) Player.lifeRegen += 4;
            if (Lifeforce)
            {
                Player.lifeForce = true;
                Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
            }
            // END OF SECTION
            if (MS) Player.moveSpeed += 0.25f;
            if (Defense8) Player.statDefense += 8;
            if (DR10) Player.endurance += 0.1f;
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        private void RedemptionBoost(Player player)
        {
            Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = Player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            RedemptionPlayer.GetCritChance(DamageClass.Druid) += 10;
        }
        private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = Player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.GetCritChance(DamageClass.Symphonic) += 10;
            ThoriumPlayer.GetCritChance(DamageClass.Radiant) += 10;
        }
        */

        public override void PostUpdate()
        {
            if (MysticAmuletMount)
            {
                Player.hairFrame.Y = 5 * Player.hairFrame.Height;
                Player.headFrame.Y = 5 * Player.headFrame.Height;
                Player.legFrame.Y = 5 * Player.legFrame.Height;
            }
            if (AlchemistCharmTier1)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                Mod ALIB = ModLoader.GetMod("AchievementLib");
                if (ALIB != null)
                {
                    ALIB.Call("UnlockGlobal", "AlchemistNPC", "Junior Alchemist");
                }
                */
            }
            if (AlchemistCharmTier4)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                Mod ALIB = ModLoader.GetMod("AchievementLib");
                if (ALIB != null)
                {
                    ALIB.Call("UnlockGlobal", "AlchemistNPC", "Senior Alchemist");
                }
                */
            }
            if (NPC.AnyNPCs(NPCType<NPCs.Explorer>()))
            {
                if (NPC.AnyNPCs(NPCType<NPCs.Alchemist>()) && NPC.AnyNPCs(NPCType<NPCs.Brewer>()) && NPC.AnyNPCs(NPCType<NPCs.Jeweler>()) && NPC.AnyNPCs(NPCType<NPCs.Architect>()) && NPC.AnyNPCs(NPCType<NPCs.Tinkerer>()) && NPC.AnyNPCs(NPCType<NPCs.Operator>()) && NPC.AnyNPCs(NPCType<NPCs.Musician>()) && NPC.AnyNPCs(NPCType<NPCs.YoungBrewer>()))
                {
                    // IMPLEMENT WHEN WEAKREFERENCES FIXED
                    /*
                    Mod ALIB = ModLoader.GetMod("AchievementLib");
                    if (ALIB != null)
                    {
                        ALIB.Call("UnlockGlobal", "AlchemistNPC", "The gang's all here!");
                    }
                    */
                }
            }
        }

        // UPDATE TO 1.4
        /*
        public static readonly PlayerLayer MiscEffects = new PlayerLayer("AlchemistNPC", "MiscEffects", PlayerLayer.MiscEffectsFront, delegate (PlayerDrawInfo drawInfo)
            {
                if (drawInfo.shadow != 0f)
                {
                    return;
                }
                Player drawPlayer = drawInfo.drawPlayer;
                if (drawPlayer.dead)
                {
                    return;
                }
                Mod mod = ModLoader.GetMod("AlchemistNPC");
                AlchemistNPCPlayer modPlayer = drawPlayer.GetModPlayer<AlchemistNPCPlayer>();
                if (modPlayer.MysticAmuletMount && modPlayer.fc <= 10)
                {
                    Texture2D texture = Mod.Assets.Request<Texture2D>("Mounts/MysticAmulet").Value;
                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
                    float strength = 1f;
                    if (strength > 1f)
                    {
                        strength = 2f - strength;
                    }
                    strength = 0.4f + strength * 0.2f;
                    DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * strength, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
                    data.shader = drawInfo.drawPlayer.miscDyes[3].dye;
                    Main.playerDrawData.Add(data);
                }
                if (modPlayer.MysticAmuletMount && modPlayer.fc > 10 && modPlayer.fc <= 20)
                {
                    Texture2D texture = Mod.Assets.Request<Texture2D>("Mounts/MysticAmulet2").Value;
                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
                    float strength = 1f;
                    if (strength > 1f)
                    {
                        strength = 2f - strength;
                    }
                    strength = 0.4f + strength * 0.2f;
                    DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * strength, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
                    data.shader = drawInfo.drawPlayer.miscDyes[3].dye;
                    Main.playerDrawData.Add(data);
                }
                if (modPlayer.MysticAmuletMount && modPlayer.fc > 20 && modPlayer.fc <= 30)
                {
                    Texture2D texture = Mod.Assets.Request<Texture2D>("Mounts/MysticAmulet3").Value;
                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
                    float strength = 1f;
                    if (strength > 1f)
                    {
                        strength = 2f - strength;
                    }
                    strength = 0.4f + strength * 0.2f;
                    DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * strength, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
                    data.shader = drawInfo.drawPlayer.miscDyes[3].dye;
                    Main.playerDrawData.Add(data);
                }
                if (modPlayer.MysticAmuletMount && modPlayer.fc > 30 && modPlayer.fc <= 40)
                {
                    Texture2D texture = Mod.Assets.Request<Texture2D>("Mounts/MysticAmulet4").Value;
                    int drawX = (int)(drawInfo.position.X + drawPlayer.width / 2f - Main.screenPosition.X);
                    int drawY = (int)(drawInfo.position.Y + drawPlayer.height / 2f - Main.screenPosition.Y);
                    float strength = 1f;
                    if (strength > 1f)
                    {
                        strength = 2f - strength;
                    }
                    strength = 0.4f + strength * 0.2f;
                    DrawData data = new DrawData(texture, new Vector2(drawX, drawY), null, Color.White * strength, 0f, new Vector2(texture.Width / 2f, texture.Height / 2f), 1f, SpriteEffects.None, 0);
                    data.shader = drawInfo.drawPlayer.miscDyes[3].dye;
                    Main.playerDrawData.Add(data);
                }
            });

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            MiscEffects.visible = true;
            layers.Add(MiscEffects);
        }
        */
    }
}
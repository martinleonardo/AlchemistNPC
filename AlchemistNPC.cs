using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AlchemistNPC.Interface;
using static Terraria.ModLoader.ModContent;
using Terraria.Achievements;
using Terraria.Localization;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using AlchemistNPC.Items;
using AlchemistNPC.Interface;
using Terraria.Audio;

namespace AlchemistNPC
{
    public class AlchemistNPC : Mod
    {
        public AlchemistNPC()
        {
            ;
        }

        public static Mod Instance;
        internal static AlchemistNPC instance;
        internal static ModConfiguration modConfiguration;
        public static ModKeybind LampLight;
        public static ModKeybind DiscordBuff;
        public static ModKeybind PipBoyTP;
        public static bool SF = false;
        public static bool GreaterDangersense = false;
        public static bool BastScroll = false;
        public static bool Stormbreaker = false;
        public static int DTH = 0;
        public static float ppx = 0f;
        public static float ppy = 0f;
        public static string GithubUserName { get { return "VVV101"; } }
        public static string GithubProjectName { get { return "AlchemistNPC"; } }
        public static int ReversivityCoinTier1ID;
        public static int ReversivityCoinTier2ID;
        public static int ReversivityCoinTier3ID;
        public static int ReversivityCoinTier4ID;
        public static int ReversivityCoinTier5ID;
        public static int ReversivityCoinTier6ID;
        public static float volume;

        public override void Load()
        {
            volume = Main.soundVolume;

            Instance = this;
            //ZY:Try to add translation for hotkey, seems worked, but requires to reload mod if change game language 
            string LampLightToggle, DiscordBuffTeleportation, PipBoy;
            if (Language.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese))
            {
                LampLightToggle = "大鸟灯开关";
                DiscordBuffTeleportation = "混沌Buff传送";
                PipBoy = "哔哔小子传送菜单";
            }
            else
            {
                LampLightToggle = "Lamp Light Toggle";
                DiscordBuffTeleportation = "Discord Buff Teleportation";
                PipBoy = "Pip-Boy Teleportation Menu";
            }
            LampLight = KeybindLoader.RegisterKeybind(this, LampLightToggle, "L");
            DiscordBuff = KeybindLoader.RegisterKeybind(this, DiscordBuffTeleportation, "Q");
            PipBoyTP = KeybindLoader.RegisterKeybind(this, PipBoy, "P");
            // UPDATE TO 1.4
            /*
			if (!Main.dedServ)
			{
				AddEquipTexture(null, EquipType.Legs, "somebody0214Robe_Legs", "AlchemistNPC/Items/Armor/somebody0214Robe_Legs");
			}
			*/
            ReversivityCoinTier1ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier1Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier1>(), 999L));
            ReversivityCoinTier2ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier2Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier2>(), 999L));
            ReversivityCoinTier3ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier3Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier3>(), 999L));
            ReversivityCoinTier4ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier4Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier4>(), 999L));
            ReversivityCoinTier5ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier5Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier5>(), 999L));
            ReversivityCoinTier6ID = CustomCurrencyManager.RegisterCurrency(new ReversivityCoinTier6Data(ModContent.ItemType<Items.Misc.ReversivityCoinTier6>(), 999L));
            instance = this;

            SetTranslation();

            if (!Main.dedServ)
            {
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot(this, "Sounds/Music/Deltarune OST - Chaos King"), ModContent.ItemType<Items.Placeable.ChaosKingMusicBox>(), ModContent.TileType<Tiles.ChaosKingMusicBox>());
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot(this, "Sounds/Music/Deltarune OST - Field of Hopes And Dreams"), ModContent.ItemType<Items.Placeable.FieldsMusicBox>(), ModContent.TileType<Tiles.FieldsMusicBox>());
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot(this, "Sounds/Music/Deltarune OST - Lantern"), ModContent.ItemType<Items.Placeable.SheamMusicBox>(), ModContent.TileType<Tiles.SheamMusicBox>());
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot(this, "Sounds/Music/Deltarune OST - The World Revolving"), ModContent.ItemType<Items.Placeable.TheWorldRevolvingMusicBox>(), ModContent.TileType<Tiles.TheWorldRevolvingMusicBox>());
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            Mod ALIB = ModLoader.GetMod("AchievementLib");
            if(ALIB != null)
            {
                ALIB.Call("AddAchievement", Instance, "Junior Alchemist", "Obtain Alchemist Charm tier 1", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/JALocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/JAUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "Senior Alchemist", "Obtain Alchemist Charm tier 4", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/SALocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/SAUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "The gang's all here!", "Find every AlchemistNPC town NPC.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/ANPCLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/ANPCUnlocked"), AchievementCategory.Challenger);
                ALIB.Call("AddAchievement", Instance, "You don't know da wae!", "Die to Ugandan Knuckles.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/UNDLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/UNDUnlocked"), AchievementCategory.Slayer);
                ALIB.Call("AddAchievement", Instance, "Da wae is clear, to the queen!", "Defeat Ugandan Knuckles.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/UNWLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/UNWUnlocked"), AchievementCategory.Slayer);
                ALIB.Call("AddAchievement", Instance, "If you will excuse me...", "Die to Bill Cipher.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/BCDLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/BCDUnlocked"), AchievementCategory.Slayer);
                ALIB.Call("AddAchievement", Instance, "The deal is off!", "Defeat Bill Cipher.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/BCWLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/BCWUnlocked"), AchievementCategory.Slayer);
                ALIB.Call("AddAchievement", Instance, "Well, cheers!", "Craft Wellcheers Vending Machine.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/WCCLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/WCCUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "The snack that smiles back", "Use Wellcheers Vending Machine too many times.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/WCULocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/WCUUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "Spear of Justice", "Obtain the Spear of Justice.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/SJLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/SJUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "if you keep going the way you are now...", "Obtain the Eye of Judgement.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/EJLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/EJUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "you're gonna have a bad time.", "Upgrade the Eye of Judgement.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/EPJLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/EPJUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "Don't worry, mom, I can handle it...", "Obtain a Magic Wand.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/MWLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/MWUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "Dip down!", "Upgrade the Magic Wand once.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/DMWLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/DMWUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "Forbidden magic", "Upgrade the Magic Wand to its maximum power.", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/MMWLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/MMWUnlocked"), AchievementCategory.Challenger);
                ALIB.Call("AddAchievement", Instance, "Pandora's Box", "Obtain a Pandora", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/PLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/PUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "Now you're thinking...", "Obtain Rick Sanchez's Portal Gun", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/PGLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/PGUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "Artificial unintelligence", "Obtain a Portal Turret", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/PTLocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/PTUnlocked"), AchievementCategory.Collector);
                ALIB.Call("AddAchievement", Instance, "The only thing to FEAR", "Obtain the incarnation of FEAR", ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/ALocked"), ModContent.Request<Texture2D>("AlchemistNPC/AchievementLib/AUnlocked"), AchievementCategory.Collector);
            }
            */
        }

        public override void Unload()
        {
            if (Main.soundVolume == 0f) Main.soundVolume = volume;
            Instance = null;
            instance = null;
            LampLight = null;
            DiscordBuff = null;
            PipBoyTP = null;
            modConfiguration = null;
        }

        public override void PostSetupContent()
        {
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			Mod censusMod = ModLoader.GetMod("Census");
			if(censusMod != null)
			{
				censusMod.Call("TownNPCCondition", NPCType("Alchemist"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Brewer"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Jeweler"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Tinkerer"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Architect"), "Have any 3 other NPC present");
				censusMod.Call("TownNPCCondition", NPCType("Operator"), "Defeat Eater of Worlds/Brain of Cthulhu and place [c/00FF00:Wing of the World] (craftable furniture) inside free housing");
				censusMod.Call("TownNPCCondition", NPCType("Musician"), "Defeat Skeletron");
				censusMod.Call("TownNPCCondition", NPCType("Young Brewer"), "World state is Hardmode and both Alchemist and Operator are alive");
				censusMod.Call("TownNPCCondition", NPCType("OtherworldlyPortal"), "Not exactly a Town NPC, one of the steps for saving the Explorer");
				censusMod.Call("TownNPCCondition", NPCType("Explorer"), "Defeat Moon Lord and find the way to use all 9 Torn Notes for saving her");
			}
			*/
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            AlchemistNPCMessageType msgType = (AlchemistNPCMessageType)reader.ReadByte();
            switch (msgType)
            {
                case AlchemistNPCMessageType.LifeAndManaSync:
                    byte playernumber = reader.ReadByte();
                    Player lifeFruitsPlayer = Main.player[playernumber];
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().LifeElixir = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().Fuaran = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().KeepBuffs = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().WellFed = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().BillIsDowned = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().RCT1 = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().RCT2 = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().RCT3 = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().RCT4 = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().RCT5 = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().RCT6 = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().BBP = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().SnatcherCounter = reader.ReadInt32();

                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().KingSlimeBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().EyeOfCthulhuBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().EaterOfWorldsBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().BrainOfCthulhuBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().QueenBeeBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().SkeletronBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().WoFBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().GSummonerBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().PigronBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().DarkMageBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().CustomBooster1 = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().DestroyerBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().PrimeBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().TwinsBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().OgreBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().PlanteraBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().GolemBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().BetsyBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().FishronBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().MartianSaucerBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().CultistBooster = reader.ReadInt32();
                    lifeFruitsPlayer.GetModPlayer<AlchemistNPCPlayer>().MoonLordBooster = reader.ReadInt32();
                    break;
                case AlchemistNPCMessageType.TeleportPlayer:
                    TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
                    break;
                case AlchemistNPCMessageType.SyncPlayerVariables:
                    playernumber = reader.ReadByte();
                    AlchemistNPCPlayer alchemistPlayer = Main.player[playernumber].GetModPlayer<AlchemistNPCPlayer>();
                    alchemistPlayer = Main.player[playernumber].GetModPlayer<AlchemistNPCPlayer>();
                    alchemistPlayer.RCT1 = reader.ReadInt32();
                    alchemistPlayer.RCT2 = reader.ReadInt32();
                    alchemistPlayer.RCT3 = reader.ReadInt32();
                    alchemistPlayer.RCT4 = reader.ReadInt32();
                    alchemistPlayer.RCT5 = reader.ReadInt32();
                    alchemistPlayer.RCT6 = reader.ReadInt32();
                    alchemistPlayer.BBP = reader.ReadInt32();
                    alchemistPlayer.SnatcherCounter = reader.ReadInt32();
                    if (Main.netMode == NetmodeID.Server)
                    {
                        var packet = GetPacket();
                        packet.Write((byte)AlchemistNPCMessageType.SyncPlayerVariables);
                        packet.Write(playernumber);
                        packet.Write(alchemistPlayer.RCT1);
                        packet.Write(alchemistPlayer.RCT2);
                        packet.Write(alchemistPlayer.RCT3);
                        packet.Write(alchemistPlayer.RCT4);
                        packet.Write(alchemistPlayer.RCT5);
                        packet.Write(alchemistPlayer.RCT6);
                        packet.Write(alchemistPlayer.BBP);
                        packet.Write(alchemistPlayer.SnatcherCounter);
                        packet.Send(-1, playernumber);
                    }
                    break;
                default:
                    Logger.Error("AlchemistNPC: Unknown Message type: " + msgType);
                    break;
            }
        }

        public enum AlchemistNPCMessageType : byte
        {
            LifeAndManaSync,
            TeleportPlayer,
            SyncPlayerVariables
        }

        public override void AddRecipeGroups()
        {
            //SBMW:Add translation to RecipeGroups, also requires to reload mod
            string evilBossMask = Language.GetTextValue("Mods.AlchemistNPC.evilBossMask");
            string cultist = Language.GetTextValue("Mods.AlchemistNPC.cultist");
            string tier3HardmodeBar = Language.GetTextValue("Mods.AlchemistNPC.tier3HardmodeBar");
            string hardmodeComponent = Language.GetTextValue("Mods.AlchemistNPC.hardmodeComponent");
            string evilBar = Language.GetTextValue("Mods.AlchemistNPC.evilBar");
            string evilMushroom = Language.GetTextValue("Mods.AlchemistNPC.evilMushroom");
            string evilComponent = Language.GetTextValue("Mods.AlchemistNPC.evilComponent");
            string evilDrop = Language.GetTextValue("Mods.AlchemistNPC.evilDrop");
            string tier2anvil = Language.GetTextValue("Mods.AlchemistNPC.tier2anvil");
            string tier2forge = Language.GetTextValue("Mods.AlchemistNPC.tier2forge");
            string tier1anvil = Language.GetTextValue("Mods.AlchemistNPC.tier1anvil");
            string celestialWings = Language.GetTextValue("Mods.AlchemistNPC.CelestialWings");
            string LunarHamaxe = Language.GetTextValue("Mods.AlchemistNPC.LunarHamaxe");
            string tier3Watch = Language.GetTextValue("Mods.AlchemistNPC.tier3Watch");

            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBossMask, new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + cultist, new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:CultistMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3HardmodeBar, new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:Tier3Bar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + hardmodeComponent, new int[]
         {
                 ItemID.CursedFlame, ItemID.Ichor
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:HardmodeComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBar, new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilBar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilMushroom, new int[]
             {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilMush", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilComponent, new int[]
             {
                 ItemID.ShadowScale, ItemID.TissueSample
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilDrop, new int[]
             {
                 ItemID.RottenChunk, ItemID.Vertebrae
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:EvilDrop", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2anvil, new int[]
             {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2forge, new int[]
             {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyForge", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier1anvil, new int[]
             {
                 ItemID.IronAnvil, ItemID.LeadAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyPreHMAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + celestialWings, new int[]
             {
                 ItemID.WingsSolar, ItemID.WingsNebula, ItemID.WingsStardust, ItemID.WingsVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyCelestialWings", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + LunarHamaxe, new int[]
             {
                 ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.LunarHamaxeVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyLunarHamaxe", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3Watch, new int[]
             {
                 ItemID.GoldWatch, ItemID.PlatinumWatch
             });
            RecipeGroup.RegisterGroup("AlchemistNPC:AnyWatch", group);

        }

        public override void AddRecipes()
        {
            CreateRecipe(ItemID.Sundial)
                .AddIngredient(ItemID.CelestialStone)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe(ItemID.Obsidian, 5)
                .AddIngredient(ItemID.StoneBlock, 10)
                .AddCondition(Recipe.Condition.NearLava)
                .AddCondition(Recipe.Condition.NearWater)
                .Register();

            CreateRecipe(ItemID.HoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Recipe.Condition.NearWater)
                .AddCondition(Recipe.Condition.NearHoney)
                .Register();

            CreateRecipe(ItemID.CrispyHoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Recipe.Condition.NearLava)
                .AddCondition(Recipe.Condition.NearHoney)
                .Register();

            CreateRecipe(ItemID.Stopwatch)
                .AddRecipeGroup("AlchemistNPC:AnyWatch")
                .AddIngredient(ItemID.HermesBoots)
                .AddIngredient(ItemID.Wire, 15)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe(ItemID.DPSMeter)
                .AddRecipeGroup("AlchemistNPC:EvilBar", 10)
                .AddRecipeGroup("AlchemistNPC:AnyWatch")
                .AddIngredient(ItemID.Wire, 25)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe(ItemID.LifeformAnalyzer)
                .AddIngredient(ItemID.TallyCounter)
                .AddIngredient(ItemID.BlackLens)
                .AddIngredient(ItemID.AntlionMandible)
                .AddRecipeGroup("AlchemistNPC:EvilDrop")
                .AddRecipeGroup("AlchemistNPC:EvilComponent")
                .AddIngredient(ItemID.Feather)
                .AddIngredient(ItemID.TatteredCloth)
                .AddIngredient(ItemID.Bone)
                .AddIngredient(ItemID.Wire, 25)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe(ItemID.PurificationPowder, 5)
                .AddIngredient(ItemID.Mushroom)
                .AddIngredient(ItemID.Daybloom)
                .AddTile(TileID.Bottles)
                .Register();

            CreateRecipe(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CorruptSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();

            CreateRecipe(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CrimsonSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();

            CreateRecipe(ItemID.FragmentStardust, 2)
                .AddIngredient(null, "EmagledFragmentation", 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();

            CreateRecipe(ItemID.FragmentNebula, 2)
                .AddIngredient(null, "EmagledFragmentation", 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();

            CreateRecipe(ItemID.FragmentVortex, 2)
                .AddIngredient(null, "EmagledFragmentation", 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();

            CreateRecipe(ItemID.FragmentSolar, 2)
                .AddIngredient(null, "EmagledFragmentation", 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }

        //SBMW:Transtation method
        public void SetTranslation()
        {
            //SBMW:Hotkey
            ModTranslation text = LocalizationLoader.CreateTranslation(this, "LampLightToggle");
            text.SetDefault("Lamp Light Toggle");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "大鸟灯开关");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "DiscordBuffTeleportation");
            text.SetDefault("Discord Buff Teleportation");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混乱药剂传送");
            LocalizationLoader.AddTranslation(text);

            //SBMW:Reversivity Coin
            //SBMW:Russian comes from Items.ReversivityCoin
            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier1");
            text.SetDefault("Reversivity Coin Tier 1");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Первого Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个1级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier2");
            text.SetDefault("Reversivity Coin Tier 2");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Второго Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个2级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier3");
            text.SetDefault("Reversivity Coin Tier 3");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Третьего Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个3级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier4");
            text.SetDefault("Reversivity Coin Tier 4");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Четвертого Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个4级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier5");
            text.SetDefault("Reversivity Coin Tier 5");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Пятого Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个5级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ReversivityCoinTier6");
            text.SetDefault("Reversivity Coin Tier 6");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монета Реверсии Шестого Уровня");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "个6级逆转硬币");
            LocalizationLoader.AddTranslation(text);

            //SBMW:RecipeGroups
            text = LocalizationLoader.CreateTranslation(this, "evilBossMask");
            text.SetDefault("Corruption/Crimson boss mask");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐化/血腥Boss面具");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "cultist");
            text.SetDefault("Cultist Mask/Hood");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪教徒面具/兜帽");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier3HardmodeBar");
            text.SetDefault("Tier 3 Hardmode Bar");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三级肉后锭(精金/钛金)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "hardmodeComponent");
            text.SetDefault("Hardmode Component");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶困难模式材料(咒焰/脓血)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilBar");
            text.SetDefault("Crimson/Corruption bar");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔金/血腥锭");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilMushroom");
            text.SetDefault("Evil Mushroom");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶蘑菇");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilComponent");
            text.SetDefault("Evil Component");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶材料(暗影鳞片/组织样本)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "evilDrop");
            text.SetDefault("Evil Drop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶掉落物(腐肉/椎骨)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier2anvil");
            text.SetDefault("Tier 2 Anvil");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "二级砧(秘银/山铜砧)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier2forge");
            text.SetDefault("Tier 2 Forge");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "二级熔炉(精金/钛金熔炉)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier1anvil");
            text.SetDefault("Tier 1 Anvil");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一级砧(铁/铅砧)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "CelestialWings");
            text.SetDefault("Celestial Wings");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Небесные Крылья");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "四柱翅膀");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "LunarHamaxe");
            text.SetDefault("Lunar Hamaxe");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "四柱工具");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "tier3Watch");
            text.SetDefault("Tier 3 Watch");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三级表(金表/铂金表)");
            LocalizationLoader.AddTranslation(text);


            text = LocalizationLoader.CreateTranslation(this, "enterText");
            text.SetDefault("If you don't like additional content or drops from the mod you could install AlchemistNPC Lite mod instead.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если вам не нравится дополнительный контент - существует облегченная версия (AlchemistNPC Lite).");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果你不喜欢AlchemistNPC中的附加物品或掉落物, 你可以安装 AlchemistNPC Lite 取消他们");
            LocalizationLoader.AddTranslation(text);

            //SBMW:Treasure Bag
            text = LocalizationLoader.CreateTranslation(this, "Knuckles");
            text.SetDefault("Ugandan Knuckles Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Угандского Наклза");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "乌干达宝藏袋");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(this, "BillCipher");
            text.SetDefault("Bill Cipher Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Билла");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "比尔·赛弗宝藏袋");
            LocalizationLoader.AddTranslation(text);
            //SBMW:Vanilla
            text = LocalizationLoader.CreateTranslation(this, "KingSlime");
            text.SetDefault("King Slime Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Короля Слизней");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "史莱姆之王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EyeofCthulhu");
            text.SetDefault("Eye of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Глаза Ктулху");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之眼宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EaterOfWorlds");
            text.SetDefault("Eater Of Worlds Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Пожирателя Миров");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界吞噬者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "BrainOfCthulhu");
            text.SetDefault("Brain Of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Мозга Ктулху");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之脑宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "QueenBee");
            text.SetDefault("Queen Bee Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Королевы Пчел");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蜂后宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Skeletron");
            text.SetDefault("Skeletron Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Скелетрона");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "骷髅王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "WallOfFlesh");
            text.SetDefault("Wall Of Flesh Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Стены Плоти");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血肉之墙宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "QueenSlime");
            text.SetDefault("Queen Slime Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Destroyer");
            text.SetDefault("Destroyer Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Уничтожителя");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机械蠕虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Twins");
            text.SetDefault("Twins Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Близнецов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "双子魔眼宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "SkeletronPrime");
            text.SetDefault("Skeletron Prime Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Скелетрона Прайм");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机械骷髅王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Plantera");
            text.SetDefault("Plantera Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Плантеры");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世纪之花宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EmpressOfLight");
            text.SetDefault("Empress of Light Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Golem");
            text.SetDefault("Golem Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Голема");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "石巨人宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Betsy");
            text.SetDefault("Betsy Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Бетси");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "贝特西宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "DukeFishron");
            text.SetDefault("Duke Fishron Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Герцога Рыброна");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "猪鲨公爵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "MoonLord");
            text.SetDefault("Moon Lord Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Лунного Лорда");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "月亮领主宝藏袋");
            LocalizationLoader.AddTranslation(text);
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            //SBMW:CalamityMod
            text = LocalizationLoader.CreateTranslation(this, "DesertScourge");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Пустынного Бича");
            text.SetDefault("Desert Scourge Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "荒漠灾虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Crabulon");
            text.SetDefault("Crabulon Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Крабулона");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蘑菇螃蟹宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "HiveMind");
            text.SetDefault("The Hive Mind Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Коллективного Разума");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐巢意志宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Perforator");
            text.SetDefault("The Perforators Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Бурителей");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血肉宿主宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "SlimeGod");
            text.SetDefault("The Slime God Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Бога Слизней");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "史莱姆之神宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Cryogen");
            text.SetDefault("Cryogen Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Криогена");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极地之灵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "BrimstoneElemental");
            text.SetDefault("Brimstone Elemental Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Серного Элементаля");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "硫磺火元素宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AquaticScourge");
            text.SetDefault("Aquatic Scourge Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Водного Бича");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "渊海灾虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Calamitas");
            text.SetDefault("Calamitas Doppelganger Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Двойника Каламитас");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "灾厄之影宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AstrageldonSlime");
            text.SetDefault("Astrum Aureus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Звёздного Заразителя");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "白金之星宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AstrumDeus");
            text.SetDefault("Astrum Deus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Звёздного Бога");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星神游龙宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Leviathan");
            text.SetDefault("The Leviathan Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Левиафана");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "利维坦宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "PlaguebringerGoliath");
            text.SetDefault("The Plaguebringer Goliath Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Голиафа-чумоносца");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瘟疫使者歌莉娅宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ravager");
            text.SetDefault("Ravager Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Опустошителя");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "毁灭魔像宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Providence");
            text.SetDefault("Providence Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Провидения");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "亵渎天神宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Polterghast");
            text.SetDefault("Polterghast Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Полтергаста");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "噬魂幽花宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "OldDuke");
            text.SetDefault("The Old Duke Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Старого Герцога");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "DevourerofGods");
            text.SetDefault("The Devourer of Gods Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Пожирателя Богов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神明吞噬者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Bumblebirb");
            text.SetDefault("Bumblebirb Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Шмелептицы");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "嗡嗡蜂鸟宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Yharon");
            text.SetDefault("Jungle Dragon, Yharon Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Дракона Джунглей, Ярона");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "丛林龙宝藏袋");
            LocalizationLoader.AddTranslation(text);

            //SBMW:ThoriumMod
            text = LocalizationLoader.CreateTranslation(this, "DarkMage");
            text.SetDefault("Dark Mage Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Темного Мага");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黑魔法师宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ogre");
            text.SetDefault("Ogre Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Огра");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "食人魔宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ThunderBird");
            text.SetDefault("The Great Thunder Bird Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Великой Птицы-Гром");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "惊雷王鹰宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "QueenJellyfish");
            text.SetDefault("The Queen Jellyfish Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Королевы Медуз");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "水母皇后宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "CountEcho");
            text.SetDefault("Viscount Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蝙蝠子爵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "GraniteEnergyStorm");
            text.SetDefault("Granite Energy Storm Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Гранитного Энергошторма");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "花岗岩流能风暴宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheBuriedChampion");
            text.SetDefault("The Buried Champion Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Похороненного Чемпиона");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "英灵遗骸宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheStarScouter");
            text.SetDefault("The Star Scouter Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星际监察者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "BoreanStrider");
            text.SetDefault("Borean Strider Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极地遁蛛宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "CoznixTheFallenBeholder");
            text.SetDefault("Coznix, The Fallen Beholder Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Козникса, Падшего Наблюдателя");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落注视者·克兹尼格斯宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheLich");
            text.SetDefault("The Lich Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Лича");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巫妖宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AbyssionTheForgottenOne");
            text.SetDefault("Abyssion, The Forgotten One Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Абиссиона, Забытого");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "被遗忘者-深渊之主宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheRagnarok");
            text.SetDefault("The Ragnarok Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Рагнарёка");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "灾难之灵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            //ElementsAwoken
            text = LocalizationLoader.CreateTranslation(this, "Wasteland");
            text.SetDefault("Wasteland Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Infernace");
            text.SetDefault("Infernace Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ScourgeFighter");
            text.SetDefault("Scourge Fighter Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Regaroth");
            text.SetDefault("Regaroth Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheCelestials");
            text.SetDefault("The Celestials Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Permafrost");
            text.SetDefault("Permafrost Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Obsidious");
            text.SetDefault("Obsidious Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Aqueous");
            text.SetDefault("Aqueous Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TempleKeepers");
            text.SetDefault("The Temple Keepers Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Guardian");
            text.SetDefault("The Guardian Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Volcanox");
            text.SetDefault("Volcanox Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "VoidLevi");
            text.SetDefault("Void Leviathan Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Azana");
            text.SetDefault("Azana Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ancients");
            text.SetDefault("The Ancients Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //Redemption
            text = LocalizationLoader.CreateTranslation(this, "KingChicken");
            text.SetDefault("The Mighty King Chicken Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ThornBane");
            text.SetDefault("Thorn, Bane of the Forest Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "TheKeeper");
            text.SetDefault("The Keeper Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "XenoCrystal");
            text.SetDefault("Xenomite Crystal Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "IEye");
            text.SetDefault("Infected Eye Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "KingSlayer");
            text.SetDefault("King Slayer III Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V1");
            text.SetDefault("Vlitch Cleaver Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V2");
            text.SetDefault("Vlitch Gigipede Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "V3");
            text.SetDefault("Omega Obliterator Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "PZ");
            text.SetDefault("Patient Zero Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ThornRematch");
            text.SetDefault("Thorn, Bane of the Forest Rematch Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Nebuleus");
            text.SetDefault("Nebuleus, Angel of the Cosmos Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //SacredTools
            text = LocalizationLoader.CreateTranslation(this, "Decree");
            text.SetDefault("The Decree Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Декри");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "FlamingPumpkin");
            text.SetDefault("The Flaming Pumpkin Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Горящей Тыквы");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Jensen");
            text.SetDefault("Jensen, the Grand Harpy Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Дженсен, Великой Гарпии");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巨型鸟妖詹森宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Araneas");
            text.SetDefault("Araneas Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Аранеи");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Raynare");
            text.SetDefault("Harpy Queen, Raynare Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Рейнейр, Королевы Гарпий");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "鸟妖女王雷纳宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Primordia");
            text.SetDefault("Primordia Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Примордии");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Abaddon");
            text.SetDefault("Abaddon, the Emissary of Nightmares Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Абаддона, Эмиссара Кошмаров");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "梦魇使者亚巴顿宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Araghur");
            text.SetDefault("Araghur, the Flare Serpent Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Арагура, Огненного Змия");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "熔火巨蟒宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Lunarians");
            text.SetDefault("The Lunarians Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Лунарианов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "月军宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Challenger");
            text.SetDefault("Erazor Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Ирэйзора");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落帝者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Spookboi");
            text.SetDefault("Nihilus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Нигилюса");
            LocalizationLoader.AddTranslation(text);

            //SpiritMod
            text = LocalizationLoader.CreateTranslation(this, "Scarabeus");
            text.SetDefault("Scarabeus Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Bane");
            text.SetDefault("Vinewrath Bane Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Flier");
            text.SetDefault("Ancient Flier Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Raider");
            text.SetDefault("Starplate Raider Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Infernon");
            text.SetDefault("Infernon Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Dusking");
            text.SetDefault("Dusking Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EtherialUmbra");
            text.SetDefault("Etherial Umbra Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "IlluminantMaster");
            text.SetDefault("Illuminant Master Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Atlas");
            text.SetDefault("Atlas Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Overseer");
            text.SetDefault("Overseer Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //Enigma
            text = LocalizationLoader.CreateTranslation(this, "Sharkron");
            text.SetDefault("Dune Sharkron Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Дюнного Акулрона");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Hypothema");
            text.SetDefault("Hypothema Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Ragnar");
            text.SetDefault("Ragnar Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Рагнара");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AnDio");
            text.SetDefault("Andesia & Dioritus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Андезии и Диоритуса");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Annihilator");
            text.SetDefault("The Annihilator Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Аннигилятора");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Slybertron");
            text.SetDefault("Slybertron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "SteamTrain");
            text.SetDefault("Steam Train Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Паровоза");
            LocalizationLoader.AddTranslation(text);

            //Pinky
            text = LocalizationLoader.CreateTranslation(this, "SunlightTrader");
            text.SetDefault("Sunlight Trader Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "THOFC");
            text.SetDefault("The Heart of the Cavern Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "MythrilSlime");
            text.SetDefault("Mythril Slime Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Valdaris");
            text.SetDefault("Valdaris Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Gatekeeper");
            text.SetDefault("The Gatekeeper Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //AAMod
            text = LocalizationLoader.CreateTranslation(this, "Monarch");
            text.SetDefault("Mushroom Monarch Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "赤孢皇宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Grips");
            text.SetDefault("Grips of Chaos Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混沌双爪宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Broodmother");
            text.SetDefault("Broodmother Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "育母炎龙宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Hydra");
            text.SetDefault("Hydra Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "九头渊蛇宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Serpent");
            text.SetDefault("Subzero Serpent Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "绝零冰蛇宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Djinn");
            text.SetDefault("Desert Djinn Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "沙漠巨灵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Retriever");
            text.SetDefault("Retriever Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "捕猎者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "RaiderU");
            text.SetDefault("Raider Ultima Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "创世哺育之母宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Orthrus");
            text.SetDefault("Orthrus X Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "双头狗宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "EFish");
            text.SetDefault("Emperor Fishron Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "猪鲨王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Nightcrawler");
            text.SetDefault("Nightcrawler Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "奈克劳尔宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Daybringer");
            text.SetDefault("Daybringer Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "戴布林格宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Yamata");
            text.SetDefault("Yamata Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "八歧大蛇宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Akuma");
            text.SetDefault("Akuma Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪鬼巨龙宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Zero");
            text.SetDefault("Zero Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "零械单元宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Shen");
            text.SetDefault("Shen Doragon Treasure Cache");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "上神应龙宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ShenGrips");
            text.SetDefault("Shen Doragon Grips Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "上神双爪宝藏袋");
            LocalizationLoader.AddTranslation(text);

            //SBMW:Some other translation
            text = LocalizationLoader.CreateTranslation(this, "Portal");
            text.SetDefault("An Otherworldly Portal was opened.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Междумировой портал был открыт.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "连接另一个世界的传送门已开启");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "barrierWeek");
            text.SetDefault("The Barrier between worlds was weakened.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Барьер между мирами был ослаблен.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界间的屏障已变得脆弱不堪");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "barrierStabilized");
            text.SetDefault("The Barrier between world is stabilized.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Барьер между мирами стабилизировался.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界间的屏障重新归于稳定");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "Eclipse");
            text.SetDefault("Eclipse creatures become anxious.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "日食生物变得焦虑不堪");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "portalOpen");
            text.SetDefault("I am alive...? I cannot believe this! Thank you!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я жива...? Не верю своим глазам! Спасибо!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我...我还活着?! 我简直无法相信! 谢谢你!");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "pale");
            text.SetDefault("pale");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "бледный");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "失色");
            LocalizationLoader.AddTranslation(text);

            //QQ
            text = LocalizationLoader.CreateTranslation(this, "D1");
            text.SetDefault("To think, she's just here to collect the horrors of Terraria...what is she thinking?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Просто подумай, она здесь лишь для того, чтобы собрать ужасы Террарии... О чём она думает?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "想一想, 她只是来收集泰拉世界中的恐惧...她究竟想干什么？");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "D2");
            text.SetDefault("I still remember the day she landed. If it weren't for the help of everyone here, I swore I would never fix her up.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я всё ещё помню день, когда она прибыла. Если бы это не было полезным для всех тут, то я клянусь, что никогда бы не помогла ей.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我仍然记得她掉到这个世界上的那一天. 如果没有这里所有人的帮助, 我发誓永远不会把她修好. ");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "D3");
            text.SetDefault("You may not have fully defeated the gate, but it seems Angela has what's left of it.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты мог победить врата не полностью, но похоже, что у Анджелы уже есть всё то, что от них осталось.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你似乎并未完全打败这个门, 不过好像Angela那有它掉落的东西");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "D4");
            text.SetDefault("I can understand trying to understand a Dungeon Slime, but going out of your way to harvest the Wall of Flesh? What was Angela thinking!?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я могу понять попытки понять Слизня Данжа, но сойти с пути чтобы собрать остатки Стены Плоти? О чём Анджела думает!?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "想要试图理解地牢史莱姆的心情我能理解, 但是试图猎杀血肉之墙? Angela在想些什么?");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AD1");
            text.SetDefault("Shame. Would had wanted Angela, but she's lured by ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как жаль. Хотел бы потолковать с Анджелой, но она привлечена ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "可惜了. 对Angela还挺有好感的, 但是她受到了来自");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "ADch1");
            text.SetDefault("");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "的诱惑");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "AD2");
            text.SetDefault("Man, how much gun is that AI packing?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чувак, сколько же пушек у этого ИИ с собой?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "伙计, AI的包里有多少枪");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation(this, "RCTT");
            text.SetDefault("Right-click to teleport here");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "右键传送至此");
            LocalizationLoader.AddTranslation(text);
            */
        }
    }
}


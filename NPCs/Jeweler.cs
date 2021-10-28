using System;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.NPCs
{
    [AutoloadHead]
    public class Jeweler : ModNPC
    {
        public static bool OH = true;
        public static bool SN = false;
        public static bool SN2 = false;
        public static bool SN3 = false;
        public static bool AS = false;
        public static bool TN1 = false;
        public static bool TN2 = false;
        public static bool TN3 = false;
        public static bool TN4 = false;
        public static bool TN5 = false;
        public static bool TN6 = false;
        public static bool TN7 = false;
        public static bool TN8 = false;
        public static bool TN9 = false;
        public override string Texture
        {
            get
            {
                return "AlchemistNPC/NPCs/Jeweler";
            }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jeweler");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ювелир");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "珠宝师");
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -2;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "ArenaShop");
            text.SetDefault("Arena Shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин Арены");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "战斗场地商店");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Carl");
            text.SetDefault("Carl");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Карл");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "John");
            text.SetDefault("John");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Джон");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "JanMare");
            text.SetDefault("JanMare");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Жан-Маре");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "LuiFransua");
            text.SetDefault("LuiFransua");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Луи-Франсуа");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Daniel");
            text.SetDefault("Daniel");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Дэниел");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Charley");
            text.SetDefault("Charley");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чарли");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ1");
            text.SetDefault("I found some gems for selling. Would you check them?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я собрал немного драгоценных камней на продажу. Посмотришь?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我找到一些珠宝, 你想看看吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ2");
            text.SetDefault("Magic rings are not as powerful as Legendary Emblems, but still can give you some advantage against powerful creatures.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Волшебные кольца не так могущественны, как Легендарные Эмблемы, но всё ещё могут дать преимущество против могущественных созданий.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法戒指并不像传说中的那样强大,但它仍然能给你对抗强大生物的力量");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ3");
            text.SetDefault("Ouch... what do you want, my friend?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ай... Чего желаешь, мой друг?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "呦... 你想要什么,我的朋友?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ4");
            text.SetDefault("I can make a Diamond Ring for you.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я могу сделать для тебя Бриллиантовое Кольцо.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我可以为你做钻石戒指.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ5");
            text.SetDefault("No, I don't think that I'm somehow related to Skeleton Merchant.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Нет, я не думаю что хоть как-то связан со Скелетом-торговцем.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "不,不要认为我和骷髅商人有关系.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ6");
            text.SetDefault("If you somehow find all Magic Rings,then you could make the Omniring.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если ты каким-то образом соберёшь все Магические кольца, то ты сможешь сделать Единое Кольцо.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果你找到了所有的魔法戒指,你可以制造欧姆尼戒指.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ7");
            text.SetDefault("Have you seen Mechanical Creatures?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты видел где-нибудь Механических Созданий?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你在周围看到机械生物了吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ8");
            text.SetDefault("Did you notice that ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты замечал, что ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你有没有注意到到我和 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ9");
            text.SetDefault(" and I look almost the same? It's because we're twin brothers.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " и я очень похожи? Это потому что мы близнецы.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 长得几乎一毛一样?这是因为我们是兄弟.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ10");
            text.SetDefault("Should you find enought of those torn notes, bring the to me and ill decipher them for you. Dont ask me why, just know that they hold a value for me.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как только найдёшь достаточно изорванных записок, неси их мне и я расшифрую их для тебя. Не спрашивай зачем, просто знай, что они имеют значение для меня.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果你发现了那些破碎的笔记，请把它们给我，我会帮你把它们破译出来。别问我为什么，你只需要知道他们对我有价值。");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Combine");
            text.SetDefault("Combine notes");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Соединить записки");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黏合笔记");
            LocalizationLoader.AddTranslation(text);
        }

        public override void ResetEffects()
        {
            SN = false;
            SN2 = false;
            SN3 = false;
            AS = false;
            TN1 = false;
            TN2 = false;
            TN3 = false;
            TN4 = false;
            TN5 = false;
            TN6 = false;
            TN7 = false;
            TN8 = false;
            TN9 = false;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 50;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss1 && AlchemistNPC.modConfiguration.JewelerSpawn)
            {
                return true;
            }
            return false;
        }



        public override string TownNPCName()
        {                                       //NPC names
            string Carl = Language.GetTextValue("Mods.AlchemistNPC.Carl");
            string John = Language.GetTextValue("Mods.AlchemistNPC.John");
            string JanMare = Language.GetTextValue("Mods.AlchemistNPC.JanMare");
            string LuiFransua = Language.GetTextValue("Mods.AlchemistNPC.LuiFransua");
            string Daniel = Language.GetTextValue("Mods.AlchemistNPC.Daniel");
            string Charley = Language.GetTextValue("Mods.AlchemistNPC.Charley");
            switch (WorldGen.genRand.Next(5))
            {
                case 0:
                    return Carl;
                case 1:
                    return John;
                case 2:
                    return JanMare;
                case 3:
                    return LuiFransua;
                case 4:
                    return Daniel;
                default:
                    return Charley;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 20;
            }
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                damage = 100;
            }
            if (NPC.downedMoonlord)
            {
                damage = 1000;
            }
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileType<Projectiles.Gemstone>();
            attackDelay = 3;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 0f;
        }


        public override string GetChat()
        {                                           //npc chat
            string EntryJ1 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ1");
            string EntryJ2 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ2");
            string EntryJ3 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ3");
            string EntryJ4 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ4");
            string EntryJ5 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ5");
            string EntryJ6 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ6");
            string EntryJ7 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ7");
            string EntryJ8 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ8");
            string EntryJ9 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ9");
            string EntryJ10 = Language.GetTextValue("Mods.AlchemistNPC.EntryJ10");
            int Merchant = NPC.FindFirstNPC(NPCID.Merchant);
            if (Merchant >= 0 && Main.rand.Next(5) == 0)
            {
                return EntryJ8 + Main.npc[Merchant].GivenName + EntryJ9;
            }
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return EntryJ2;
                    case 1:
                        return EntryJ6;
                }
            }
            switch (Main.rand.Next(6))
            {
                case 0:
                    return EntryJ1;
                case 1:
                    return EntryJ3;
                case 2:
                    return EntryJ4;
                case 3:
                    return EntryJ5;
                case 4:
                    return EntryJ10;
                default:
                    return EntryJ7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string ArenaShop = Language.GetTextValue("Mods.AlchemistNPC.ArenaShop");
            string Combine = Language.GetTextValue("Mods.AlchemistNPC.Combine");
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = ArenaShop;
            Player player = Main.player[Main.myPlayer];
            if (player.active)
            {
                for (int j = 0; j < player.inventory.Length; j++)
                {
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.SecretNote>())
                    {
                        SN = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.SecretNote2>())
                    {
                        SN2 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.SecretNote3>())
                    {
                        SN3 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote1>())
                    {
                        TN1 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote2>())
                    {
                        TN2 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote3>())
                    {
                        TN3 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote4>())
                    {
                        TN4 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote5>())
                    {
                        TN5 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote6>())
                    {
                        TN6 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote7>())
                    {
                        TN7 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote8>())
                    {
                        TN8 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.TornNote9>())
                    {
                        TN9 = true;
                    }
                }
            }
            if (TN1 && TN2 && TN3 && !SN)
            {
                button2 = Combine;
            }
            if (TN4 && TN5 && TN6 && !SN2)
            {
                button2 = Combine;
            }
            if (TN7 && TN8 && TN9 && !SN3)
            {
                button2 = Combine;
            }
            if (SN && SN2 && SN3)
            {
                button2 = Combine;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                OH = true;
                AS = false;
                shop = true;
            }
            else
            {
                Player player = Main.player[Main.myPlayer];
                if (TN1 && TN2 && TN3 && !SN)
                {
                    player.QuickSpawnItem(ModContent.ItemType<Items.Notes.SecretNote>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Notes.TornNote1>()))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote1>())
                            {
                                inventory[k].stack--;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote2>())
                            {
                                inventory[k].stack--;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote3>())
                            {
                                inventory[k].stack--;
                            }
                        }
                    }
                }
                if (TN4 && TN5 && TN6 && !SN2)
                {
                    player.QuickSpawnItem(ModContent.ItemType<Items.Notes.SecretNote2>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Notes.TornNote4>()))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote4>())
                            {
                                inventory[k].stack--;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote5>())
                            {
                                inventory[k].stack--;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote6>())
                            {
                                inventory[k].stack--;
                            }
                        }
                    }
                }
                if (TN7 && TN8 && TN9 && !SN3)
                {
                    player.QuickSpawnItem(ModContent.ItemType<Items.Notes.SecretNote3>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Notes.TornNote7>()))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote7>())
                            {
                                inventory[k].stack--;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote8>())
                            {
                                inventory[k].stack--;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.TornNote9>())
                            {
                                inventory[k].stack--;
                            }
                        }
                    }
                }
                if (SN && SN2 && SN3)
                {
                    player.QuickSpawnItem(ModContent.ItemType<Items.Summoning.NotesBook>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(ModContent.ItemType<Items.Notes.SecretNote>()))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.SecretNote>())
                            {
                                inventory[k].stack--;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.SecretNote2>())
                            {
                                inventory[k].stack--;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.SecretNote3>())
                            {
                                inventory[k].stack--;
                            }
                        }
                    }
                }
                OH = false;
                AS = true;
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (OH)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Amethyst);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Topaz);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Sapphire);
                    shop.item[nextSlot].shopCustomPrice = 3000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Emerald);
                    shop.item[nextSlot].shopCustomPrice = 3000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Amber);
                    shop.item[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FossilOre);
                    shop.item[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
					// IMPLEMENT WHEN WEAKREFERENCES FIXED
					/*
                    if (ModLoader.GetMod("ThoriumMod") != null)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("Opal"));
                        shop.item[nextSlot].shopCustomPrice = 5000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("Onyx"));
                        shop.item[nextSlot].shopCustomPrice = 5000;
                        nextSlot++;
                    }
					*/
                    shop.item[nextSlot].SetDefaults(ItemID.BandofStarpower);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BandofRegeneration);
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    if (Main.netMode == 1 || Main.netMode == 2)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.LifeCrystal);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedGolemBoss)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.LifeFruit);
                            shop.item[nextSlot].shopCustomPrice = 200000;
                            nextSlot++;
                        }
                    }
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Ruby);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Diamond);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.DiamondRing);
                    shop.item[nextSlot].shopCustomPrice = 2000000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemType<Items.Summoning.HorrifyingSkull>());
                    shop.item[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
					// IMPLEMENT WHEN WEAKREFERENCES FIXED
					/*
                    if (ModLoader.GetMod("Tremor") != null)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Rupicide"));
                        shop.item[nextSlot].shopCustomPrice = 5000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Opal"));
                        shop.item[nextSlot].shopCustomPrice = 30000;
                        nextSlot++;
                        if (Main.hardMode)
                        {
                            shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("MagiumShard"));
                            shop.item[nextSlot].shopCustomPrice = 7500;
                            nextSlot++;
                            shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("RuneBar"));
                            shop.item[nextSlot].shopCustomPrice = 7500;
                            nextSlot++;
                        }
                        if (NPC.downedMoonlord)
                        {
                            shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("LapisLazuli"));
                            shop.item[nextSlot].shopCustomPrice = 150000;
                            nextSlot++;
                        }
                    }
                    if (ModLoader.GetMod("ThoriumMod") != null)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("GraniteEnergyCore"));
                        shop.item[nextSlot].shopCustomPrice = 10000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("BronzeFragments"));
                        shop.item[nextSlot].shopCustomPrice = 10000;
                        nextSlot++;
                    }
                    if (ModLoader.GetMod("SpiritMod") != null)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("GraniteChunk"));
                        shop.item[nextSlot].shopCustomPrice = 10000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("MarbleChunk"));
                        shop.item[nextSlot].shopCustomPrice = 10000;
                        nextSlot++;
                    }
					*/
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Summoning.AlchemistHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Summoning.BrewerHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Summoning.JewelerHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Summoning.ArchitectHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Summoning.TinkererHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Summoning.MusicianHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                    }
                }
            }
            if (AS)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Campfire);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
					// IMPLEMENT WHEN WEAKREFERENCES FIXED
					/*
                    if (ModLoader.GetMod("ThoriumMod") != null)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("Mistletoe"));
                        shop.item[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                    }
					*/
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.WaterBucket);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.HoneyBucket);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.LavaBucket);
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.HeartLantern);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.StarinaBottle);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.WaterCandle);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.PeaceCandle);
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
					// IMPLEMENT WHEN WEAKREFERENCES FIXED
					/*
                    if (ModLoader.GetMod("CalamityMod") != null)
                    {
                        if (NPC.downedPlantBoss)
                        {
                            shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("TranquilityCandle"));
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                            shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CalamityMod").ItemType("ChaosCandle"));
                            shop.item[nextSlot].shopCustomPrice = 150000;
                            nextSlot++;
                        }
                    }
					*/
                    shop.item[nextSlot].SetDefaults(ItemID.Spike);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.DartTrap);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.GeyserTrap);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SharpeningStation);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BewitchingTable);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.AmmoBox);
                    shop.item[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.CrystalBall);
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                    }
                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.WoodenSpike);
                        shop.item[nextSlot].shopCustomPrice = 20000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.SpearTrap);
                        shop.item[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.SpikyBallTrap);
                        shop.item[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.SuperDartTrap);
                        shop.item[nextSlot].shopCustomPrice = 750000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.FlameTrap);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                    }
                }
            }
        }
    }
}

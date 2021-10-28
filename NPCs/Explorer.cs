using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.NPCs
{
    [AutoloadHead]
    public class Explorer : ModNPC
    {
        public static bool C11 = false;
        public static bool C12 = false;
        public static bool C13 = false;
        public static bool C14 = false;
        public static bool C15 = false;
        public static bool C21 = false;
        public static bool C22 = false;
        public static bool C23 = false;
        public static bool C24 = false;
        public static bool C25 = false;
        public static bool C26 = false;
        public static bool C31 = false;
        public static bool C32 = false;
        public static bool C33 = false;
        public static bool C34 = false;
        public static bool C35 = false;
        public static bool C41 = false;
        public static bool C42 = false;
        public static bool C43 = false;
        public static bool C44 = false;
        public static bool C45 = false;
        public static bool C51 = false;
        public static bool C52 = false;
        public static bool C53 = false;
        public static bool C54 = false;
        public static bool C55 = false;
        public static bool C61 = false;
        public static bool C62 = false;
        public static bool C63 = false;
        public static bool C64 = false;
        public static bool C65 = false;
        public static bool C71 = false;
        public static bool C72 = false;
        public static bool C73 = false;
        public static bool C74 = false;
        public static bool C75 = false;
        public static bool C81 = false;
        public static bool C82 = false;
        public static bool C83 = false;
        public static bool C84 = false;

        public override string Texture
        {
            get
            {
                return "AlchemistNPC/NPCs/Explorer";
            }
        }

        public override void ResetEffects()
        {
            C11 = false;
            C12 = false;
            C13 = false;
            C14 = false;
            C15 = false;
            C21 = false;
            C22 = false;
            C23 = false;
            C24 = false;
            C25 = false;
            C26 = false;
            C31 = false;
            C32 = false;
            C33 = false;
            C34 = false;
            C35 = false;
            C41 = false;
            C42 = false;
            C43 = false;
            C44 = false;
            C45 = false;
            C51 = false;
            C52 = false;
            C53 = false;
            C54 = false;
            C55 = false;
            C61 = false;
            C62 = false;
            C63 = false;
            C64 = false;
            C65 = false;
            C71 = false;
            C72 = false;
            C73 = false;
            C74 = false;
            C75 = false;
            C81 = false;
            C82 = false;
            C83 = false;
            C84 = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Explorer");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Исследовательница");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "探险家");
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Elizabeth");
            text.SetDefault("Elizabeth");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Элизавета");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "伊丽莎白");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Dora");
            text.SetDefault("Dora");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даша");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "朵拉");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Create1");
            text.SetDefault("Create #1");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создать №1");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "制造 #1");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Create2");
            text.SetDefault("Create #2");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создать №2");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "制造 #2");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Create3");
            text.SetDefault("Create #3");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создать №3");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "制造 #3");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Create4");
            text.SetDefault("Create #4");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создать №4");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "制造 #4");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Create5");
            text.SetDefault("Create #5");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создать №5");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "制造 #5");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Create6");
            text.SetDefault("Create #6");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создать №6");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "制造 #6");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Create7");
            text.SetDefault("Create #7");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создать №7");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "制造 #7");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Create8");
            text.SetDefault("Create #8");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создать №8");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "制造 #8");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE1");
            text.SetDefault("So, were my notes of any use to you?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Были ли мои записки хоть сколько-нибудь полезны для тебя?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "所以, 我的笔记对你来说有用吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE2");
            text.SetDefault("I know about special materials which can help you.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я знаю про особые материалы. Они могут помочь тебе.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我有一些关于特殊材料方面的知识, 也许可以帮到你.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE3");
            text.SetDefault("You want to try Blade with power of Determination? Just make Extractor and get some Soul Essences and Hate Vials.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты хочешь попробовать Меч с силой Решимости? Просто сделай Экстрактор и добудь немного Эссенций Душ и Пробирок с Ненавистью.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你想试试权力的感觉吗? 只需要制作一个抽取器并且获得一些灵魂精华和仇恨之瓶就行了");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE4");
            text.SetDefault("''There's a legendary yoyo known as the Sasscade.''... I am pretty sure you heard about that before. But I know how you can get it.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Существует Легендарное Йо-йо, известное как Сасскад.''... Я уверена, что ты слышал об этом раньше. Но я знаю, как ты можешь заполучить его.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''有个传说中的悠悠球叫做萨斯卡德.''...我很确定你之前听到过这句话, 但是我知道, 如何得到它!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE5");
            text.SetDefault("If you want to take part in my researches, then grab my notes and check if you can help. All results will belong to you.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если хочешь принять участие в моих исследованиях, тогда возьми мои записи и посмотри, если сможешь мне помочь. Все результаты достанутся тебе.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果你想得到我研究成果的一部分, 就拿起笔记然后看看你能不能帮忙. 所有的成果都归你!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE6");
            text.SetDefault("Luckily, I get my Interdimensional Casket with me, so I can make potions. My inventions, of course.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хорошо, что я забрала Межизмеренческую Шкатулку с собой, так что я могу делать зелья. Мои изобретения, кстати.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "运气不错, 我带着我的次元盒, 所以我可以制作药水, 由我发明的药水");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE7");
            text.SetDefault("Celestial's Particles are pretty interesting... You can use them for crafting some special accessories and equipment or simply for making Celestial Fragments.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Частицы Божества довольно интересны... Ты можешь использовать их для создания специальных аксессуаров и снаряжения или всего лишь для изготовления Небесных Фрагментов.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "始源碎片十分的有趣...你可以用他们制造一些特殊的饰品和装备或者是天界碎片");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE8");
            text.SetDefault("If you've already found the Otherworldly Amulet, then you can ask ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если ты уже нашёл Амулет Иного Мира, то тогда сможешь сделать так, чтобы ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果你已经找到了异界护身符, 你就可以让 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE9");
            text.SetDefault(" to sell Celestial Fragments.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " продавала Небесные Фрагменты.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 卖天界碎片");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE10");
            text.SetDefault("That was the most powerful and dangerous creature in the jungle, but you killed it. Does that mean that you are now the most dangerous creature in the jungle?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Это было самое опасное и могущественное создание в джунглях, но ты убил его. Значит ли это, что теперь ты - самое опасное существо джунглей?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "那是丛林中最为强大和危险的生物, 但是你杀了它. 这是否意味着以后你就是丛林中最强大最危险的生物了呢?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE11");
            text.SetDefault("Otherworldly Amulet has much more uses than you ever thought... It could help Alchemist to make Celestial's Particles, it could summon mount Poro for you and it is required for making Autoinjector or Watcher Amulet.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Амулет Иного мира имеет куда больше функций, чем ты бы мог подумать... Он может помочь Алхимику создавать Частицы Божества, он может призвать для тебя ездового питомца Поро и он неободим для создания Автоинъектора или Амулета Дозорного.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "异界护身符拥有着远超你想象的力量...它可以帮助炼金师制作始源碎片, 可以召唤坐骑魄罗, 同时也是制作自动注射器和凝视者护符的材料");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE12");
            text.SetDefault("If you managed to create Watcher Amulet, then you could buy Flask of Rainbows from Young Brewer. It is a very powerful imbuement, which can help you overcome great enemies.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если ты сможешь создать Амулет Дозорного, то тогда ты сможешь покупать Флаконы Радуги у Юного Зельевара. Это очень мощное покрытие оружия, которое может помочь тебе победить очень серьёзных противников.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果你想要制作凝视者护符, 你可以从年轻药剂师那里购买瓶中彩虹, 这是一种十分强力的注入剂, 可以帮助你打败强大的敌人");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE13");
            text.SetDefault("I once met a man that traveled on top an alicorn. He looked truly FABulous!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я однажды встретила человека, путешествующего верхом на единороге. Он выглядел просто потрясающе!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我曾经遇到过一个骑在天角兽上旅行的人. 他看起来真是太神了! ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE14");
            text.SetDefault("Can you bring me the Unicorn for examination? I am sure that your bug net is strong enough for that.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Можешь достать мне Единорога для исследований? Я уверена, что твоя сетка для ловли достаточно крепка для этого.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你能给我弄一个独角兽来做试验吗. 我相信你的捕虫网足够强力! ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE15");
            text.SetDefault("Messing with the quantic shroud is no fun-time business, hero. Be careful when choosing what power to pick on.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Дурачиться с квантовыми полями не самое весёлое занятие, герой. Поосторожнее выбирай силу, с которой будешь работать.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "把大量套装弄乱可不是一件有趣的事, 英雄. 在选择能力的时候一定要小心. ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE16");
            text.SetDefault("The time-space continuum is possibly the worst combination in this existance: both a delicate but mastercrafted estructure in a skillfully achieved but pathetically fragile balance and at the same time an absolute and undeniable force of nature that posseses total control of our everything and composes what we call ''reality and fiction'', volatile as you wouldn't believe.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Простанственно-временной континуум - это возможно наихудшее сочетание из существующих: одновременно тончайшая и мастерски созданная структура в мастерски достигнутом, но невероятно хрупком балансе и в то же самое время абсолютная и непреодолимая сила природы, что обладает полным контролем над нашим ''всем'' и формирует то, что мы называем ''реальностью и вымыслом'', меняясь так, что ты и не поверишь.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "时空连续体可能会成为最糟糕的结合体在这种存在形式下: 这两者都是一个微妙而精细的结构, 处于一种巧妙而脆弱的平衡, 同时是一种绝对不可否认控制我们一切，并构成了我们所说的 “现实和虚拟”的自然力量, 你不会相信是不稳定的.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryE17");
            text.SetDefault("Take it from someone with experience on it, friend: ''A flying giant divine cosmic worm of the heavens of who-damn-knows-what-deities is the most normal thing you'll find out there compared to what lurks in the darkness of deep space.''");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выслушай это от кого-то с опытом, друг: ''Древний гигантский летающий космический червь небес чёрт-знает-какого-божества - это самое нормальное что ты найдёшь, сравнивая с тем, что скрывается во тьме глубого космоса.''");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "朋友, 从有经验的人那分享来的一句话: “相比于深空里潜伏着的各种你会发现的东西, 一个会飞的谁他妈直到它是不是神的宇宙巨型蠕虫简直再正常不过了”");
            LocalizationLoader.AddTranslation(text);
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 500;
            NPC.lifeMax = 500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Mechanic;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return false;
        }


        public override string TownNPCName()
        {
            string Elizabeth = Language.GetTextValue("Mods.AlchemistNPC.Elizabeth");
            string Dora = Language.GetTextValue("Mods.AlchemistNPC.Dora");
            switch (WorldGen.genRand.Next(1))
            {
                case 0:
                    return Elizabeth;
                default:
                    return Dora;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 100;
            knockback = 16f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileType<Projectiles.Nyx>();
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 32f;
        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            scale = 1f;
            closeness = 15;
            item = ModContent.ItemType<Items.Weapons.Nyx>();
        }

        public override string GetChat()
        {                                           //npc chat
            string Entry1 = Language.GetTextValue("Mods.AlchemistNPC.EntryE1");
            string Entry2 = Language.GetTextValue("Mods.AlchemistNPC.EntryE2");
            string Entry3 = Language.GetTextValue("Mods.AlchemistNPC.EntryE3");
            string Entry4 = Language.GetTextValue("Mods.AlchemistNPC.EntryE4");
            string Entry5 = Language.GetTextValue("Mods.AlchemistNPC.EntryE5");
            string Entry6 = Language.GetTextValue("Mods.AlchemistNPC.EntryE6");
            string Entry7 = Language.GetTextValue("Mods.AlchemistNPC.EntryE7");
            string Entry8 = Language.GetTextValue("Mods.AlchemistNPC.EntryE8");
            string Entry9 = Language.GetTextValue("Mods.AlchemistNPC.EntryE9");
            string Entry10 = Language.GetTextValue("Mods.AlchemistNPC.EntryE10");
            string Entry11 = Language.GetTextValue("Mods.AlchemistNPC.EntryE11");
            string Entry12 = Language.GetTextValue("Mods.AlchemistNPC.EntryE12");
            string Entry13 = Language.GetTextValue("Mods.AlchemistNPC.EntryE13");
            string Entry14 = Language.GetTextValue("Mods.AlchemistNPC.EntryE14");
            string Entry15 = Language.GetTextValue("Mods.AlchemistNPC.EntryE15");
            string Entry16 = Language.GetTextValue("Mods.AlchemistNPC.EntryE16");
            string Entry17 = Language.GetTextValue("Mods.AlchemistNPC.EntryE17");
            int Operator = NPC.FindFirstNPC(NPCType<NPCs.Operator>());
            if (Operator >= 0 && Main.rand.Next(4) == 0)
            {
                return Entry8 + Main.npc[Operator].GivenName + Entry9;
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				if ((bool)Calamity.Call("Downed", "dog") && Main.rand.Next(10) == 0)
				{
					return Entry17;
				}
			}
			*/
            switch (Main.rand.Next(14))
            {
                case 0:
                    return Entry1;
                case 1:
                    return Entry2;
                case 2:
                    return Entry3;
                case 3:
                    return Entry4;
                case 4:
                    return Entry5;
                case 5:
                    return Entry6;
                case 6:
                    return Entry7;
                case 7:
                    return Entry11;
                case 8:
                    return Entry12;
                case 9:
                    return Entry13;
                case 10:
                    return Entry14;
                case 11:
                    return Entry15;
                case 12:
                    return Entry16;
                default:
                    return Entry10;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string Create1 = Language.GetTextValue("Mods.AlchemistNPC.Create1");
            string Create2 = Language.GetTextValue("Mods.AlchemistNPC.Create2");
            string Create3 = Language.GetTextValue("Mods.AlchemistNPC.Create3");
            string Create4 = Language.GetTextValue("Mods.AlchemistNPC.Create4");
            string Create5 = Language.GetTextValue("Mods.AlchemistNPC.Create5");
            string Create6 = Language.GetTextValue("Mods.AlchemistNPC.Create6");
            string Create7 = Language.GetTextValue("Mods.AlchemistNPC.Create7");
            string Create8 = Language.GetTextValue("Mods.AlchemistNPC.Create8");
            button = Language.GetTextValue("LegacyInterface.28");
            Player player = Main.player[Main.myPlayer];
            if (player.active)
            {
                for (int j = 0; j < player.inventory.Length; j++)
                {
                    if (player.inventory[j].type == 3389)
                    {
                        C11 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C12 = true;
                    }
                    if (player.inventory[j].type == 1326)
                    {
                        C13 = true;
                    }
                    if (player.inventory[j].type == 3366)
                    {
                        C14 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.ResearchNote1>())
                    {
                        C15 = true;
                    }
                    if (player.inventory[j].type == 495)
                    {
                        C21 = true;
                    }
                    if (player.inventory[j].type == 3541)
                    {
                        C22 = true;
                    }
                    if (player.inventory[j].type == 493)
                    {
                        C23 = true;
                    }
                    if (player.inventory[j].type == 1611)
                    {
                        C24 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Summoning.CaughtUnicorn>())
                    {
                        C25 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.ResearchNote2>())
                    {
                        C26 = true;
                    }
                    if (player.inventory[j].type == 2882)
                    {
                        C31 = true;
                    }
                    if (player.inventory[j].type == 1295)
                    {
                        C32 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C33 = true;
                    }
                    if (player.inventory[j].type == 1858)
                    {
                        C34 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.ResearchNote3>())
                    {
                        C35 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C41 = true;
                    }
                    if (player.inventory[j].type == 1363)
                    {
                        C42 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Materials.HateVial>())
                    {
                        C43 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.RainbowFlask>())
                    {
                        C44 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.ResearchNote4>())
                    {
                        C45 = true;
                    }
                    if (player.inventory[j].type == 1156)
                    {
                        C51 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C52 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.RainbowFlask>())
                    {
                        C53 = true;
                    }
                    if (player.inventory[j].type == 900)
                    {
                        C54 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.ResearchNote5>())
                    {
                        C55 = true;
                    }
                    if (player.inventory[j].type == 1327)
                    {
                        C61 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Materials.HateVial>())
                    {
                        C62 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C63 = true;
                    }
                    if (player.inventory[j].type == 1865)
                    {
                        C64 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.ResearchNote6>())
                    {
                        C65 = true;
                    }
                    if (player.inventory[j].type == 3384)
                    {
                        C71 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>())
                    {
                        C72 = true;
                    }
                    if (player.inventory[j].type == 3569)
                    {
                        C73 = true;
                    }
                    if (player.inventory[j].type == 3122)
                    {
                        C74 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.ResearchNote7>())
                    {
                        C75 = true;
                    }
                    if (player.inventory[j].type == 3384)
                    {
                        C81 = true;
                    }
                    if (player.inventory[j].type == 3628)
                    {
                        C82 = true;
                    }
                    if (player.inventory[j].type == 3820)
                    {
                        C83 = true;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Notes.ResearchNote8>())
                    {
                        C84 = true;
                    }
                }
            }
            if (C11 && C12 && C13 && C14 && C15)
            {
                button2 = Create1;
            }
            if (C21 && C22 && C23 && C24 && C25 && C26)
            {
                button2 = Create2;
            }
            if (C31 && C32 && C33 && C34 && C35)
            {
                button2 = Create3;
            }
            if (C41 && C42 && C43 && C44 && C45)
            {
                button2 = Create4;
            }
            if (C51 && C52 && C53 && C54 && C55)
            {
                button2 = Create5;
            }
            if (C61 && C62 && C63 && C64 && C65)
            {
                button2 = Create6;
            }
            if (C71 && C72 && C73 && C74 && C75)
            {
                button2 = Create7;
            }
            if (C81 && C82 && C83 && C84)
            {
                button2 = Create8;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                if (C11 && C12 && C13 && C14 && C15)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.Sasscade>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(3389))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == 3389 && C11)
                            {
                                inventory[k].stack--;
                                C11 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C12)
                            {
                                inventory[k].stack--;
                                C12 = false;
                            }
                            if (inventory[k].type == 1326 && C13)
                            {
                                inventory[k].stack--;
                                C13 = false;
                            }
                            if (inventory[k].type == 3366 && C14)
                            {
                                inventory[k].stack--;
                                C14 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote1>() && C15)
                            {
                                inventory[k].stack--;
                                C15 = false;
                            }
                        }
                    }
                }
                if (C21 && C22 && C23 && C24 && C25 && C26)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.MagicWand>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(495))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == 495 && C21)
                            {
                                inventory[k].stack--;
                                C21 = false;
                            }
                            if (inventory[k].type == 3541 && C22)
                            {
                                inventory[k].stack--;
                                C22 = false;
                            }
                            if (inventory[k].type == 493 && C23)
                            {
                                inventory[k].stack--;
                                C23 = false;
                            }
                            if (inventory[k].type == 1611 && C24)
                            {
                                inventory[k].stack--;
                                C24 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Summoning.CaughtUnicorn>() && C25)
                            {
                                inventory[k].stack--;
                                C25 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote2>() && C26)
                            {
                                inventory[k].stack--;
                                C26 = false;
                            }
                        }
                    }
                }
                if (C31 && C32 && C33 && C34 && C35)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.QuantumDestabilizer>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(2882))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == 2882 && C31)
                            {
                                inventory[k].stack--;
                                C31 = false;
                            }
                            if (inventory[k].type == 1295 && C32)
                            {
                                inventory[k].stack--;
                                C32 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C33)
                            {
                                inventory[k].stack--;
                                C33 = false;
                            }
                            if (inventory[k].type == 1858 && C34)
                            {
                                inventory[k].stack--;
                                C34 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote3>() && C35)
                            {
                                inventory[k].stack--;
                                C35 = false;
                            }
                        }
                    }
                }
                if (C41 && C42 && C43 && C44 && C45)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.EyeOfJudgement>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(1363))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C41)
                            {
                                inventory[k].stack--;
                                C41 = false;
                            }
                            if (inventory[k].type == 1363 && C42)
                            {
                                inventory[k].stack--;
                                C42 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.HateVial>() && C43)
                            {
                                inventory[k].stack--;
                                C43 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.RainbowFlask>() && C44)
                            {
                                inventory[k].stack--;
                                C44 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote4>() && C45)
                            {
                                inventory[k].stack--;
                                C45 = false;
                            }
                        }
                    }
                }
                if (C51 && C52 && C53 && C54 && C55)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.PandoraPF422>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(1156))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == 1156 && C51)
                            {
                                inventory[k].stack--;
                                C51 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C52)
                            {
                                inventory[k].stack--;
                                C52 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.RainbowFlask>() && C53)
                            {
                                inventory[k].stack--;
                                C53 = false;
                            }
                            if (inventory[k].type == 900 && C54)
                            {
                                inventory[k].stack--;
                                C54 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote5>() && C55)
                            {
                                inventory[k].stack--;
                                C55 = false;
                            }
                        }
                    }
                }
                if (C61 && C62 && C63 && C64 && C65)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.Akumu>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(1327))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == 1327 && C61)
                            {
                                inventory[k].stack--;
                                C61 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.HateVial>() && C62)
                            {
                                inventory[k].stack--;
                                C62 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C63)
                            {
                                inventory[k].stack--;
                                C63 = false;
                            }
                            if (inventory[k].type == 1865 && C64)
                            {
                                inventory[k].stack--;
                                C64 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote6>() && C65)
                            {
                                inventory[k].stack--;
                                C65 = false;
                            }
                        }
                    }
                }
                if (C71 && C72 && C73 && C74 && C75)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.PortalGun>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(3384))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == 3384 && C71)
                            {
                                inventory[k].stack--;
                                C71 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Materials.AlchemicalBundle>() && C72)
                            {
                                inventory[k].stack--;
                                C72 = false;
                            }
                            if (inventory[k].type == 3569 && C73)
                            {
                                inventory[k].stack--;
                                C73 = false;
                            }
                            if (inventory[k].type == 3122 && C74)
                            {
                                inventory[k].stack--;
                                C74 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote7>() && C75)
                            {
                                inventory[k].stack--;
                                C75 = false;
                            }
                        }
                    }
                }
                if (C81 && C82 && C83 && C84)
                {
                    Player player = Main.player[Main.myPlayer];
                    player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.TurretStaff>());
                    shop = false;
                    if (Main.player[Main.myPlayer].HasItem(3384))
                    {
                        Item[] inventory = Main.player[Main.myPlayer].inventory;
                        for (int k = 0; k < inventory.Length; k++)
                        {
                            if (inventory[k].type == 3384 && C81)
                            {
                                inventory[k].stack--;
                                C81 = false;
                            }
                            if (inventory[k].type == 3628 && C82)
                            {
                                inventory[k].stack--;
                                C82 = false;
                            }
                            if (inventory[k].type == 3820 && C83)
                            {
                                inventory[k].stack--;
                                C83 = false;
                            }
                            if (inventory[k].type == ModContent.ItemType<Items.Notes.ResearchNote8>() && C84)
                            {
                                inventory[k].stack--;
                                C84 = false;
                            }
                        }
                    }
                }
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemType<Items.ExplorersBrew>());
            shop.item[nextSlot].shopCustomPrice = 250000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.PerfectDiscordPotion>());
            shop.item[nextSlot].shopCustomPrice = 330000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Misc.GlobalTeleporterUp>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Materials.ChromaticCrystal>());
            shop.item[nextSlot].shopCustomPrice = 500000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Materials.NyctosythiaCrystal>());
            shop.item[nextSlot].shopCustomPrice = 500000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Materials.SunkroveraCrystal>());
            shop.item[nextSlot].shopCustomPrice = 500000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Notes.ResearchNote1>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Notes.ResearchNote2>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Notes.ResearchNote3>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Notes.ResearchNote4>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Notes.ResearchNote5>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Notes.ResearchNote6>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Notes.ResearchNote7>());
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemType<Items.Notes.ResearchNote8>());
            nextSlot++;
            Player player = Main.player[Main.myPlayer];
            if (player.active)
            {
                for (int j = 0; j < player.inventory.Length; j++)
                {
                    if (player.inventory[j].type == ModContent.ItemType<Items.Weapons.QuantumDestabilizer>())
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.EnergyCell>());
                        nextSlot++;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Weapons.Tritantrum>())
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.PlasmaRound>());
                        nextSlot++;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Weapons.ChaingunMeatGrinder>())
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.MGB>());
                        nextSlot++;
                    }
                    if (player.inventory[j].type == ModContent.ItemType<Items.Weapons.PortalGun>() || player.inventory[j].type == ModContent.ItemType<Items.Weapons.OverloadedPortalGun>())
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.EnergyCapsule>());
                        nextSlot++;
                    }
                }
            }
            shop.item[nextSlot].SetDefaults(ItemType<Items.Summoning.RealityPiercer>());
            nextSlot++;
        }
    }
}

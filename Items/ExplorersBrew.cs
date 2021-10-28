using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace AlchemistNPC.Items
{
    public class ExplorersBrew : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explorer's Brew");
			Tooltip.SetDefault("[c/00FF00:Unique Explorer's potion]"
			+"\nGrants all possible visions, greatly increases light radius around player and your attacks can Electrocute enemies"
			+"\nAlso gives effects of Gills, Flippers and Water Walking potions");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Варево Исследователя");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт все возможные виды зрения, значительно увеличивает скорость копания.\nЗначительно увеличивает радиус света вокруг игрока и ваши атаки могут поразить врага Электрошоком\nТакже даёт эффекты зельев Подводного Дыхания, Ласт и Хождения по воде");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "探险者陈酿");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "[c/00FF00:特调探险者药剂]\n获得所有感知效果, 极大增加玩家周围的光照效果, 并且你的攻击会电疗敌人\n同时给予鱼鳃、脚蹼和水上行走药剂效果");
        }    

		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.ExplorersBrew>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
    }
}

using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC.NPCs;
 
namespace AlchemistNPC.Items.Summoning
{
    public class KnucklesUgandaDoll : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("National Ugandan Treasure");
			Tooltip.SetDefault("''I'm 100% sure this will kill you'' - Gregg"
			+"\nUsing this may cause disasterous consequences..."
			+"\nBut the reward can retribute all your sufferings");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Национальное сокровище Уганды");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Я на 100 процентов уверен, что это тебя убьёт'' - Gregg\nПрименение этого может вызвать нехорошие последствия...\nНо награда способна возместить все ваши страдания");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "乌干达国宝");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我100%确定这可以杀掉你 - 格雷格"
			+"\n使用它可能会导致灾难性的后果..."
			+"\n但是奖励足以回报你的受苦");
        }    
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RecallPotion);
            Item.maxStack = 99;
            Item.consumable = false;
			Item.scale = 0.5f;
			Item.UseSound = SoundID.Item37;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Knuckles>());
			ModGlobalNPC.ksu = true;
			ModGlobalNPC.kc = 0;
			ModGlobalNPC.ks = false;
			return true;
		}
    }
}

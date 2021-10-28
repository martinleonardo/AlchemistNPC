using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.QuestFishes
{
	public class NebulaFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Fish");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Туманная Рыба");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星云鱼");
		}

		public override void SetDefaults()
		{
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 26;
			Item.height = 26;
			Item.uniqueStack = true;
			Item.rare = -11;		//The rarity of -11 gives the item orange color
		}

		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).NebulaFish = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			if (Main.hardMode && NPC.downedAncientCultist)
			{
				return true;
			}
			return false;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "There's this unearthly looking fish... probably looks that way because it's from celestial bodies of water. Probably tastes heavenly too, so go get it for me!";
			catchLocation = "Caught nearby Nebula Pillar.";
		}
	}
}

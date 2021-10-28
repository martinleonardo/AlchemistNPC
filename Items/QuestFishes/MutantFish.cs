using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.QuestFishes
{
	public class MutantFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mutant Fish");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мутировавшая Рыба");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "变种鱼");
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
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).DriedFish = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return Main.hardMode;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "It seems like our dear Alchemist often fails in making ''quality'' potions. He always pouring his bad results into nearest big pool. And today, I saw consequences of that. A Mutant fish, which was looking like Airplane. I want you to get it to me!";
			catchLocation = "Caught anywhere.";
		}
	}
}

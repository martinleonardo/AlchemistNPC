using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.QuestFishes
{
	public class MiniShark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini Shark");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мини Акула");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "迷你鲨");
		}

		public override void SetDefaults()
		{
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 26;
			Item.height = 26;
			Item.uniqueStack = true;
			Item.rare = -11;
		}

		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MiniShark = true;
		}
		
		public override bool IsQuestFish()
		{
			return true;
		}

		public override bool IsAnglerQuestAvailable()
		{
			return true;
		}

		public override void AnglerQuestChat(ref string description, ref string catchLocation)
		{
			description = "As I heard, sometimes sharks can't grow big enough to be counted as actual sharks. Then they should be called ''Mini Sharks''. And now you are gonna get me one of these!";
			catchLocation = "Caught in the Ocean.";
		}
	}
}

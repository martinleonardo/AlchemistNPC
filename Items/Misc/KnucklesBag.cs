using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	public class KnucklesBag : ModItem
	{
		public override int BossBagNPC => NPCType<NPCs.Knuckles>();
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "宝藏袋");
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 24;
			Item.height = 24;
			Item.rare = 9;
			Item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.EdgeOfChaos>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.LastTantrum>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.BreathOfTheVoid>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.ChaosBomb>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.UgandanTotem>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Equippable.AutoinjectorMK2>());
			player.QuickSpawnItem(ItemID.PlatinumCoin, 25);
		}
	}
}
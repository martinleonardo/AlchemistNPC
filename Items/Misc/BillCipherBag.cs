using Terraria;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	public class BillCipherBag : ModItem
	{
		public override int BossBagNPC => NPCType<NPCs.BillCipher>();
		
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
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.GoldenKnuckles>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.WrathOfTheCelestial>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Weapons.LaserCannon>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Equippable.GrapplingHookGunItem>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Equippable.IlluminatiGift>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Misc.BillSoul>());
			if (player.HasBuff(ModContent.BuffType<Buffs.GrimReaper>()) && Main.rand.Next(5) == 0)
			{
				player.QuickSpawnItem(ModContent.ItemType<Items.Equippable.MysticAmulet>());
			}
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (CalamityModRevengeance)
				{
					player.QuickSpawnItem(ModContent.ItemType<Items.MysticAmulet>());
				}
			}
			*/
			player.QuickSpawnItem(ItemID.PlatinumCoin, 10);
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		public bool CalamityModRevengeance
		{
        get { return CalamityMod.World.CalamityWorld.revenge; }
        }
		
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		*/
	}
}
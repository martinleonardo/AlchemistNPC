using Terraria;
using Terraria.ID;
using System.Linq;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Wings)]
	public class MechanicalWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Wings");
			Tooltip.SetDefault("Allows you to fly"
			+ "\nShoots deadly lasers at nearby enemies ");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Механические Крылья");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Позволяют летать\nСтреляют в ближайших противников лазерами");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机械翅膀");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "允许飞行\n发射致命激光攻击附近敌人");

            int     wingTimeMax = 120;
            float   speed = 9f;
            float   acceleration = 2f;

            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(wingTimeMax, speed, acceleration);
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 1000000;
			Item.rare = 8;
			Item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<Buffs.LaserBattery>(), 2);
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.135f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SteampunkWings)
				.AddIngredient(ItemID.MechanicalBatteryPiece)
				.AddIngredient(ItemID.XenoStaff)
				.AddIngredient(ItemID.HallowedBar, 12)
				.AddIngredient(ItemID.SoulofFright, 10)
				.AddIngredient(ItemID.SoulofSight, 10)
				.AddIngredient(ItemID.SoulofMight, 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class JustitiaCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia Crown (O-02-62)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Корона Юстиции (O-02-62)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "审判鸟王冠 (O-02-62)");
            Tooltip.SetDefault("Just like anything else, it had hope at first. The desire for peace now only exists in fairy tales."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases melee speed by 20%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как и что-либо другое, оно имело надежду поначалу. Теперь же мечта о мире имеет место лишь в сказках.\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость атак ближнего боя на 20%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'就像其他生物一样, 它最初也满怀着希望. 但如今, 对和平的渴望只能潜藏在幼稚的童话里.'\n[c/FF0000:EGO 盔甲]\n增加20%近战速度");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "JustitiaSetBonus");
		    text.SetDefault("Increases current melee damage by 30% and adds 15% to melee critical strike chance");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает текущий урон в ближнем бою на 30% и добаляет 15% к шансу критического удара");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加当前30%的近战伤害和15%近战暴击率");
            LocalizationLoader.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = 11;
			Item.defense = 25;
		}
		
        //Fix when implemented
        /*
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}
		*/

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.20f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.JustitiaSuit>() && legs.type == ModContent.ItemType<Items.Armor.JustitiaLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			string JustitiaSetBonus = Language.GetTextValue("Mods.AlchemistNPC.JustitiaSetBonus");
			player.setBonus = JustitiaSetBonus;
			player.GetDamage(DamageClass.Melee) += 0.30f;
			player.GetCritChance(DamageClass.Melee) += 15;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Blindfold)
				.AddIngredient(ItemID.LunarBar, 8)
				.AddIngredient(ItemID.FragmentNebula, 8)
            	.AddIngredient(ItemID.FragmentSolar, 8)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}
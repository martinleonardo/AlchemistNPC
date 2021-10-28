using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class StormbreakerThrown: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormbreaker");
			Tooltip.SetDefault("Forged to fight the most powerful beings in the universe. Wield it wisely."
			+"\nRight click in inventory to change damage type");
			
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Громобой");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выкован для противодействия самым мощным существам во вселенной. Используй его мудро.\nПравый клик в инвентаре меняет тип урона");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "风暴战锤");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "为了与宇宙中最强大的存在战斗而打造. 请明智地使用它."
			+"\n在物品栏中右键切换伤害类型");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(3858);
			Item.DamageType = DamageClass.Throwing;
			Item.damage = 110;
			Item.crit = 21;
			Item.width = 50;
			Item.height = 40;
			Item.hammer = 600;
			Item.axe = 120;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 10;
			Item.expert = true;
			Item.scale = 1.5f;
			Item.shoot = ProjectileType<Projectiles.StormbreakerSwing>();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.shoot = ProjectileType<Projectiles.StormbreakerSwing>();
			}
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 15;
				Item.useAnimation = 15;
				Item.damage = 150;
				Item.shootSpeed = 24f;
				Item.shoot = ProjectileType<Projectiles.StormbreakerT>();
				Item.noMelee = true;
				Item.noUseGraphic = true;
			}
			
			return base.CanUseItem(player);
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
			Item.consumable = true;
            Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, ModContent.ItemType<Items.Weapons.Stormbreaker>(), 1, false, 81);
        }
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 82;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.NimbusRod)
				.AddRecipeGroup("AlchemistNPC:AnyLunarHamaxe")
				.AddIngredient(ItemID.MoltenHamaxe)
				.AddIngredient(ItemID.MeteorHamaxe)
				.AddIngredient(ItemID.LivingWoodWand)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}

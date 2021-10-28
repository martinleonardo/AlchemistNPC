using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
    public class DarkMagicWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Magic Wand");
            Tooltip.SetDefault("Royal Dark Magic Wand"
            + "\nShoots wide beam that can eliminate everything on its way."
            + "\nThe longer you are holding the beam, the more powerful it becomes"
            + "\nMana cost grows respectively");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Тёмная Волшебная Палочка");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Королевская Тёмная Волшебная Палочка\nИспускает широкий луч, который способен уничтожить всё на своём пути\nЧем дольше удерживается луч, тем мощнее он становится\nЗатраты маны увеличиваются соответственно");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔杖");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "皇家魔杖\n发射一束能消灭一切的激光束\n激光持续时间越长, 威力越强\n法力消耗分别增加");
        }

        public override void SetDefaults()
        {
            Item.damage = 150;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Magic;
            Item.channel = true;                            //Channel so that you can held the weapon [Important]
            Item.mana = 10;
            Item.rare = 11;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 20;
            Item.UseSound = SoundID.Item13;
            Item.useStyle = 5;
            Item.shootSpeed = 14f;
            Item.useAnimation = 20;
            Item.knockBack = 1;
            Item.shoot = ProjectileType<Projectiles.MagicWandC>();
            Item.value = Item.sellPrice(1, 0, 0, 0);
        }

        public override void UseStyle(Player player, Rectangle rectangle)
        {
            Item.damage = 150;
            Item.mana = 10;
            ((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).chargetime++;
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).chargetime >= 390)
            {
                Item.damage = 250;
                Item.mana = 30;
                player.moveSpeed *= 0.50f;
            }
            else if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).chargetime >= 210)
            {
                Item.damage = 200;
                Item.mana = 20;
                player.moveSpeed *= 0.8f;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(null, "MagicWand")
                .AddIngredient(null, "ChromaticCrystal", 3)
                .AddIngredient(null, "SunkroveraCrystal", 3)
                .AddIngredient(null, "NyctosythiaCrystal", 3)
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 10)
					.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 15)

				}
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
					.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3)
					.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3)
					.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3)

				}
				*/
				.AddIngredient(null, "EmagledFragmentation", 100)
                .AddTile(null, "MateriaTransmutator")
                .Register();
        }
    }
}

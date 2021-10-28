using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
    public class OverloadedPortalGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rick's Portal Gun (Overloaded)");
            Tooltip.SetDefault("Copy of Rick Sanchez's Portal Gun"
            + "\nUses unstable technologies, making it work more rapidly"
            + "\nOpens portals to the random dangerous dimensions"
            + "\nRequires Energy Capsules as ammo"
            + "\nHope this thing wouldn't cause appearence of SEAL team Ricks");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Портальная пушка Рика (Перегруженная)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Копия портальной пушки Рика Санчеза\nИспользует нестабильные технологии, заставляющие её работать быстрее\nОткрывает порталы в различные измерения\nТребует Капсулы с энергией в качестве патронов\nНадеюсь, что она не вызовет появление Рик спецназа");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瑞克的传送枪 (超载)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瑞克·桑切斯的传送枪的复制品"
            + "\n使用不稳定科技, 这使它工作得更快"
            + "\n打开通往随机危险维度的传送门"
            + "\n需要能量胶囊作为弹药"
            + "\n希望这玩意别引来瑞克海豹突击队");
        }

        public override void SetDefaults()
        {
            Item.damage = 125;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 3000000;
            Item.rare = 11;
            Item.UseSound = SoundID.Item114;
            Item.autoReuse = true;
            Item.shoot = ProjectileType<Projectiles.PortalGunProj>();
            Item.shootSpeed = 16f;
            Item.useAmmo = ModContent.ItemType<Items.Weapons.EnergyCapsule>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(null, "PortalGun")
                .AddIngredient(null, "ChromaticCrystal", 3)
                .AddIngredient(null, "SunkroveraCrystal", 3)
                .AddIngredient(null, "NyctosythiaCrystal", 3)
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 5)
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 25)

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

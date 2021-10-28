using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class QuantumDestabilizer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Experiment #618"
			+"\nReleases entity destabilizing beam, which deals extremely high damage"
			+"\nRequires 1 seconds to charge the shot"
			+"\nRequires Energy Cells as ammo");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Квантовый Дестабилизатор");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эксперимент №618\nВыпускает луч, дестабилизирующий состояние противника и наносящий очень высокие повреждения\nТребует 1 секунду на заряд\nТребует Энергоячейки в качестве патронов");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "量子干扰器");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蓝图 #618\n释放出一束物质破坏光束, 能造成极高的伤害\n需要一秒钟充能\n需要能源电池作为弹药");
        }

		public override void SetDefaults()
		{
			Item.damage = 600;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.channel = true;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item13;
			Item.useStyle = 5;
			Item.shootSpeed = 14f;
			Item.useAnimation = 20;   
			Item.knockBack = 10;			
			Item.shoot = ProjectileType<Projectiles.QuantumDestabilizer>();
			Item.useAmmo = ModContent.ItemType<Items.Weapons.EnergyCell>();
			Item.value = Item.sellPrice(1, 0, 0, 0);
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14, 1);
		}
	}
}

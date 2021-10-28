using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TerrainReformer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Terrain Reformer");
			Tooltip.SetDefault("The legendary terrain reforming device made by Ancients"
			+"\nLeft click for precise mining"
			+"\nRight click for digging extremely fast");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Преобразователь Поверностей");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Легендарное устройства ландшафтного дизайна, созданное Древними\nЛевый клик для точной добычи блоков\nПравый клик для быстрого разрывания земли");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "大地重塑者");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "由远古文明所制作的传奇地形改造装置\n左键精确开采\n右键极速挖掘");
		}

		public override void SetDefaults() {
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 5;
			Item.useAnimation = 10;
			Item.pick = 225;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 100000;
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += 5;
			Item.useTurn = true;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.pick = 225;
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				Item.pick = 0;
				return true;
			}
			return base.UseItem(player);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
			}
			if (player.altFunctionUse == 2 || (player.altFunctionUse != 2 && Main.mouseRight))
			{
				int range = 32;
				int minTileX = (int)(player.position.X / 16f - (float)range);
				int maxTileX = (int)(player.position.X / 16f + (float)range);
				int minTileY = (int)(player.position.Y / 16f - (float)range);
				int maxTileY = (int)(player.position.Y / 16f + (float)range);
				if (minTileX < 0) {
					minTileX = 0;
				}
				if (maxTileX > Main.maxTilesX) {
					maxTileX = Main.maxTilesX;
				}
				if (minTileY < 0) {
					minTileY = 0;
				}
				if (maxTileY > Main.maxTilesY) {
					maxTileY = Main.maxTilesY;
				}
				for (int i = minTileX; i < maxTileX; ++i)
				{
					for (int j = minTileY; j < maxTileY; ++j)
					{
						if (Main.tile[i, j].type == 88 || Main.tile[i, j].type == 21 || Main.tile[i, j].type == 26 || Main.tile[i, j].type == 237 ) continue;
						if (Main.tile[i, j].type == null) continue;
						if (!Main.tile[i, j].IsActive) continue;
						if (hitbox.Intersects(new Rectangle(i * 16, j * 16, 16, 16)))
						{
							WorldGen.KillTile(i, j, false, false, false);
						}
					}
				}
			}
		}
	}
}
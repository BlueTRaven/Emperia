using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Mushor 
{
public class Shroomflask : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomy Flask");
		}
	public override void SetDefaults()
	{
		item.width = 28;  //The width of the .png file in pixels divided by 2.
		item.damage = 22;  
		item.mana = 15;//Keep this reasonable please.
		item.magic = true;  //Dictates whether this is a melee-class weapon.
		item.noMelee = true;
		item.noUseGraphic = true;
		item.useAnimation = 23;
		item.useStyle = 1;
		item.useTime = 23;
		item.knockBack = 6.5f;  //Ranges from 1 to 9.
		item.UseSound = SoundID.Item106;
		item.autoReuse = true;  //Dictates whether the weapon can be "auto-fired".
		item.height = 30;  //The height of the .png file in pixels divided by 2.
		item.maxStack = 1;
		item.value = 60000;  //Value is calculated in copper coins.
		item.rare = 7;  //Ranges from 1 to 11.
		item.shoot = mod.ProjectileType("ShroomFlask");
		item.shootSpeed = 9f;
	}
}}

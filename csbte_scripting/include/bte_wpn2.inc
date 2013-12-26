#define PLUGIN_NAME	"BTE Weapon Base"
#define PLUGIN_VERSION	"1.0"
#define PLUGIN_AUTHOR	"BTE TEAM"

#define BTE_WPN_FILE "bte_wpn.ini"
#define BTE_MYWPN_FILE "bte_precachewpn.ini"
#define PRECACHE_MAX	50
#define BTE_LOG_FILE	"bte_wpn_log.log"
#define BTE_CONFIG_FILE	"bte_wpn_config.ini"

#define MODEL_URL	"models/bte_wpn"
#define SPR_URL		"sprites/special"
#define SOUND_URL	"weapons"

native bte_zb3_is_boomer_skilling(id)

/* idwpn default */
// CSW_KNIFE	1
// CSW_GLOCK18	2
// CSW_USP	3
#define PRINT(%1) client_print(1,print_chat,%1)
#define SPRINT(%1) server_print(%1)
#define write_coord_f(%0) ( engfunc( EngFunc_WriteCoord, %0 ) )
#define MAX_WPN		512
#define MAX_WPN_RIFLES	256
#define MAX_WPN_PISTOLS	128
#define MAX_WPN_KNIFES	64
#define MAX_WPN_HES	64
#define CSW_END		CSW_P90+1

#define MAX_MYWPN_RIFLES	100
#define MAX_MYWPN_PISTOLS	50
#define MAX_MYWPN_KNIFES	20
#define MAX_MYWPN_HES	20
#define WPN_SLOT	4

#define CHANNEL_SVDEX	1
#define MAX_BLOCK	256

// Save Weapon Data
#define DEF_ISWEAPONBOX	11
#define DEF_SPAWN	12
#define DEF_ID		13
#define DEF_CLIP	14
#define DEF_AMMO	15
#define DEF_OWNER	16
#define DEF_ISDOUBLE	17
#define DEF_ISDROPPED	18
// Save Entity Data
#define DEF_ENTCLASS	19
#define DEF_ENTID		20
#define DEF_ENTSTAT		21

#define Set_Ent_Data(%1,%2,%3) set_pdata_int(%1,%2,%3,4)
#define Get_Ent_Data(%1,%2) get_pdata_int(%1,%2,4)
#define Set_Wpn_Data(%1,%2,%3) set_pdata_int(%1,%2,%3,4)
#define Get_Wpn_Data(%1,%2) get_pdata_int(%1,%2,4)

#define MAXMENUPOS 26
new g_Aliases[MAXMENUPOS][] = {"usp","glock","deagle","p228","elites","fn57","m3","xm1014","mp5","tmp","p90","mac10","ump45","ak47","galil","famas","sg552","m4a1","aug","scout","awp","g3sg1","sg550","m249","hegren","shield"} 
new g_Aliases2[MAXMENUPOS][] = {"km45","9x19mm","nighthawk","228compact","elites","fiveseven","12gauge","autoshotgun","smg","mp","c90","mac10","ump45","cv47","defender","clarion","krieg552","m4a1","bullpup","scout","magnum","d3au1","krieg550","m249","hegren","hegren"}

new const Float:g_vecZero[3]={0.0,0.0,0.0}

new const WEAPON_BPAMMO[CSW_P90+1] = {
	-1,  52, -1, 90,  1,  32,    1, 100, 90, 1, 120, 
		100, 100, 90, 90, 90,   100, 120, 30, 120, 200, 
		32 , 90, 120, 90, 2,    35, 90, 90, -1,  100
}
new const WEAPON_CLIP[CSW_P90+1] = {
	-1,  13, -1, 10,  1,  7,    1, 30, 30,  1,  30, 
		20, 25, 30, 35, 25,   12, 20, 10, 30, 100, 
		8 , 30, 30, 20,  2,    7, 30, 30, -1,  50
}

new const RELOAD_ANIM[CSW_P90+1] = {
	-1,  5, -1, 3, -1,  6,   -1, 1, 1, -1, 14, 
		4,  1, 3,  1,  1,   13, 7, 4,  1,  3, 
		6, 11, 1,  3, -1,    4, 1, 1, -1,  1
}
new const SHOOT_ANIM[CSW_P90+1] = {
	-1,  1, -1, 3, -1,  1,   -1, 3, 3, -1, 1, 
		1,  3, 3,  3,  3,   1, 7, 1,  3,  3, 
		1, 1, 3,  3, -1,    1, 3, 3, -1,  3
}
new const Float:WEAPON_DELAY[CSW_P90+1] = {
	0.00, 2.70, 0.00, 2.00, 0.00, 0.55,   0.00, 3.15, 3.30, 0.00, 4.50, 
		 2.70, 3.50, 3.35, 2.45, 3.30,   2.70, 2.20, 2.50, 2.63, 4.70, 
		 0.55, 3.05, 2.12, 3.50, 0.00,   2.20, 3.00, 2.45, 0.00, 3.40
}
new const MAXCLIP[] = { -1, 13, -1, 10, -1, 7, -1, 30, 30, -1, 30, 20, 25, 30, 35, 25, 12, 20,
			10, 30, 100, 8, 30, 30, 20, -1, 7, 30, 30, -1, 50 }
new const CSWPN_POSITION[] = { 0,3,0,9,1,12,3,13,14,3,5,6,15,16,17,18,4,2,2,7,4,5,6,11,3,2,1,10,1,1,8,0}
new const Float:WEAPON_MAXSPEED[]={250.0, 250.0, 0.0, 260.0, 250.0, 240.0, 250.0, 250.0, 240.0, 250.0, 250.0, 250.0, 250.0,
210.0, 240.0, 240.0, 250.0, 250.0, 210.0, 250.0, 220.0, 230.0, 230.0, 250.0, 210.0, 250.0, 250.0, 235.0, 221.0, 250.0, 245.0}
new const WEAPON_NAME[][] = { "", "weapon_p228", "", "weapon_scout", "weapon_hegrenade", "weapon_xm1014", "weapon_c4", "weapon_mac10",
			"weapon_aug", "weapon_smokegrenade", "weapon_elite", "weapon_fiveseven", "weapon_ump45", "weapon_sg550",
			"weapon_galil", "weapon_famas", "weapon_usp", "weapon_glock18", "weapon_awp", "weapon_mp5navy", "weapon_m249",
			"weapon_m3", "weapon_m4a1", "weapon_tmp", "weapon_g3sg1", "weapon_flashbang", "weapon_deagle", "weapon_sg552",
			"weapon_ak47", "weapon_knife", "weapon_p90"
}
new const WEAPON_TOTALANIM[]={0,7,0,5,0,7,0,6,6,0,16,6,6,5,6,6,16,13,6,6,5,7,14,6,5,0,6,6,6,0,6,0}
new const WEAPON_EVENT[]={0,18,0,4,0,11,0,13,8,0,24,15,14,9,27,28,12,20,1,21,5,10,6,22,2,0,17,0,3,19,16}
new const WEAPON_AMMOID[] = { -1, 9, -1, 2, 12, 5, 14, 6, 4, 13, 10, 7, 6, 4, 4, 4, 6, 10,
			1, 10, 3, 5, 4, 10, 2, 11, 8, 4, 2, -1, 7
}
new const WEAPON_AMMOTYPE[][] = { "", "357sig", "", "762nato", "", "buckshot", "", "45acp", "556nato", "", "9mm", "57mm", "45acp",
			"556nato", "556nato", "556nato", "45acp", "9mm", "338magnum", "9mm", "556natobox", "buckshot",
			"556nato", "9mm", "762nato", "", "50ae", "556nato", "762nato", "", "57mm"
}
enum _:(+=2) {		
	ammo_buckshot = 11,
	ammo_9mm,
	ammo_556nato,
	ammo_556natobox,
	ammo_762nato,
	ammo_45acp,
	ammo_50ae,
	ammo_338Magnum,
	ammo_57mm,
	ammo_357sig
}

new const g_iAmmoOffsets[CSW_P90+1] = {
	-1,	ammo_357sig,	-1,				ammo_762nato,	-1,				ammo_buckshot,
		-1,				ammo_45acp,		ammo_556nato,	-1,				ammo_9mm, 
		ammo_57mm,		ammo_45acp,		ammo_556nato,	ammo_556nato,	ammo_556nato,
		ammo_45acp,		ammo_9mm,		ammo_338Magnum, ammo_9mm,		ammo_556natobox, 
		ammo_buckshot,	ammo_556nato,	ammo_9mm,		ammo_762nato,	-1,
		ammo_50ae,		ammo_556nato,	ammo_762nato,	-1,				ammo_57mm}
new const DEPLOY_ANIM[CSW_P90+1] = {
	-1,  6, -1, 4, 3,  
	6,   1, 2, 2, 3, 
	15, 5,  2, 4,  2,  
	2,  6, 8, 5,  2, 
	4, 6, 5, 2,  4, 
	3,    5, 2, 2, 3,
	2
}
new g_bte_replace2[][]=
{
	"[d_cswpn]",
	"[d_tchange1]",
	"[d_tchange2]",
	"[d_damage]",
	"[d_speed]",
	"[d_zoom]",
	"[d_recoil]",
	"[d_clip]",
	"[d_reload]",
	"[d_deploy]",
	"[d_knockback]",
	"[d_gravity]",
	"[l_nade]",
	"[l_costammo]",
	"[l_tchange1]",
	"[l_tchange2]",
	"[l_reload]",
	"[l_knockback]",
	"[l_radius]",
	"[l_damage]",
	"[l_gravity]",
	"[l_lighteffect]",
	"[l_speed]",
	"[l_forward]",
	"[l_right]",
	"[l_up]",
	"[l_type]",
	"[l_angle]",
	"[m_timeready]",
	"[sp_speed]",
	"[sp_times]",
	"[m_damage]",
	"[m_radius]",
	"[m_gravity]",
	"[m_speed]",
	"[speed1]",
	"[speed2]",
	"[distance1]",
	"[distance2]",
	"[damage2]",
	"[dmgzb2]",
	"[delay1]",
	"[delay2]",
	"[angle]",
	"[sequence]",
	"[knockback2]",
	"[recoil2]"
}
new g_bte_replace[][]=
{
	"[type]",
	"[menu]",
//	"[name]",
	"[model]",
	"[p_sub]",
	"[p_body]",
	"[w_sub]",
	"[w_body]",
	"[p_sequence]",
	"[sequence]",
	"[seqframerate]",
	"[cswpn]",
	"[damage]",
	"[speed]",
	"[zoomspeed]",
	"[zoom]",
	"[clip]",
	"[ammo]",
	"[maxammo]",
	"[ammocost]",
	"[recoil]",
	"[spread]",
	"[gravity]",
	"[knockback]",
	"[knockbackh]",
	"[stop_speed]",
	"[stop_time]",
	"[reload]",
	"[deploy]",
	"[cost]",
	"[sound]",
	"[sprite]",
	"[team]",
	"[buy]",
	"[shake]",
	"[dmgzb]",
	"[dmgzs]",
	"[enhance]",
	//"[dmghs]",
	"[special]",
	"[buy_mod]"
	//"[enhance]"
	
}
new g_guns_events[][] = 
{
	"events/awp.sc",
	"events/g3sg1.sc",
	"events/ak47.sc",
	"events/scout.sc",
	"events/m249.sc",
	"events/m4a1.sc",
	"events/sg552.sc",
	"events/aug.sc",
	"events/sg550.sc",
	"events/m3.sc",
	"events/xm1014.sc",
	"events/usp.sc",
	"events/mac10.sc",
	"events/ump45.sc",
	"events/fiveseven.sc",
	"events/p90.sc",
	"events/deagle.sc",
	"events/p228.sc",
	"events/glock18.sc",
	"events/mp5n.sc",
	"events/tmp.sc",
	"events/elite_left.sc",
	"events/elite_right.sc",
	"events/galil.sc",
	"events/famas.sc"
}
// cs wepaon type bit sum
const CSWPN_NOCLIP	= ((1<<2)|(1<<CSW_HEGRENADE)|(1<<CSW_SMOKEGRENADE)|(1<<CSW_FLASHBANG)|(1<<CSW_KNIFE)|(1<<CSW_C4))
const CSWPN_NOTREMOVE = (1<<CSW_SMOKEGRENADE)|(1<<CSW_FLASHBANG)|(1<<CSW_C4)
const CSWPN_SHOTGUNS	= ((1<<CSW_M3)|(1<<CSW_XM1014))
const CSWPN_SILENT	= ((1<<CSW_USP)|(1<<CSW_M4A1))
const CSWPN_SNIPER	= ((1<<CSW_SCOUT)|(1<<CSW_SG550)|(1<<CSW_AWP)|(1<<CSW_G3SG1))
const CSWPN_FIRSTZOOM	= ((1<<CSW_AUG)|(1<<CSW_SG552))
const CSWPN_BURST	= ((1<<CSW_FAMAS)|(1<<CSW_GLOCK18))
const NOSHOOT2_BS = ((1<<CSW_KNIFE)|(1<<CSW_GLOCK18)|(1<<CSW_ELITE))
const CSWPN_SEC = (1<<CSW_P228)|(1<<CSW_ELITE)|(1<<CSW_FIVESEVEN)|(1<<CSW_USP)|(1<<CSW_GLOCK18)|(1<<CSW_DEAGLE)
const PRIMARY_WEAPONS_BIT_SUM = (1<<CSW_SCOUT)|(1<<CSW_XM1014)|(1<<CSW_MAC10)|(1<<CSW_AUG)|(1<<CSW_UMP45)|(1<<CSW_SG550)|(1<<CSW_GALIL)|(1<<CSW_FAMAS)|(1<<CSW_AWP)|(1<<CSW_MP5NAVY)|(1<<CSW_M249)|(1<<CSW_M3)|(1<<CSW_M4A1)|(1<<CSW_TMP)|(1<<CSW_G3SG1)|(1<<CSW_SG552)|(1<<CSW_AK47)|(1<<CSW_P90)
const SECONDARY_WEAPONS_BIT_SUM = (1<<CSW_P228)|(1<<CSW_ELITE)|(1<<CSW_FIVESEVEN)|(1<<CSW_USP)|(1<<CSW_GLOCK18)|(1<<CSW_DEAGLE)

//Weapon/Player Offset
const m_rgpWeaponBoxPlayerItems	 = 34
const m_pPlayer			= 41
const m_pNext	 		= 42
const m_iId			= 43
const m_fKnown			= 44
const m_flNextPrimaryAttack	= 46
const m_flNextSecondaryAttack	= 47
const m_flTimeWeaponIdle	= 48
const m_iPrimaryAmmoType	= 49
const m_iClip			= 51
const m_fInReload		= 54
const m_fInSpecialReload	= 55
const m_fSilent			= 74
const m_flNextAttack		= 83
const m_rgpPlayerItems = 367
const m_pActiveItem		= 373
const m_iFOV			= 363
const m_iTeam			= 114

const m_iShotsFired = 64
const m_iDefaultAmmo = 56
const m_flFamasShoot = 71
const m_iFamasShotsFired = 72
const m_iWeaponState = 74
const m_fHasBeenKilledLastRound = 113

#define WPNSTATE_USP_SILENCED (1<<0)
#define WPNSTATE_GLOCK18_BURST_MODE (1<<1)
#define WPNSTATE_M4A1_SILENCED (1<<2)
#define WPNSTATE_ELITE_LEFT (1<<3)
#define WPNSTATE_FAMAS_BURST_MODE (1<<4)
#define WPNSTATE_SHIELD_DRAWN (1<<5)

const m_rgAmmo_player_Slot0	= 376
const m_Activity		= 73
const m_rgAmmo = 376
const EXTRAOFFSET = 4
const OFFSET_LINUX = 5
const OFFSET_LINUX_WEAPONS = 4
const OFFSET_WEAPONCLIP = 52
const OFFSET_AWM_AMMO  = 377 
const OFFSET_SCOUT_AMMO = 378
const OFFSET_PARA_AMMO = 379
const OFFSET_FAMAS_AMMO = 380
const OFFSET_M3_AMMO = 381
const OFFSET_USP_AMMO = 382
const OFFSET_FIVESEVEN_AMMO = 383
const OFFSET_DEAGLE_AMMO = 384
const OFFSET_P228_AMMO = 385
const OFFSET_GLOCK_AMMO = 386
const OFFSET_FLASH_AMMO = 387
const OFFSET_HE_AMMO = 388
const OFFSET_SMOKE_AMMO = 389
const OFFSET_C4_AMMO = 390
const OFFSET_CLIPAMMO = 51
const OFFSET_ZOOMTYPE	= 363

enum _:BUFF_STAT(+=1)
{
	BUFF_START = 0,
	BUFF_FLAME,
	BUFF_HOLY,
	BUFF_FIRE,
	BUFF_END
}
enum _:WEAPON_SPECIAL
{
	SPECIAL_M134EX=1, /////
	SPECIAL_HAMMER,   /////
	SPECIAL_INFINITY, /////
	SPECIAL_MUSKET,   /////
	SPECIAL_CROSSBOW, ///// -- 5
	SPECIAL_SKULL1,   /////
	SPECIAL_HOLYBOMB, /////
	SPECIAL_AT4CS,    /////
	SPECIAL_SKULLAXE, /////
	SPECIAL_DRAGONTAIL, ///// --- 10
	SPECIAL_CATAPULT, /////
	SPECIAL_CANNON,   /////
	SPECIAL_KATANA,   /////
	SPECIAL_STRONGKNIFE,/////
	SPECIAL_TRACER,   ///// --- 15
	SPECIAL_M79,	  /////
	SPECIAL_FIRECRAKER, /////
	SPECIAL_VIOLIN,    /////
	SPECIAL_FIREBOMB,  /////
	SPECIAL_POISON,    ///// --- 20
	SPECIAL_BALROG7,   /////
	SPECIAL_SKULL3,    /////
	SPECIAL_SFMG,     //////
	SPECIAL_BAZOOKA, //////
	SPECIAL_ZG ,        ///// --- 25
	SPECIAL_HERO,
	SPECIAL_SFSNIPER,  
	SPECIAL_OICW,
	SPECIAL_M249EP,
	SPECIAL_BALROG9, ///// --- 30
	SPECIAL_BALROG5,
	SPECIAL_BALROG1,
	SPECIAL_CHAINSAW,
	SPECIAL_QBARREL,
	SPECIAL_BALROG3, ////--- 35
	SPECIAL_M16A1,
	SPECIAL_COILGUN,
	SPECIAL_FIXSHOOT,
	SPECIAL_SPAS12EX,
	SPECIAL_SPAS12EX2, ///// --- 40
	SPECIAL_BALROG11,
	SPECIAL_M200,
	SPECIAL_PLASMA,
	SPECIAL_WATERCANNON, 
	SPECIAL_SFSWORD,//// ----- 45
	SPECIAL_SKULL8,
	SPECIAL_TKNIFE,
	SPECIAL_JANUSMK5,
	SPECIAL_BOW,
	SPECIAL_JANUS7, ///// ---- 50
	SPECIAL_DGUN
}
enum _:ENTITY_CLASS (+=100)
{
	ENTCLASS_NADE=2000,
	ENTCLASS_NADE_BOUNCE,
	ENTCLASS_FLAME,
	ENTCLASS_BOLT,
	ENTCLASS_DRAGONTAIL,
	ENTCLASS_CANNON,
	ENTCLASS_PLASMA,
	ENTCLASS_SMOKE,
	ENTCLASS_TKNIFE,
	ENTCLASS_KILLME,
	ENTCLASS_BOW,
	ENTCLASS_SFSNIPER,
	ENTCLASS_DGUN
}
enum _:WPN_DEFAULT_SECTION
{
	SECTION_TYPE = 0,
	SECTION_MENU,
//	SECTION_NAME,
	SECTION_MODEL,
	SECTION_P_SUB,
	SECTION_P_BODY,
	SECTION_W_SUB,
	SECTION_W_BODY,
	SECTION_P_SEQ,
	SECTION_SEQ,
	SECTION_SEQFRAMERATE,
	SECTION_CSWPN,
	SECTION_DAMAGE,
	SECTION_SPEED,
	SECTION_ZOOMSPEED,
	SECTION_ZOOM,
	SECTION_CLIP,
	SECTION_AMMO,
	SECTION_MAXAMMO,
	SECTION_AMMOCOST,
	SECTION_RECOIL,
	SECTION_SPREAD,
	SECTION_GRAVITY,
	SECTION_KNOCKBACK,
	SECTION_KNOCKBACKH,
	SECTION_STOP_SPEED,
	SECTION_STOP_TIME,
	SECTION_RELOAD,
	SECTION_DEPLOY,
	SECTION_COST,
	SECTION_SOUND,
	SECTION_SPRITE,
	SECTION_TEAM,
	SECTION_BUY,
	SECTION_SHAKE,
	SECTION_DMG_ZB,
	SECTION_DMG_ZS,
	SECTION_ENHANCE,
	SECTION_SPECIAL,
	SECTION_BUYMOD,
	SECTION_STARTNUM
	
}
enum _:WPN_SLOT_TYPE
{
	WPN_RIFLE = 1,
	WPN_PISTOL,
	WPN_KNIFE,
	WPN_HE
}
enum _:WPN_TYPE
{
	WEAPONS_NORMAL = 1,  // 
	WEAPONS_DOUBLE,      //
	WEAPONS_LAUNCHER,	//
	WEAPONS_SHOTGUN,     //
	WEAPONS_M134,        //
	WEAPONS_SPSHOOT,     //
	WEAPONS_FLAMETHROWER, //
	WEAPONS_BAZOOKA, //
	WEAPONS_M32, // 9
	WEAPONS_SVDEX,
	WEAPONS_CHAINSAW,
	WEAPONS_FG, //12
	WEAPONS_CUSTOM,
	WEAPONS_SPAS12,
	WEAPONS_PLASMA //15
}
enum _:WPN_KNIFE_SECTION
{
	SECTION_K_SPEED1 = SECTION_STARTNUM,
	SECTION_K_SPEED2,
	SECTION_K_DISTANCE1,
	SECTION_K_DISTANCE2,
	SECTION_K_DAMAGE2,	
	SECTION_K_DAMAGEZB2,
	SECTION_K_DELAY1,
	SECTION_K_DELAY2,
	SECTION_K_ANGLE,
	SECTION_K_SEQUENCE
}
enum _:WPN_DOUBLE_SECTION
{
	SECTION_D_CSWPN = SECTION_STARTNUM,
	SECTION_D_TIMECHANGE1,
	SECTION_D_TIMECHANGE2,
	SECTION_D_DAMAGE,
	SECTION_D_SPEED,
	SECTION_D_ZOOM,
	SECTION_D_RECOIL,
	SECTION_D_CLIP,
	SECTION_D_RELOAD,
	SECTION_D_DEPLOY,
	SECTION_D_KNOCKBACK,
	SECTION_D_GRAVITY
}
enum _:WPN_LAUNCHER_SECTION
{
	SECTION_L_NADE = SECTION_STARTNUM,
	SECTION_L_COSTAMMO,
	SECTION_L_TIMECHANGE1,
	SECTION_L_TIMECHANGE2,
	SECTION_L_TIMERELOAD,
	SECTION_L_KNOCKBACK,
	SECTION_L_RADIUS,
	SECTION_L_DAMAGE,
	SECTION_L_GRAVITY,
	SECTION_L_LIGHTEFFECT,
	SECTION_L_SPEED,
	SECTION_L_ANGLE,
	SECTION_L_FORWARD,
	SECTION_L_RIGHT,
	SECTION_L_UP,
	SECTION_L_TYPE
}
enum _:WPN_CUSTOM_SECTION
{
	SECTION_FORWARD = SECTION_STARTNUM,
	SECTION_RIGHT,
	SECTION_UP
}

enum _:WPN_M32_SECTION
{
	SECTION_M_DAMAGE = SECTION_STARTNUM,
	SECTION_M_RADIUS,
	SECTION_M_GRAVITY,
	SECTION_M_SPEED
}
enum _:WPN_SPECIALSHOOT_SECTION
{
	SECTION_SP_SPEED = SECTION_STARTNUM,
	SECTION_SP_TIMES
}
enum _:WPN_SPAS12_SECTION
{
	SECTION_SPEED2 = SECTION_STARTNUM,
	SECTION_DAMAGE2,
	SECTION_RECOIL2
}
enum _:WPN_CHAINSAW_SECTION
{
	SECTION_C_KNOCKBACK2 = SECTION_STARTNUM,
	SECTION_C_SPEED2,
	SECTION_C_DISTANCE1,
	SECTION_C_DISTANCE2,
	SECTION_C_DAMAGE2,
	SECTION_C_DAMAGEZB2,
	SECTION_C_ANGLE
}
// zoom type
enum _:ZOOM_TYPE
{
	ZOOMTYPE_NONE = 0,
	ZOOMTYPE_AUG,
	ZOOMTYPE_SNIPER,
	ZOOMTYPE_ONCE
}
// fake damage
enum _:FAKEDAMAGETYPE
{
	FAKE_TYPE_HULL = (1<<1),
	FAKE_TYPE_GENER = (1<<2),
	FAKE_TYPE_GENER_HEAD = (1<<3), //for flamethrower
	FAKE_TYPE_TRACEBLEED = (1<<4),
	FAKE_TYPE_CHECKDIRECT = (1<<5),
	FAKE_TYPE_CHECKPHIT = (1<<6),
	FAKE_TYPE_HITHEAD = (1<<7)
}
enum _:FAKEDAMAGERESULT
{
	FAKE_RESULT_HIT_PLAYER,
	FAKE_RESULT_HIT_WALL,
	FAKE_RESULT_HIT_NONE
}
enum _:FAKEBUTTON
{
	FAKE_SLASH = 1,
	FAKE_STAB
}	
// Weapon anim
enum _:SHOTGUN_ANIM
{
	SHOTGUN_idle,
	SHOTGUN_shoot1,
	SHOTGUN_shoot2,
	SHOTGUN_insert,
	SHOTGUN_after_reload,
	SHOTGUN_start_reload,
	SHOTGUN_draw
}
enum _:INFINITY_ANIM
{
	INFINITY_idle,
	INFINITY_idle_leftempty,
	shoot_left_1,
	shoot_left_2,
	shoot_left_3,
	shoot_left_4,
	shoot_left_5,
	shoot_leftlast,
	shoot_right_1,
	shoot_right_2,
	shoot_right_3,
	shoot_right_4,
	shoot_right_5,
	shoot_rightlast,
	INFINITY_reload,
	INFINITY_draw,
	SP_shoot_left_1, //16
	SP_shoot_left_2,
	SP_shoot_right_1,
	SP_shoot_right_2
}
// Launcher
enum _:Launcher_Anim
{
	LAUNCHER_Anim_Draw,
	LAUNCER_Anim_Shoot,
	LAUNCER_Anim_ShootLast
}
// M134 Stat
enum _:M134_Anim
{
	M134_Anim_FireReady,
	M134_Anim_FireAfter,
	M134_Anim_IdleChange,
	M134_Anim_FireChange
}
enum _:M134_STAT
{
	M134_IDLE,
	M134_SPIN_UP,
	M134_SPINNING,
	M134_SPIN_DOWN
}
enum _:MUSKET_STAT
{
	MUSKET_IDLE,
	MUSKET_PREFIRE
}
enum _:KNIFE_DELAY_ANIM
{
	KNIFE_IDLE = 0,
	KNIFE_PRE,
	KNIFE_CD
}
enum _:Sfsword_Anim
{
	Sfsword_idel = 0,
	Sfsword_on,
	Sfsword_off,
	Sfsword_draw,
	Sfsword_stab,
	Sfsword_stab_miss,
	Sfsword_midslash1,
	Sfsword_midslash2,
	Sfsword_midslash3,
	Sfsword_off_idle,
	Sfsword_off_slash1
}


#define DMG_GENERIC 0
#define DMG_CRUSH (1<<0)
#define DMG_BULLET (1<<1)
#define DMG_SLASH (1<<2)
#define DMG_BURN (1<<3)
#define DMG_FREEZE (1<<4)
#define DMG_FALL (1<<5)
#define DMG_BLAST (1<<6)
#define DMG_CLUB (1<<7)
#define DMG_SHOCK (1<<8)
#define DMG_SONIC (1<<9)
#define DMG_ENERGYBEAM (1<<10)
#define DMG_NEVERGIB (1<<12)
#define DMG_ALWAYSGIB (1<<13)
#define DMG_DROWN (1<<14)
//#define DMG_TIMEBASED (~(0x3FFF))

#define DMG_PARALYZE (1<<15)
#define DMG_NERVEGAS (1<<16)
#define DMG_POISON (1<<17)
#define DMG_RADIATION (1<<18)
#define DMG_DROWNRECOVER (1<<19)
#define DMG_ACID (1<<20)
#define DMG_SLOWBURN (1<<21)
#define DMG_SLOWFREEZE (1<<22)
#define DMG_MORTAR (1<<23)
#define DMG_EXPLOSION (1<<24)
#define DMG_GIB_CORPSE (DMG_CRUSH | DMG_FALL | DMG_BLAST | DMG_SONIC | DMG_CLUB)
#define DMG_SHOWNHUD (DMG_POISON | DMG_ACID | DMG_FREEZE | DMG_SLOWFREEZE | DMG_DROWN | DMG_BURN | DMG_SLOWBURN | DMG_NERVEGAS | DMG_RADIATION | DMG_SHOCK)

enum _:HITGROUP
{
	HITGROUP_GENERIC = 0,
	HITGROUP_HEAD,
	HITGROUP_CHEST,
	HITGROUP_STOMACH,
	HITGROUP_LEFTARM,
	HITGROUP_RIGHTARM,
	HITGROUP_LEFTLEG,
	HITGROUP_RIGHTLEG,
	HITGROUP_SHIELD	
}

#define JANUSMK5_CANUSE		1
#define JANUSMK5_USING		2

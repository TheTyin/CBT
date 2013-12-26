// MetaHook Include
// Version 1.0
// Author: Martin
// Editor: Csoldjb (Thanks to Martin!!!)

#define	HUMAN		20
#define	TANK_ZB		0
#define	SPEED_ZB	1
#define	HEAVY_ZB	2
#define	HEAL_ZB		3
#define	DEIMOS_ZB	4
#define	CHINA_ZB	5
#define	BOMMER_ZB	6
#define	RESIDENT_ZB	7

native MH_DrawTargaImage(id,szTga[],iFunc,iCenter,r,g,b,Float:x,Float:y,iMode,iChan,Float:fTime) //
native MH_DrawCountDown(id,sz[],itime)
native MH_DrawCountDownReset(id)
native MH_RespawnBar(id,i,Float:time)
native MH_IsMetaHookPlayer(iIndex)
native MH_DrawFontText(id,text[],icenter,Float:x,Float:y,r,g,b,iSale,Float:fLastTime,Float:fFadeTime,iFillBg,iChannel)
native MH_PlayBink(id,sBink[],Float:x,Float:y,iR,iG,iB,iLoop,iPlay,iCenter,iFullScreen)
native MH_DrawRetina(id,sTga[],iShow,iFullScreen,iFlash,iChanne,Float:fTime)

native MH_DrawExtraAmmo(iIndex,iType)
native MH_Quest(id,i1,i2,i3)
native MH_WeaponSkin(id,i1,sz[],i2)
native MH_SendDRRank(id,iRank,id2,s[])
native MH_ChangeTattoo(id,sTattoo[],iType)
native MH_SendClientModRunning(iIndex,iModRunning)
native MH_SpecialEvent(iIndex , iSpecialEvent)
native MH_DrawImage(iIndex, iCheck = 1, iCenter = 1, const szSprite[], Float:x = 0.5, Float:y = 0.5, r = 255, g = 255, b = 255, iMode = 0, Float:flDisplayTime = 1.0, iChanne = 0, iLength)
native MH_DrawAdditiveImage(iIndex, iCheck = 1, iCenter = 1, const szSprite[], Float:x = 0.5, Float:y = 0.5, r = 255, g = 255, b = 255, iMode = 0, Float:flDisplayTime = 1.0, iChanne = 0, iLength)
native MH_DrawHolesImage(iIndex, iCheck = 1, iCenter = 1, const szSprite[], Float:x = 0.5, Float:y = 0.5, r = 255, g = 255, b = 255, iMode = 0, Float:flDisplayTime = 1.0, iChanne = 0, iLength)
native MH_DrawText(iIndex, iCenter = 1, const szText[], Float:x = 0.5, Float:y = 0.5, r = 255, g = 255, b = 255, Float:flDisplayTime = 1.0, iChanne = 0)
native MH_SetViewEntityBody(iIndex, iBody = -1)
native MH_SetViewEntityRender(iIndex, iMode = -1, iEffect, iColorR, iColorG, iColorB, iAmout)
native MH_DrawScoreBoard(iIndex,iTopLeftNum, iTopCenterNum, iTopRightNum, iDownLeftNum, iDownRightNum ,iMode)
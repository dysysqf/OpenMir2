﻿using GameSvr.CommandSystem;
using SystemModule;

namespace GameSvr
{
    [GameCommand("TakeOnHorse", "", 10)]
    public class TakeOnHorseCommand : BaseCommond
    {
        [DefaultCommand]
        public void TakeOnHorse(TPlayObject PlayObject)
        {
            if (PlayObject.m_boOnHorse)
            {
                return;
            }
            if (PlayObject.m_btHorseType == 0)
            {
                PlayObject.SysMsg("骑马必须先戴上马牌!!!", MsgColor.Red, MsgType.Hint);
                return;
            }
            PlayObject.m_boOnHorse = true;
            PlayObject.FeatureChanged();
            if (PlayObject.m_boOnHorse)
            {
                M2Share.g_FunctionNPC.GotoLable(PlayObject, "@OnHorse", false);
            }
        }
    }
}
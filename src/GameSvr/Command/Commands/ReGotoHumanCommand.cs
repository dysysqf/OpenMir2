﻿using GameSvr.CommandSystem;
using SystemModule;

namespace GameSvr
{
    /// <summary>
    /// 飞到指定玩家身边
    /// </summary>
    [GameCommand("ReGotoHuman", "飞到指定玩家身边", M2Share.g_sGameCommandReGotoHelpMsg, 10)]
    public class ReGotoHumanCommand : BaseCommond
    {
        [DefaultCommand]
        public void ReGotoHuman(string[] @Params, TPlayObject PlayObject)
        {
            if (@Params == null)
            {
                return;
            }
            var sHumanName = @Params.Length > 0 ? @Params[0] : "";
            if (string.IsNullOrEmpty(sHumanName) || !string.IsNullOrEmpty(sHumanName) && sHumanName[1] == '?')
            {
                PlayObject.SysMsg(GameCommand.ShowHelp, MsgColor.Red, MsgType.Hint);
                return;
            }
            var m_PlayObject = M2Share.UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(string.Format(M2Share.g_sNowNotOnLineOrOnOtherServer, sHumanName), MsgColor.Red, MsgType.Hint);
                return;
            }
            PlayObject.SpaceMove(m_PlayObject.m_PEnvir.sMapName, m_PlayObject.m_nCurrX, m_PlayObject.m_nCurrY, 0);
        }
    }
}
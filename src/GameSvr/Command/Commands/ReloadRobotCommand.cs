﻿using GameSvr.CommandSystem;
using SystemModule;

namespace GameSvr
{
    /// <summary>
    /// 重新加载机器人脚本
    /// </summary>
    [GameCommand("ReloadRobot", "重新加载机器人脚本", 10)]
    public class ReloadRobotCommand : BaseCommond
    {
        public void ReloadRobot(TPlayObject PlayObject)
        {
            M2Share.RobotManage.ReLoadRobot();
            PlayObject.SysMsg("重新加载机器人配置完成...", MsgColor.Green, MsgType.Hint);
        }
    }
}
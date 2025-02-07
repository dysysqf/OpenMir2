﻿using SystemModule;
using SystemModule.Sockets;

namespace LoginSvr
{
    /// <summary>
    /// 远程监控服务(无用)
    /// </summary>
    public class MonSocService
    {
        private static readonly MonSocService instance = new MonSocService();

        public static MonSocService Instance
        {
            get { return instance; }
        }

        private readonly ISocketServer socketServer;
        private MasSocService _masSockService => MasSocService.Instance;
        private ConfigManager _configManager => ConfigManager.Instance;

        public MonSocService()
        {
            socketServer = new ISocketServer(ushort.MaxValue, 128);
            socketServer.Init();
        }

        public void Start()
        {
            socketServer.Start(_configManager.Config.sMonAddr, _configManager.Config.nMonPort);
        }

        public void ProcessCleanSession()
        {
            string sMsg = string.Empty;
            int nC = _masSockService.ServerList.Count;
            for (var i = 0; i < _masSockService.ServerList.Count; i++)
            {
                var msgServer = _masSockService.ServerList[i];
                var sServerName = msgServer.sServerName;
                if (!string.IsNullOrEmpty(sServerName))
                {
                    sMsg = sMsg + sServerName + "/" + msgServer.nServerIndex + "/" + msgServer.nOnlineCount + "/";
                    if ((HUtil32.GetTickCount() - msgServer.dwKeepAliveTick) < 30000)
                    {
                        sMsg = sMsg + "正常 ;";
                    }
                    else
                    {
                        sMsg = sMsg + "超时 ;";
                    }
                }
                else
                {
                    sMsg = "-/-/-/-;";
                }
            }
            var socketList = socketServer.GetSockets();
            for (var i = 0; i < socketList.Count; i++)
            {
                socketList[i].Socket.SendText(nC + ";" + sMsg);
            }
        }
    }
}
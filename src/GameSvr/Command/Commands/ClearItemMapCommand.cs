﻿using GameSvr.CommandSystem;

namespace GameSvr.Command
{
    [GameCommand("ClearItemMap", "清除指定地图范围物品", "地图编号", 10)]
    public class ClearItemMapCommand : BaseCommond
    {
        [DefaultCommand]
        public void ClearItemMap(string[] @Params, TPlayObject PlayObject)
        {
            if (@Params == null)
            {
                return;
            }
            var sMap = @Params.Length > 0 ? @Params[0] : "";
            var sItemName = @Params.Length > 1 ? @Params[1] : "";
            var nX = @Params.Length > 2 ? Convert.ToInt32(@Params[2]) : 0;
            var nY = @Params.Length > 3 ? Convert.ToInt32(@Params[3]) : 0;
            var nRange = @Params.Length > 4 ? Convert.ToInt32(@Params[4]) : 0;
            if (sMap == "" || string.IsNullOrEmpty(sItemName) || nX < 0 || nY < 0 || nRange < 0 || !string.IsNullOrEmpty(sItemName) && sItemName[0] == '?')
            {
                //PlayObject.SysMsg(string.Format(M2Share.g_sGameCommandParamUnKnow, this.Attributes.Name, M2Share.g_sGameCommandCLEARITEMMAPHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (sItemName == "ALL")
            {
            }
            // TMapItem MapItem = null;
            // var ItemList = new List<TMapItem>();
            // var Envir = M2Share.g_MapManager.FindMap(sMap);// 查找地图
            // if (Envir != null)
            // {
            //     ItemList = new List<TMapItem>();
            //     Envir.GetMapItem(nX, nY, nRange, ItemList);// 取地图上指定范围的物品
            //     if (!boClearAll)// /清除指定物品
            //     {
            //         if (ItemList.Count > 0)
            //         {
            //             for (int i = 0; i < ItemList.Count; i++)
            //             {
            //                 MapItem = ItemList[i];
            //                 if ((string.Compare(MapItem.Name, sItemName, StringComparison.OrdinalIgnoreCase) == 0))
            //                 {
            //                     for (int nXX = nX - nRange; nXX <= nX + nRange; nXX++)
            //                     {
            //                         for (int nYY = nY - nRange; nYY <= nY + nRange; nYY++)
            //                         {
            //                             Envir.DeleteFromMap(nXX, nYY, CellType.OS_ITEMOBJECT, MapItem);
            //                             if (MapItem == null)
            //                             {
            //                                 break;
            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         }
            //     }
            //     else
            //     {
            //         //清除全部物品
            //         if (ItemList.Count > 0)
            //         {
            //             for (int i = 0; i < ItemList.Count; i++)
            //             {
            //                 MapItem = ItemList[i];
            //                 for (int nXX = nX - nRange; nXX <= nX + nRange; nXX++)
            //                 {
            //                     for (int nYY = nY - nRange; nYY <= nY + nRange; nYY++)
            //                     {
            //                         Envir.DeleteFromMap(nXX, nYY, CellType.OS_ITEMOBJECT, MapItem);
            //                         if (MapItem == null)
            //                         {
            //                             break;
            //                         }
            //                     }
            //                 }
            //             }
            //         }
            //     }
            //     ItemList = null;
            // }
        }
    }
}
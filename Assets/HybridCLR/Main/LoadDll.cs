using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HybridCLR;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class LoadDll : MonoBehaviour
{


    public static List<string> AOTMetaAssemblyNames { get; } = new List<string>()
    {
        "mscorlib.dll",
        "System.dll",
        "System.Core.dll",
        "Nino.Serialization.dll",
        "Nino.Shared.dll",
    };

    async void Start()
    {
        await DownLoadAssets();
    }

    private static Dictionary<string, byte[]> s_assetDatas = new Dictionary<string, byte[]>();

    public static byte[] GetAssetData(string dllName)
    {
        return s_assetDatas[dllName];
    }

    private string GetWebRequestPath(string asset)
    {
        var path = $"{Application.streamingAssetsPath}/{asset}";
        if (!path.Contains("://"))
        {
            path = "file://" + path;
        }
        if (path.EndsWith(".dll"))
        {
            path += ".bytes";
        }
        return path;
    }

    async UniTask<bool> DownLoadAssets()
    {
        var assets = new List<string>
        {
            "Assembly-CSharp.dll",
        }.Concat(AOTMetaAssemblyNames);

        async UniTask<bool> GetBytesAsync(string asset)
        {
            string dllPath = GetWebRequestPath(asset);
            var request = await UnityWebRequest.Get(dllPath).SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
                return false;
            }
            else
            {
                byte[] assetData = request.downloadHandler.data;
                Debug.Log($"dll:{asset}  size:{assetData.Length}");
                s_assetDatas[asset] = assetData;
                return true;
            }
        }
        
        foreach (var asset in assets)
        {
            bool result = await GetBytesAsync(asset);
            if (!result)
            {
                return false;
            }
        }

        StartGame();
        return true;
    }


    void StartGame()
    {
        LoadMetadataForAOTAssemblies();

#if !UNITY_EDITOR
        var gameAss = System.Reflection.Assembly.Load(GetAssetData("Assembly-CSharp.dll"));
#else
        var gameAss = AppDomain.CurrentDomain.GetAssemblies().First(assembly => assembly.GetName().Name == "Assembly-CSharp");
#endif
         var methodInfo = gameAss.GetType("Nono.Game").GetMethod("Main");
         methodInfo?.Invoke(null, null);
    }
    
    private static void LoadMetadataForAOTAssemblies()
    {
        HomologousImageMode mode = HomologousImageMode.SuperSet;
        foreach (var aotDllName in AOTMetaAssemblyNames)
        {
            byte[] dllBytes = GetAssetData(aotDllName);
            LoadImageErrorCode err = RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);
            Debug.Log($"LoadMetadataForAOTAssembly:{aotDllName}. mode:{mode} ret:{err}");
        }
    }
}

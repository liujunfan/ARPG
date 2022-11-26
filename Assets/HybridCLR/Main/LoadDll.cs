using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HybridCLR;
using UnityEngine;
using UnityEngine.Networking;

public class LoadDll : MonoBehaviour
{


    public static List<string> AOTMetaAssemblyNames { get; } = new List<string>()
    {
        "mscorlib.dll",
        "System.dll",
        "System.Core.dll",
    };

    void Start()
    {
        StartCoroutine(DownLoadAssets(this.StartGame));
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

    IEnumerator DownLoadAssets(Action onDownloadComplete)
    {
        var assets = new List<string>
        {
            "prefabs",
            "Assembly-CSharp.dll",
        }.Concat(AOTMetaAssemblyNames);

        foreach (var asset in assets)
        {
            string dllPath = GetWebRequestPath(asset);
            Debug.Log($"start download asset:{dllPath}");
            UnityWebRequest www = UnityWebRequest.Get(dllPath);
            yield return www.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
#else
            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log(www.error);
            }
#endif
            else
            {
                // Or retrieve results as binary data
                byte[] assetData = www.downloadHandler.data;
                Debug.Log($"dll:{asset}  size:{assetData.Length}");
                s_assetDatas[asset] = assetData;
            }
        }

        onDownloadComplete();
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

﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace ET
{
    public partial class StartSceneConfigCategory
    {
        public MultiMap<int, StartSceneConfig> Gates = new();
        public MultiMap<int, StartSceneConfig> ProcessScenes = new();
        public Dictionary<long, Dictionary<string, StartSceneConfig>> ClientScenesByName = new();
        public StartSceneConfig LocationConfig;
        public List<StartSceneConfig> Realms = new();
        public List<StartSceneConfig> Routers = new();
        public MultiMap<int, StartSceneConfig> Logics = new();
        public List<StartSceneConfig> Maps = new();
        public List<StartSceneConfig> DataCaches = new();
        public StartSceneConfig Match;
        public StartSceneConfig Benchmark;

        public List<StartSceneConfig> GetByProcess(int process)
        {
            return this.ProcessScenes[process];
        }

        public StartSceneConfig GetBySceneName(int zone, string name)
        {
            return this.ClientScenesByName[zone][name];
        }

        partial void PostInit()
        {
            foreach (StartSceneConfig startSceneConfig in this.DataMap.Values)
            {
                this.ProcessScenes.Add(startSceneConfig.Process, startSceneConfig);

                if (!this.ClientScenesByName.ContainsKey(startSceneConfig.Zone))
                {
                    this.ClientScenesByName.Add(startSceneConfig.Zone, new Dictionary<string, StartSceneConfig>());
                }

                this.ClientScenesByName[startSceneConfig.Zone].Add(startSceneConfig.Name, startSceneConfig);

                switch (startSceneConfig.Type)
                {
                    case SceneType.Realm:
                        this.Realms.Add(startSceneConfig);
                        break;
                    case SceneType.Gate:
                        this.Gates.Add(startSceneConfig.Zone, startSceneConfig);
                        break;
                    case SceneType.Logic:
                        this.Logics.Add(startSceneConfig.Zone, startSceneConfig);
                        break;
                    case SceneType.Location:
                        this.LocationConfig = startSceneConfig;
                        break;
                    case SceneType.Router:
                        this.Routers.Add(startSceneConfig);
                        break;
                    case SceneType.Map:
                        this.Maps.Add(startSceneConfig);
                        break;
                    case SceneType.DataCache:
                        this.DataCaches.Add(startSceneConfig);
                        break;
                    case SceneType.Match:
                        this.Match = startSceneConfig;
                        break;
                    case SceneType.BenchmarkServer:
                        this.Benchmark = startSceneConfig;
                        break;
                }
            }
        }
    }

    [EnableClass]
    public partial class StartSceneConfig : ISupportInitialize
    {
        public ActorId ActorId;

        public SceneType Type;

        public StartProcessConfig StartProcessConfig
        {
            get
            {
                return StartProcessConfigCategory.Instance.Get(this.Process);
            }
        }

        public StartZoneConfig StartZoneConfig
        {
            get
            {
                return StartZoneConfigCategory.Instance.Get(this.Zone);
            }
        }

        // 内网地址外网端口，通过防火墙映射端口过来
        private IPEndPoint innerIPPort;

        public IPEndPoint InnerIPPort
        {
            get
            {
                if (this.innerIPPort == null)
                {
                    this.innerIPPort = NetworkHelper.ToIPEndPoint($"{this.StartProcessConfig.InnerIP}:{this.Port}");
                }

                return this.innerIPPort;
            }
        }

        private IPEndPoint outerIPPort;

        // 外网地址外网端口
        public IPEndPoint OuterIPPort
        {
            get
            {
                if (this.outerIPPort == null)
                {
                    this.outerIPPort = NetworkHelper.ToIPEndPoint($"{this.StartProcessConfig.OuterIP}:{this.Port}");
                }

                return this.outerIPPort;
            }
        }

        public void BeginInit()
        {
        }

        public void EndInit()
        {
        }

        partial void PostInit()
        {
            this.ActorId = new ActorId(this.Process, this.Id, 1);
            this.Type = EnumHelper.FromString<SceneType>(this.SceneType);
        }
    }
}
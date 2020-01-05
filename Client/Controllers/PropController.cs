using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models.Mapping;
using Client.Enums;

namespace Client.Controllers
{
    public class PropController : BaseController
    {
        private static List<int> trafficSignalHashes = new List<int> { 1043035044 }; // eeeee worried. should not need this?!?!?!
        // private static List<Prop> m_spawnedStaticProps = new List<Prop>();
        // private static List<Prop> m_spawnedDynamicProps = new List<Prop>();

        private static List<int> m_spawnedProps = new List<int>();

        private Dhprop m_toDeleteTempProps = null;

        private bool m_spawnProps = false;
        private bool m_deleteTempPropsEnabled = false;

        public bool DoneSpawningProps { get; private set; } = false;

        internal PropController() : base(nameof(PropController)) { }

        [EventHandler("onClientMapStop")]
        public void OnClientMapStop()
        {
            DeleteSpawnedProps();

            m_deleteTempPropsEnabled = false;
            m_spawnProps = false;
            DoneSpawningProps = false;
        }

        [Tick]
        public async Task OnTick()
        {
            try
            {
                if(!m_spawnProps || GameController.GameState != GameState.VEHICLE_SELECT) // only load props in vehicle select
                {
                    return;
                }

                m_spawnProps = false; // only spawn once

                DoneSpawningProps = false;
                Logger.Info($"We got {Client.Instance.Game.CurrentMap.mission.PropData.ModelName.Length} props to spawn");

                await SpawnStaticProps(Client.Instance.Game.CurrentMap.mission.PropData);
                Logger.Info("Done spawning static");
                await SpawnDynamicProps(Client.Instance.Game.CurrentMap.mission.DynamicProps);
                DoneSpawningProps = true;
            }
            catch (Exception e)
            {
                Logger.Exception(e, "PropController:OnTick");
                await Delay(5000);
            }
        }

        [Tick]
        public async Task DeleteTempPropsTick()
        {
            try
            {
                await Delay(1000);

                if(!m_deleteTempPropsEnabled || m_toDeleteTempProps == null)
                {
                    return;
                }

                var nearbyProps = World.GetAllProps().ToList();

                var toKeep = new List<Prop>();

                foreach (var prop in nearbyProps)
                {
                    // we don't want this but somehow some traffic lights are not in Dhprop in some maps that have them literally on the track.
                    if(trafficSignalHashes.Exists(t => t == prop.Model.Hash)) // && m_toDeleteTempProps.pos.Any(p => pos.DistanceToSquared2D(new Vector3(p.x, p.y, p.z)) < 12f)
                    {
                        SafeDelete(prop.Handle);
                        continue;
                    }

                    toKeep.Add(prop);
                }

                for (int i = 0; i < m_toDeleteTempProps.no; i++)
                {
                    var coords = new Vector3(m_toDeleteTempProps.pos[i].x, m_toDeleteTempProps.pos[i].y, m_toDeleteTempProps.pos[i].z);

                    var prop = toKeep.FirstOrDefault(p => p.Position.DistanceToSquared2D(coords) < 25f);
                    if (prop != null)
                    {
                        SafeDelete(prop.Handle);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Exception(e, "PropController:DeleteTempPropsTick");
                await Delay(5000);
            }

            await Task.FromResult(0);
        }

        public async Task<bool> SpawnStaticProps(PropData propData)
        {
            try
            {
                if (propData.Total < 1) return true;

                int count = 0;
                List<uint> hashesToUnload = new List<uint>();

                for (int i = 0; i < propData.Total; i++)
                {
                    var hash = (uint)propData.ModelName[i];

                    // probably never 0, but you never know. it's R*
                    // also if any maps contains v1604+ hashes
                    if (hash == 0 || !IsModelValid(hash) || !IsModelInCdimage(hash)) 
                    {
                        continue;
                    }

                    RequestModel(hash);
                    while (!HasModelLoaded(hash))
                    {
                        await Delay(0);
                    }

                    var prop = CreateObjectNoOffset(hash, propData.Location[i].x, propData.Location[i].y, propData.Location[i].z, false, true, false);

                    if (prop == 0)
                    {
                        continue;
                    }

                    SetEntityRotation(prop, propData.Rotation[i].x, propData.Rotation[i].y, propData.Rotation[i].z, 2, true);
                    FreezeEntityPosition(prop, true);
                    SetObjectTextureVariant(prop, propData.PropVariation[i]);

                    m_spawnedProps.Add(prop);
                    hashesToUnload.Add(hash);

                    count++;
                }

                // unload later to avoid waiting for model loading when used multiple times
                foreach (var hash in hashesToUnload)
                {
                    SetModelAsNoLongerNeeded(hash);
                }

                Logger.Info($"Spawned {count}/{propData.Total} props");
            }
            catch (Exception e)
            {
                Logger.Exception(e, "SpawnStaticProps");
                return false;
            }

            return true;
        }

        public async Task<bool> SpawnDynamicProps(Dprop dynamicProps)
        {
            try
            {
                if (dynamicProps.Total < 1) return true;

                var count = 0;

                List<uint> m_hashesToUnload = new List<uint>();
                for (int i = 0; i < dynamicProps.Total; i++)
                {
                    var pos = new Vector3(dynamicProps.Locations[i].x, dynamicProps.Locations[i].y, dynamicProps.Locations[i].z);
                    var rot = new Vector3(dynamicProps.Rotations[i].x, dynamicProps.Rotations[i].y, dynamicProps.Rotations[i].z);
                    var model = new Model(dynamicProps.ModelName[i]);

                    var hash = (uint)dynamicProps.ModelName[i];

                    if (hash == 0 || !IsModelValid(hash) || !IsModelInCdimage(hash))
                    {
                        continue;
                    }

                    RequestModel(hash);
                    while (!HasModelLoaded(hash))
                    {
                        await Delay(0);
                    }

                    var prop = new Prop(CreateObjectNoOffset((uint)model.Hash, pos.X, pos.Y, pos.Z, false, true, true));

                    if (prop == null)
                    {
                        continue;
                    }

                    prop.Rotation = rot;

                    SetObjectTextureVariant(prop.Handle, dynamicProps.PropVariation[i]);

                    m_spawnedProps.Add(prop.Handle);
                    m_hashesToUnload.Add(hash);
                    count++;
                }

                foreach (var hash in m_hashesToUnload)
                {
                    SetModelAsNoLongerNeeded(hash);
                }

                Logger.Info($"Spawned {count}/{dynamicProps.Total} props");
            }
            catch (Exception e)
            {
                Logger.Exception(e, "SpawnDynamicProps");
                return false;
            }

            return true;
        }

        public void LoadMapProps(Dhprop deleteProps)
        {
            try
            {
                if (deleteProps.no > 0)
                {
                    m_toDeleteTempProps = deleteProps;
                    m_deleteTempPropsEnabled = true;
                }

                m_spawnProps = true;
                Logger.Info("Ok lets load");
            }
            catch (Exception e)
            {
                Logger.Exception(e, "SpawnDynamicProps");
            }
        }

        private void DeleteSpawnedProps()
        {
            if (m_spawnedProps.Count != 0)
            {
                foreach (var prop in m_spawnedProps)
                {
                    SafeDelete(prop);
                }
                m_spawnedProps.Clear();
            }
        }

        private void SafeDelete(int p)
        {
            SetEntityAsMissionEntity(p, false, false);
            SetEntityAsNoLongerNeeded(ref p);
            DeleteEntity(ref p);
        }
    }
}

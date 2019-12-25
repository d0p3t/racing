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
        // private static List<Prop> m_spawnedStaticProps = new List<Prop>();
        // private static List<Prop> m_spawnedDynamicProps = new List<Prop>();

        private Dhprop m_toDeleteTempProps;
        private int m_deletedTempPropsCount = 0;

        private static List<int> trafficSignalHashes = new List<int> { -655644382, 862871082, 1043035044 };

        private bool m_spawnProps = false;

        internal PropController() : base(nameof(PropController)) { }

        [EventHandler("onClientMapStart")]
        public async void OnClientMapStart()
        {
            try
            {
                while (Client.Instance.Game.CurrentMap == null)
                    await Delay(0);

                DeleteMapProps(Client.Instance.Game.CurrentMap.mission.DeleteProps);

                m_spawnProps = true;
            }
            catch (Exception e)
            {
                Logger.Exception(e, "PropController:onClientMapStart");
            }
            await Task.FromResult(0);
        }

        [Tick]
        public async Task OnTick()
        {
            try
            {
                if(!m_spawnProps || GameController.GameState != GameState.LOADING)
                {
                    return;
                }

                Debug.WriteLine("ok loading!");
                await SpawnStaticProps(Client.Instance.Game.CurrentMap.mission.PropData);
                await SpawnDynamicProps(Client.Instance.Game.CurrentMap.mission.DynamicProps);

                GameController.GameState = GameState.VEHICLE_SELECT;

                m_spawnProps = false;
            }
            catch (Exception e)
            {
                Logger.Exception(e, "PropController:OnTick");
                await Delay(5000);
            }
        }

        public async Task<bool> SpawnStaticProps(PropData propData)
        {
            try
            {
                if (propData.Total < 1) return true;

                int count = 0;

                List<uint> m_hashesToUnload = new List<uint>();
                for (int i = 0; i < propData.Total; i++)
                {
                    var pos = new Vector3(propData.Location[i].x, propData.Location[i].y, propData.Location[i].z);
                    var rot = new Vector3(propData.Rotation[i].x, propData.Rotation[i].y, propData.Rotation[i].z);
                    var model = new Model(propData.ModelName[i]);

                    var hash = (uint)propData.ModelName[i];
                    RequestModel(hash);

                    var start = GetGameTimer();

                    while (!HasModelLoaded(hash))
                    {
                        if (GetGameTimer() - start > 1000)
                        {
                            break;
                        }
                        await Delay(0);
                    }

                    var prop = new Prop(CreateObjectNoOffset((uint)model.Hash, pos.X, pos.Y, pos.Z, false, true, false));

                    if(prop == null)
                    {
                        continue;
                    }

                    prop.Rotation = rot;

                    prop.IsPositionFrozen = true;
                    SetObjectTextureVariant(prop.Handle, propData.PropVariation[i]);
                    //prop.LodDistance = propData.LODDistance[i];

                    m_hashesToUnload.Add(hash);

                    count++;
                }

                foreach (var hash in m_hashesToUnload)
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
                // DeleteSpawnedProps(m_spawnedDynamicProps);

                if (dynamicProps.Total < 1) return true;

                var count = 0;

                List<uint> m_hashesToUnload = new List<uint>();
                for (int i = 0; i < dynamicProps.Total; i++)
                {
                    var pos = new Vector3(dynamicProps.Locations[i].x, dynamicProps.Locations[i].y, dynamicProps.Locations[i].z);
                    var rot = new Vector3(dynamicProps.Rotations[i].x, dynamicProps.Rotations[i].y, dynamicProps.Rotations[i].z);
                    var model = new Model(dynamicProps.ModelName[i]);

                    var hash = (uint)dynamicProps.ModelName[i];
                    RequestModel(hash);

                    var start = GetGameTimer();

                    while (!HasModelLoaded(hash))
                    {
                        if(GetGameTimer() - start > 1000)
                        {
                            break;
                        }
                        await Delay(0);
                    }

                    var prop = new Prop(CreateObjectNoOffset((uint)model.Hash, pos.X, pos.Y, pos.Z, false, true, true));

                    if (prop == null)
                    {
                        continue;
                    }

                    prop.Rotation = rot;
                    // prop.Heading = dynamicProps.Heading[i]; // yea its not heading
                    SetObjectTextureVariant(prop.Handle, dynamicProps.PropVariation[i]);

                    // m_spawnedDynamicProps.Add(prop);
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

        public void DeleteMapProps(Dhprop deleteProps)
        {
            try
            {
                if(deleteProps.no < 1)
                {
                    return;
                }

                m_toDeleteTempProps = deleteProps;
                m_deletedTempPropsCount = 0;

                Tick += DeleteTempPropsTick;
            }
            catch (Exception e)
            {
                Logger.Exception(e, "SpawnDynamicProps");
            }
        }

        public async Task DeleteTempPropsTick()
        {
            try
            {
                if(m_toDeleteTempProps == null)
                {
                    return;
                }

                if(!m_toDeleteTempProps.mn.Any(p => p != -1))
                {
                    Logger.Info("Done deleting all temp props");
                    Tick -= DeleteTempPropsTick;
                    return;
                }

                var nearbyProps = World.GetAllProps().ToList();

                List<Prop> toKeep = new List<Prop>();

                foreach (var prop in nearbyProps)
                {
                    if(trafficSignalHashes.Exists(t => t == prop.Model.Hash))
                    {
                        
                        prop.Delete();
                        continue;
                    }

                    toKeep.Add(prop);
                }

                nearbyProps = toKeep;

                for (int i = 0; i < m_toDeleteTempProps.no; i++)
                {
                    if(trafficSignalHashes.Exists(t => t == m_toDeleteTempProps.mn[i]))
                    {
                        m_toDeleteTempProps.mn[i] = -1;
                        continue;
                    }

                    if (m_toDeleteTempProps.mn[i] == -1)
                        continue;

                    var coords = new Vector3(m_toDeleteTempProps.pos[i].x, m_toDeleteTempProps.pos[i].y, m_toDeleteTempProps.pos[i].z);

                    var prop = nearbyProps.FirstOrDefault(p => p.Position.DistanceToSquared2D(coords) < 12f);
                    if (prop != null)
                    {
                        Logger.Info("We found an object! Deleting it now...");
                        m_toDeleteTempProps.mn[i] = -1;
                        prop.Delete();
                    }
                }

                await Delay(1000);
            }
            catch (Exception e)
            {
                Logger.Exception(e, "DeleteTempPropsTick");
                await Delay(2500);
            }

            await Task.FromResult(0);
        }

        private void DeleteSpawnedProps(List<Prop> props)
        {
            if (props.Count != 0)
            {
                foreach (var prop in props)
                {
                    prop.MarkAsNoLongerNeeded();
                    prop.Delete();
                }
                props.Clear();
            }
        }
    }
}

using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Enums;

namespace Client.Controllers
{
    public class VehicleController : BaseController
    {
        private bool m_setupLobby = false;
        private Vector3 m_vehiclePosition { get
            {
                var lobby = Client.Instance.Game.CurrentMap.mission.Generated.LobbyStartLocation;

                return new Vector3(lobby.x, lobby.y, lobby.z);
            } 
        }

        private Vehicle m_selectVehicle = null;
        private Camera m_selectVehicleCam = null;

        internal VehicleController(): base(nameof(VehicleController))
        {

        }

        public void MapStart()
        {
            m_setupLobby = true;
        }

        [Tick]
        public async Task OnVehicleSelectTick()
        {
            try
            {
                if (GameController.GameState != GameState.VEHICLE_SELECT)
                    return;

                if(m_setupLobby)
                {
                    if (Game.PlayerPed.LastVehicle != null)
                        Game.PlayerPed.LastVehicle.Delete();

                    if (Game.PlayerPed.CurrentVehicle != null)
                        Game.PlayerPed.CurrentVehicle.Delete();

                    if (m_selectVehicle != null)
                    {
                        m_selectVehicle.Delete();
                        m_selectVehicle = null;
                    }

                    m_setupLobby = false;

                    var camPos = Client.Instance.Game.CurrentMap.mission.Generated.LobbyCam;

                    m_selectVehicleCam = World.CreateCamera(new Vector3(camPos.x, camPos.y, camPos.z), Vector3.Zero, 180f);

                    World.RenderingCamera = m_selectVehicleCam;

                    m_selectVehicle = await World.CreateVehicle(new Model(VehicleHash.Adder), m_vehiclePosition);

                    if (m_selectVehicle != null)
                    {
                        m_selectVehicle.PlaceOnGround();
                        m_selectVehicle.IsPositionFrozen = true;
                        m_selectVehicle.Mods.PrimaryColor = VehicleColor.HotPink;
                    }
                }

                if(Game.IsControlJustPressed(0, Control.FrontendSocialClub))
                {
                    World.RenderingCamera = null;
                    m_selectVehicleCam.Delete();
                    m_selectVehicleCam = null;

                    Client.Instance.Game.GameStateListener.Invoke(GameState.PRE_COUNTDOWN);

                    TriggerEvent("racing:spawn");
                }
            }
            catch (Exception e)
            {
                Logger.Exception(e, "VehicleController");
                await Delay(5000);
            }
        }
    }
}

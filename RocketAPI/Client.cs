using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Protobuf;
using PokemonGo.RocketAPI.Enums;
using PokemonGo.RocketAPI.Exceptions;
using PokemonGo.RocketAPI.Extensions;
using PokemonGo.RocketAPI.Helpers;
using PokemonGo.RocketAPI.HttpClient;
using PokemonGo.RocketAPI.Login;
using POGOProtos.Inventory;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Envelopes;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using POGOProtos.Networking.Responses;

namespace PokemonGo.RocketAPI
{
    public interface IClient
    {
        Rpc.Login Login { get; }
        Rpc.Player Player { get; }
        Rpc.Download Download { get; }
        Rpc.Inventory Inventory { get; }
        Rpc.Map Map { get; }
        Rpc.Fort Fort { get; }
        Rpc.Encounter Encounter { get; }
        Rpc.Misc Misc { get; }
    }

    public class Client : IClient
    {
        public Rpc.Login Login { get; set; }
        public Rpc.Player Player { get; set; }
        public Rpc.Download Download { get; set; }
        public Rpc.Inventory Inventory { get; set; }
        public Rpc.Map Map { get; set; }
        public Rpc.Fort Fort { get; set; }
        public Rpc.Encounter Encounter { get; set; }
        public Rpc.Misc Misc { get; set; }

        public IApiFailureStrategy ApiFailure { get; set; }
        public ISettings Settings { get; }
        public string AuthToken { get; set; }

        public double CurrentLatitude { get; internal set; }
        public double CurrentLongitude { get; internal set; }
        public double CurrentAltitude { get; internal set; }

        public AuthType AuthType => Settings.AuthType;

        internal readonly PokemonHttpClient PokemonHttpClient = new PokemonHttpClient();
        internal string ApiUrl { get; set; }
        internal AuthTicket AuthTicket { get; set; }

        public Client(ISettings settings, IApiFailureStrategy apiFailureStrategy)
        {
            Settings = settings;
            ApiFailure = apiFailureStrategy;

            Login = new Rpc.Login(this);
            Player = new Rpc.Player(this);
            Download = new Rpc.Download(this);
            Inventory = new Rpc.Inventory(this);
            Map = new Rpc.Map(this);
            Fort = new Rpc.Fort(this);
            Encounter = new Rpc.Encounter(this);
            Misc = new Rpc.Misc(this);

            Player.SetCoordinates(Settings.DefaultLatitude, Settings.DefaultLongitude, Settings.DefaultAltitude);
        }
    }
}
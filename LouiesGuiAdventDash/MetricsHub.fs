module MetricsHub

open System
open Microsoft.AspNet.SignalR
open Microsoft.AspNet.SignalR.Hubs
open Microsoft.Owin.Hosting
open Microsoft.AspNet.SignalR.Owin
open PerfModel

    type IMetricsHub = 
        abstract member AddMessage: string -> unit
        abstract member BroadcastPerformance: PerfModel seq -> unit

    [<HubName("metricsHub")>]
    type metricsHub() = 
        inherit Hub<IMetricsHub>()

        //if we were intrested in seeing who is connecting
        //or doing something on a new connection this would be the place
        override x.OnConnected() =
            base.OnConnected()

        // A function that can be invoked by any client since signalr uses web sockets for two way communication.
        member public x.SendMessage(message : string) : unit =
            base.Clients.All.AddMessage message


                // A function that can be invoked by any client since signalr uses web sockets for two way communication.
        member public x.BroadcastPerformance(perfromance : PerfModel seq) : unit =
            base.Clients.All.BroadcastPerformance perfromance

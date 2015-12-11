﻿// C#

// var manager = new Runtime.RuntimeManager();
//            var server = manager.GetProtServer();
//
//            server.OnClientConnected += 
//            (o, a) =>
//            {
//                Console.WriteLine("inc con: " + a.Client.Client.RemoteEndPoint.ToString());
//
//                var reader = new System.IO.StreamReader(a.Client.GetStream());
//
//                while (true)
//                {
//                    var msg = reader.ReadLine();
//                    Console.WriteLine(msg);
//                }
//
//            };
//
//            server.ListenForClientsAsync(8080);

open EasyProt.Runtime

[<EntryPoint>]
let main argv = 
    let manager = new RuntimeManager()
    let server = manager.GetProtServer()

    server.OnClientConnected.AddHandler(fun _ a ->
    
                 System.Console.WriteLine("inc con: " + a.Client.Client.RemoteEndPoint.ToString());

                 let reader = new System.IO.StreamReader(a.Client.GetStream());
 
                 while true do
                    let msg = reader.ReadLine();
                    System.Console.WriteLine(msg);
               )

    server.ListenForClientsAsync(8080)

    System.Console.ReadLine() |> ignore
    0 

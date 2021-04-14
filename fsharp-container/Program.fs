open System
open System.Threading
open Suave

let webserver () =
    let cts = new CancellationTokenSource()

    let conf =
        { defaultConfig with
              bindings = [ HttpBinding.createSimple HTTP "0.0.0.0" 8080 ]
              cancellationToken = cts.Token }

    let listening, server =
        startWebServerAsync conf (Successful.OK "Hello World")

    Async.Start(server, cts.Token)
    printfn "Make requests now on 8080"
    Console.ReadKey true |> ignore

    cts.Cancel()

[<EntryPoint>]
let main argv =
    webserver ()
    0 // always good!
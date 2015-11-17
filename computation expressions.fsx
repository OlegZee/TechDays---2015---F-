module Techtalks.ComputationExpressions


type TestBuilder() =
    member this.Bind(v,f) =
        printfn "bind!"
        f v
    member this.Return(v) =
        printfn "return"
        v

let test = TestBuilder()

let xx = test {
    let! a = "abc"
    return a
}

xx |> printfn "%A"












let numbers =
    query {
        for n in [4;12;32;48;72;16;23] do
        where (n % 2 = 0)
        sortBy (n % 10)
        select n
    } |> Seq.toList












type 't AsyncPlus =
    (('t -> unit) * (string -> unit)) -> unit

let ret (v:'t) : 't AsyncPlus =
    fun (succ,_) -> succ v
let fail ex : 't AsyncPlus =
    fun (_,failed) -> failed ex
let bind (v:'t AsyncPlus, f:'t -> 'u) : 'u AsyncPlus =
    fun (succ,fail) -> v(f >> succ,fail)

type AsyncPlusBuilder() =
    member this.Bind = bind
    member this.Return = ret



open System
open System.Net
open Microsoft.FSharp.Control.CommonExtensions

// Fetch the contents of a web page asynchronously
let fetchUrlAsync url =
    async {
        let req = WebRequest.Create(Uri(url))
        use! resp = req.AsyncGetResponse()  // new keyword "use!"
        use stream = resp.GetResponseStream()
        use reader = new IO.StreamReader(stream)
        let html = reader.ReadToEnd()
        printfn "finished downloading %s" url
        }

let dn = fetchUrlAsync "http://www.microsoft.com"

#time
Async.RunSynchronously dn
#time

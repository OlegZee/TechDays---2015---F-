module TechTalks.TypeProviders

#r "packages/FSharp.Data.dll"

open FSharp.Data




type Simple =
  JsonProvider<"""
    { "name":"John", "age":94 } """>
let simple =
  Simple.Parse("""
    { "name":"Tomas", "age":4 } """)
simple |> printf "%A"


















let data = WorldBankData.GetDataContext()

let population =
    data.Countries.``Russian Federation``.Indicators.``Urban population``
    |> Seq.maxBy fst

population |> printfn "%A"

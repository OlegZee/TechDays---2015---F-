module Techtalks

// примитивы
let a = 123
let b = 1234.0
let c = true
let str = "Hello, world"
let none = ()





[<Measure>] type kg
[<Measure>] type m

let d = 100.<m>
let m = 20.2<kg>

let mm = d / m * m
// let ``wat?`` = d + m
let sq = d * d

// преобразование типов
let c = float a + b

// кортежи
let tuple = a,b
let v1,v2 = 1,2







// Определение типов: алиасы, записи
type Pt = int * int
type Point = {X: int; Y: int}
type Point2 = {X: int; Y: int}
type Size = {Width: int; Height: int}
type Rectangle = {Location: Point; Size: Size}

// создание экземпляров
let p = 10,10
let pt:Pt = 10,10

let loc = {Point.X = 10; Y = 10}
let size = {Width = 50; Height = 20}

let bounds =
  {Location = loc; Size = {Width = 40; Height = 20}}

type ScoringStrategy = {
    name: string
    eval: string -> float
    whatIf: string * float -> float
}












// ADT
type Shape =
    | Point of Point
    | Rectangle of Point * Size
    | Circle of Point * int

let shapes =
    [
    Point ({X = 100; Y = 100})
    Rectangle ({X = 10; Y = 10},{Width = 40; Height = 15})
    Circle ({X = 100; Y = 100}, 60)
    ]

// Generic types

type Tree<'TNode> =
    | Nil
    | Node of 'TNode * Tree<'TNode> * Tree<'TNode>

type 'a Tree2 =
    | Nil
    | Node of 'a * 'a Tree2 * 'a Tree2














// встроенные типы
// list
type 'a LinkedList =
    | Nil
    | (::) of 'a * LinkedList<'a>

let numList = 1 :: 2 :: 3 :: Nil
printfn "%A" numList

(*
// А так нельзя:
let rec ll () = 1 :: ll ()
ll() |> Seq.take 100
*)

let l2 = [1; 2; 3] @@ l2
let filtered = l2 |> List.filter (fun n -> n > 1)
let lq = l2 |> List.map (fun n -> n * n)


// sequence, map
let s = seq {
    for i = 1 to 10 do yield i * 2
    yield 1; yield 2
}
printfn "%A" s

let doubles = s |> Seq.zip l2
doubles |> printfn "%A"

let map = Map.empty |> Map.add "key" 42
let mapsq = Map.ofSeq doubles

let i3 = mapsq.[3]













// OOP

type ShapeBase(location:Point) =
    let _location = ref location
    member this.getLocation() = !_location
    member this.setLocation(l) = _location := l

type Circle(location:Point, radius: int) =
    inherit ShapeBase(location)

    member this.Radius with get() = radius

let circle = Circle({X = 20; Y = 20}, 50)
let shape_loc = circle.getLocation()
let shape_radius = circle.Radius

let shape =  circle :>ShapeBase





// equality comparison

let shape1 = Shape.Circle ({X=10;Y=10}, 20)
let shape2 = Shape.Circle ({X=10;Y=10}, 20)
let shape3 = Shape.Point {X=10;Y=10}

shape1 = shape2 |> printfn "%A"
shape2 = shape3 |> printfn "%A"

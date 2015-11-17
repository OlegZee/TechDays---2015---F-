module Techtalks.``Pattern Matching``

type Point = Point of int * int

let a = 123

let div a b =
    match b with
    | 0 -> None
    | 1 -> Some a
    | n when n = 2 -> Some (a/2)
    | _ -> Some (a/b)

let rec filter p lst =
    match lst with
    | [] -> []
    | x::tail when p x -> x::(filter p tail)
    | _::tail -> (filter p tail)
    | _ -> []












// сложные паттерны
type color = R | B
type 'a tree =
    | E
    | T of color * 'a tree * 'a * 'a tree
let balance = function
    | B, T(R, T(R, a, x, b), y, c), z, d
    | B, T(R, a, x, T(R, b, y, c)), z, d
    | B, a, x, T(R, T(R, b, y, c), z, d)
    | B, a, x, T(R, b, y, T(R, c, z, d))
        -> T(R, T(B, a, x, b), y, T(B, c, z, d))
    | c, l, x, r -> T(c, l, x, r)













// active patterns

let (|Contains|) needle (haystack : string) =
    haystack.Contains(needle)
let (|StartsWith|_|) needle (haystack : string) =
    if haystack.StartsWith(needle) then Some()
    else None

let (|Q1|Q2|Q3|Q4|O|) (x,y) =
    match sign x, sign y with
    | 1,1 -> Q1
    | -1,1 -> Q2
    | -1,-1 -> Q3
    | 1,-1 -> Q4
    | _ -> O

let q =
  match (1,2) with
  | Q1 -> "1"
  | Q2 -> "2"
  

let testString = function
    | Contains "kitty" true -> printfn "Text contains 'kitty'"
    | Contains "doggy" true -> printfn "Text contains 'doggy'"
    | StartsWith "abc" -> printfn "Text begins with 'abc'"
    | _ -> printfn "Text neither contains 'kitty' nor 'doggy'";;


testString "abcdef"
testString "a kitty and a doggy"

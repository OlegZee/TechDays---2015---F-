


module Techtalks.Functions

let fsin = fun v -> sin(v)
let fmul = fun a -> fun b -> a * b

fsin 1.1 |> printfn "%f"
fmul 11 2 |> printfn "%A"

// то же, только короче
let fsin' v = sin v
let mul a b = a * b
let r2 = mul 23 11




// композиция
let applyTwice f a = f(f a)
let sq a = a * a

let pow4 = applyTwice sq

let result = pow4 5.0









// аннотирование типов
let filter (l:List<int>) (e: int->bool) :List<int> = l
let filter':
    List<int> -> (int -> bool) -> List<int>
    = fun l p -> l // TODO implement me

// currying
let inline fmul a b = a * b
let mul4' = fmul 4.0
let result3 = fmul 7

let g = mul4' <| float 7

let add6 = applyTwice ((+) 3)
let result4 = add6 2











// infix Operators
let (<+>) a b = a + " + " + b
let stmt = "abc" <+> "def"
let stmt1 = (<+>) "abc" "def"

let (|>) v f = f v
let (<|) f v = f v
let r4 = 5 |> mul 3

let (</) a b = a |> b
let (/>) a b = a <| b
let r5 = 5 </mul/> 3

// piping
let (>>) f g a = g (f a)
let mul6 = mul 2 >> mul 3
let r6 = mul6 7






// рекурсия
let rec fac n =
    if n <= 1 then 1 else n * fac(n-1)

let rec fx a = gx a*2
    and gx a = fx 2 + a

fac 10 |> printfn "%A"





// tail recursion
let facopt n =
    let rec fimp n a =
        if n = 1 then a
        else fimp (n-1) n * a
    fimp n 1

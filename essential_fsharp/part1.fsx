// Pascal case for type definitions, camel case for everything else



// defining a type as a tuple
type Customer1 = string * bool * bool

// assigning the identifier "fred" a given tuple 
let walter = ("Walter", true, true)


// this is better since it says what type Mary is
let alice : Customer1 = ("Alice", true, true)

// decomposition of alice
let (id, isEligible, isRegistered) = alice

// assigning a record type instead of a tuple - can be done on one line
type Customer2 = {Id:string; IsEligible:bool; IsRegistered:bool}

// but multiple lines is nicer to read and no more semicolon - tabs are not supported so IDE needs to convert them to spaces pre-compilation
type Customer = {
    Id : string
    IsEligible : bool
    IsRegistered : bool
}


// notice how I had to add ": Customer"; since Customer2 already exists with the same structure, the compiler can't tell the diff
//
let quincy : Customer = {
    Id = "Quincy"
    IsEligible = true
    IsRegistered = true
}


// creating my first function; the "M" indicates the number is a decimal; inputs are in tuple form - notice the difference in function signatures
// The curried form (above) is preferred
let calculateTotal1 (customer : Customer, spend : decimal) : decimal =
    let discount = 
        if customer.IsEligible && spend >= 100.0M
        then (spend * 0.1M) else 0.0M
    let total = spend - discount
    total


// creating my first function; the "M" indicates the number is a decimal; inputs are in curried form
let calculateTotal (customer : Customer) (spend : decimal) : decimal =
    let discount = 
        if customer.IsEligible && spend >= 100.0M
        then (spend * 0.1M) else 0.0M
    spend - discount
    

let john = {Id = "John"; IsEligible = true; IsRegistered = true}
let richard = {Id = "Richard"; IsEligible = false; IsRegistered = true}


let assertJohn = (calculateTotal john 100.0M = 90.0M)

// the parenthese shown in the above line are not strictly nessecary
let assertRichard = calculateTotal richard 100.0M = 90.0M


// could make a function which uses generic inputs for the test
let areEqual  expected actual = 
    expected = actual


let sean = {Id= "Sean"; IsEligible = true; IsRegistered = true}
let assertSean = areEqual 90.0M (calculateTotal sean 100.0M) 






// --- OTHER NOTES ---
// = sign is multi purpose; binds and checks for equality 
// the <- assigns but you need the mutable keyword in the binding
let mutable myInt = 0
myInt <- 1



// start on page 14
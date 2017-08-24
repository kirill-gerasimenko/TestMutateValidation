// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System.Windows
open System

open FsXaml 
open Gjallarhorn
open Gjallarhorn.Bindable
open Gjallarhorn.Validation
open Gjallarhorn.Wpf

type Window = XAML<"SampleView.xaml">

let createViewModel () =
    let bindingSource = Binding.createObservableSource ()

    let validator = Validation.Validators.hasLengthAtLeast 3

    let mutable1 = Mutable.create ""
    let mutable2 = Mutable.create ""

    mutable1 |> Binding.mutateToFromViewValidated bindingSource "Text1" validator
    mutable2 |> Binding.toFromViewValidated bindingSource "Text2" validator |> ignore

    bindingSource

[<STAThread>]
[<EntryPoint>]
let main _ = 
    Platform.install true |> ignore

    let app = Application ()
    let win = Window ()

    win.DataContext <- createViewModel ()

    app.Run win |> ignore

    0 

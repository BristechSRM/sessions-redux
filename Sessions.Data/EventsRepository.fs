﻿module EventsRepository

open Dapper
open Dapper.Contrib.Extensions
open Database
open Entities
open System

let getAll () =
  getConnection().GetAll<Event>()

let get (eventId : Guid) =
  getConnection().Get<Event>(eventId)

let add (event: Event) =
  let guid = Guid.NewGuid()
  insert { event with Id = guid } |> ignore
  guid
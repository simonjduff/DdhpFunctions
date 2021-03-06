﻿#r "Newtonsoft.Json"
#r "Microsoft.WindowsAzure.Storage"
#r "ClubReadUpdaterLib.dll"
using System;
using ClubReadUpdater.Lib;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

public async static

Task Run(string myQueueItem, 
    IQueryable<ClubReadUpdater.Lib.DdhpEvent> clubEvents, 
    IQueryable<ClubReadUpdater.Lib.Player> players,
    IQueryable<ClubReadUpdater.Lib.StorageStat> stats,
    CloudTable clubWriter, 
    TraceWriter log)
{
    var runner = new Runner((message) => log.Info(message));

    await runner.Run(myQueueItem,
        clubEvents,
        players,
        stats,
        clubWriter);
}
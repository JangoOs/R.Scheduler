SET OUTDIR=C:\Git\R.Scheduler\src\

@ECHO === === === === === === === ===

@ECHO ===NUGET Publishing ....

del *.nupkg

NuGet pack "%OUTDIR%R.Scheduler\R.Scheduler.nuspec"
::NuGet pack "%OUTDIR%R.Scheduler.Contracts\R.Scheduler.Contracts.nuspec"


nuget.exe push R.Scheduler.1.2.9.nupkg -Source https://www.nuget.org/api/v2/package
::nuget.exe push R.Scheduler.Contracts.1.2.2.nupkg -Source https://www.nuget.org/api/v2/package

           
@ECHO === === === === === === === ===

PAUSE

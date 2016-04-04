@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

rem About to restore packages
call %NuGet% restore

rem About to build solution
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" Xero.Api.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net40

rem About to pack Nugets
call %NuGet% pack "minimal.nuspec" -Symbols -OutputDirectory Build\lib\net40 -Version %version%
call %NuGet% pack "nuget.nuspec" -symbols -OutputDirectory  Build\lib\net40 -Version %version%
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
echo "calling nuget restore"
call %NuGet% restore

rem About to build solution
echo "building solution"
"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" Xero.Api.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net40

rem About to pack Nugets
echo "packing nugets"
call %NuGet% pack "minimal.nuspec" -symbols -o Build\net40 -p Configuration=%config% %version%
call %NuGet% pack nuget.nuspec-symbols -o Build\net40 -p Configuration=%config% %version%
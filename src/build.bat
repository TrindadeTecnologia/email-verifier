@echo off

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

REM Restore Packages
%nuget% restore Trindade.EmailVerifier.sln

REM Build
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Trindade.EmailVerifier.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net45

%nuget% pack "src\Trindade.EmailVerifier.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"

@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

%nuget% restore src\Trindade.EmailVerifier.sln

REM Build
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Trindade.EmailVerifier.sln /tv:14.0 /p:GenerateBuildInfoConfigFile=false /p:VisualStudioVersion=14.0

REM Package
mkdir Build
mkdir Build\lib
mkdir Build\lib\net45

cmd /c %nuget% pack "src\Trindade.EmailVerifier.nuspec" -symbols -o Build -p Configuration=%config% %version%

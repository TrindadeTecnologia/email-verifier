nuget restore src/Trindade.EmailVerifier.sln
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Trindade.EmailVerifier.sln /p:Configuration="Release" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false /tv:14.0 /p:GenerateBuildInfoConfigFile=false /p:VisualStudioVersion=14.0

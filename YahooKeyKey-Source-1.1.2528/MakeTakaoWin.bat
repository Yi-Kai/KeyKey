@echo off
msbuild Takao.xml /p:BuildCmd=Clean;Platform=Win32
msbuild Takao.xml /p:BuildCmd=Clean;Platform=x64
msbuild Takao.xml /p:BuildCmd=Build;Platform=Win32
msbuild Takao.xml /p:BuildCmd=Build;Platform=x64
cd Distributions\Takao\Installer-Windows
call makedist

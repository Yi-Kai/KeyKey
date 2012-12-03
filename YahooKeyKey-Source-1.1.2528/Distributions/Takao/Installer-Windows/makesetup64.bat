if exist setup64.exe (del setup64.exe)
msbuild /target:Bootstrapper setup64.proj
rename setup.exe setup64.exe
iexpress /N Installer64.sed
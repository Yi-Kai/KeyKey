if exist setup.exe (del setup.exe)
msbuild /target:Bootstrapper setup.proj
iexpress /N Installer.sed
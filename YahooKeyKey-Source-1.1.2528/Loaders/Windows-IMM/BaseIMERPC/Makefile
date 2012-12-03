all: BIClientRPCInterface.h BIServerRPCInterface.h ..\BaseIMERPC-x64\BIClientRPCInterface.h ..\BaseIMERPC-x64\BIServerRPCInterface.h

BIClientRPCInterface.h: BIClientRPCInterface.idl
	midl /app_config BIClientRPCInterface.idl

BIServerRPCInterface.h: BIServerRPCInterface.idl
	midl /app_config BIServerRPCInterface.idl

..\BaseIMERPC-x64\BIClientRPCInterface.h: BIClientRPCInterface.idl
	midl /app_config /out ..\BaseIMERPC-x64 /x64 BIClientRPCInterface.idl

..\BaseIMERPC-x64\BIServerRPCInterface.h: BIServerRPCInterface.idl
	midl /app_config /out ..\BaseIMERPC-x64 /x64  BIServerRPCInterface.idl

clean:
	del BIClientRPCInterface.h
	del BIClientRPCInterface_c.c
	del BIClientRPCInterface_s.c
	del BIServerRPCInterface.h
	del BIServerRPCInterface_c.c
	del BIServerRPCInterface_s.c
	del ..\BaseIMERPC-x64\BIClientRPCInterface.h
	del ..\BaseIMERPC-x64\BIClientRPCInterface_c.c
	del ..\BaseIMERPC-x64\BIClientRPCInterface_s.c
	del ..\BaseIMERPC-x64\BIServerRPCInterface.h
	del ..\BaseIMERPC-x64\BIServerRPCInterface_c.c
	del ..\BaseIMERPC-x64\BIServerRPCInterface_s.c

rebuild: clean all

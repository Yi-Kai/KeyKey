all: LIServerRPCInterface.h

LIServerRPCInterface.h: LIServerRPCInterface.idl
	midl /app_config LIServerRPCInterface.idl

clean:
	del LIServerRPCInterface.h
	del LIServerRPCInterface_c.c
	del LIServerRPCInterface_s.c

rebuild: clean all

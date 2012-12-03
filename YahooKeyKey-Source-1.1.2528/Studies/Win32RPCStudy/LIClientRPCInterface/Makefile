all: LIClientRPCInterface.h

LIClientRPCInterface.h: LIClientRPCInterface.idl
	midl /app_config LIClientRPCInterface.idl

clean:
	del LIClientRPCInterface.h
	del LIClientRPCInterface_c.c
	del LIClientRPCInterface_s.c

rebuild: clean all

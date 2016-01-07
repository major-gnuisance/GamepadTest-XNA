# View README.txt for documentation

#### Configuration variables

# Source files
CSFILES = $(wildcard *.cs) $(wildcard Properties/*cs)

# Compiler options
DMCSOPTS = -r:FNA.dll,System.Windows.Forms.dll,System.Drawing.dll -target:exe -sdk:4.0

# Executable name
PROGNAME = "GamepadTest.exe"

# Build paths
DEBUGDIR = "bin/Debug"
RELEASEDIR = "bin/Release"

# Symlinks required for running the builds
# (dlls, content, etc)
SYMLINKS = ../../FNA.dll ../../FNA.dll.config ../../Content

#### Targets

.PHONY: release debug clean run rundebug readme help

targets:
	cat "TARGETS.txt"

# Convenience aliases
help: targets
d: debug
dr: debugrun
r: release
rr: run
all: release

# Targets you're supposed to use
release: $(RELEASEDIR)/$(PROGNAME)

debug: $(DEBUGDIR)/$(PROGNAME)

clean:
	rm $(DEBUGDIR)/* $(RELEASEDIR)/* 2>&- || true
	rmdir -p $(DEBUGDIR) $(RELEASEDIR) 2>&- || true

run: release
	./run.sh

debugrun: debug
	./run.sh debug

## Actual build targets
$(DEBUGDIR)/$(PROGNAME): $(CSFILES)
	mkdir -p bin/Debug
	ln -s $(SYMLINKS) $(DEBUGDIR) 2>&- || true
	dmcs -debug $(DMCSOPTS) -out:$@ $(CSFILES)

$(RELEASEDIR)/$(PROGNAME): $(CSFILES)
	mkdir -p bin/Release
	ln -s $(SYMLINKS) $(RELEASEDIR) 2>&- || true
	dmcs -optimize $(DMCSOPTS) -out:$@ $(CSFILES)


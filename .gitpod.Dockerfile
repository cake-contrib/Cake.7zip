FROM gitpod/workspace-full

USER gitpod
WORKDIR $HOME

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
ENV DOTNET_NOLOGO=1

ENV DOTNET_ROOT=/tmp/dotnet
ENV PATH=$PATH:$DOTNET_ROOT

RUN sudo apt-get update && \
    # install libgit2
    sudo apt-get -y install libgit2-dev && \
    # install mono
    sudo apt-get -y install gnupg ca-certificates && \
    sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF && \
    echo "deb https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list && \
    sudo apt-get update && \
    sudo apt-get -y install mono-devel
    # .NET installed ONLY (!) via .gitpod.yml task until the following issue is fixed: https://github.com/gitpod-io/gitpod/issues/5090
    #mkdir -p $DOTNET_ROOT && \
    #wget https://dot.net/v1/dotnet-install.sh -O $DOTNET_ROOT/dotnet-install.sh && \
    #chmod +x $DOTNET_ROOT/dotnet-install.sh
    #bash dotnet-install.sh --channel 2.1 --install-dir $DOTNET_ROOT && \
    #bash dotnet-install.sh --channel 3.1 --install-dir $DOTNET_ROOT && \
    #bash dotnet-install.sh --channel 5.0 --install-dir $DOTNET_ROOT && \
    #bash dotnet-install.sh --channel 6.0 --install-dir $DOTNET_ROOT

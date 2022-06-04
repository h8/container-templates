FROM elixir:latest

ENV DEBIAN_FRONTEND=noninteractive

ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID

# Replace 135 on thle line 17 to you actual docker group GID
RUN apt-get update \
    && apt-get -y install --no-install-recommends apt-utils dialog 2>&1 \
    && apt-get -y install inotify-tools git mc procps lsb-release sudo tree docker.io \
    && groupadd --gid $USER_GID $USERNAME \
    && useradd -s /bin/bash --uid $USER_UID --gid $USER_GID -m $USERNAME \
    && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME \
    && chmod 0440 /etc/sudoers.d/$USERNAME \
    && groupmod -g 135 docker \
    && usermod -aG docker $USERNAME \
    && newgrp docker \
    && apt-get install -y locales && rm -rf /var/lib/apt/lists/* \
    && localedef -i en_US -c -f UTF-8 -A /usr/share/locale/locale.alias en_US.UTF-8 \
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/* \
    && mix local.hex --force \
    && mix local.rebar --force

ENV LANG en_US.utf8

USER vscode
WORKDIR /home/vscode

ENV DEBIAN_FRONTEND=
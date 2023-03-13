declare -a arr10=("docker pull alpine"
                "docker pull busybox"
                "docker pull nginx"
                "docker pull ubuntu"
                "docker pull python"
                "docker pull redis"
                "docker pull postgres"
                "docker pull node"
                "docker pull httpd"
                "docker pull mongo")
declare -a arr20=(
                "docker pull mysql"
                "docker pull memcached"
                "docker pull traefik"
                "docker pull mariadb"
                "docker pull docker"
                "docker pull rabbitmq"
                "docker pull hello-world"
                "docker pull openjdk"
                "docker pull golang"
                "docker pull registry"
              )
for i in "${arr20[@]}"
do
    web1=https://registry.hub.docker.com/v2/repositories/library/${i:12}/tags?page_size=1024
    curl -L -s ${web1}|jq '."results"[]["name"]' > ${i:12}.txt
    curl -L -s ${web1}|jq '."results"' > meta/${i:12}.json
    echo "Version is done <<<<<<<<<<<<<<<<<<<<<<<<"
done
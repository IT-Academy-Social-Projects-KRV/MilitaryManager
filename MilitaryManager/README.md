### Setup

1. Install Docker from [here](https://docs.docker.com/desktop/install/windows-install/);
1. Install node.js [v14.16.0](https://nodejs.org/de/blog/release/v14.16.0/);
1. Install Angular cli 'npm install -g @angular/cli';
1. Go to client-app folder `cd client-app`;
1. Install node packages `npm install`;
1. Build angular app `ng build`;
1. Open sln and set 'docker-compose' as startup project;
1. Run project;

### Dependencies and libraries
- primeng - https://www.primefaces.org/primeng-v11-lts/#/
- angularCLI - 14.16.0
- node - v14.16.0
- 6.14.11
- .net core 3.1
- visual studio 2022 v(TODO)

### Angular cli

### Docker commands

`Show active containers`
```bush
docker ps
```

`Show all containers`
```bush
docker ps -a
```

`Show all images`
```bush 
docker images
```

`Remove container by guid`
```bush
docker rm <container_guid>
```

`Remove image by guid`
```bush
docker rmi <image_guid>
```

`Remove all containers`
```bush
docker rm $(docker ps -a -q) -f
```

`Remove all images`
```bush
docker rmi $(docker images -q) -f
```

# Multi-network WordPress Installation - Soluzione

## Task 1) Creare le due reti

```powershell
docker network create backend
docker network create frontend
```

## Task 2) Avviare MySQL sulla rete backend

```powershell
docker run `
    --name mysql `
    -e MYSQL_ROOT_PASSWORD=somewordpress `
    -e MYSQL_DATABASE=wordpress `
    -e MYSQL_USER=wordpress `
    -e MYSQL_PASSWORD=wordpress `
    --net backend `
    -d `
    mysql:5.7
```

## Task 3) Avviare WordPress sulla rete frontend

```powershell
docker run `
    --name wordpress `
    -e WORDPRESS_DB_HOST=mysql:3306 `
    -e WORDPRESS_DB_USER=wordpress `
    -e WORDPRESS_DB_PASSWORD=wordpress `
    -e WORDPRESS_DB_NAME=wordpress `
    -d `
    -p "8000:80" `
    --net frontend `
    wordpress
```

## Task 4) Collegare WordPress al backend

WordPress è sulla rete `frontend`, MySQL sulla `backend`. Non comunicano. Per risolvere:

```powershell
docker network connect backend wordpress
```

Ora WordPress è su entrambe le reti (`frontend` + `backend`) e può raggiungere MySQL via DNS.

## Task 5) Verifica

Apri il browser su [http://localhost:8000](http://localhost:8000): dovresti vedere la pagina di installazione di WordPress.

## Cleanup

```powershell
docker stop wordpress mysql
docker rm wordpress mysql
docker network rm frontend backend
```

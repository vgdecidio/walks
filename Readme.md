
# Walks Api

This is my first asp project for learning and practicing ASP DOT NET.


## API Reference

#### Get all items

```http
  GET /api/items
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Get item

```http
  GET /api/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### add(num1, num2)

Takes two numbers and returns the sum.


## Documentation

[youtube video](https://www.youtube.com/watch?v=3BFxALltQaM) for setting up SQL SERVER to run on mac os.
[Link for the SQL server Image](https://hub.docker.com/r/microsoft/azure-sql-edge)

- Currently for me the User is sa and pwd is Password123.

- For this to work i ran the commands:
```shell
    # if you haven’t installed it already
    dotnet tool install --global dotnet-ef

    # apply all pending migrations
    dotnet ef database update

```

## Project Setup

### Setup SQL Docker Image:

```shell
    docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Password123' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
    docker run -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Password123' -e 'MSSQL_PID=Developer -e 'MSSQL_USER=SA' -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```
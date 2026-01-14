# RabbitMQ Lab (.NET)

Educational project focused on learning and experimenting with:
- RabbitMQ
- Docker / docker-compose
- CQRS
- Outbox Pattern
- Minimal API (.NET)

## Tech Stack
- .NET 9
- RabbitMQ
- Docker
- Minimal API
- CQRS (Command / Query separation)

## Running the project

```bash
docker-compose up -d
```

## OrderService API:
- POST /orders
- GET /orders/{id}
- Get /orders
- DELETE /orders/{id}

## Project structure
- docker/ – infrastruktura (RabbitMQ)
- services/OrderService – serwis z CQRS
- services/POC – eksperymenty / spike'i

# CoffeeQueue

ASP.NET Core 8.0 MVC app for managing a coffee order queue.

## Overview

A simple queue management system for coffee orders. Tracks 20 queue slots (A01–A20), each assigned a coffee type, with status flow: **available → reserved → preparing → ready**.

## Tech Stack

- **Framework**: ASP.NET Core 8.0 MVC
- **Runtime**: .NET 8.0
- **Containerization**: Docker (multi-stage build)
- **CI/CD**: GitHub Actions → GHCR

## Project Structure

```
CoffeeQueue/
├── Controllers/
│   └── QueueController.cs      # MVC + REST API endpoints
├── Services/
│   ├── QueueService.cs         # Queue logic, in-memory state
│   └── QueueWorker.cs          # Background heartbeat service
├── Views/
│   └── Queue/Index.cshtml      # Main queue UI
├── wwwroot/                    # Static assets (CSS)
├── Dockerfile                  # Multi-stage Docker build
└── Program.cs                  # App entry point
```

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/` | Queue dashboard |
| `GET` | `/api/items` | Get all queue items |
| `POST` | `/api/reserve/{number}` | Reserve a queue slot |
| `POST` | `/api/status/{number}/{status}` | Update item status |

## Coffee Types

| Emoji | Type |
|-------|------|
| ☕ | Espresso |
| 🥤 | Americano |
| ☕ | Cappuccino |
| 🥛 | Latte |
| 🍫 | Mocha |
| 🤎 | Flat White |
| 🧊 | Cold Brew |
| ✨ | Macchiato |

## Getting Started

### Prerequisites

- .NET 8.0 SDK

### Run Locally

```bash
dotnet run
```

App starts at `http://localhost:5000`.

### Docker

```bash
docker build -t coffeequeue .
docker run -p 8080:8080 coffeequeue
```

## CI/CD

GitHub Actions workflow builds and pushes Docker image to GitHub Container Registry (GHCR) on manual trigger.

```bash
# Image available at:
ghcr.io/<owner>/coffeequeue:latest
ghcr.io/<owner>/coffeequeue:<sha>
```

## License

MIT

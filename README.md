# Lab project

* I use this project as a lab, so this readme can be outdated.
* Everything inside "Infra" folder can be a nuget package. The MessageHandler is a infra project.

## Solution structure
```
└──Infra
    └── MessageHandler
└── IO
    ├── Api
    └── Subscriber
└── Plugins
    ├── InMemoryRepository
    └── PubSub
├── Application
├── Domain
└── UnitTests
```
## Dependency map
![Dependency map](doc_assets/dependency.png)

## Named pipe pub sub implementation
![Connection schema](doc_assets/connection_schema.png)